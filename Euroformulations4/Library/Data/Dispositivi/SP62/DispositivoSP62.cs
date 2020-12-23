using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Euroformulations4.Library.Data.Dispositivi
{
    public class DispositivoSP62: DispositivoBase
    {
        bool bServiceRunning = false;
        
        private Library.Language lang = Library.Language.GetInstance();
        private SerialPort seriale;
        private string sData = "";
        private string sPort = "";

        #region SPECIALIZED EVENT HANDLER
        public event WhiteCalibrationEventHandler WhiteCalibrated = null;
        public delegate void WhiteCalibrationEventHandler();
        public event BlackCalibrationEventHandler BlackCalibrated = null;
        public delegate void BlackCalibrationEventHandler();
        public event InitializationEventHandler Initialized = null;
        public delegate void InitializationEventHandler(string s);
        #endregion

        public DispositivoSP62()
        {
            bReadReflectance = true;

            seriale = new SerialPort();
            seriale.BaudRate = 9600;
            seriale.DataBits = 8;
            seriale.Parity = Parity.None;
            seriale.StopBits = StopBits.One;
            seriale.DtrEnable = true;
            seriale.RtsEnable = true;
            seriale.Handshake = Handshake.None;

            Data.SharedSettings settings = new Data.SharedSettings();
            this.sPort = settings.GetValue("SP62COMPort");
        }

        public string Port { set { this.sPort = value; } }

        public void DeviceInitRequest()
        {
            bServiceRunning = false;
            try
            {
                if (seriale.IsOpen)
                {
                    seriale.Close();
                }

                seriale.PortName = this.sPort;
                seriale.Open();

                if (seriale.IsOpen)
                {
                    if (Ping())
                    {
                        bServiceRunning = true;
                        Initialized("");
                    }
                    else
                    {
                        throw new Exception("not connected");
                    }
                }
                else
                {
                    throw new Exception("not connected");
                }  
            }
            catch (Exception ex)
            {
                base.OnErroreDispositivo(ex.Message);
            }
        }

        #region SERVICE MANAGEMENT
        public override void StartService()
        {
            DeviceInitRequest();
            //string response = SendCommand("0201SM", "<00>");  //attiva lettura punti tramite comando meccanico
        }
        public override void StopService()
        {
            seriale.Close();
            bServiceRunning = false;
        }
        public override bool IsServiceRunning()
        {
            return bServiceRunning;
        }     
        #endregion

        #region DATA MANAGEMENT
        public override void ReadRequest()
        {
            try
            {
                string sCommandRead = SendCommand("13XD", "<00>");
                if (sCommandRead.Trim() != "<00>") 
                {
                    if (sCommandRead.Trim() == "<A8>") { throw new Exception("Calibration error"); }
                    else { throw new Exception("Read error"); }
                    
                }
                string sPunti = SendCommand("05XD", "<00>");
                if (sPunti.Trim() == "") { throw new Exception("Read error"); }
                sPunti = sPunti.Replace("\r\n<00>", "");
                sPunti = sPunti.Trim();
                string[] items = sPunti.Split(new string[] { ", " }, StringSplitOptions.None);

                string sData = "";
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].Trim() != "")
                    {
                        sData += items[i];
                        if (i != (items.Length - 1)) { sData += "\t"; }
                    }
                }

                base.OnDatiRicevuti(sData);
            }
            catch (Exception ex)
            {
                base.OnErroreDispositivo(ex.Message);
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
            Library.Data.Dispositivi.frmFunzioniSP62 frm = new Library.Data.Dispositivi.frmFunzioniSP62(this);
            frm.ConnectVisible = bShowConnect;
            frm.TopLevel = bTopLevel;
            frm.AutoScroll = true;
            return frm;
        }
        #endregion
        
        #region SPECIALIZED DATA MANAGEMENT
        public void WhiteCalibrationRequest()
        {
            try
            {
                string sCommandRead = SendCommand("01CR", "<00>");
                if (sCommandRead.Trim() == "<00>")
                {
                    WhiteCalibrated();
                }
                else
                {
                    throw new Exception("White calibration error");
                }
            }
            catch (Exception ex)
            {
                base.OnErroreDispositivo(ex.Message);
            }
        }
        public void BlackCalibrationRequest()
        {
            try
            {
                string sCommandRead = SendCommand("00CR", "<00>");
                if (sCommandRead.Trim() == "<00>")
                {
                    BlackCalibrated();
                }
                else
                {
                    throw new Exception("Black calibration error");
                }
            }
            catch (Exception ex)
            {
                base.OnErroreDispositivo(ex.Message);
            }
        }
        #endregion
        
        #region FUNCTIONS
        private string SendCommand(string command, string endCodeContained)
        {
            command += ((char)13);
            sData = "";
            seriale.DataReceived += new SerialDataReceivedEventHandler(ReceivedData);
            seriale.Write(command);

            for (int i = 0; i < 100; i++)
            {
                if (sData.Contains(endCodeContained))
                {
                    i = 100;
                }
                else
                {
                    System.Threading.Thread.Sleep(50);
                }
            }

            seriale.DataReceived -= new SerialDataReceivedEventHandler(ReceivedData);
            return sData;
        }
        private void ReceivedData(object sender, SerialDataReceivedEventArgs e)
        {
            sData += seriale.ReadExisting();
        }
        public static DateTime GetLastCalibration()
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            return DateTime.Parse(settings.GetValue("LastSP62Calibration"));
        }
        public static void SetCalibratedNow()
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            settings.SetValue("LastSP62Calibration", DateTime.Now.ToString());
        }
        private bool Ping()
        {
            string sCommandRead = SendCommand("CE", "<00>");
            if (sCommandRead.Trim() != "")
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

/**********  COMANDI NON PRESENTI
 * Serial Number: 11XD
 * 
 * 
 * 
 */
