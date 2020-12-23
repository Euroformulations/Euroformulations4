using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Euroformulations4.Library;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace Euroformulations4.SubWindows.Costi
{
    public partial class frmLattaggi : Form
    {
        private Language lang = Language.GetInstance();
        private Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
        Library.Data.Database.DBConnect_Npgsql dbc;
        NpgsqlDataReader risultatiole;

        public frmLattaggi()
        {
            InitializeComponent();
            dbc = new Library.Data.Database.DBConnect_Npgsql();
            dbc.connect(Library.GVar.Database);
        }

        private void frmLattaggi_Load(object sender, EventArgs e)
        {
            label2.Text = lang.GetWord("cost08");
            label1.Text = lang.GetWord("cost09");
            label3.Text = lang.GetWord("cost10");
            lblWarning.Text = lang.GetWord("cost39");
            btnAdd.Text = lang.GetWord("cost11");
            btnDelete.Text = lang.GetWord("cost12");
            dgLattaggi.Columns[2].HeaderText = lang.GetWord("cost13");
            dgLattaggi.Columns[3].HeaderText = lang.GetWord("cost14");
            dgLattaggi.Columns[4].HeaderText = lang.GetWord("cost06");
            dgLattaggi.Columns[5].HeaderText = lang.GetWord("cost05");
            dgLattaggi.Columns[6].HeaderText = lang.GetWord("formula66");
            dgLattaggi.Columns[6].Visible = GVar.attivazioni.Act_RefillCustom;
            dgLattaggi.Columns[7].HeaderText = lang.GetWord("cost37");
            dgLattaggi.Columns[7].Visible = GVar.attivazioni.Act_Barcode;
            

            #region Lettura listini già inseriti
            string sQuery = "SELECT * FROM listino ORDER BY id_list LIMIT 1";
            if (GVar.attivazioni.Act_ListiniUnlimited)
            {
                sQuery = "SELECT * FROM listino ORDER BY nome_listino";
            }
            dbc.sqlview_ErrorSafe(sQuery, ref risultatiole);
            while (risultatiole.Read())
            {
                lstPriceList.Items.Add(risultatiole["nome_listino"].ToString());
            }
            risultatiole.Close();
            #endregion

            #region POPOLANDO COMBOBOX BASE
            for (int i = 0; i < GVar.ListaBasi.Count; i++)
            {
                lstBasePaint.Items.Add(GVar.ListaBasi[i]);
            }
            #endregion
            
            SetButtonColor(btnAdd);
            SetButtonColor(btnDelete);
        }

        private void frmLattaggi_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbc.disconnect();
        }

        private void ListPriceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBasePaint.SelectedIndex = -1;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;

            if (lstPriceList.Text.ToString().Length > 0)
            {
                lstBasePaint.Enabled = true;
            }
        }

        private void listBasePaint_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgLattaggi.Rows.Clear();
            double costo_Tmp = 0;

            #region Lettura id listino
            int ID_LISTINO = -1;
            dbc.sqlview_ErrorSafe("SELECT * FROM listino WHERE nome_listino = '" + lstPriceList.Text.Replace("'","''") + "'", ref risultatiole);
            risultatiole.Read();
            ID_LISTINO = Convert.ToInt32(risultatiole["id_list"].ToString());
            risultatiole.Close();
            #endregion

            dbc.sqlview_ErrorSafe("SELECT * FROM lattaggi WHERE id_listino = " + ID_LISTINO + " and nome_base_latt = '" + lstBasePaint.Text + "' order by lattaggio", ref risultatiole);
            while (risultatiole.Read())
            {
                costo_Tmp = Math.Round(Convert.ToDouble(risultatiole["costo_lattaggio"].ToString().Replace(",", "."), CultureInfo.InvariantCulture), Convert.ToInt32(sharedSettings.GetValue("DecimalNumber")));
                string sRefill = risultatiole["riempimento"].ToString().Replace(",", ".");
                double dRefill = 100;
                if(sRefill.Trim() != "")
                {
                    dRefill = Convert.ToDouble(sRefill, CultureInfo.InvariantCulture);
                    dRefill *= 100;
                }
                dgLattaggi.Rows.Add(ID_LISTINO, Convert.ToInt32(risultatiole["id_lattaggi"].ToString()), risultatiole["nome_base_latt"].ToString(), risultatiole["lattaggio"].ToString(), risultatiole["unita_lattaggio"].ToString(), costo_Tmp.ToString(), dRefill.ToString(), risultatiole["barcode"].ToString());
            }
            risultatiole.Close();

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void AddPriceList_Click(object sender, EventArgs e)
        {
            #region Lettura id listino
            int ID_LISTINO = -1;
            dbc.sqlview_ErrorSafe("SELECT * FROM listino WHERE nome_listino = '" + lstPriceList.Text.Replace("'","''") + "'", ref risultatiole);
            risultatiole.Read();
            ID_LISTINO = Convert.ToInt32(risultatiole["id_list"].ToString());
            risultatiole.Close();
            #endregion

            #region AGGIUNTA E RECUPERO ID LATTAGGIO
            if (ID_LISTINO > -1)
            {
                string Sql = null;
                int ID_LATTAGGIO = -1;
                Sql = "INSERT INTO lattaggi (nome_base_latt, id_listino, lattaggio, unita_lattaggio, costo_lattaggio, riempimento) VALUES ('" + lstBasePaint.Text + "'," + ID_LISTINO + ", 0, 'L', 0, 1 )";
                dbc.SQLExe(Sql);
                dbc.sqlview_ErrorSafe("SELECT MAX(id_lattaggi) as IDMAX FROM lattaggi", ref risultatiole);
                risultatiole.Read();
                ID_LATTAGGIO = Convert.ToInt32(risultatiole["IDMAX"].ToString());
                risultatiole.Close();

                if (ID_LATTAGGIO > -1)
                {
                    dgLattaggi.Rows.Add(ID_LISTINO, ID_LATTAGGIO, lstBasePaint.Text, 0, "L", 0 , 100);
                }
            }
            #endregion
        }

        private void Dglattaggi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sBarCode = "";
                if (dgLattaggi.Rows[e.RowIndex].Cells[7].Value != null)
                {
                    sBarCode = dgLattaggi.Rows[e.RowIndex].Cells[7].Value.ToString();
                }
                double dRefill = 1d;
                string sRefill = dgLattaggi.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                if (sRefill != "")
                {
                    dRefill = Convert.ToDouble(sRefill.Replace(",", "."), CultureInfo.InvariantCulture);
                    if (dRefill < 1d || dRefill > 200d) { throw new Exception(lang.GetWord("cost16")); }
                    dRefill = dRefill / 100d;
                }

                dbc.SQLExe_ErrorSafe("UPDATE lattaggi SET lattaggio = " + dgLattaggi.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(',', '.').Replace("'", "") + " , unita_lattaggio = '" + dgLattaggi.Rows[e.RowIndex].Cells[4].Value.ToString() + "', costo_lattaggio = " + dgLattaggi.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(',', '.') + ", riempimento = " + dRefill.ToString().Replace(',', '.') + ", barcode = '" + sBarCode + "' WHERE id_lattaggi = " + dgLattaggi.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(',', '.'));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletePriceList_Click(object sender, EventArgs e)
        {
            if (dgLattaggi.SelectedCells.Count > 0)
            {
                int rowIndex = dgLattaggi.SelectedCells[0].RowIndex;

                DialogResult dialogResult = MessageBox.Show(lang.GetWord("cost18") + " " + dgLattaggi.Rows[rowIndex].Cells[3].Value.ToString() + " " + dgLattaggi.Rows[rowIndex].Cells[4].Value.ToString() + "?", lang.GetWord("cost17"), MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        dbc.SQLExe("DELETE FROM lattaggi WHERE id_lattaggi = " + dgLattaggi.Rows[rowIndex].Cells[1].Value.ToString());
                        dgLattaggi.Rows.RemoveAt(rowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(lang.GetWord("cost19") + " " + ex.Message);
                    }
                }
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
