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
    public partial class frmFunzioniOne : Form
    {
        private Library.Data.Dispositivi.DispositivoOne one;
        private static Library.Language lang = Library.Language.GetInstance();
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

        public frmFunzioniOne(Library.Data.Dispositivi.DispositivoOne one)
        {
            InitializeComponent();
            this.one = one;

            one.DatiRicevuti += new DispositivoBase.DatiRicevutiEventHandler(DataReceived);
            one.WhiteCalibrated += new DispositivoOne.WhiteCalibrationEventHandler(WhiteDone);
            one.ErroreDispositivo += new DispositivoBase.ErroreDispositivoEventHandler(Errore);
            one.Initialized += new DispositivoOne.InitializationEventHandler(InitializeResponse);
        }

        public bool ConnectVisible
        {
            set { this.btnConnect.Visible = value; }
        }

        private void frmCalibraStrumento_Load(object sender, EventArgs e)
        {
            this.Text = lang.GetWord("device07");
            btnConnect.Text = lang.GetWord("device12");
            btnWhite.Text = lang.GetWord("calibra01");
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            one.DatiRicevuti -= new DispositivoBase.DatiRicevutiEventHandler(DataReceived);
            one.WhiteCalibrated -= new DispositivoOne.WhiteCalibrationEventHandler(WhiteDone);
            one.ErroreDispositivo -= new DispositivoOne.ErroreDispositivoEventHandler(Errore);
            one.Initialized -= new DispositivoOne.InitializationEventHandler(InitializeResponse);
        }

        

        private void DataReceived(string data)
        {
            MessageBox.Show(data);
        }
        private void Errore(string data)
        {
            MessageBox.Show(data);
            pBoxWhite.Visible = false;
            pBoxConnected.Visible = false;
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            pBoxWhite.Visible = false;
            Library.Data.Dispositivi.DispositivoOne.unSetCalibratedNow();
            one.WhiteCalibrationRequest();
        }

        private void WhiteDone()
        {
            dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                Library.Data.Dispositivi.DispositivoOne.SetCalibratedNow();
                pBoxWhite.Visible = true;
                if (this.TopLevel) { this.Close(); }
            }));

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            pBoxConnected.Visible = false;
            pBoxWhite.Visible = false;
            Library.Data.Dispositivi.DispositivoOne.unSetCalibratedNow();
            one.DeviceInitRequest();
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
    }
}
