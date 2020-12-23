using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.Settings
{
    public partial class frmDispositivi : Form
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private SubWindows.WindowMain.frmEuroFormulationsNew frmEF = null;
        private System.Windows.Forms.Form frmDeviceDetail = null;
        private bool bModificato = false;

        public frmDispositivi()
        {
            InitializeComponent();
        }

        private void UserDataChanged(object sender, EventArgs e)
        {
            bModificato = true;
        }

        public SubWindows.WindowMain.frmEuroFormulationsNew MAIN_FORM
        {
            set { this.frmEF = value; }
        }

        private void frmDispositivi_Load(object sender, EventArgs e)
        {
            try
            {
                #region Traduzioni
                this.Text = lang.GetWord("settings57");
                gbDefaultDevice.Text = lang.GetWord("settings58");
                gbDeviceDetail.Text = lang.GetWord("settings59");
                btnSalva.Text = lang.GetWord("save");
                gbTipoLettura.Text = lang.GetWord("settings64");
                #endregion

                Library.Data.SharedSettings settings = new Library.Data.SharedSettings();

                //cmb dispositivi
                Dictionary<int, string> dicDispositivi = Library.Data.Dispositivi.DispositiviManager.GetDispositiviDic();
                cmbDispositivi.DataSource = new BindingSource(dicDispositivi, null);
                cmbDispositivi.DisplayMember = "Value";
                cmbDispositivi.ValueMember = "Key";
                Library.Data.Dispositivi.eDispositiviTipo tipo = Library.Data.Dispositivi.DispositiviManager.GetDispositivoTipo(settings.GetValue("StrumentoLetturaDefault"));
                cmbDispositivi.SelectedValue = (int)tipo;

                gbDeviceDetail.Text += " - " + dicDispositivi[(int)tipo];
                
                //cmb tipo lettura
                Dictionary<int, string> dicLetturaTipo = new Dictionary<int, string>();
                dicLetturaTipo.Add((int)Library.Data.Dispositivi.eLetturaTipo.Singola, lang.GetWord("settings62"));
                dicLetturaTipo.Add((int)Library.Data.Dispositivi.eLetturaTipo.Multipla, lang.GetWord("settings63"));
                cmbLetturaTipo.DataSource = new BindingSource(dicLetturaTipo, null);
                cmbLetturaTipo.DisplayMember = "Value";
                cmbLetturaTipo.ValueMember = "Key";
                Library.Data.Dispositivi.eLetturaTipo tipoLettura = (Library.Data.Dispositivi.eLetturaTipo)Convert.ToInt32(settings.GetValue("DeviceReadType"));
                cmbLetturaTipo.SelectedValue = (int)tipoLettura;

                //dettaglio dispositivo selezionato
                Library.Data.Dispositivi.DispositivoBase disp = Library.Data.Dispositivi.DispositiviManager.GetDispositivo();
                frmDeviceDetail = disp.GetWindowManager(false, true);
                if (frmDeviceDetail != null)
                {
                    panDeviceDetail.Controls.Add(frmDeviceDetail);
                    frmDeviceDetail.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frmDeviceDetail.Dock = DockStyle.Fill;
                    frmDeviceDetail.Show();
                }

                cmbDispositivi.SelectedIndexChanged += new EventHandler(UserDataChanged);
                cmbLetturaTipo.SelectedIndexChanged += new EventHandler(UserDataChanged);
                gbTipoLettura.Visible =   (Library.GVar.attivazioni.Act_ColorSearch || Library.GVar.attivazioni.Act_QualityControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            SalvaExecute(true);
        }

        private void SalvaExecute(bool bReboot)
        {
            try
            {
                Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
                if (cmbDispositivi.SelectedValue != null)
                {
                    settings.SetValue("StrumentoLetturaDefault", cmbDispositivi.SelectedValue.ToString());
                }
                if (cmbLetturaTipo.SelectedValue != null)
                {
                    settings.SetValue("DeviceReadType", cmbLetturaTipo.SelectedValue.ToString());
                }

                if (bReboot)
                {
                    bModificato = false;
                    MessageBox.Show(lang.GetWord("settings45"), lang.GetWord("settings25"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.frmEF.RebootNow = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDispositivi_FontChanged(object sender, EventArgs e)
        {
            
        }

        private void frmDispositivi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bModificato)
                {
                    DialogResult dialogResult = MessageBox.Show(lang.GetWord("save_message"), lang.GetWord("save_header"), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SalvaExecute(true);
                    }
                }

                if (this.frmDeviceDetail != null) { frmDeviceDetail.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
