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

namespace Euroformulations4.SubWindows.Settings
{
    public partial class frmDatabase : Form
    {
        private Library.Language lang = Library.Language.GetInstance();
        private IniFile conf = new IniFile();
        private SubWindows.WindowMain.frmEuroFormulationsNew frmEF = null;
        private BackgroundWorker importDB = null;

        public frmDatabase()
        {
            InitializeComponent();
        }
        public SubWindows.WindowMain.frmEuroFormulationsNew MainForm { set { this.frmEF = value; } }
        private void frmDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                //traduzioni
                gbCurrentDB.Text = lang.GetWord("settings78");
                gbSelection.Text = lang.GetWord("settings79");
                btnConfirm.Text = lang.GetWord("settings80");
                btnEdit.Text = lang.GetWord("settings81");
                btnDelete.Text = lang.GetWord("settings82");
                btnCreate.Text = lang.GetWord("settings83");
                gbNuovoDB.Text = lang.GetWord("settings84");
                
                UpdateComboDB();

                if (!GVar.attivazioni.Act_MultiDB)
                {
                    gbNuovoDB.Enabled = false;
                }
                this.ActiveControl = cmbDb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
        private void cmbDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDb.SelectedValue == null) return;

                string sNomeDB = cmbDb.SelectedValue.ToString();
                if (sNomeDB.Trim() == GVar.Database.Trim())
                {
                    btnConfirm.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (GVar.attivazioni.Act_MultiDB)
                    {
                        btnConfirm.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDb.SelectedValue == null) { throw new Exception(lang.GetWord("settings66")); }
                string sDBRealName = cmbDb.SelectedValue.ToString();
                if (sDBRealName.Trim() == GVar.Database.Trim())
                {
                    throw new Exception(lang.GetWord("settings72"));  //for security
                }
                DialogResult dialogResult = MessageBox.Show(lang.GetWord("settings74"), lang.GetWord("settings73"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes){ return; }
                Library.Data.Database.DBStructureManager.DropDatabase(sDBRealName);
                IniFile ini = new IniFile();
                ini.IniWriteValue("DBLIST", sDBRealName, null);
                UpdateComboDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDb.SelectedValue == null) return;
                
                IniFile conf = new IniFile();
                conf.IniWriteValue("DATABASE", "ActiveDB", cmbDb.SelectedValue.ToString());
                this.frmEF.RebootNow = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (importDB != null)
                {
                    if (importDB.IsBusy)
                    {
                        throw new Exception(lang.GetWord("db01"));
                    }
                }
                openFileDialog1.Filter = lang.GetWord("db13") + " (*.zip)|*.zip|" + lang.GetWord("db14") + " (*.*)|*.*";
                openFileDialog1.Title = lang.GetWord("db12");
                openFileDialog1.FileName = "";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result != DialogResult.OK) return;

                string path = openFileDialog1.FileName;
                if (path == String.Empty) return;

                DialogResult dialogResult = MessageBox.Show(lang.GetWord("settings44"), lang.GetWord("settings43"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) { return; }
                
                frmDBImport db = new frmDBImport();
                db.ExecuteNewDatabase(path, Path.GetFileNameWithoutExtension(path));
                this.frmEF.Visible = false;
                db.ShowDialog();
                this.frmEF.RebootNow = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (importDB != null)
                {
                    if (importDB.IsBusy)
                    {
                        throw new Exception(lang.GetWord("db01"));
                    }
                }
                openFileDialog1.Filter = lang.GetWord("db13") + " (*.zip)|*.zip|" + lang.GetWord("db14") + " (*.*)|*.*";
                openFileDialog1.Title = lang.GetWord("db12");
                openFileDialog1.FileName = "";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result != DialogResult.OK) return;

                string path = openFileDialog1.FileName;
                if (path == String.Empty) return;

                DialogResult dialogResult = MessageBox.Show(lang.GetWord("settings76"), lang.GetWord("settings43"), MessageBoxButtons.YesNo);
                bool bEraseAll = dialogResult == DialogResult.Yes;
                string sTextConfirm = "";
                if (!bEraseAll)
                {
                    if (Library.Data.Database.DBImport.ListiniIntoZipFile(path))
                    {
                        sTextConfirm += lang.GetWord("settings77") + ". ";
                    }
                }

                //conferma a procedere
                sTextConfirm += lang.GetWord("settings44");
                dialogResult = MessageBox.Show(sTextConfirm, lang.GetWord("settings43"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) { return; }

                

                frmDBImport db = new frmDBImport();
                db.ExecuteUpdateDatabase(path, cmbDb.Text, bEraseAll, cmbDb.SelectedValue.ToString());
                this.frmEF.Visible = false;
                db.ShowDialog();
                this.frmEF.RebootNow = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region UTILITIES
        private void UpdateComboDB()
        {
            Dictionary<string, Dictionary<string, string>> ini = conf.GetIniRapresentation();
            Dictionary<string, string> dicDBList = ini["DBLIST"];
            cmbDb.DataSource = new BindingSource(dicDBList, null);
            cmbDb.DisplayMember = "Value";
            cmbDb.ValueMember = "Key";
            cmbDb.SelectedValue = GVar.Database;
            cmbDb_SelectedIndexChanged(null, null);
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
        #endregion
    }
}
