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
using System.Diagnostics;

namespace Euroformulations4.SubWindows.Clienti
{
    public partial class frmVisualizzaCliente : Form
    {
        private Library.Data.Database.DBConnector db;
        
        private bool bGoPersonale = false;
        private static Language lang = Language.GetInstance();
        private int IDCLIENTE_REQUEST = -1;
        
        private string DOVESONO = "NULL_CLIENTE";
        private string RICHIAMO = "GENERAL MENU";
        private ToolTip tp = new ToolTip();

        #region INIZIALIZAZIONE VARIABILI COSTANTI COMBOBOX IN LINGUA EN
        private string TxtName;
        private string TxtSurname;
        private string TxtCompany;
        private string TxtVat;
        private string TxtEmail;
        private string TxtAll;
        private string TxtPriceList;
        #endregion

        public frmVisualizzaCliente()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        public frmVisualizzaCliente(string ric = "GENERAL MENU")
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
            RICHIAMO = ric;
        }

        public int REQUEST_IDCliente
        {
            get { return IDCLIENTE_REQUEST; }
        }

        

        public string REQUEST_DvSono
        {
            get { return DOVESONO; }
        }

        

        public bool REQUEST_GoPersonal
        {
            get { return bGoPersonale; }
        }

        private void frmVisualizzaCliente_Load(object sender, EventArgs e)
        {
            TxtCustomerLabel.Text = lang.GetWord("customer20");
            label2.Text = lang.GetWord("customer21");
            label3.Text = "( " + lang.GetWord("customer22") + " )";
            dgClienti.Columns[1].HeaderText = lang.GetWord("customer23");
            dgClienti.Columns[2].HeaderText = lang.GetWord("customer24");
            dgClienti.Columns[3].HeaderText = lang.GetWord("customer25");
            dgClienti.Columns[4].HeaderText = lang.GetWord("customer26");
            dgClienti.Columns[5].HeaderText = lang.GetWord("customer27");
            dgClienti.Columns[6].HeaderText = lang.GetWord("customer30");
            
            TxtName = lang.GetWord("customer23");
            TxtAll = lang.GetWord("allFieldsCombo");
            TxtSurname = lang.GetWord("customer24");
            TxtCompany = lang.GetWord("customer25");
            TxtVat = lang.GetWord("customer26");
            TxtEmail = lang.GetWord("customer27");
            TxtPriceList = lang.GetWord("customer30");
            gbBarcode.Text = lang.GetWord("settings03");

            if (RICHIAMO != "GENERAL MENU")  //related to
            {
                CmSClienti.Items.RemoveAt(0);
                CmSClienti.Items.RemoveAt(0);
                this.Text = lang.GetWord("customer43");
                tp.SetToolTip(pbHelp1, lang.GetWord("help04"));
            }
            else
            {
                CmSClienti.Items.RemoveAt(2);
                this.Text = lang.GetWord("customer20");
                tp.SetToolTip(pbHelp1, lang.GetWord("help03"));
            }
            itemEditCustomer.Text = lang.GetWord("customer46");
            itemDeleteCustomer.Text = lang.GetWord("customer47");
            itemNewCustomer.Text = lang.GetWord("customer48");


            #region COMBOFILTER COSTANTI DEFAULT VALUE
            ComboFilter.Items.Add(TxtAll);
            ComboFilter.Items.Add(TxtName);
            ComboFilter.Items.Add(TxtSurname);
            ComboFilter.Items.Add(TxtCompany);
            ComboFilter.Items.Add(TxtVat);
            ComboFilter.Items.Add(TxtEmail);
            ComboFilter.Items.Add(TxtPriceList);
            ComboFilter.Text = TxtAll;
            #endregion

            #region COMBOBOX PRICELIST

            DataTable dt = db.SQLQuerySelect("SELECT * FROM listino");
            foreach (DataRow dr in dt.Rows)
            {
                comboPricelist.Items.Add(dr["nome_listino"].ToString());
            }
            #endregion

            UpdateDGClienti();
            
            this.ActiveControl = txtBarcode;
        }

        private void UpdateDGClienti()
        {
            dgClienti.Rows.Clear();
            DataTable dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE deleted = 0");
            foreach (DataRow dr in dt.Rows)
            {
                dgClienti.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["cognome"].ToString(), dr["azienda"].ToString(), dr["partitaiva"].ToString(), dr["email"].ToString(), dr["nome_listino"].ToString());
            }

            dgClienti.ClearSelection();
        }

        private void CancellaCliente_Click(object sender, EventArgs e)
        {
            if (dgClienti.Rows.Count > 0 && dgClienti.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show(lang.GetWord("customer39") + " " + dgClienti.SelectedRows[0].Cells[1].Value.ToString() + " " + dgClienti.SelectedRows[0].Cells[2].Value.ToString() + "?", lang.GetWord("customer38"), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string sIDCliente = dgClienti.SelectedRows[0].Cells[0].Value.ToString();
                        
                        Dictionary<string, object> dicDelCliente = new Dictionary<string, object>
                        {
                            {"deleted", "1"},
                            {"servertimesync", "1"},
                            {"lastupdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                        };
                        db.QueryUpdate("clienti", dicDelCliente, "id = " + sIDCliente);

                        Dictionary<string, object> dataHistory = new Dictionary<string, object>
                        {
                            {"idcliente", Library.Data.Database.DBConnector.eSpecialValue.NULL}
                        };
                        db.QueryUpdate("history", dataHistory, "idcliente = " + sIDCliente);
                        
                        Dictionary<string, object> dataPersonali = new Dictionary<string, object>
                        {
                            {"client_id", Library.Data.Database.DBConnector.eSpecialValue.NULL}
                        };
                        db.QueryUpdate("formule_personali", dataPersonali, "client_id = " + sIDCliente);

                        dgClienti.Rows.RemoveAt(dgClienti.SelectedRows[0].Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(lang.GetWord("customer40") + " " + ex.Message);
                    }
                }
            }
        }

        private void frmVisualizzaCliente_FormClosing(object sender, FormClosingEventArgs e)
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

        private void modificaCliente_Click(object sender, EventArgs e)
        {
            if (dgClienti.Rows.Count > 0 && dgClienti.SelectedRows.Count > 0)
            {
                IDCLIENTE_REQUEST = Convert.ToInt32(dgClienti.SelectedRows[0].Cells[0].Value.ToString());
                DOVESONO = "MODIFICA";
                this.Close();
            }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgClienti.Rows.Count > 0 && dgClienti.SelectedRows.Count > 0)
            {
                IDCLIENTE_REQUEST = Convert.ToInt32(dgClienti.SelectedRows[0].Cells[0].Value.ToString());
                DOVESONO = "VISUALIZZA";
                this.Close();
            }
        }

        private void RicercaClienti_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (RICHIAMO == "GENERAL MENU")
            {
                if (dgClienti.Rows.Count > 0 && dgClienti.SelectedRows.Count > 0)
                {
                    IDCLIENTE_REQUEST = Convert.ToInt32(dgClienti.SelectedRows[0].Cells[0].Value.ToString());
                    DOVESONO = "VISUALIZZA";
                    this.Close();
                }
            }
            else
            {
                if (e.RowIndex != -1 && dgClienti.Rows.Count > 0)
                {
                    IDCLIENTE_REQUEST = Convert.ToInt32(dgClienti.SelectedRows[0].Cells[0].Value.ToString());
                    DOVESONO = "DBCLICK";
                    this.Close();
                }   
            }
        }

        private void RicercaClienti_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgClienti.Rows.Count > 0 && RICHIAMO == "GENERAL MENU" && dgClienti.SelectedRows.Count > 0)
            {
                int IDCliente = Convert.ToInt32(dgClienti.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        

        private void ComboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgClienti.ClearSelection();
            if (ComboFilter.Text == TxtPriceList)
            {
                comboPricelist.Visible = true;
                label3.Visible = false;
            }
            else if (ComboFilter.Text == TxtAll)
            {
                dgClienti.Rows.Clear();
                DataTable dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list");
                foreach(DataRow dr in dt.Rows)
                {
                    dgClienti.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["cognome"].ToString(), dr["azienda"].ToString(), dr["partitaiva"].ToString(), dr["email"].ToString(), dr["nome_listino"].ToString());
                }
                dgClienti.ClearSelection();
                comboPricelist.Visible = false;
                label3.Visible = true;
            }
            else
            {
                comboPricelist.Visible = false;
                label3.Visible = true;
            }
        }

        private void comboPricelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPricelist.Text.Length > 0)
            {
                dgClienti.Rows.Clear();

                string sql = "SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE nome_listino = '" + comboPricelist.Text + "'";
                DataTable dt = db.SQLQuerySelect(sql);
                foreach(DataRow dr in dt.Rows)
                {
                    dgClienti.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["cognome"].ToString(), dr["azienda"].ToString(), dr["partitaiva"].ToString(), dr["email"].ToString(), dr["nome_listino"].ToString());
                }
                dgClienti.ClearSelection();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // tasto destro - new client
            frmClienteEdit frmNewClient = new frmClienteEdit();
            frmNewClient.ShowDialog();
            UpdateDGClienti();
        }

        

        

       

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter) { return; }
                string sql = "SELECT id FROM clienti WHERE barcode = '"+ txtBarcode.Text +"'";
                DataTable dt = db.SQLQuerySelect(sql);
                if (dt.Rows.Count != 1) { return; }

                IDCLIENTE_REQUEST = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                DOVESONO = "DBCLICK";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmSClienti_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (dgClienti.SelectedRows.Count <= 0);
        }

        private void FilterName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgClienti.Rows.Clear();
                DataTable dt = null;

                if (ComboFilter.Text == TxtAll)
                {
                    dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE " +
                        "LOWER(nome) LIKE '%" + FilterName.Text.Trim().ToLower() + "%' " +
                        "or LOWER(cognome) LIKE '%" + FilterName.Text.Trim().ToLower() + "%' " +
                        "or LOWER(azienda) LIKE '%" + FilterName.Text.Trim().ToLower() + "%' " +
                        "or LOWER(nomepaese) LIKE '%" + FilterName.Text.Trim().ToLower() + "%' " +
                        "or LOWER(email) LIKE '%" + FilterName.Text.Trim().ToLower() + "%'  " +
                        "or LOWER(nome_listino) LIKE '%" + FilterName.Text.Trim().ToLower() + "%'");
                }
                else if (ComboFilter.Text == TxtCompany)
                {
                    dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE LOWER(azienda) LIKE '" + FilterName.Text.ToLower() + "%'");
                }
                else if (ComboFilter.Text == TxtEmail)
                {
                    dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE LOWER(email) LIKE '" + FilterName.Text.ToLower() + "%'");
                }
                else if (ComboFilter.Text == TxtSurname)
                {
                    dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE LOWER(cognome) LIKE '" + FilterName.Text.ToLower() + "%'");
                }
                else if (ComboFilter.Text == TxtVat)
                {
                    dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE LOWER(partitaiva) LIKE '" + FilterName.Text.ToLower() + "%'");
                }
                else if (ComboFilter.Text == TxtPriceList)
                {
                    dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE LOWER(nome_listino) LIKE '" + FilterName.Text.ToLower() + "%'");
                }
                else if (ComboFilter.Text == TxtName)
                {
                    dt = db.SQLQuerySelect("SELECT * FROM clienti LEFT JOIN listino ON clienti.idlistino = listino.id_list WHERE LOWER(nome) LIKE '" + FilterName.Text.ToLower() + "%'");
                }

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgClienti.Rows.Add(dr["id"].ToString(), dr["nome"].ToString(), dr["cognome"].ToString(), dr["azienda"].ToString(), dr["partitaiva"].ToString(), dr["email"].ToString(), dr["nome_listino"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(lang.GetWord("customer41") + " " + ex.Message);
            }
        }
    }
}
