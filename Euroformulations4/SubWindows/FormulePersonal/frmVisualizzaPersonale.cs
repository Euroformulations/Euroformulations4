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
using Npgsql;

namespace Euroformulations4.SubWindows.FormulePersonal
{
    public partial class frmVisualizzaPersonale : Form
    {
        private Library.Data.Database.DBConnector db;
        private Language lang = Language.GetInstance();       
        private int IDFORMULA_REQUEST = -1;
        private string DOVESONO = "NULL";
        private int selectedFormula = -1;
        private string TxtColorname = "Colorname";
        private string TxtBase = "Base";
        private string TxtCustomers = "Customers";
        private string TxtCreatedBy = "Created By";
        private string TxtDirectory = "Directory";
        private string TxtAll = "ALL FIELDS";
        private ToolTip tp = new ToolTip();

        public frmVisualizzaPersonale()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        public int SelectedFormulaLoad
        {
            set { this.selectedFormula = value; }
        }

        public int REQUEST_IDFormula
        {
            get { return IDFORMULA_REQUEST; }
        }

        public string REQUEST_DvSono
        {
            get { return DOVESONO; }
        }

        private void frmVisualizzaPersonale_Load(object sender, EventArgs e)
        {
            TxtCustomerLabel.Text = lang.GetWord("fper24");
            label2.Text = lang.GetWord("fper25");
            label3.Text = lang.GetWord("fper26");
            dgFormulePersonali.Columns[1].HeaderText = lang.GetWord("fper27");
            dgFormulePersonali.Columns[2].HeaderText = lang.GetWord("fper28");
            dgFormulePersonali.Columns[3].HeaderText = lang.GetWord("fper29");
            dgFormulePersonali.Columns[4].HeaderText = lang.GetWord("fper30");
            dgFormulePersonali.Columns[5].HeaderText = lang.GetWord("fper31");
            dgFormulePersonali.Columns[6].HeaderText = lang.GetWord("fper32");
            dgFormulePersonali.Columns[7].HeaderText = lang.GetWord("fper33");
            TxtColorname = lang.GetWord("fper29");
            TxtBase = lang.GetWord("fper30");
            TxtCustomers = lang.GetWord("fper31");
            TxtCreatedBy = lang.GetWord("fper32");
            TxtDirectory = lang.GetWord("fper33");
            TxtAll = lang.GetWord("fper38");
            itemEditFormula.Text = lang.GetWord("fper64");
            itemDeleteFormula.Text = lang.GetWord("fper65");
            tp.SetToolTip(pbHelp, lang.GetWord("help02"));

            #region COMBOFILTER COSTANTI DEFAULT VALUE
            ComboFilter.Items.Add(TxtAll);
            ComboFilter.Items.Add(TxtColorname);
            ComboFilter.Items.Add(TxtBase);
            ComboFilter.Items.Add(TxtCustomers);
            ComboFilter.Items.Add(TxtCreatedBy);
            ComboFilter.Items.Add(TxtDirectory);
            ComboFilter.Text = TxtAll;
            #endregion

            string sql = Library.Data.Machine.SQLSelectMachines();
            DataTable dt = db.SQLQuerySelect("SELECT * FROM  formule_personali LEFT OUTER JOIN clienti ON clienti.id = formule_personali.client_id ORDER BY dateformula DESC");

            UpdateDGDati(dt);
            this.selectedFormula = -1;

            if (this.selectedFormula == -1) dgFormulePersonali.ClearSelection();

            this.ActiveControl = dgFormulePersonali;
        }

        private void frmVisualizzaPersonale_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception) 
            { 
                //LOG HERE
            }
            
        }

        private void UpdateDGDati(DataTable dt)
        {
            dgFormulePersonali.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                dgFormulePersonali.Rows.Add(dr["idp"].ToString(), "", DateTime.Parse(dr["dateformula"].ToString()), dr["colorname"].ToString(), dr["base"].ToString(), dr["nome"].ToString() + " " + dr["cognome"].ToString(), dr["createdby"].ToString(), dr["directory_txt"].ToString(), dr["unit"].ToString());
                dgFormulePersonali.Rows[dgFormulePersonali.RowCount - 1].Cells[1].Style.BackColor = Color.FromArgb(Convert.ToInt32(dr["r"].ToString()), Convert.ToInt32(dr["g"].ToString()), Convert.ToInt32(dr["b"].ToString()));
                if (this.selectedFormula != -1 && this.selectedFormula.ToString() == dr["idp"].ToString())
                {
                    dgFormulePersonali.Rows[dgFormulePersonali.RowCount - 1].Selected = true;
                }
            }
        }

        private void CancellaCliente_Click(object sender, EventArgs e)
        {
            if (dgFormulePersonali.Rows.Count > 0 && dgFormulePersonali.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(lang.GetWord("fper35") + " " + dgFormulePersonali.SelectedRows[0].Cells[3].Value.ToString() + "?", lang.GetWord("fper34"), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        db.QueryDelete("formule_personali", "idp = " + dgFormulePersonali.SelectedRows[0].Cells[0].Value.ToString());
                        dgFormulePersonali.Rows.RemoveAt(dgFormulePersonali.SelectedRows[0].Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(lang.GetWord("fper36") + " " + ex.Message);
                    }
                }
            }
        }

        private void RicercaPersonale_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgFormulePersonali.SelectedRows.Count == 1)
                {
                    IDFORMULA_REQUEST = Convert.ToInt32(dgFormulePersonali.SelectedRows[0].Cells[0].Value.ToString());
                    DOVESONO = "DBCLICK";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modificaFormula_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgFormulePersonali.Rows.Count > 0 && dgFormulePersonali.SelectedRows.Count > 0)
                {
                    if (dgFormulePersonali.SelectedRows[0].Cells[8].Value.ToString() == "OUNCE" || dgFormulePersonali.SelectedRows[0].Cells[8].Value.ToString() == "ONCE")
                    {
                        Library.Data.DBSettings settings = new Library.Data.DBSettings();
                        int IDMachine = Convert.ToInt32(settings.GetValue("IDMachineOunceEdit"));
                        if (IDMachine == -1)
                        {
                            throw new Exception(lang.GetWord("formula69"));
                        }
                    }

                    IDFORMULA_REQUEST = Convert.ToInt32(dgFormulePersonali.SelectedRows[0].Cells[0].Value.ToString());
                    DOVESONO = "MODIFICA";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgFormulePersonali.Rows.Clear();
                string sComboText = ComboFilter.Text;
                string sql = "SELECT * FROM  formule_personali LEFT OUTER JOIN clienti ON clienti.id = formule_personali.client_id ";
                if (sComboText == TxtAll)
                {
                    sql += "WHERE ( LOWER(nome) LIKE '" + FilterName.Text.ToLower() + "%' or LOWER(cognome) LIKE '" + FilterName.Text.ToLower() + "%' or LOWER(colorname) LIKE '" + FilterName.Text.ToLower() + "%' or LOWER(base) LIKE '" + FilterName.Text.ToLower() + "%' or LOWER(createdby) LIKE '" + FilterName.Text.ToLower() + "%' or LOWER(directory_txt) LIKE '" + FilterName.Text.ToLower() + "%')";
                }
                else if (sComboText == TxtBase)
                {
                    sql += "WHERE ( LOWER(base) LIKE '" + FilterName.Text.ToLower() + "%')";
                }
                else if (sComboText == TxtCustomers)
                {
                    sql += "WHERE ( LOWER(nome) LIKE '" + FilterName.Text.ToLower() + "%' or LOWER(cognome) LIKE '" + FilterName.Text.ToLower() + "%')";
                }
                else if (sComboText == TxtCreatedBy)
                {
                    sql += "WHERE ( LOWER(createdby) LIKE '" + FilterName.Text.ToLower() + "%')";
                }
                else if (sComboText == TxtDirectory)
                {
                    sql += "WHERE ( LOWER(directory_txt) LIKE '" + FilterName.Text.ToLower() + "%')";
                }
                else if (sComboText == TxtColorname)
                {
                    sql += "WHERE ( LOWER(colorname) LIKE '" + FilterName.Text.ToLower() + "%')";
                }

                DataTable dt = db.SQLQuerySelect(sql);

                UpdateDGDati(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(lang.GetWord("fper37") + " " + ex.Message);
            }
        }

        private void CmSClienti_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (dgFormulePersonali.SelectedRows.Count <= 0);
        }

    }
}
