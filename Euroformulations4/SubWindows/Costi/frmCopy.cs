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
using System.Globalization;

namespace Euroformulations4.SubWindows.Costi
{
    public partial class frmCopy : Form
    {
        private static Language lang = Language.GetInstance();
        private Library.Data.Database.DBConnector db;

        public frmCopy()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        private void frmCopy_Load(object sender, EventArgs e)
        {
            groupBox1.Text = lang.GetWord("copy01");
            label1.Text = lang.GetWord("copy02");
            label2.Text = lang.GetWord("copy03");
            label3.Text = lang.GetWord("copy04");
            label4.Text = lang.GetWord("copy05");
            label5.Text = lang.GetWord("copy06");
            CopyPriceList.Text = lang.GetWord("copy07");

            DataTable dt = db.SQLQuerySelect("SELECT nome_listino FROM listino");
            foreach (DataRow dr in dt.Rows)
            {
                string nomelistino = dr["nome_listino"].ToString();
                copiada.Items.Add(nomelistino);
                copiaa.Items.Add(nomelistino);
            }
        }

        private void frmCopy_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyPriceList_Click(object sender, EventArgs e)
        {
            try
            {
                CopyPriceList.Enabled = false;
                double costoTMP = 0;

                #region IDdestinazione e IDSORGENTE
                int IDDESTINAZIONE = -1;
                int IDSORGENTE = -1;

                string sql = "SELECT * FROM listino WHERE nome_listino ='" + copiada.Text + "'";
                DataTable dt = db.SQLQuerySelect(sql);
                IDSORGENTE = Convert.ToInt32(dt.Rows[0]["id_list"].ToString());

                sql = "SELECT * FROM listino WHERE nome_listino ='" + copiaa.Text + "'";
                dt = db.SQLQuerySelect(sql);
                IDDESTINAZIONE = Convert.ToInt32(dt.Rows[0]["id_list"].ToString());
                #endregion

                #region COPIA PIGMENTI
                if (txtcolorant.Text != "")
                {
                    sql = "SELECT * FROM pig_costi WHERE id_listino = " + IDSORGENTE;
                    DataTable dt2 = db.SQLQuerySelect(sql);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        costoTMP = Convert.ToDouble(dr2["costo"].ToString().Replace(",", "."), CultureInfo.InvariantCulture) + (Convert.ToDouble(dr2["costo"].ToString().Replace(",", "."), CultureInfo.InvariantCulture) * (Convert.ToDouble(txtcolorant.Text.Replace(",", "."), CultureInfo.InvariantCulture) / 100));
                        Dictionary<string, object> data = new Dictionary<string, object>();
                        data.Add("costo", costoTMP.ToString().Replace(",", "."));
                        data.Add("unita", dr2["unita"].ToString());
                        db.QueryUpdate("pig_costi", data, "nome_pigmento = '" + dr2["nome_pigmento"].ToString() + "' AND id_listino = " + IDDESTINAZIONE);
                    }
                }
                #endregion

                #region COPIA BASI
                if (txtbase.Text != "")
                {
                    sql = "SELECT * FROM base_costi WHERE id_listino = " + IDSORGENTE;
                    DataTable dt2 = db.SQLQuerySelect(sql);
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        costoTMP = Convert.ToDouble(dr2["costo_base"].ToString().Replace(",", "."), CultureInfo.InvariantCulture) + (Convert.ToDouble(dr2["costo_base"].ToString().Replace(",", "."), CultureInfo.InvariantCulture) * (Convert.ToDouble(txtbase.Text.Replace(",", "."), CultureInfo.InvariantCulture) / 100));
                        Dictionary<string, object> data = new Dictionary<string, object>();
                        data.Add("costo_base", costoTMP.ToString().Replace(",", "."));
                        data.Add("unita_base", dr2["unita_base"].ToString());
                        db.QueryUpdate("base_costi", data, "nome_base = '" + dr2["nome_base"].ToString() + "' AND id_listino = " + IDDESTINAZIONE);
                    }
                }
                #endregion

                #region COPIA LATTAGGI
                if (txtbase.Text != "")
                {
                    db.QueryDelete("lattaggi", "id_listino = " + IDDESTINAZIONE);

                    string sqlCopyLatte = "INSERT INTO lattaggi (barcode, nome_base_latt, lattaggio, unita_lattaggio, costo_lattaggio, riempimento, id_listino ) SELECT barcode, nome_base_latt, lattaggio, unita_lattaggio, costo_lattaggio + costo_lattaggio * " + txtbase.Text.Replace(",", ".") + " / 100, riempimento, " + IDDESTINAZIONE + " from lattaggi WHERE id_listino = " + IDSORGENTE;
                    db.SQLQuery_AffectedRows(sqlCopyLatte);
                }
                #endregion

                MessageBox.Show(lang.GetWord("copy09"), lang.GetWord("copy08"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region Azzero i controlli
                txtcolorant.Text = "";
                txtbase.Text = "";
                copiada.Text = "";
                copiaa.Text = "";
                CopyPriceList.Enabled = false;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(lang.GetWord("copy10") + " " + ex.Message, lang.GetWord("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                CopyPriceList.Enabled = true;
            }
        }

        private void copiaa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (copiada.Text.Length > 0)
            {
                if (copiaa.Text.Length > 0)
                {
                    txtcolorant.Enabled = true;
                    txtbase.Enabled = true;
                    CopyPriceList.Enabled = true;
                }
            }
        }

        private void txtcolorant_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Controllo solo numeri
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ',') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void txtbase_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Controllo solo numeri
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ',') && (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
            #endregion
        }

    }
}
