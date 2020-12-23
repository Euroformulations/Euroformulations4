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
using Npgsql;
using System.Globalization;

namespace Euroformulations4.SubWindows.FormulaSelection
{
    public partial class frmHistory : Form
    {
        private Library.Language lang = Library.Language.GetInstance();
        private Library.Data.Database.DBConnector db;
        private int iIDHHitory = -1;
        private ToolTip tp = new ToolTip();

        public frmHistory()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        public int IDHistory
        {
            get { return iIDHHitory; }
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            try
            {
                dgDati.Columns[1].HeaderText = lang.GetWord("formula11");
                dgDati.Columns[2].HeaderText = lang.GetWord("formula17");
                dgDati.Columns[3].HeaderText = lang.GetWord("formula12");
                dgDati.Columns[4].HeaderText = lang.GetWord("formula18");
                dgDati.Columns[5].HeaderText = lang.GetWord("formula13");
                dgDati.Columns[6].HeaderText = lang.GetWord("formula14");
                dgDati.Columns[7].HeaderText = lang.GetWord("formula15");
                dgDati.Columns[8].HeaderText = lang.GetWord("formula66");
                dgDati.Columns[8].Visible = Library.GVar.attivazioni.Act_RefillCustom;
                lblTitolo.Text = lang.GetWord("formula16");

                Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
                int iMaxRecords = Convert.ToInt32(sharedSettings.GetValue("HistoryView"));
                string sql = "Select * From history order by id DESC LIMIT " + iMaxRecords;
                System.Data.DataTable dt = db.SQLQuerySelect(sql);
                UpdateTable(dt);

                dgDati.Columns[1].DefaultCellStyle.SelectionBackColor = Color.Transparent;

                tp.SetToolTip(pbHelp, lang.GetWord("help01"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                dgDati.Rows[iRow].Cells[2].Value = DateTime.Parse(dr["dateformula"].ToString());
                dgDati.Rows[iRow].Cells[3].Value = dr["colorname"].ToString();
                dgDati.Rows[iRow].Cells[4].Value = dr["formulasize"].ToString().Replace(".", ",").Replace("-", " ");
                dgDati.Rows[iRow].Cells[5].Value = dr["system"].ToString();
                dgDati.Rows[iRow].Cells[6].Value = dr["colorcharts"].ToString();
                dgDati.Rows[iRow].Cells[7].Value = dr["use"].ToString();
                string sRefill = dr["riempimento"].ToString().Replace(",", ".");
                double dRefill = 100;
                if (sRefill.Trim() != "")
                {
                    dRefill = Convert.ToDouble(sRefill, CultureInfo.InvariantCulture);
                    dRefill *= 100;
                }
                dgDati.Rows[iRow].Cells[8].Value = ((int)dRefill).ToString();
                iRow++;
            }
            dgDati.ClearSelection();
        }

        private void dgDati_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgDati.SelectedRows.Count != 1) return;
                iIDHHitory = Convert.ToInt32(dgDati.SelectedRows[0].Cells[0].Value.ToString());
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

        private void frmHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception) { }
        }

    }
}
