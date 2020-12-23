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
    public class DispositivoCube: DispositivoBase
    {
        bool bServiceRunning = false;
        private Thread tStart = null;
        private Thread tPing = null;
        private Library.Language lang = Library.Language.GetInstance();
        private Cube cube;       

        #region SPECIALIZED EVENT HANDLER
        public event WhiteCalibrationEventHandler WhiteCalibrated = null;
        public delegate void WhiteCalibrationEventHandler();
        public event InitializationEventHandler Initialized = null;
        public delegate void InitializationEventHandler(string s);
        #endregion

        public DispositivoCube()
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            string sCOMPort = settings.GetValue("CubeCOMPort");

            cube = new Cube();
            cube.portName = sCOMPort;
            Cube.CubeSampled += new Cube.SampleMonitor(LABRicevuti);
        }

        public string Port
        {
            set { cube.portName = value; }
        }

        #region SERVICE MANAGEMENT
        public override void StartService()
        {
            tStart = new Thread(StartExecute);
            tPing = new Thread(PingExecute);
            tStart.IsBackground = true;
            tPing.IsBackground = true;
            tStart.Start();
        }
        private void StartExecute()
        {
            for (int i = 0; i < 20 && !cube.isConnected(); i++)
            {
                try
                {
                    if (!cube.Connect())
                    {
                        Thread.Sleep(10);
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }

            if (!cube.isConnected())
            {
                base.OnErroreDispositivo("Cube connection failed. Retry later.");
            }
            else
            {
                cube.setIdleTimer(480);
            }
            bServiceRunning = true;
            tPing.Start();
        }
        private void PingExecute()
        {
            try
            {
                while (bServiceRunning)
                {
                    bool bConnected = cube.pingCube();
                    Thread.Sleep(250000);
                }
            }
            catch (Exception){}
        }
        public override void StopService()
        {
            try
            {
                if (!cube.isConnected()) { return; }
                if (!cube.Disconnect())
                {
                    MessageBox.Show("disconnection error. Retry later");
                }
            }
            catch (Exception) { }
            finally 
            {
                bServiceRunning = false;
            }
        }
        public override bool IsServiceRunning()
        {
            return bServiceRunning;
        }     
        #endregion

        #region DATA MANAGEMENT
        public override void ReadRequest()
        {
            if (cube.isConnected())
            {
                float[] lab_d50 = cube.getLabData(); //D50 illuminant
                LABRicevuti(lab_d50[0], lab_d50[1], lab_d50[2]);
            }
            else
            {
                base.OnErroreDispositivo(lang.GetWord("device09"));
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
            Library.Data.Dispositivi.frmFunzioniCube frm = new Library.Data.Dispositivi.frmFunzioniCube(this);
            frm.ConnectVisible = bShowConnect;
            frm.TopLevel = bTopLevel;
            frm.AutoScroll = true;
            return frm;
        }
        #endregion

        #region SPECIALIZED DATA MANAGEMENT
        public void WhiteCalibrationRequest()
        {
            if (cube.isConnected())
            {
                //calibrazione
                ushort[] rawData = cube.getRawData();
                ushort[] trimData = DataHandler.TrimClearData(rawData);
                float[] caliData = DataHandler.UShortArrayToFloatArray(trimData);
                cube.setUserGreyScale(caliData);
                SetCalibratedNow();
                if (WhiteCalibrated != null) { WhiteCalibrated(); }
            }
            else
            {
                base.OnErroreDispositivo(lang.GetWord("device09"));
            }
        }
        public void DeviceInitRequest()
        {
            if (cube.isConnected())
            {
                try
                {
                    cube.Disconnect();
                }
                catch (Exception) { }
            }

            //connessione
            for (int i = 0; i < 20 && !cube.isConnected(); i++)
            {
                try
                {
                    if (!cube.Connect())
                    {
                        Thread.Sleep(10);
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }

            if (cube.isConnected())
            {
                if (Initialized != null) { Initialized(""); }
            }
            else
            {
                if (Initialized != null) { Initialized("Cube connection failed. Retry later."); }
            }
        }
        #endregion

        #region FUNCTIONS
        private void LABRicevuti(float l, float a, float b)
        {
            //PRE: l, a, b as CIELab in D50 illuminant
            double[] xyz_d65 = Library.Colore.LAB_XYZ(l, a, b);
            double[] lab = Library.Colore.XYZ_LAB(xyz_d65[0], xyz_d65[1], xyz_d65[2]);

            base.OnDatiRicevuti(lab[0].ToString() + "\t" + lab[1].ToString() + "\t" + lab[2].ToString());
        }
        public static void SetCalibratedNow()
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            settings.SetValue("LastCubeCalibration", DateTime.Now.ToString());
        }
        public static DateTime GetLastCalibration()
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            return DateTime.Parse(settings.GetValue("LastCubeCalibration"));
        }
        #endregion
    }
}
