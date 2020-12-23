using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Euroformulations4.SubWindows.FormulaSelection
{
    public partial class frmFormulaSearch : Form
    {
        private Library.Language lang = Library.Language.GetInstance();
        private Library.Data.Database.DBConnector db;
        private int iIDFormula = -1;
        private ToolTip tp = new ToolTip();

        public frmFormulaSearch()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        public int IDFormulaSelected
        {
            get { return iIDFormula; }
        }

        private void frmFormulaSearch_Load(object sender, EventArgs e)
        {
            #region Traduzioni
            groupColorName.Text = lang.GetWord("formula12");
            groupProduct.Text = lang.GetWord("formula13");
            groupColorcharts.Text = lang.GetWord("formula14");
            groupUse.Text = lang.GetWord("formula15");
            btnSearch.Text = lang.GetWord("formula10");
            dgDati.Columns[1].HeaderText = lang.GetWord("formula11");
            dgDati.Columns[2].HeaderText = lang.GetWord("formula12");
            dgDati.Columns[3].HeaderText = lang.GetWord("formula13");
            dgDati.Columns[4].HeaderText = lang.GetWord("formula14");
            dgDati.Columns[5].HeaderText = lang.GetWord("formula15");
            #endregion

            dgDati.Columns[1].DefaultCellStyle.SelectionBackColor = Color.Transparent;

            #region Load Combo Filtri
            System.Data.DataTable dt = db.SQLQuerySelect("SELECT DISTINCT(system) as PRODUCT, ordersystem FROM formule ORDER BY ordersystem, system");
            cmbProduct.Items.Add("");
            foreach (DataRow dr in dt.Rows)
            {
                cmbProduct.Items.Add(dr["PRODUCT"].ToString());
            }

            dt = db.SQLQuerySelect("SELECT DISTINCT(colorcharts) as CHARTS FROM formule ORDER BY CHARTS");
            cmbColorCharts.Items.Add("");
            foreach (DataRow dr in dt.Rows)
            {
                cmbColorCharts.Items.Add(dr["CHARTS"].ToString());
            }

            dt = db.SQLQuerySelect("SELECT DISTINCT(use) as INTEXT FROM formule");
            cmbUse.Items.Add("");
            foreach (DataRow dr in dt.Rows)
            {
                cmbUse.Items.Add(dr["INTEXT"].ToString());
            }

            #endregion

            tp.SetToolTip(pbHelp, lang.GetWord("help01"));
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                picWait.Visible = true;
                btnSearch.Enabled = false;
                dgDati.Visible = false;

                #region GET Data from Filtri
                string sColor = txtColor.Text;
                string sProduct = cmbProduct.Text;
                string sColorCharts = cmbColorCharts.Text;
                string sUse = cmbUse.Text;
                #endregion

                #region Query
                if (sColor.Trim() != "" || sProduct.Trim() != "" || sColorCharts.Trim() != "" || sUse.Trim() != "")
                {
                    string sql = "SELECT * FROM formule where LOWER(colorname) LIKE '%" + sColor.ToLower() + "%'";
                    if (sProduct.Trim() != "") { sql += " AND system = '" + sProduct + "'"; }
                    if (sColorCharts.Trim() != "") { sql += " AND colorcharts = '" + sColorCharts + "'"; }
                    if (sUse.Trim() != "") { sql += " AND use = '" + sUse + "'"; }
                    System.Data.DataTable dt = db.SQLQuerySelect(sql);
                    UpdateTable(dt);

                    if (dgDati.RowCount > 1)
                    {
                        //dgDati.Focus();
                        this.ActiveControl = dgDati;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dgDati.Visible = true;
                btnSearch.Enabled = true;
                picWait.Visible = false;
            }
        }

        private void UpdateTable(DataTable dt)
        {
            dgDati.Rows.Clear();
            int iRow = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dgDati.Rows.Add();
                dgDati.Rows[iRow].Cells[0].Value = dr["id"].ToString();
                dgDati.Rows[iRow].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["R"].ToString()), Convert.ToInt32(dr["G"].ToString()), Convert.ToInt32(dr["B"].ToString()));
                dgDati.Rows[iRow].Cells[2].Value = dr["colorname"].ToString();
                dgDati.Rows[iRow].Cells[3].Value = dr["system"].ToString();
                dgDati.Rows[iRow].Cells[4].Value = dr["colorcharts"].ToString();
                dgDati.Rows[iRow].Cells[5].Value = dr["use"].ToString();
                dgDati.Rows[iRow].Cells[6].Value = dr["base"].ToString();
                dgDati.Rows[iRow].Cells[7].Value = dr["R"].ToString();
                dgDati.Rows[iRow].Cells[8].Value = dr["G"].ToString();
                dgDati.Rows[iRow].Cells[9].Value = dr["B"].ToString();
                iRow++;
            }
            dgDati.ClearSelection();
        }

        private void dgDati_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgDati.SelectedRows.Count != 1) return;
                iIDFormula = Convert.ToInt32(dgDati.SelectedRows[0].Cells[0].Value.ToString());
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDati_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgDati_CellDoubleClick(null, null);
            }
        }
        private void searchcolor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                Search_Click(null, null);
                txtColor.Text = txtColor.Text.Replace(Environment.NewLine, "");
                if (dgDati.RowCount > 1)
                {
                    dgDati.Focus();
                }
            }
        }

        private void frmFormulaSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception) { }
        }

        private void Groupbox_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
