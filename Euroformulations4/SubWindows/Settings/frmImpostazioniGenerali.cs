using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Euroformulations4.Library;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.IO.Compression;
using Ionic.Zip;
using System.Globalization;

namespace Euroformulations4.SubWindows.Settings
{
    public partial class frmImpostazioniGenerali : Form
    {
        private Dictionary<string, string> dicLingue;
        private SubWindows.WindowMain.frmEuroFormulationsNew frmEF = null;
        private Dispatcher disp = Dispatcher.CurrentDispatcher;
        private static Library.Language lang = Library.Language.GetInstance();
        private IniFile conf;
        private ToolTip tp = new ToolTip();
        private bool bModificato = false;

        public frmImpostazioniGenerali()
        {
            InitializeComponent();
            dicLingue = lang.AllLanguages;
            
            try
            {
                conf = new IniFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region PROPERTY
        public SubWindows.WindowMain.frmEuroFormulationsNew MAIN_FORM
        {
            set { this.frmEF = value; }
        }
        #endregion

        #region LOAD/SAVE
        private void frmImpostazioniGenerali_Load(object sender, EventArgs e)
        {
            try
            {
                gbBarcode.Text = lang.GetWord("settings03");
                gbErogazioneMultipla.Text = lang.GetWord("settings92");
                GroupBox2.Text = lang.GetWord("settings05");
                gbDigits.Text = lang.GetWord("settings07");
                gbHistory.Text = lang.GetWord("settings08");
                SalvaTab1.Text = lang.GetWord("settings09");
                chkBarcode.Text = lang.GetWord("settings21");
                groupBox5.Text = lang.GetWord("settings46");
                gbPriceList.Text = lang.GetWord("settings48");
                gbResizable.Text = lang.GetWord("settings75");
                gbFormula.Text = lang.GetWord("settings93");
                gbAdminPassword.Text = lang.GetWord("settings90");
                lblPassword.Text = lang.GetWord("Password");
                lblConfirm.Text = lang.GetWord("confirm");
                gbFormulaManagement.Text = lang.GetWord("newproduct01");
                btnProductMNG.Text = lang.GetWord("newproduct16");
                btnFattoriCorrettivi.Text = lang.GetWord("fcor01");
                gbDriver.Text = lang.GetWord("settings98");
                btnDriver.Text = lang.GetWord("settings99");

                Dictionary<int, string> dicWindowType = new Dictionary<int, string>();
                dicWindowType.Add(0, lang.GetWord("yes"));
                dicWindowType.Add(1, lang.GetWord("no"));
                dicWindowType.Add(2, lang.GetWord("fullscreen"));

                #region GENERAL SETTING
                Library.Data.Database.DBConnector db = new Library.Data.Database.DBConnector();
                Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
                Library.Data.DBSettings dbSettings = new Library.Data.DBSettings();

                cmbSaveSize.DataSource = new BindingSource(dicWindowType, null);
                cmbSaveSize.DisplayMember = "Value";
                cmbSaveSize.ValueMember = "Key";
                switch (settings.GetValue("ModeSave"))
                {
                    case "YES":
                        {
                            cmbSaveSize.SelectedValue = 0;
                            break;
                        }
                    case "FULL SCREEN":
                        {
                            cmbSaveSize.SelectedValue = 2;
                            break;
                        }
                    default:
                        {
                            cmbSaveSize.SelectedValue = 1;
                            break;
                        }
                }

                txtCifreDecimali.Text = settings.GetValue("DecimalNumber");
                txtHistoryRows.Text = settings.GetValue("HistoryView");
                txtAdminPass.Text = settings.GetValue("SettingsPassword");
                txtAdminPassConfirm.Text = txtAdminPass.Text;

                chkBarcode.Checked = false;
                if (GVar.attivazioni.Act_Barcode)
                {
                    if (settings.GetValue("BarCodeStatus") == "SI")
                    {
                        chkBarcode.Checked = true;
                    }
                }
                else
                {
                    chkBarcode.Enabled = false;
                }

                string sListinoDefault = dbSettings.GetValue("ListinoDefault");
                bool bDefaultFound = false;
                Dictionary<int, string> dicListini = new Dictionary<int, string>();
                dicListini.Add(-1, "");
                string sQuery = "SELECT * FROM listino ORDER BY id_list LIMIT 1";
                if (GVar.attivazioni.Act_ListiniUnlimited)
                {
                    sQuery = "SELECT * FROM listino ORDER BY nome_listino";
                }
                DataTable dtListini = db.SQLQuerySelect(sQuery);
                foreach (DataRow dr in dtListini.Rows)
                {
                    string sListino = dr["id_list"].ToString();
                    if (sListino == sListinoDefault) { bDefaultFound = true; }
                    dicListini.Add(Convert.ToInt32(sListino), dr["nome_listino"].ToString());
                }
                cmbListino.DataSource = new BindingSource(dicListini, null);
                cmbListino.DisplayMember = "Value";
                cmbListino.ValueMember = "Key";

                if (sListinoDefault != "" && bDefaultFound)
                {
                    cmbListino.SelectedValue = Convert.ToInt32(sListinoDefault);
                }

                Dictionary<int, string> dicResizable = new Dictionary<int, string>();
                dicResizable.Add(0, lang.GetWord("no"));
                dicResizable.Add(1, lang.GetWord("yes"));
                cmbResizable.DataSource = new BindingSource(dicResizable, null);
                cmbResizable.DisplayMember = "Value";
                cmbResizable.ValueMember = "Key";
                if (dbSettings.GetValue("resizemainwindow") == "1")
                {
                    cmbResizable.SelectedValue = 1;
                }
                else
                {
                    cmbResizable.SelectedValue = 0;
                }

                //erogazione multipla
                Dictionary<int, string> dicErogazioneMultipla = new Dictionary<int, string>();
                dicErogazioneMultipla.Add(0, lang.GetWord("no"));
                dicErogazioneMultipla.Add(1, lang.GetWord("yes"));
                cmbErogazioneMultipla.DataSource = new BindingSource(dicErogazioneMultipla, null);
                cmbErogazioneMultipla.DisplayMember = "Value";
                cmbErogazioneMultipla.ValueMember = "Key";
                if (settings.GetValue("MultiErogazione") == "1")
                {
                    cmbErogazioneMultipla.SelectedValue = 1;
                }
                else
                {
                    cmbErogazioneMultipla.SelectedValue = 0;
                }

                Dictionary<int, string> dicDeltaWarning = new Dictionary<int, string>();
                dicDeltaWarning.Add(0, lang.GetWord("no"));
                dicDeltaWarning.Add(1, lang.GetWord("yes"));
                cmbDeltaWarning.DataSource = new BindingSource(dicDeltaWarning, null);
                cmbDeltaWarning.DisplayMember = "Value";
                cmbDeltaWarning.ValueMember = "Key";
                if (settings.GetValue("DeltaWarning") == "0")
                {
                    cmbDeltaWarning.SelectedValue = 0;
                }
                else
                {
                    cmbDeltaWarning.SelectedValue = 1;
                }

                txtDELimit.Text = dbSettings.GetValue("DEFormulaLimit");

                //combo lingue
                cmbLanguage.DataSource = new BindingSource(dicLingue, null);
                cmbLanguage.DisplayMember = "Value";
                cmbLanguage.ValueMember = "Key";
                cmbLanguage.SelectedValue = "en"; //default
                
                try
                {
                    cmbLanguage.SelectedValue = Language.CodLinguaFromIniFile();
                }
                catch (Exception)
                { }
                #endregion

                if (!GVar.attivazioni.Act_NuovoProdotto) { btnProductMNG.Enabled = false; }
                if (!GVar.attivazioni.Act_FattoreCorrettivo) { btnFattoriCorrettivi.Enabled = false; }

                //hidden area
                //gbDELimit.Visible = false;
                //gbFormula.Size = new Size(gbDigits.Size.Width, 50);
                //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //event handler
            cmbSaveSize.SelectedIndexChanged += new EventHandler(UserDataChanged);
            cmbLanguage.SelectedIndexChanged += new EventHandler(UserDataChanged);
            txtCifreDecimali.TextChanged += new EventHandler(UserDataChanged);
            txtHistoryRows.TextChanged += new EventHandler(UserDataChanged);
            cmbDeltaWarning.SelectedIndexChanged += new EventHandler(UserDataChanged);
            chkBarcode.CheckedChanged += new EventHandler(UserDataChanged);
            cmbListino.SelectedIndexChanged += new EventHandler(UserDataChanged);
            cmbResizable.SelectedIndexChanged += new EventHandler(UserDataChanged);
            txtAdminPass.TextChanged += new EventHandler(UserDataChanged);
        }
        private void SalvaTab1_Click(object sender, EventArgs e)
        {
            SaveGeneraliExecute(true);
        }
        private void SaveGeneraliExecute(bool bReboot)
        {
            try
            {
                if (txtAdminPass.Text != txtAdminPassConfirm.Text) { throw new Exception(lang.GetWord("settings91")); }

                Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
                Library.Data.DBSettings dbSettings = new Library.Data.DBSettings();
                int iDecimal = 3;
                try
                {
                    iDecimal = Convert.ToInt32(txtCifreDecimali.Text);
                }
                catch (Exception) { }
                settings.SetValue("DecimalNumber", iDecimal.ToString());
                int iHistoryRows = 150;
                try
                {
                    iHistoryRows = Convert.ToInt32(txtHistoryRows.Text);
                }
                catch (Exception) { }
                settings.SetValue("HistoryView", iHistoryRows.ToString());
                settings.SetValue("SettingsPassword", txtAdminPass.Text);

                if (cmbDeltaWarning.SelectedValue != null)
                {
                    if (Convert.ToInt32(cmbDeltaWarning.SelectedValue) == 0)
                    {
                        settings.SetValue("DeltaWarning", "0");
                    }
                    else
                    {
                        settings.SetValue("DeltaWarning", "1");
                    }
                }
                double dDeltaLimit = 3d;
                try
                {
                    dDeltaLimit = Convert.ToDouble(txtDELimit.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                }
                catch (Exception) { }
                dbSettings.SetValue("DEFormulaLimit", dDeltaLimit.ToString().Replace(",", "."));

                if (cmbErogazioneMultipla.SelectedValue != null)
                {
                    if (Convert.ToInt32(cmbErogazioneMultipla.SelectedValue) == 0)
                    {
                        settings.SetValue("MultiErogazione", "0");
                    }
                    else
                    {
                        settings.SetValue("MultiErogazione", "1");
                    }
                }
                if (cmbListino.SelectedValue != null)
                {
                    if (cmbListino.SelectedValue.ToString() == "-1")
                    {
                        dbSettings.SetValue("ListinoDefault", "");
                    }
                    else
                    {
                        dbSettings.SetValue("ListinoDefault", cmbListino.SelectedValue.ToString());
                    }
                }
                if (cmbResizable.SelectedValue != null)
                {
                    dbSettings.SetValue("resizemainwindow", cmbResizable.SelectedValue.ToString() == "1" ? "1" : "0");
                }
                if (GVar.attivazioni.Act_Barcode)
                {
                    if (chkBarcode.Checked)
                    {
                        settings.SetValue("BarCodeStatus", "SI");
                    }
                    else
                    {
                        settings.SetValue("BarCodeStatus", "NO");
                    }
                }

                if (cmbSaveSize.SelectedValue != null)
                {
                    int iWindowTipe = Convert.ToInt32(cmbSaveSize.SelectedValue);
                    switch (iWindowTipe)
                    {
                        case 0:
                            {
                                settings.SetValue("ModeSave", "YES");
                                break;
                            }
                        case 2:
                            {
                                settings.SetValue("ModeSave", "FULL SCREEN");
                                break;
                            }
                        default:
                            {
                                settings.SetValue("ModeSave", "NO");
                                break;
                            }
                    }
                }

                if (cmbLanguage.SelectedValue != null)
                {
                    string codLingua = cmbLanguage.SelectedValue.ToString();
                    IniFileUnicode langFile = new IniFileUnicode(System.Windows.Forms.Application.StartupPath + "/include/language.ini");
                    langFile.Write("DEFAULT", "linguapredefinita", codLingua);
                    lang.SetLanguage(codLingua);
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
        #endregion

        #region TAB GENERAL SETTINGS
        private void btnTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + @"\template");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SettCifreDecimali_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void historyview_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtDELimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                if (e.KeyChar != '.' && e.KeyChar != ',') { e.Handled = true; }

            }
        }
        private void btnBookmarks_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + @"\Bookmarks_guide_eng.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void UserDataChanged(object sender, EventArgs e)
        {
            bModificato = true;
        }

        private void frmImpostazioniGenerali_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bModificato)
                {
                    DialogResult dialogResult = MessageBox.Show(lang.GetWord("save_message"), lang.GetWord("save_header"), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveGeneraliExecute(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Prodotti.frmNewProduct frmNuovoProdotto = new Prodotti.frmNewProduct();
                frmNuovoProdotto.StartPosition = FormStartPosition.Manual;
                frmNuovoProdotto.Location = new Point(GVar.AppLocation_X + 260, GVar.AppLocation_Y + 145);
                frmNuovoProdotto.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFattoriCorrettivi_Click(object sender, EventArgs e)
        {
            try
            {
                FattoriCorrettivi.frmFattoreCorrettivo frmCorrettivo = new FattoriCorrettivi.frmFattoreCorrettivo();
                frmCorrettivo.StartPosition = FormStartPosition.Manual;
                frmCorrettivo.Location = new Point(GVar.AppLocation_X + 260, GVar.AppLocation_Y + 145);
                frmCorrettivo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_EnabledChanged(object sender, EventArgs e)
        {
            SetButtonColor((Button)sender);
        }
        private void SetButtonColor(Button btn)
        {
            if (!btn.Enabled)
            {
                btn.BackColor = System.Drawing.Color.Gainsboro;
                btn.ForeColor = System.Drawing.Color.Black;
                btn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                btn.BackColor = System.Drawing.Color.White;
                btn.ForeColor = System.Drawing.Color.FromArgb(0, 149, 66);
                btn.FlatAppearance.BorderSize = 2;
            }
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + @"\include\driver");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
