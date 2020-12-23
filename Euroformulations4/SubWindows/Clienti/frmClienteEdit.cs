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
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace Euroformulations4.SubWindows.Clienti
{
    public partial class frmClienteEdit : Form
    {
        public enum ePage
        { 
            nothing = 0,
            view_client = 1,
            formula_from_history = 2,
            formula_from_personali = 3
        }
        private ePage page = ePage.nothing;
        private int IDFORMULA_REQUEST = -1;
        private bool bModificato = false;
        private int iIDCliente = -1;
        private static Library.Language lang = Library.Language.GetInstance();
        private Library.Data.Database.DBConnector db;

        public frmClienteEdit(int idcliente)
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
            this.iIDCliente = idcliente;
        }

        public frmClienteEdit() : this(-1) { }

        #region PROPERTIES
        public ePage PageTo { get { return page; } }
        public int REQUEST_IDFormula
        {
            get { return IDFORMULA_REQUEST; }
        }
        public int IDCliente
        {
            get { return iIDCliente; }
        }
        #endregion

        private void frmNuovoCliente_Load(object sender, EventArgs e)
        {
            #region traduzioni
            this.Text = lang.GetWord("customer14");
            tabDetail.Text = lang.GetWord("customer19");
            tabHistory.Text = lang.GetWord("customer44");
            tabPersonali.Text = lang.GetWord("customer45");

            //general
            label2.Text = lang.GetWord("customer02");
            label3.Text = lang.GetWord("customer03");
            label7.Text = lang.GetWord("customer04");
            lblAddress.Text = lang.GetWord("customer05");
            label9.Text = lang.GetWord("customer06");
            label11.Text = lang.GetWord("customer07");
            label10.Text = lang.GetWord("customer08");
            label4.Text = lang.GetWord("customer09");
            label12.Text = lang.GetWord("customer10");
            lblPersonalNotes.Text = lang.GetWord("customer11");
            label13.Text = lang.GetWord("customer12");
            btnSalva.Text = lang.GetWord("customer13");
            lblPriceList.Text = lang.GetWord("customer30");
            lblTipo.Text = lang.GetWord("customer49");
            label22.Text = lang.GetWord("customer54");
            label5.Text = lang.GetWord("customer55");
            label15.Text = lang.GetWord("customer56");
            label21.Text = lang.GetWord("customer57");
            btnPrint.Text = lang.GetWord("quality63");
            
            //history
            dgHistory.Columns[1].HeaderText = lang.GetWord("customer31");
            dgHistory.Columns[2].HeaderText = lang.GetWord("customer32");
            dgHistory.Columns[3].HeaderText = lang.GetWord("customer33");
            dgHistory.Columns[4].HeaderText = lang.GetWord("customer34");
            dgHistory.Columns[5].HeaderText = lang.GetWord("customer35");
            dgHistory.Columns[6].HeaderText = lang.GetWord("customer36");
            dgHistory.Columns[7].HeaderText = lang.GetWord("customer37");

            //personali
            dgPersonale.Columns[1].HeaderText = lang.GetWord("customer31");
            dgPersonale.Columns[2].HeaderText = lang.GetWord("customer32");
            dgPersonale.Columns[3].HeaderText = lang.GetWord("customer33");
            dgPersonale.Columns[4].HeaderText = lang.GetWord("customer34");
            dgPersonale.Columns[5].HeaderText = lang.GetWord("customer35");
            dgPersonale.Columns[6].HeaderText = lang.GetWord("customer36");
            dgPersonale.Columns[7].HeaderText = lang.GetWord("customer37");
            #endregion
            
            try
            {
                #region LOAD LISTINI
                Dictionary<int, string> dicListini = new Dictionary<int, string>();
                dicListini.Add(-1, "");

                DataTable dt = db.SQLQuerySelect("SELECT * FROM listino ORDER BY nome_listino");
                foreach (DataRow dr in dt.Rows)
                {
                    dicListini.Add(Convert.ToInt32(dr["id_list"].ToString()), dr["nome_listino"].ToString());
                }
                cmbListino.DataSource = new BindingSource(dicListini, null);
                cmbListino.DisplayMember = "Value";
                cmbListino.ValueMember = "Key";
                #endregion

                #region LOAD TIPO
                Dictionary<int, string> dicTipo = new Dictionary<int, string>();
                dicTipo.Add((int)Library.Data.Clienti.eClientiTipo.Privato, lang.GetWord("customer52"));
                dicTipo.Add((int)Library.Data.Clienti.eClientiTipo.Azienda, lang.GetWord("customer25"));
                cmbTipo.DataSource = new BindingSource(dicTipo, null);
                cmbTipo.DisplayMember = "Value";
                cmbTipo.ValueMember = "Key";
                cmbTipo.SelectedIndexChanged += new EventHandler(cmbTipo_SelectedIndexChanged);
                #endregion

                #region LOAD COUNTRY
                Dictionary<string, string> dicCountry = new Dictionary<string, string>();
                dt = db.SQLQuerySelect("SELECT * FROM regioni ORDER BY name");
                foreach (DataRow dr in dt.Rows)
                {
                    dicCountry.Add(dr["code"].ToString(), dr["name"].ToString() + " (" + dr["code"].ToString() + ")");
                }
                cmbCountry.DataSource = new BindingSource(dicCountry, null);
                cmbCountry.DisplayMember = "Value";
                cmbCountry.ValueMember = "Key";
                #endregion

                if (this.iIDCliente == -1)
                {
                    //NEW
                    cmbTipo.SelectedValue = (int)Library.Data.Clienti.eClientiTipo.Privato;
                    cmbCountry.SelectedValue = Library.Language.GetCountryCode();
                    tabCustomer.Controls.Remove(tabHistory);
                    tabCustomer.Controls.Remove(tabPersonali);
                }
                else
                {
                    //EDIT
                    TabPage tab = tabDetail;
                    tabCustomer.TabPages[0] = tabHistory;
                    tabCustomer.TabPages[1] = tabPersonali;
                    tabCustomer.TabPages[2] = tab;

                    #region general tab
                    string sql = "SELECT * FROM clienti WHERE id = " + this.iIDCliente;
                    dt = db.SQLQuerySelect(sql);
                    DataRow dr = dt.Rows[0];
                    txtName.Text = dr["nome"].ToString();
                    txtSurname.Text = dr["cognome"].ToString();
                    txtCompany.Text = dr["azienda"].ToString();
                    txtCustomerCode.Text = dr["barcode"].ToString();
                    txtAddress.Text = dr["indirizzo"].ToString();
                    txtCity.Text = dr["city"].ToString();
                    txtCap.Text = dr["cap"].ToString();
                    cmbCountry.SelectedValue = dr["country"].ToString();
                    txtPhone1.Text = dr["tel1"].ToString();
                    txtPhone2.Text = dr["tel2"].ToString();
                    txtFax.Text = dr["fax"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtVAT.Text = dr["partitaiva"].ToString();
                    txtNote.Text = dr["note"].ToString();

                    string sIDListino = dr["idlistino"].ToString();
                    if (sIDListino.Trim() != "")
                    {
                        cmbListino.SelectedValue = Convert.ToInt32(dr["idlistino"].ToString());
                    }
                    switch (dr["tipo"].ToString())
                    {
                        case "0":
                            {
                                cmbTipo.SelectedValue = (int)Library.Data.Clienti.eClientiTipo.Privato;
                                cmbTipo.Enabled = false;
                                label6.Visible = false;
                                break;
                            }
                        case "1":
                            {
                                cmbTipo.SelectedValue = (int)Library.Data.Clienti.eClientiTipo.Azienda;
                                cmbTipo.Enabled = false;
                                label6.Visible = false;
                                break;
                            }
                        default:
                            {
                                dicTipo = new Dictionary<int, string>();
                                dicTipo.Add((int)Library.Data.Clienti.eClientiTipo.Indefinito, "");
                                dicTipo.Add((int)Library.Data.Clienti.eClientiTipo.Privato, lang.GetWord("customer52"));
                                dicTipo.Add((int)Library.Data.Clienti.eClientiTipo.Azienda, lang.GetWord("customer25"));
                                cmbTipo.DataSource = new BindingSource(dicTipo, null);
                                cmbTipo.SelectedValue = (int)Library.Data.Clienti.eClientiTipo.Indefinito;
                                break;
                            }
                    }
                    #endregion

                    #region history tab
                    sql = "SELECT * FROM history WHERE idcliente = " + IDCliente + " ORDER BY dateformula DESC";
                    dt = db.SQLQuerySelect(sql);
                    int i = 0;
                    foreach (DataRow dr2 in dt.Rows)
                    {
                        dgHistory.Rows.Add();
                        dgHistory.Rows[i].Cells[0].Value = dr2["id"];
                        dgHistory.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr2["R"].ToString()), Convert.ToInt32(dr2["G"].ToString()), Convert.ToInt32(dr2["B"].ToString()));
                        dgHistory.Rows[i].Cells[2].Value = dr2["dateformula"];
                        dgHistory.Rows[i].Cells[3].Value = dr2["colorname"];
                        dgHistory.Rows[i].Cells[4].Value = dr2["formulasize"].ToString().Replace(".", ",").Replace("-", " ");
                        dgHistory.Rows[i].Cells[5].Value = dr2["system"];
                        dgHistory.Rows[i].Cells[6].Value = dr2["colorcharts"];
                        dgHistory.Rows[i].Cells[7].Value = dr2["use"];
                        i++;
                    }

                    foreach (DataGridViewRow row in dgHistory.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.ToolTipText = lang.GetWord("customer42");
                        }
                    }
                    dgHistory.ClearSelection();
                    #endregion

                    #region personali tab
                    sql = "SELECT * FROM formule_personali WHERE client_id = " + IDCliente + " ORDER BY dateformula DESC";
                    dt = db.SQLQuerySelect(sql);
                    i = 0;
                    foreach (DataRow dr3 in dt.Rows)
                    {
                        dgPersonale.Rows.Add();
                        dgPersonale.Rows[i].Cells[0].Value = dr3["idp"];
                        dgPersonale.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr3["R"].ToString()), Convert.ToInt32(dr3["G"].ToString()), Convert.ToInt32(dr3["B"].ToString()));
                        dgPersonale.Rows[i].Cells[2].Value = dr3["dateformula"];
                        dgPersonale.Rows[i].Cells[3].Value = dr3["colorname"];
                        dgPersonale.Rows[i].Cells[4].Value = dr3["formulasize"].ToString().Replace(".", ",").Replace("-", " ");
                        dgPersonale.Rows[i].Cells[5].Value = dr3["system"];
                        dgPersonale.Rows[i].Cells[6].Value = dr3["colorcharts"];
                        dgPersonale.Rows[i].Cells[7].Value = dr3["use"];
                        i++;
                    }

                    foreach (DataGridViewRow row in dgPersonale.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.ToolTipText = lang.GetWord("customer42");
                        }
                    }
                    dgPersonale.ClearSelection();
                    #endregion
                }

                //print
                if(!System.IO.File.Exists(Application.StartupPath + "\\template\\customer.docx"))
                {
                    btnPrint.Enabled = false;
                    btnPrint.Visible = false;
                }

                //event handler (data changed)
                txtName.TextChanged += new EventHandler(UserDataChanged);
                txtSurname.TextChanged += new EventHandler(UserDataChanged);
                txtCompany.TextChanged += new EventHandler(UserDataChanged);
                cmbListino.SelectedIndexChanged += new EventHandler(UserDataChanged);
                txtAddress.TextChanged += new EventHandler(UserDataChanged);
                txtPhone1.TextChanged += new EventHandler(UserDataChanged);
                txtPhone2.TextChanged += new EventHandler(UserDataChanged);
                txtFax.TextChanged += new EventHandler(UserDataChanged);
                txtEmail.TextChanged += new EventHandler(UserDataChanged);
                txtVAT.TextChanged += new EventHandler(UserDataChanged);
                txtCustomerCode.TextChanged += new EventHandler(UserDataChanged);
                txtNote.TextChanged += new EventHandler(UserDataChanged);
                cmbTipo.SelectedValueChanged += new EventHandler(UserDataChanged);
                cmbTipo_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserDataChanged(object sender, EventArgs e)
        {
            bModificato = true;
        }

        private void SaveCliente_Click(object sender, EventArgs e)
        {
            btnSalva.Enabled = false;
            SaveClienteExecute(true);
            btnSalva.Enabled = true;
        }

        private void frmNuovoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bModificato && page != ePage.view_client)
                {
                    DialogResult dialogResult = MessageBox.Show(lang.GetWord("save_message"), lang.GetWord("save_header"), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveClienteExecute(false);
                        page = ePage.view_client;
                    }
                }
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region FUNCTION
        private void ValidazioneInput()
        {
            object oTipo = cmbTipo.SelectedValue;
            object oCountry = cmbCountry.SelectedValue;
            if (oCountry == null) { throw new Exception(lang.GetWord("customer18")); }
            string sCountry = cmbCountry.SelectedValue.ToString();

            if (oTipo == null) throw new Exception(lang.GetWord("customer53"));

            switch ((Library.Data.Clienti.eClientiTipo)oTipo)
            {
                case Library.Data.Clienti.eClientiTipo.Privato:
                    {
                        if (txtName.Text.Trim() == "" || txtSurname.Text.Trim() == "") { throw new Exception(lang.GetWord("customer18")); }
                        break;
                    }
                case Library.Data.Clienti.eClientiTipo.Azienda:
                    {
                        if (txtCompany.Text.Trim() == "" ) { throw new Exception(lang.GetWord("customer18")); }
                        break;
                    }
                case Library.Data.Clienti.eClientiTipo.Indefinito:
                    {
                        throw new Exception(lang.GetWord("customer53"));
                    }
            }
            if (txtEmail.Text.Trim() != "" && !txtEmail.Text.Trim().Contains('@'))
            {
                txtEmail.Focus();
                throw new Exception(lang.GetWord("customer18"));
            }
        }
        private void SaveClienteExecute(bool bShowMessageOnSuccess)
        {
            try
            {
                ValidazioneInput();
                object oTipo = cmbTipo.SelectedValue;
                string sCountry = cmbCountry.SelectedValue.ToString();

                //listino
                string sIDListino = "-1";
                if (cmbListino.SelectedValue != null)
                {
                    sIDListino = cmbListino.SelectedValue.ToString();
                }

                Library.Data.Database.DBConnector db = new Library.Data.Database.DBConnector();

                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("nome", "'" + txtName.Text.Replace("'", "''").ToString() + "'");
                data.Add("cognome", "'" + txtSurname.Text.Replace("'", "''").ToString() + "'");
                data.Add("tipo", oTipo.ToString());
                data.Add("azienda", "'" + txtCompany.Text.Replace("'", "''").ToString() + "'");
                data.Add("barcode", txtCustomerCode.Text);
                data.Add("indirizzo", "'" + txtAddress.Text.Replace("'", "''").ToString() + "'");
                data.Add("city", "'" + txtCity.Text.Replace("'", "''").ToString() + "'");
                data.Add("cap", "'" + txtCap.Text.Replace("'", "''").ToString() + "'");
                data.Add("country", "'" + sCountry + "'");
                data.Add("tel1", "'" + txtPhone1.Text.Replace("'", "''").ToString() + "'");
                data.Add("tel2", "'" + txtPhone2.Text.Replace("'", "''").ToString() + "'");
                data.Add("fax", "'" + txtFax.Text.Replace("'", "''").ToString() + "'");
                data.Add("email", "'" + txtEmail.Text.Replace("'", "''").ToString() + "'");
                data.Add("partitaiva", "'" + txtVAT.Text.Replace("'", "''").ToString() + "'");
                data.Add("note", "'" + txtNote.Text.Replace("'", "''").ToString() + "'");
                data.Add("cloud", "'no'");
                data.Add("idlistino", sIDListino);

                if (this.iIDCliente == -1)
                {
                    data.Add("servertimesync", "0");
                    data.Add("deleted", "0");
                    data.Add("codef4", GVar.attivazioni.IDEuroFormulationInCloud);

                    object oIDClienteInserito = db.QueryInsert("clienti", data, "id");
                    if (db.LastQueryError != "") throw new Exception(db.LastQueryError);
                    if (oIDClienteInserito != null)
                    {
                        try
                        {
                            iIDCliente = Convert.ToInt32(oIDClienteInserito.ToString());
                        }catch (Exception) { }
                    }
                    if (bShowMessageOnSuccess) { MessageBox.Show(lang.GetWord("customer15"), lang.GetWord("customer14"), MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else
                {
                    Dictionary<string, object> data2 = new Dictionary<string, object>();
                    foreach (KeyValuePair<string, string> entry in data)
                    {
                        data2.Add(entry.Key, entry.Value);
                    }
                    data2.Add("servertimesync", "1");
                    data2.Add("lastupdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    db.QueryUpdate("clienti", data2, "id = " + this.iIDCliente);
                    if (db.LastQueryError != "") throw new Exception(db.LastQueryError);
                    if (bShowMessageOnSuccess) { MessageBox.Show(lang.GetWord("customer17"), lang.GetWord("customer16"), MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }

                db.CloseConnection();
                this.page = ePage.view_client;
                if (bShowMessageOnSuccess) { this.Close(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object oTipo = cmbTipo.SelectedValue;
                if (oTipo == null) return;

                switch (Convert.ToInt32(oTipo))
                {
                    case 0:
                        {
                            //privato
                            label12.Visible = false;
                            label7.Visible = false;
                            label19.Visible = false;
                            txtCompany.Enabled = false;
                            txtVAT.Enabled = false;
                            label14.Visible = true;
                            label16.Visible = true;
                            break;
                        }
                    case 1:
                        {
                            //azienda
                            label12.Visible = true;
                            label7.Visible = true;
                            label19.Visible = true;
                            txtCompany.Enabled = true;
                            txtVAT.Enabled = true;
                            label14.Visible = false;
                            label16.Visible = false;
                            break;
                        }
                    default:
                        {
                            label12.Visible = true;
                            label7.Visible = false;
                            label19.Visible = false;
                            txtCompany.Enabled = true;
                            txtVAT.Enabled = true;
                            label14.Visible = true;
                            label16.Visible = false;
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void KeyPressOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void dgPersonale_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgPersonale.SelectedRows.Count <= 0 && dgPersonale.SelectedRows.Count > 0) return;
                this.IDFORMULA_REQUEST = Convert.ToInt32(dgPersonale.SelectedRows[0].Cells[0].Value.ToString());
                this.page = ePage.formula_from_personali;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgHistory_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgHistory.SelectedRows.Count <= 0 && dgHistory.SelectedRows.Count > 0) return;
                this.IDFORMULA_REQUEST = Convert.ToInt32(dgHistory.SelectedRows[0].Cells[0].Value.ToString());
                this.page = ePage.formula_from_history;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}