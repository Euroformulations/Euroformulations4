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
    public partial class frmFunzioniSelect : Form
    {
        private Library.Data.Dispositivi.DispositivoSelect select;
        private static Library.Language lang = Library.Language.GetInstance();
        private bool bWhiteCalibrated = false;
        private bool bBlackCalibrated = false;
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

        public frmFunzioniSelect(Library.Data.Dispositivi.DispositivoSelect select)
        {
            InitializeComponent();
            this.select = select;

            select.BlackCalibrated += new DispositivoSelect.BlackCalibrationEventHandler(BlackDone);
            select.WhiteCalibrated += new DispositivoSelect.WhiteCalibrationEventHandler(WhiteDone);
            select.ErroreDispositivo += new DispositivoBase.ErroreDispositivoEventHandler(Errore);
            select.Initialized += new DispositivoSelect.InitializationEventHandler(InitializeResponse);
        }

        public bool ConnectVisible
        {
            set { this.btnConnect.Visible = value; }
        }

        private void frmCalibraStrumento_Load(object sender, EventArgs e)
        {
            btnWhite.Text = lang.GetWord("calibra01");
            btnBlack.Text = lang.GetWord("calibra02");
            btnConnect.Text = lang.GetWord("device04");
            this.Text = lang.GetWord("device02");
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            select.BlackCalibrated -= new DispositivoSelect.BlackCalibrationEventHandler(BlackDone);
            select.WhiteCalibrated -= new DispositivoSelect.WhiteCalibrationEventHandler(WhiteDone);
            select.ErroreDispositivo -= new DispositivoBase.ErroreDispositivoEventHandler(Errore);
            select.Initialized -= new DispositivoSelect.InitializationEventHandler(InitializeResponse);
        }

        private void CheckCalibrationCompleted()
        {
            try
            {
                if (bWhiteCalibrated && bBlackCalibrated)
                {
                    Library.Data.Dispositivi.DispositivoSelect.SetCalibratedNow();
                    if (this.TopLevel) { this.Close(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            select.WhiteCalibrationRequest();
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            select.BlackCalibrationRequest();
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            select.DeviceInitRequest();
        }

        private void InitializeResponse(string response)
        {
            dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                if (response.Trim() == "")
                {
                    pBoxConnected.Visible = true;
                }
                else
                {
                    pBoxConnected.Visible = false;
                    MessageBox.Show(response);
                }
            }));
        }
    }
}
