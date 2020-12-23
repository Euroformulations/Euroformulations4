using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.Settings.FattoriCorrettivi
{
    public partial class frmFattoreCorrettivo : Form
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private Library.Data.Database.DBConnector db = null;
        private Color colBack, colFore;
        public frmFattoreCorrettivo()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        private void frmFattoreCorrettivo_Load(object sender, EventArgs e)
        {
            try
            {
                #region TRADUZIONI
                this.Text = lang.GetWord("fcor01");
                tabBasi.Text = lang.GetWord("stat06");
                tabColoranti.Text = lang.GetWord("stat02");
                dgBasi.Columns[0].HeaderText = lang.GetWord("fcor04");
                dgBasi.Columns[1].HeaderText = lang.GetWord("fcor01").ToLower();
                label2.Text = lang.GetWord("fcor02");
                label1.Text = lang.GetWord("fcor03");
                dgColoranti.Columns[0].HeaderText = lang.GetWord("fcor04");
                dgColoranti.Columns[1].HeaderText = lang.GetWord("fcor05");
                dgColoranti.Columns[2].HeaderText = lang.GetWord("fcor01").ToLower();
                btnAdd.Text = lang.GetWord("cost11");
                btnDelete.Text = lang.GetWord("cost12");
                ToolTip toolTipSelected = new ToolTip();
                toolTipSelected.SetToolTip(this.pbHelp, lang.GetWord("newproduct14"));
                toolTipSelected.SetToolTip(this.pbColHelp, lang.GetWord("newproduct14"));
                lblBaseStep1.Text = lang.GetWord("newproduct15");
                lblColStep3.Text = lang.GetWord("fcor09");
                #endregion
                
                //tab basi
                #region LETTURA FATTORI CORRETTIVI DELLE BASI
                DataTable dt = db.SQLQuerySelect("SELECT base, fcbase FROM base ORDER BY base;");
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dgBasi.Rows.Add();
                    dgBasi.Rows[i].Cells[0].Value = dr["base"].ToString();
                    lstBase.Items.Add(dr["base"].ToString());
                    dgBasi.Rows[i].Cells[1].Value = dr["fcbase"].ToString();
                    i++;
                }
                #endregion

                #region LETTURA E SALVATAGGIO SU ColoranteCodeFull DEL CODICE E DEL NOME COMPLETO DEI COLORANTI
                DataTable dtp = db.SQLQuerySelect("SELECT fullname,code FROM pigmenti;");
                foreach (DataRow dr in dtp.Rows)
                {
                    ColoranteCodeFull colorante = new ColoranteCodeFull();
                    colorante.fullname = dr["fullname"].ToString();
                    colorante.codename = dr["code"].ToString();
                    lstColorant.Items.Add(colorante);
                }
                #endregion

                #region LETTURA FATTORI CORRETTIVI DEI COLORANTI GIA' PRESENTI NEL DATABASE
                string fullname = "";
                DataTable fcpig = db.SQLQuerySelect("SELECT * FROM fcpig;");
                foreach (DataRow dr in fcpig.Rows)
                {
                    DataTable cfullname = db.SQLQuerySelect("SELECT fullname FROM pigmenti WHERE code = '" + dr["coloranti"].ToString() + "';");
                    foreach (DataRow drc in cfullname.Rows)
                    {
                        fullname = drc["fullname"].ToString();
                    }

                    dgColoranti.Rows.Add(dr["basi"].ToString(), fullname, dr["fcor"].ToString(), dr["coloranti"].ToString());
                }
                #endregion                
                
                colBack = dgColoranti.DefaultCellStyle.SelectionBackColor;
                colFore = dgColoranti.DefaultCellStyle.SelectionForeColor;
                dgColoranti.DefaultCellStyle.SelectionBackColor = dgColoranti.DefaultCellStyle.BackColor;
                dgColoranti.DefaultCellStyle.SelectionForeColor = dgColoranti.DefaultCellStyle.ForeColor;

                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmFattoreCorrettivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Library.Formulation.Formula.ResetStaticData();
                if (db != null) { db.CloseConnection(); }
            }
            catch (Exception)
            {}
        }

        private void dgDati_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgDati_KeyPress);
            if (dgBasi.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgDati_KeyPress);
                }
            }
        }

        private void dgColoranti_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgDati_KeyPress);
            if (dgColoranti.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgDati_KeyPress);
                }
            }
        }

        private void dgDati_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBase.Text.Length > 0 && lstColorant.Text.Length > 0)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void txtColorant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBase.Text.Length > 0 && lstColorant.Text.Length > 0)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool ControlloAssociazione = true;

            #region CONTROLLO CHE NON ESISTA GIA' UNA COMBINAZIONE
            for (int y = 0; y < dgColoranti.Rows.Count; y++)
            {
                string Associazione = dgColoranti.Rows[y].Cells[0].Value.ToString() + dgColoranti.Rows[y].Cells[1].Value.ToString();
                string ControlloString = lstBase.Text + lstColorant.Text;
                if (Associazione == ControlloString)
                {
                    ControlloAssociazione = false;
                }
            }
            #endregion

            if (ControlloAssociazione == true )
            {
                ColoranteCodeFull colorante = (ColoranteCodeFull)lstColorant.SelectedItem;
                dgColoranti.Rows.Add(lstBase.Text.ToString(), colorante.fullname, 1, colorante.codename);
                Dictionary<string, string> dicData = new Dictionary<string, string>();
                dicData.Add("basi",lstBase.Text.ToString());
                dicData.Add("coloranti", colorante.codename);
                dicData.Add("fcor", "1");
                db.QueryInsert("fcpig", dicData);
            }
            else
            {
                MessageBox.Show(lang.GetWord("fcor08"));
            }
        }

        private void dgBasi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                double densita = Convert.ToDouble(dgBasi.Rows[rowIndex].Cells[1].Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("fcbase", densita.ToString().Replace(',', '.'));

                db.QueryUpdate("base", data, "base = '" + dgBasi.Rows[rowIndex].Cells[0].Value.ToString() + "'");
                if (db.LastQueryError != "") { throw new Exception(db.LastQueryError); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        class ColoranteCodeFull
        {
            public string fullname = "";
            public string codename = "";

            public override string ToString()
            {
                return fullname;
            }
        }

        private void dgColoranti_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                double FcColoranti = Convert.ToDouble(dgColoranti.Rows[rowIndex].Cells[2].Value.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("fcor", FcColoranti.ToString().Replace(',', '.'));

                db.QueryUpdate("fcpig", data, "basi = '" + dgColoranti.Rows[rowIndex].Cells[0].Value.ToString() + "' and coloranti = '" + dgColoranti.Rows[rowIndex].Cells[3].Value.ToString() + "'");
                if (db.LastQueryError != "") { throw new Exception(db.LastQueryError); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgColoranti.SelectedRows.Count > 0)
            {
                int Row =dgColoranti.CurrentRow.Index;
                db.QueryDelete("fcpig", "basi = '" + dgColoranti.Rows[Row].Cells[0].Value.ToString() + "' and coloranti = '" + dgColoranti.Rows[Row].Cells[3].Value.ToString() + "'");
                dgColoranti.Rows.RemoveAt(dgColoranti.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show(lang.GetWord("settings96"));
            }
        }

        private void dgColoranti_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgColoranti.DefaultCellStyle.SelectionBackColor = colBack;
            dgColoranti.DefaultCellStyle.SelectionForeColor = colFore;
            if (dgColoranti.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
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
