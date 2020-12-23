using Euroformulations4.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace Euroformulations4.SubWindows.Settings
{
    public partial class frmMachine : Form
    {
        private SubWindows.WindowMain.frmEuroFormulationsNew frmEF = null;
        private static Library.Language lang = Library.Language.GetInstance();
        private Library.Data.DBSettings dbSettings = new Library.Data.DBSettings();
        private ToolTip tp = new ToolTip();
        private bool bMachineUpdateMode = false;
        private int iIDMacchina = -1;

        public frmMachine()
        {
            InitializeComponent();
        }

        public SubWindows.WindowMain.frmEuroFormulationsNew MAIN_FORM
        {
            set { this.frmEF = value; }
        }

        private void frmMachine_Load(object sender, EventArgs e)
        {
            try
            {
                Library.Data.Database.DBConnector db = new Library.Data.Database.DBConnector();

                #region Traduzioni
                gbType.Text = lang.GetWord("settings10");
                gbPathFormula.Text = lang.GetWord("settings11");
                gbPathDriver.Text = lang.GetWord("settings13");
                gbIdentification.Text = lang.GetWord("settings12");
                gbOunceType.Text = lang.GetWord("settings56");
                btnAutoConfigure.Text = lang.GetWord("settings14");
                btnImportExport.Text = lang.GetWord("settings50");
                Save_Modifica.Text = lang.GetWord("settings16");
                tp.SetToolTip(pbHelp, lang.GetWord("help05"));
                DataMachine.Columns[1].HeaderText = lang.GetWord("settings17");
                DataMachine.Columns[2].HeaderText = lang.GetWord("settings18");
                DataMachine.Columns[3].HeaderText = lang.GetWord("settings19");
                DataMachine.Columns[4].HeaderText = lang.GetWord("settings20");
                DataMachine.Columns[5].HeaderText = lang.GetWord("settings56");
                DataMachine.Columns[7].HeaderText = lang.GetWord("settings95");
                gbOunceEdit.Text = lang.GetWord("settings94");
                chkOunceEdit.Text = lang.GetWord("settings95");
                #endregion

                cmbDriver.DisplayMember = "name";
                cmbDriver.ValueMember = "code";
                BindingSource bsAddresses = new BindingSource();
                bsAddresses.DataSource = MachineDataView();
                cmbDriver.DataSource = bsAddresses;
                bsAddresses.Sort = "name ASC";
                cmbDriver.SelectedValue = -1;

                cmbOunceType.Items.Add("");
                foreach (KeyValuePair<Library.Data.eStandardOncia, double> pair in Library.Data.Machine.OunceType)
                {
                    cmbOunceType.Items.Add(pair.Value.ToString().Replace(",", "."));
                }

                ResetInput();
                UpdateTabellaMachines(db.SQLQuerySelect(Library.Data.Machine.SQLSelectMachines()));
                this.ActiveControl = DataMachine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        #region FUNCTIONS
        private void UpdateTabellaMachines(DataTable dt)
        {
            int IDManuale = Convert.ToInt32(dbSettings.GetValue("IDMachineOunceEdit"));
            DataMachine.Rows.Clear();
            int i= 0;
            foreach (DataRow dr in dt.Rows)
            {
                int machine_type = Convert.ToInt32(dr["machine_type"].ToString());
                string sTipoDriver = Library.Data.Machine.dicNomiMacchine[(Library.Data.Machine.eMacchina)machine_type];
                DataMachine.Rows.Add();
                DataMachine.Rows[i].Cells[0].Value = dr["id_machine"].ToString();
                DataMachine.Rows[i].Cells[1].Value  = dr["name"].ToString();
                DataMachine.Rows[i].Cells[2].Value = sTipoDriver;
                DataMachine.Rows[i].Cells[3].Value = dr["pathfile"].ToString();
                DataMachine.Rows[i].Cells[4].Value = dr["exefile"].ToString();
                DataMachine.Rows[i].Cells[5].Value = dr["oncetype"].ToString().Replace(",", ".");
                DataMachine.Rows[i].Cells[6].Value = machine_type.ToString();

                DataMachine.Rows[i].Cells[7].Value = lang.GetWord("no").ToUpper();
                DataMachine.Rows[i].Cells[7].Tag = 0;
                if (IDManuale != -1)
                {
                    if (IDManuale.ToString() == dr["id_machine"].ToString())
                    {
                        DataMachine.Rows[i].Cells[7].Value = lang.GetWord("yes").ToUpper();
                        DataMachine.Rows[i].Cells[7].Tag = 1;
                    }
                }

                i++;
            }
            DataMachine.ClearSelection();
        }
        private void ResetInput()
        {
            cmbDriver.SelectedValue = -1;
            pathFile.Text = "";
            exeFile.Text = "";
            cmbOunceType.Text = "";
            MachineIdentification.Text = "";
            cmbDriver.Enabled = true;
            cmbOunceType.Enabled = true;
            MachineIdentification.Enabled = true;
            btnAutoConfigure.Enabled = false;
            DataMachine.ClearSelection();
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
        public DataView MachineDataView()
        {
            DataSet set1 = new DataSet();
            string sXMLData =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<machines>" +
                "<item><code>-1</code><name></name></item>";

            foreach (Library.Data.Machine.eMacchina item in Library.Data.Machine.Drivers)
            {
                sXMLData += "<item><code>" + (int)item + "</code><name>" + Library.Data.Machine.dicNomiMacchine[item].Replace("&", "&amp;") + "</name></item>";
            }
            sXMLData += "</machines>";
            StringReader reader = new StringReader(sXMLData);
            set1.ReadXml(reader);
            DataTableCollection tables = set1.Tables;
            DataView view1 = new DataView(tables[0]);
            return view1;
        }
        #endregion

        private void btnAutoConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                object oValue = cmbDriver.SelectedValue;
                if (oValue == null) return;

                Dictionary<string, string> dicData = Library.Data.Machine.AutoConfigureDriver((Library.Data.Machine.eMacchina)Convert.ToInt32(oValue));
                exeFile.Text = dicData["exe"];
                pathFile.Text = dicData["path"];
            }
                                
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnImportExport_Click(object sender, EventArgs e)
        {
            Library.Data.Database.DBConnector db = null;
            try
            {
                frmImportExportMachine importExport = new frmImportExportMachine();
                importExport.ShowDialog();

                db = new Library.Data.Database.DBConnector();
                UpdateTabellaMachines(db.SQLQuerySelect(Library.Data.Machine.SQLSelectMachines()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (db != null)
                {
                    try
                    {
                        db.CloseConnection();
                    }
                    catch (Exception)
                    {
                        //LOG
                    }
                }
            }
        }
        
        private void Save_Modifica_Click(object sender, EventArgs e)
        {
            Library.Data.Database.DBConnector db = null;
            try
            {
                db = new Library.Data.Database.DBConnector();
                object oValue = cmbDriver.SelectedValue;
                if (oValue == null) throw new Exception(lang.GetWord("settings55"));
                if (oValue.ToString() == "-1") { throw new Exception(lang.GetWord("settings55")); }
                if (MachineIdentification.Text.Trim().Length <= 0) throw new Exception(lang.GetWord("settings53"));
                if (cmbOunceType.Enabled && cmbOunceType.Text.Trim().Length <= 0) throw new Exception(lang.GetWord("settings54"));
                string Error_Insert = "";
                Library.Data.Machine.eMacchina eTipo = (Library.Data.Machine.eMacchina)Convert.ToInt32(oValue);
                int IDManualeCurrent = Convert.ToInt32(dbSettings.GetValue("IDMachineOunceEdit"));

                if (bMachineUpdateMode)
                {
                    Dictionary<string, object> data = new Dictionary<string, object>()
                    {
                        {"pathfile", "'" + pathFile.Text + "'"},
                        {"exefile", "'" + exeFile.Text + "'"}
                    };
                    if (cmbOunceType.Text.Trim() != "")
                    {
                        data.Add("oncetype", cmbOunceType.Text.Replace(",", "."));
                    }

                    db.QueryUpdate("machine", data, "id_machine = " + iIDMacchina);

                    if (Library.Data.Machine.ContainsManual(eTipo))
                    {
                        if (chkOunceEdit.Checked)
                        {
                            dbSettings.SetValue("IDMachineOunceEdit", iIDMacchina.ToString());
                        }
                        else
                        {
                            if (IDManualeCurrent == iIDMacchina)
                            {
                                dbSettings.SetValue("IDMachineOunceEdit", "-1");
                            }
                        }
                        
                    }
                }
                else
                {
                    //unique machine
                    DataTable dtMacchina = db.SQLQuerySelect("SELECT * FROM machine WHERE name = '" + MachineIdentification.Text.Trim() + "'");
                    if (dtMacchina.Rows.Count > 0) { throw new Exception(lang.GetWord("settings51")); }

                    if (Library.Data.Machine.ContainsManual(eTipo))
                    {
                        //manuale selezionata
                        Dictionary<string, string> data = new Dictionary<string, string>()
                        {
                            {"machine_type", ((int) eTipo).ToString()},
                            {"name", "'" + MachineIdentification.Text + "'"},
                            {"oncetype", cmbOunceType.Text.Replace(",", ".")},
                            {"tipo", ((int)Library.Data.eMacchinaTipo.Manuale).ToString()}
                        };

                        object oIDMachine = db.QueryInsert("machine", data, "id_machine");
                        Error_Insert = db.LastQueryError;
                        if (Error_Insert == "" && chkOunceEdit.Checked)
                        {
                            dbSettings.SetValue("IDMachineOunceEdit", oIDMachine.ToString());
                        }
                    }
                    else
                    {
                        if (Library.Data.Machine.ContainsAuto(eTipo))
                        {
                            //auto
                            Dictionary<string, string> data = new Dictionary<string, string>()
                            {
                                {"machine_type", ((int) eTipo).ToString()},
                                {"pathfile", "'" + pathFile.Text + "'"},
                                {"exefile", "'" + exeFile.Text + "'"},
                                {"name","'" +  MachineIdentification.Text + "'"},
                                {"tipo", ((int)Library.Data.eMacchinaTipo.Automatica).ToString()}
                            };
                            db.QueryInsert("machine", data);
                            Error_Insert = db.LastQueryError;
                        }
                        else
                        {
                            throw new Exception("unknown machine driver type.");
                        }
                    }
                }

                if (Error_Insert != "")
                {
                    MessageBox.Show(lang.GetWord("settings31"), lang.GetWord("settings32"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //query ok
                    if (!bMachineUpdateMode)
                    {
                        MessageBox.Show(lang.GetWord("settings28") + " " + cmbDriver.Text + " " + lang.GetWord("settings29"), lang.GetWord("settings27"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MachineIdentification.Enabled = true;
                        Save_Modifica.Text = "Save machine";
                        MessageBox.Show(lang.GetWord("settings30") + " " + cmbDriver.Text + " " + lang.GetWord("settings29"), lang.GetWord("settings27"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ResetInput();
                }

                bMachineUpdateMode = false;
                cmbDriver.Enabled = true;
                cmbOunceType.Enabled = true;
                chkOunceEdit.Checked = false;
                UpdateTabellaMachines(db.SQLQuerySelect(Library.Data.Machine.SQLSelectMachines()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (db != null)
                {
                    try { db.CloseConnection(); }
                    catch (Exception) { }
                }
            }
        }
        private void cmbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            object oTipo = cmbDriver.SelectedValue;
            if (oTipo == null) { return; }
            if (Convert.ToInt32(oTipo) == -1)
            {
                btnAutoConfigure.Enabled = false;
                exeFile.Enabled = true;
                pathFile.Enabled = true;
                cmbOunceType.Text = "";
                cmbOunceType.Enabled = false;
                return;
            }

            Library.Data.Machine.eMacchina macchina = (Library.Data.Machine.eMacchina) Convert.ToInt32(oTipo);

            btnAutoConfigure.Enabled = Library.Data.Machine.bMachineAutoConfigurable(macchina);

            chkOunceEdit.Checked = false;

            if(Library.Data.Machine.ContainsManual(macchina))
            {
                exeFile.Enabled = false;
                pathFile.Enabled = false;
                cmbOunceType.Enabled = true;
                gbOunceEdit.Enabled = true;
            }
            else
            {
                exeFile.Enabled = true;
                pathFile.Enabled = true;
                cmbOunceType.Text = "";
                cmbOunceType.Enabled = false;
                gbOunceEdit.Enabled = false;
            }
        }
        private void DataMachine_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DataMachine.Rows.Count == 0 || DataMachine.SelectedRows.Count == 0) { return; }

                int machine_type = Convert.ToInt32(DataMachine.SelectedRows[0].Cells[6].Value.ToString());
                Library.Data.Machine.eMacchina machine = (Library.Data.Machine.eMacchina) machine_type;

                cmbDriver.SelectedValue = machine_type;
                MachineIdentification.Text = DataMachine.SelectedRows[0].Cells[1].Value.ToString();

                if(Library.Data.Machine.ContainsManual(machine))
                {
                    cmbOunceType.Enabled = true;
                    cmbOunceType.SelectedItem = DataMachine.SelectedRows[0].Cells[5].Value.ToString();
                    pathFile.Text = "";
                    pathFile.Enabled = false;
                    exeFile.Text = "";
                    exeFile.Enabled = false;
                }
                else
                {
                    cmbOunceType.Text = "";
                    cmbOunceType.Enabled = false;
                    pathFile.Enabled = true;
                    exeFile.Enabled = true;
                    pathFile.Text = DataMachine.SelectedRows[0].Cells[3].Value.ToString();
                    exeFile.Text = DataMachine.SelectedRows[0].Cells[4].Value.ToString();
                }

                this.iIDMacchina = Convert.ToInt32(DataMachine.SelectedRows[0].Cells[0].Value.ToString());
                Save_Modifica.Text = "Update machine";
                bMachineUpdateMode = true;
                MachineIdentification.Enabled = false;
                cmbDriver.Enabled = false;

                int iDefOunceEdit = Convert.ToInt32(DataMachine.SelectedRows[0].Cells[7].Tag.ToString());
                chkOunceEdit.Checked = iDefOunceEdit == 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Library.Data.Database.DBConnector db = null;
            try
            {
                db = new Library.Data.Database.DBConnector();
                int IDMachine = Convert.ToInt32(DataMachine.SelectedRows[0].Cells[0].Value.ToString());

                Library.Data.DBSettings settings = new Library.Data.DBSettings();
                if (settings.GetValue("IDMachineOunceEdit") == IDMachine.ToString())
                {
                    settings.SetValue("IDMachineOunceEdit", "-1");
                }

                db.QueryDelete("machine", "id_machine = " + IDMachine);
                if (DataMachine.SelectedRows.Count > 0)
                {
                    DataMachine.Rows.RemoveAt(DataMachine.CurrentRow.Index);
                }

                int IDMachineOunceEdit = Convert.ToInt32(dbSettings.GetValue("IDMachineOunceEdit"));
                if (IDMachine == IDMachineOunceEdit)
                {
                    dbSettings.SetValue("IDMachineOunceEdit", "-1");
                }

                if (db.LastQueryError != "")
                {
                    throw new Exception(lang.GetWord("settings28") + " " + cmbDriver.Text + " " + lang.GetWord("settings33"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ResetInput();
                chkOunceEdit.Checked = false;
                bMachineUpdateMode = false;

                UpdateTabellaMachines(db.SQLQuerySelect(Library.Data.Machine.SQLSelectMachines()));

                if (db != null)
                {
                    try
                    {
                        db.CloseConnection();
                    }
                    catch (Exception) { }
                }
            }
        }

        private void dgMenu_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (DataMachine.SelectedRows.Count <= 0);
        }
        
    }
}
