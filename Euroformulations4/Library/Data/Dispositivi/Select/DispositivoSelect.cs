using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Euroformulations4.Library.Data.Dispositivi
{
    public class DispositivoSelect: DispositivoBase
    {
        private byte[] ip = new byte[] { 127, 0, 0, 1 };
        private string sExecutablePath;
        private bool bServiceRunning = false;
        private TcpListener serverSocket = null;
        private HandleClinet client2Send = null;   //client che uso per inviare
        private HandleClinet client2Receive = null; //client che uso per ricevere
        private System.Timers.Timer timerController = null;
        private Thread tStart = null;
        Process process = null;

        #region SPECIALIZED EVENT HANDLER
        public event WhiteCalibrationEventHandler WhiteCalibrated = null;
        public delegate void WhiteCalibrationEventHandler();

        public event BlackCalibrationEventHandler BlackCalibrated = null;
        public delegate void BlackCalibrationEventHandler();

        public event InitializationEventHandler Initialized = null;
        public delegate void InitializationEventHandler(string s);
        #endregion

        public DispositivoSelect(string sExecutablePath)
        {
            this.sExecutablePath = sExecutablePath;

            if (!System.IO.File.Exists(sExecutablePath)) 
            {
                base.OnErroreDispositivo("device client not found");
            }
        }

        #region SERVICE MANAGEMENT
        public override void StartService()
        {
            //start server
            if (bServiceRunning) { return; }

            timerController = new System.Timers.Timer(7000);
            timerController.Elapsed += new System.Timers.ElapsedEventHandler(ChannelControllerTick);

            tStart = new Thread(StartExecute);

            //avvio servizio + controllore
            tStart.Start();
            timerController.Start();
        }
        public override void StopService()
        {
            if (!bServiceRunning) { return; }

            bServiceRunning = false;

            if (client2Send != null)
            {
                client2Send.SendSTOPRequest();  // ask executable client to terminate
                if (!process.WaitForExit(5000)) //wait 5 seconds, after that it forces to terminate
                {
                    client2Send.CloseClient();
                }
            }

            if (client2Receive != null) { client2Receive.CloseClient(); }

            serverSocket.Stop();
        }
        public override bool IsServiceRunning()
        {
            return bServiceRunning;
        }
        private void StartExecute()
        {
            try
            {
                //serverSocket = new TcpListener(new IPAddress(ip), port);
                serverSocket = new TcpListener(new IPAddress(ip), 0);

                //start server
                serverSocket.Start();
                int porta = ((IPEndPoint)serverSocket.LocalEndpoint).Port;
                
                //start executable client
                this.process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        FileName = this.sExecutablePath,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = " " + porta.ToString()
                    }
                };
                process.EnableRaisingEvents = true;
                process.Exited += this.ProcessExited;
                process.Start();

                //receive connection 1
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                client2Receive = new HandleClinet(clientSocket);
                client2Receive.startClient();

                //receive connection 2
                clientSocket = serverSocket.AcceptTcpClient();
                client2Send = new HandleClinet(clientSocket);
                client2Send.startClient();

                //aspetta finchè i client non sono identificabili
                while (!client2Receive.ThreadInited || !client2Receive.ThreadInited) { Thread.Sleep(1); }

                //se client usato per ricevere dall'altra parte è in ascolto allora devo scambiare i due canali
                if (client2Receive.IsChannelSender_ServerSide)
                {
                    HandleClinet temp = client2Receive;
                    client2Receive = client2Send;
                    client2Send = temp;
                }

                client2Send.DataReceived += new HandleClinet.DataReceivedEventHandler(Ricevuto);
                client2Receive.DataReceived += new HandleClinet.DataReceivedEventHandler(Ricevuto);

                bServiceRunning = true;
            }
            catch (Exception ex)
            {
                try { StopService(); }
                catch (Exception) { }
                throw new Exception(ex.Message);
            }
        }
        private void ChannelControllerTick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (tStart != null)
            {
                if (tStart.IsAlive)
                {
                    try { StopService(); }
                    catch (Exception) { }
                    base.OnErroreDispositivo("No exe device connection");
                }
            }
            timerController.Stop();
        }
        #endregion

        #region DATA MANAGEMENT
        public override void ReadRequest()
        {
            if (client2Send != null)
            {
                client2Send.SendCommand("lab");
            }
        }
        public override bool Calibrato()
        {
            DateTime dtLastCalibration = GetLastCalibration();
            DateTime dtCompare = DateTime.Now.AddHours(-12);
            if (dtLastCalibration < dtCompare)
                return false;
            return true;
        }
        public override System.Windows.Forms.Form GetWindowManager(bool bTopLevel, bool bShowConnect)
        {
            Library.Data.Dispositivi.frmFunzioniSelect frm = new Library.Data.Dispositivi.frmFunzioniSelect(this);
            frm.ConnectVisible = bShowConnect;
            frm.TopLevel = bTopLevel;
            frm.AutoScroll = true;
            return frm;
        }
        #endregion

        #region SPECIALIZED DATA MANAGEMENT
        public void WhiteCalibrationRequest()
        {
            if (client2Send != null)
            {
                client2Send.SendCommand("white");
            }
        }
        public void BlackCalibrationRequest()
        {
            if (client2Send != null)
            {
                client2Send.SendCommand("black");
            }
        }
        public void DeviceInitRequest()
        {
            if (client2Send != null)
            {
                client2Send.SendInitialization();
            }
        }
        #endregion

        #region FUNCTIONS
        private void Ricevuto(string data)
        {
            if (data.StartsWith("lab"))
            {
                string[] items = data.Split('\t');
                base.OnDatiRicevuti(items[1] + "\t" + items[2] + "\t" + items[3]);
            }
            else if (data == "white_done")
            {
                if (WhiteCalibrated != null) { WhiteCalibrated(); }
            }
            else if (data == "black_done")
            {
                if (BlackCalibrated != null) { BlackCalibrated(); }
            }
            else if (data.StartsWith("statusInit"))
            {
                string[] items = data.Split('\t');
                if (items[1] == "")
                {
                    if (Initialized != null) { Initialized(""); }
                }
                else
                {
                    if (Initialized != null) { Initialized(items[2]); }
                }
            }
            else if (data.StartsWith("err") || data.StartsWith("initerr"))
            {
                string[] items = data.Split('\t');
                switch (items[1])
                {
                    case "22": 
                        {
                            base.OnErroreDispositivo("Device not connected");
                            break;
                        }
                    default:
                        {
                            base.OnErroreDispositivo(items[1]);
                            break;
                        }
                }
            }
        }
        private void ProcessExited(object sender, EventArgs e)
        {
            Process p = (Process)sender;
            if (p.ExitCode != 0)
            {
                //error
                try
                {
                    StopService();
                }
                catch (Exception) { }
                base.OnErroreDispositivo("exedeverror:" + p.ExitCode.ToString());
            }
        }
        public static DateTime GetLastCalibration()
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            if (!settings.HasKey("LastCalibration"))
            {
                settings.SetValue("LastCalibration", DateTime.MinValue.ToString());
            }
            return DateTime.Parse(settings.GetValue("LastCalibration"));
        }
        public static void SetCalibratedNow()
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            settings.SetValue("LastCalibration", DateTime.Now.ToString());
        }
        #endregion
    }
}
