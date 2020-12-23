using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Euroformulations4.Library.Data.Dispositivi
{
    public partial class frmFunzioniSP62 : Form
    {
        private Library.Data.Dispositivi.DispositivoSP62 sp;
        private static Library.Language lang = Library.Language.GetInstance();
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        private bool bWhiteCalibrated = false;
        private bool bBlackCalibrated = false;

        public frmFunzioniSP62(Library.Data.Dispositivi.DispositivoSP62 sp)
        {
            InitializeComponent();
            this.sp = sp;

            sp.ErroreDispositivo += new DispositivoBase.ErroreDispositivoEventHandler(Errore);
            sp.BlackCalibrated += new DispositivoSP62.BlackCalibrationEventHandler(BlackDone);
            sp.WhiteCalibrated += new DispositivoSP62.WhiteCalibrationEventHandler(WhiteDone);
            sp.Initialized += new DispositivoSP62.InitializationEventHandler(InitializeResponse);
        }

        private void frmCalibraStrumento_Load(object sender, EventArgs e)
        {
            this.Text = lang.GetWord("device16");
            btnConnect.Text = lang.GetWord("device04");
            gbCom.Text = lang.GetWord("device11");

            //com port
            Data.SharedSettings settings = new Data.SharedSettings();
            txtComPort.Text = settings.GetValue("SP62COMPort");
        }

        public bool ConnectVisible
        {
            set { this.btnConnect.Visible = value; gbCom.Visible = value; }
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            settings.SetValue("SP62COMPort", txtComPort.Text);

            sp.ErroreDispositivo -= new DispositivoBase.ErroreDispositivoEventHandler(Errore);
            sp.BlackCalibrated -= new DispositivoSP62.BlackCalibrationEventHandler(BlackDone);
            sp.WhiteCalibrated -= new DispositivoSP62.WhiteCalibrationEventHandler(WhiteDone);
            sp.Initialized -= new DispositivoSP62.InitializationEventHandler(InitializeResponse);
        }

        private void Errore(string data)
        {
            MessageBox.Show(data);
            pBoxWhite.Visible = false;
            pBoxBlack.Visible = false;
            pBoxConnected.Visible = false;
        }

        private void BlackDone()
        {
            dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                this.bBlackCalibrated = true;
                pBoxBlack.Visible = true;
                CheckCalibrationCompleted();
            }));
        }
        private void WhiteDone()
        {
            dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                this.bWhiteCalibrated = true;
                pBoxWhite.Visible = true;
                CheckCalibrationCompleted();
            }));

        }
        private void InitializeResponse(string response)
        {
            dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                if (response.Trim() == "")
                {
                    pBoxConnected.Visible = true;
                    MessageBox.Show(lang.GetWord("device08"));
                }
                else
                {
                    pBoxConnected.Visible = false;
                    MessageBox.Show(response);
                }
            }));
        }
        private void CheckCalibrationCompleted()
        {
            try
            {
                if (bWhiteCalibrated && bBlackCalibrated)
                {
                    Library.Data.Dispositivi.DispositivoSP62.SetCalibratedNow();
                    if (this.TopLevel) { this.Close(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            pBoxConnected.Visible = false;
            pBoxWhite.Visible = false;

            Data.SharedSettings settings = new Data.SharedSettings();
            settings.SetValue("SP62COMPort", txtComPort.Text);

            sp.Port = txtComPort.Text;
            sp.DeviceInitRequest();
        }
        private void btnWhite_Click(object sender, EventArgs e)
        {
            sp.WhiteCalibrationRequest();
        }
        private void btnBlack_Click(object sender, EventArgs e)
        {
            sp.BlackCalibrationRequest();
        }
    }
}
