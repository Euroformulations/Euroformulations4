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
    public partial class frmFunzioniCube : Form
    {
        private Library.Data.Dispositivi.DispositivoCube cube;
        private static Library.Language lang = Library.Language.GetInstance();
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

        public frmFunzioniCube(Library.Data.Dispositivi.DispositivoCube cube)
        {
            InitializeComponent();
            this.cube = cube;

            cube.DatiRicevuti += new DispositivoBase.DatiRicevutiEventHandler(DataReceived);
            cube.WhiteCalibrated += new DispositivoCube.WhiteCalibrationEventHandler(WhiteDone);
            cube.ErroreDispositivo += new DispositivoBase.ErroreDispositivoEventHandler(Errore);
            cube.Initialized += new DispositivoCube.InitializationEventHandler(InitializeResponse);
        }

        public bool ConnectVisible
        {
            set { this.btnConnect.Visible = value; gbCom.Visible = value; }
        }

        private void frmCalibraStrumento_Load(object sender, EventArgs e)
        {
            this.Text = lang.GetWord("device10");
            btnConnect.Text = lang.GetWord("device04");
            btnWhite.Text = lang.GetWord("calibra01");
            gbCom.Text = lang.GetWord("device11");

            //com port
            Data.SharedSettings settings = new Data.SharedSettings();
            txtComPort.Text = settings.GetValue("CubeCOMPort");
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            Data.SharedSettings settings = new Data.SharedSettings();
            settings.SetValue("CubeCOMPort", txtComPort.Text);

            cube.DatiRicevuti -= new DispositivoCube.DatiRicevutiEventHandler(DataReceived);
            cube.WhiteCalibrated -= new DispositivoCube.WhiteCalibrationEventHandler(WhiteDone);
            cube.ErroreDispositivo -= new DispositivoCube.ErroreDispositivoEventHandler(Errore);
            cube.Initialized -= new DispositivoCube.InitializationEventHandler(InitializeResponse);
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
            cube.WhiteCalibrationRequest();
        }

        private void WhiteDone()
        {
            dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                pBoxWhite.Visible = true;
                if (this.TopLevel) { this.Close(); }
            }));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            pBoxConnected.Visible = false;
            pBoxWhite.Visible = false;

            Data.SharedSettings settings = new Data.SharedSettings();
            settings.SetValue("CubeCOMPort", txtComPort.Text);

            cube.Port = txtComPort.Text;
            cube.DeviceInitRequest();
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
