using Euroformulations4.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.Settings.Prodotti
{
    public partial class frmNewProduct : Form
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private Library.Data.Database.DBConnector db;
        private List<string> lstBasiUpper = new List<string>();

        public frmNewProduct()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        private void frmNewProduct_Load(object sender, EventArgs e)
        {
            try
            {
                #region TRADUZIONI
                this.Text = lang.GetWord("newproduct16");
                lblStep1.Text = lang.GetWord("newproduct03");
                lblStep2.Text = lang.GetWord("newproduct04");
                lblStep3.Text = lang.GetWord("newproduct05");
                dgDati.Columns[1].HeaderText = lang.GetWord("newproduct06");
                dgDati.Columns[2].HeaderText = lang.GetWord("newproduct07");
                btnSalva.Text = lang.GetWord("save");
                #endregion

                UpdateDTProdotti();

                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDTProdotti()
        {
            lstProdotti.Items.Clear();
            lstBasiUpper = new List<string>();

            DataTable dt = db.SQLQuerySelect("SELECT DISTINCT system FROM formule;");
            foreach (DataRow dr in dt.Rows)
            {
                lstProdotti.Items.Add(dr["system"].ToString());
            }

            dt = db.SQLQuerySelect("SELECT base FROM base;");
            foreach (DataRow dr in dt.Rows)
            {
                lstBasiUpper.Add(dr["base"].ToString().ToUpper());
            }
        }

        private void lstProdotti_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = true;
                dgDati.Rows.Clear();

                string sql = "SELECT DISTINCT base FROM formule WHERE system = '" + lstProdotti.Text + "';";
                DataTable dt = db.SQLQuerySelect(sql);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dgDati.Rows.Add();
                    dgDati.Rows[i].Cells[0].Value = dr["base"].ToString();
                    dgDati.Rows[i].Cells[1].Value = dr["base"].ToString();

                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDati_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgDati_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgDati_KeyPress);
            if (dgDati.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgDati_KeyPress);
                }
            }

        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                string sNuovoProdotto = txtNomeProdotto.Text.Trim();
                if (sNuovoProdotto == "") { throw new Exception(lang.GetWord("newproduct08")); }
                if (dgDati.Rows.Count == 0) { throw new Exception(lang.GetWord("newproduct09")); }

                foreach (var sOldProdotto in lstProdotti.Items)
                {
                    if (sOldProdotto.ToString().Trim().ToUpper() == sNuovoProdotto.ToUpper()) { throw new Exception(lang.GetWord("newproduct10")); }
                }

                int i = 0;
                string[] vBasiNew = new string[dgDati.Rows.Count];
                string[] vOldBasi = new string[dgDati.Rows.Count];
                double[] vDensitaNew = new double[dgDati.Rows.Count];

                foreach (DataGridViewRow row in this.dgDati.Rows)
                {
                    try
                    {
                        string sNomeBase = row.Cells[1].Value.ToString().Trim();
                        double dDensita = Convert.ToDouble(row.Cells[2].Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                        //verificare base nuova
                        if (lstBasiUpper.Contains(sNomeBase.ToUpper())) { throw new Exception(sNomeBase + " " + lang.GetWord("newproduct13")); }

                        vBasiNew[i] = sNomeBase;
                        vOldBasi[i] = row.Cells[0].Value.ToString().Trim();
                        vDensitaNew[i] = dDensita;
                    }
                    catch (Exception)
                    {
                        throw new Exception(lang.GetWord("newproduct11") + " " + (i + 1));
                    }

                    i++;
                }

                //1 - inserimento nuove basi
                for (int j = 0; j < vBasiNew.Length; j++ )
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("base", vBasiNew[j]);
                    data.Add("density", vDensitaNew[j].ToString().Replace(",", "."));
                    data.Add("fcbase", "1");
                    data.Add("deletable", "1");

                    db.QueryInsert("base", data);
                }

                //2 - CLONA LE FORMULE DEL VECCHIO PRODOTTO (AGGIORNANDO CON NUOVO NOME PRODOTTO)
                string sqlClone = "INSERT INTO formule (de, decmc, nw, template, dateformula, notetxt, colorname, base, unit, oncetype, formulasize, p1, q1, p2, q2, p3, q3, p4, q4, p5, q5, colorcharts, system, use, r, g, b, ciel, ciea, cieb, hvalue, cvalue, ciel_cubecc, ciea_cubecc, cieb_cubecc) "
                + "SELECT de, decmc, nw, template, dateformula, notetxt, colorname, base, unit, oncetype, formulasize, p1, q1, p2, q2, p3, q3, p4, q4, p5, q5, colorcharts,'" + sNuovoProdotto.Replace("'", "''") + "', use, r, g, b, ciel, ciea, cieb, hvalue, cvalue, ciel_cubecc, ciea_cubecc, cieb_cubecc FROM formule WHERE system = '" + lstProdotti.Text.Replace("'", "''") + "'";
                db.SQLQuery_AffectedRows(sqlClone);
                if (db.LastQueryError != "") { throw new Exception(db.LastQueryError); }

                //3 - UPD FORMULE DEL NUOVO PRODOTTO CON LE BASI NUOVE
                for (int j = 0; j < vBasiNew.Length; j++)
                {
                    Dictionary<string, object> data = new Dictionary<string,object>();
                    data.Add("base", vBasiNew[j]);
                    GVar.ListaBasi.Add(vBasiNew[j]);
                    db.QueryUpdate("formule", data, "base = '"+ vOldBasi[j].Replace("'", "''") +"' AND system = '"+ sNuovoProdotto.Replace("'", "''") +"'");
                }

                //4 - PER OGNI LISTINO: AGGIORNA LISTINI
                DataTable dt = db.SQLQuerySelect("SELECT id_list FROM listino;");
                foreach (DataRow dr in dt.Rows)
                {
                    string sIDListino = dr["id_list"].ToString();
                    for (int j = 0; j < vBasiNew.Length; j++)
                    {
                        Dictionary<string, object> data = new Dictionary<string, object>();
                        data.Add("nome_base", vBasiNew[j]);
                        data.Add("costo_base", "0");
                        data.Add("unita_base", "L");
                        data.Add("id_listino", sIDListino);

                        db.QueryInsert("base_costi", data);
                    }
                }

                MessageBox.Show(sNuovoProdotto + " " + lang.GetWord("newproduct12"));

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmNewProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Library.Formulation.Formula.ResetStaticData();
                if (db != null) { db.CloseConnection(); }
            }
            catch (Exception)
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT base, deletable FROM base WHERE base IN ( SELECT DISTINCT base FROM formule WHERE system = '" + lstProdotti.Text + "');";
                DataTable dt = db.SQLQuerySelect(sql);
                bool bDeletable = true;
                List<string> lstBasi = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    bDeletable = bDeletable && (dr["deletable"].ToString() == "1");
                    lstBasi.Add(dr["base"].ToString());
                }

                if (!bDeletable) { throw new Exception(lang.GetWord("settings97")); }

                DialogResult dialogResult = MessageBox.Show(lang.GetWord("customer39") + " " + lstProdotti.Text + " ?", lang.GetWord("quality61"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes){ return; }

                foreach (string sBase in lstBasi)
                {
                    string sErrors = "";
                    db.QueryDelete("base", "base = '" + sBase + "'"); sErrors += db.LastQueryError;
                    db.QueryDelete("base_costi", "nome_base = '" + sBase + "'"); sErrors += db.LastQueryError;
                    db.QueryDelete("fcpig", "basi = '" + sBase + "'"); sErrors += db.LastQueryError;
                    db.QueryDelete("formule", "base = '" + sBase + "'"); sErrors += db.LastQueryError;
                    db.QueryDelete("formule_personali", "base = '" + sBase + "'"); sErrors += db.LastQueryError;
                    db.QueryDelete("history", "base = '" + sBase + "'"); sErrors += db.LastQueryError;
                    db.QueryDelete("lattaggi", "nome_base_latt = '" + sBase + "'"); sErrors += db.LastQueryError;

                    if (sErrors != "")
                    {
                        MessageBox.Show("Error: " + sErrors);
                    }
                }

                dgDati.Rows.Clear();
                txtNomeProdotto.Text = "";
                UpdateDTProdotti();
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

    }
}
