using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Euroformulations4.Library.Data.Dispositivi
{
    public class HandleClinet
    {
        private bool bThreadInitDone = false;
        public TcpClient clientSocket = null;
        private bool bStopThreadRequest = false;
        private bool bInvioChannel = false;
        public Thread ctThread = null;
        NetworkStream networkStream = null;
        public ManualResetEvent mre = new ManualResetEvent(false);

        public event DataReceivedEventHandler DataReceived;
        public delegate void DataReceivedEventHandler(string s);

        private string currentRequest = "";

        public HandleClinet(TcpClient clientSocket)
        {
            this.clientSocket = clientSocket;
            networkStream = clientSocket.GetStream();
        }

        public bool IsChannelSender_ServerSide
        {
            get { return bInvioChannel; }
        }

        public bool ThreadInited
        {
            get { return bThreadInitDone; }
        }

        public void startClient()
        {
            ctThread = new Thread(doJob);
            ctThread.Start();
        }

        private void doJob()
        {
            //ricevo
            string bChannelReceive = Ricezione();  //s = canale invio, r = canale ricezione. Note: riferito al client!!!
            if (bChannelReceive == "r")
            {
                bInvioChannel = true;
                Thread.CurrentThread.Name = "r";
            }
            else
            {
                Thread.CurrentThread.Name = "s";
            }

            Invio("ok");
            bThreadInitDone = true;

            while (clientSocket.Connected && !bStopThreadRequest)
            {
                try
                {
                    if (bInvioChannel)
                    {
                        mre.Reset();
                        mre.WaitOne();
                        Invio(currentRequest);
                    }

                    string sData = Ricezione();
                    DataReceived(sData);
                }
                catch (Exception) { }
            }
        }

        private string Ricezione()
        {
            lock (networkStream)
            {
                byte[] bytesFrom = new byte[(int)clientSocket.ReceiveBufferSize];  //512 TODO: expected
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                int delimiterPos = dataFromClient.IndexOf(";");
                int nChars = Convert.ToInt32(dataFromClient.Substring(0, delimiterPos));
                dataFromClient = dataFromClient.Substring(delimiterPos + 1, nChars);
                return dataFromClient;
            }
        }

        private void Invio(string message)
        {
            lock (networkStream)
            {
                message = message.Length + ";" + message;
                byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();
            }
        }

        public void SendCommand(string sCommand)
        {
            currentRequest = sCommand;
            mre.Set(); //TODO try/catch
        }

        public void SendInitialization()
        {
            currentRequest = "init"; mre.Set();  //TODO try/catch
        }

        public void SendSTOPRequest()
        {
            currentRequest = "stop"; mre.Set();  //TODO try/catch
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void CloseClient()
        {
            bStopThreadRequest = true;
            clientSocket.Close();
            try
            {
                ctThread.Abort();
            }
            catch (Exception) { }
        }
    }
}
