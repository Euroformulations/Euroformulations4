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
using System.Diagnostics;
using System.IO;

namespace Euroformulations4.SubWindows.Costi
{
    public partial class frmColBase : Form
    {
        private Language lang = Language.GetInstance();
        private Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
        private Library.Data.Database.DBConnector db;
        private Dictionary<string, string> dicColRGB = new Dictionary<string, string>();

        public frmColBase()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        private void frmColBase_Load(object sender, EventArgs e)
        {
            groupBox2.Text = lang.GetWord("cost01");
            tabColoranti.Text = lang.GetWord("cost02");
            tabBasi.Text = lang.GetWord("cost03");
            dgColoranti.Columns[1].HeaderText = lang.GetWord("fper27");
            dgColoranti.Columns[2].HeaderText = lang.GetWord("cost04");
            dgColoranti.Columns[3].HeaderText = lang.GetWord("cost05");
            dgColoranti.Columns[4].HeaderText = lang.GetWord("cost06");

            gbUnit.Text = lang.GetWord("cost06");

            dgBasi.Columns[1].HeaderText = lang.GetWord("cost07");
            dgBasi.Columns[2].HeaderText = lang.GetWord("cost05");
            dgBasi.Columns[3].HeaderText = lang.GetWord("cost06");

            DataTable dt = db.SQLQuerySelect("SELECT nome_listino FROM listino");
            foreach (DataRow dr in dt.Rows)
            {
                ListPriceList.Items.Add(dr["nome_listino"].ToString());
            }

            dt = db.SQLQuerySelect("SELECT * FROM pigmenti");
            foreach (DataRow dr in dt.Rows)
            {
                if (!dicColRGB.ContainsKey(dr["fullname"].ToString()))
                {
                    dicColRGB.Add(dr["fullname"].ToString(), dr["pr"].ToString() + ";" + dr["pg"].ToString() + ";" + dr["pb"].ToString());
                }
            }

            dgColoranti.Columns[1].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;

            cmbUnita.Items.Add("L");
            cmbUnita.Items.Add("KG");
        }

        private void frmColBase_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ListPriceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListPriceList.Text.ToString().Length > 0)
            {
                dgColoranti.Rows.Clear();
                dgBasi.Rows.Clear();
                double costo_Tmp = 0;

                #region LETTURA ID LISTINO
                int ID_Listino = -1;
                string sql = "SELECT * FROM listino WHERE nome_listino = '" + ListPriceList.Text.Replace("'", "''") + "'";
                DataTable dt = db.SQLQuerySelect(sql);
                ID_Listino = Convert.ToInt32(dt.Rows[0]["id_list"].ToString());
                #endregion

                #region Lettura e popolamento DataGrid Pigmenti
                sql = "SELECT * FROM pig_costi WHERE id_listino = " + ID_Listino + " ORDER BY nome_pigmento";
                DataTable dt2 = db.SQLQuerySelect(sql);
                int i = 0;
                foreach (DataRow dr2 in dt2.Rows)
                {
                    costo_Tmp = Math.Round(Convert.ToDouble(dr2["costo"].ToString().Replace(",", "."), CultureInfo.InvariantCulture), Convert.ToInt32(sharedSettings.GetValue("DecimalNumber")));
                    dgColoranti.Rows.Add(dr2["id_pig_costi"].ToString(), "", dr2["nome_pigmento"].ToString(), costo_Tmp.ToString(), dr2["unita"].ToString());
                    try
                    {
                        if (dicColRGB.ContainsKey(dr2["nome_pigmento"].ToString()))
                        {
                            string[] sTernaRGB = dicColRGB[dr2["nome_pigmento"].ToString()].Split(';');

                            dgColoranti.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(
                                Convert.ToInt32(sTernaRGB[0]),
                                Convert.ToInt32(sTernaRGB[1]),
                                Convert.ToInt32(sTernaRGB[2])
                                );
                        }
                    }
                    catch (Exception) 
                    { 
                        dgColoranti.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.White; 
                    }

                    i++;
                }
                dgColoranti.ClearSelection();
                #endregion

                #region Lettura e popolamento DataGrid Basi
                sql = "SELECT * FROM base_costi WHERE id_listino = " + ID_Listino + " ORDER BY nome_base";
                DataTable dt3 = db.SQLQuerySelect(sql);
                foreach (DataRow dr3 in dt3.Rows)
                {
                    costo_Tmp = Math.Round(Convert.ToDouble(dr3["costo_base"].ToString().Replace(",", "."), CultureInfo.InvariantCulture), Convert.ToInt32(sharedSettings.GetValue("DecimalNumber")));
                    dgBasi.Rows.Add(dr3["id_base_costi"].ToString(), dr3["nome_base"].ToString(), costo_Tmp.ToString(), dr3["unita_base"].ToString());
                }
                dgBasi.ClearSelection();
                #endregion
                
                gbUnit.Enabled = true;
            }

        }

        private void DataGridp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateRow(dgColoranti, e.RowIndex, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridb_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateRow(dgBasi, e.RowIndex, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateRow(DataGridView dg, int rowIndex, bool bTabellaColoranti)
        {
            if (bTabellaColoranti)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("costo", dg.Rows[rowIndex].Cells[3].Value.ToString().Replace(',', '.').Replace("'", ""));
                data.Add("unita", dg.Rows[rowIndex].Cells[4].Value.ToString());
                db.QueryUpdate("pig_costi", data, "id_pig_costi = " + dg.Rows[rowIndex].Cells[0].Value);
            }
            else
            { 
                //basi
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("costo_base", dg.Rows[rowIndex].Cells[2].Value.ToString().Replace(',', '.').Replace("'", "''"));
                data.Add("unita_base", dg.Rows[rowIndex].Cells[3].Value.ToString());
                db.QueryUpdate("base_costi", data, "id_base_costi = " + dg.Rows[rowIndex].Cells[0].Value);
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

        private void cmbUnita_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabBasi)
                {
                    int i = 0;
                    foreach (DataGridViewRow row in dgBasi.Rows)
                    {
                        if (row.Cells[3].Value.ToString() != cmbUnita.SelectedItem.ToString())
                        {
                            row.Cells[3].Value = cmbUnita.SelectedItem.ToString();
                            UpdateRow(dgBasi, i, false);
                        }
                        i++;
                    }
                }
                else
                {
                    int i = 0;
                    foreach (DataGridViewRow row in dgColoranti.Rows)
                    {
                        if (row.Cells[4].Value.ToString() != cmbUnita.SelectedItem.ToString())
                        {
                            row.Cells[4].Value = cmbUnita.SelectedItem.ToString();
                            UpdateRow(dgColoranti, i, true);
                        }
                        i++;
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
