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
    public partial class frmOrders : Form
    {
        Library.Data.Database.DBConnector db;
        private static Library.Language lang;
        Library.Email email;
        private bool bEnableEvent;
        private int _idformulaRequest = -1;
        
        public frmOrders()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
            lang = Library.Language.GetInstance();
            bEnableEvent = false;
            email = null;
        }

        public int Request_IDFormula { get { return _idformulaRequest; } }

        #region EVENTS
        private void frmOrders_Load(object sender, EventArgs e)
        {
            try
            {
                //traduzioni
                dgEmail.Columns[1].HeaderText = lang.GetWord("email01");
                dgEmail.Columns[2].HeaderText = lang.GetWord("email02");
                dgOrdini.Columns[1].HeaderText = lang.GetWord("email03");
                dgOrdini.Columns[2].HeaderText = lang.GetWord("email04");
                dgOrdini.Columns[3].HeaderText = lang.GetWord("email05");
                gbOggetto.Text = lang.GetWord("email06");
                gbCorpo.Text = lang.GetWord("email07");
                gbColorInfo.Text = lang.GetWord("email08");
                lblCColori.Text = lang.GetWord("formula14") + " :";
                lblColor.Text = lang.GetWord("formula12") + " :";
                lblProdotto.Text = lang.GetWord("formula13") + " :";
                lblUso.Text = lang.GetWord("formula15") + " :";

                deleteEmailToolStripMenuItem.Text = lang.GetWord("email10");
                markAsDispensedToolStripMenuItem.Text = lang.GetWord("email09");

                dgEmail.Rows.Clear();
                List<Library.Email> mailbox = Library.Email.GetEmail(db);
                int i = 0;

                foreach (Library.Email mail in mailbox)
                {
                    dgEmail.Rows.Add();
                    dgEmail.Rows[i].Cells[0].Value = mail.ID;
                    dgEmail.Rows[i].Cells[1].Value = mail.Mittente;
                    dgEmail.Rows[i].Cells[2].Value = mail.DataOra.ToString();
                    if (mail.Executed)
                    {
                        dgEmail.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                    }

                    i++;
                }
                dgEmail.ClearSelection();
                
                SetOrderOptionsEnabled(false);
                SetEmailOptionsEnabled(false);
                bEnableEvent = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (db != null) { db.CloseConnection(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgEmail_SelectionChanged(object sender, EventArgs e)
        {
            if (!bEnableEvent) { return; }
            bEnableEvent = false;
            try
            {
                if (dgEmail.SelectedRows.Count == 0) { return; }
                int idEmail = Convert.ToInt32(dgEmail.SelectedRows[0].Cells[0].Value.ToString());
                email = new Library.Email(idEmail);
                txtOggetto.Text = email.Oggetto;
                txtCorpo.Text = email.Corpo;

                //update orders table
                dgOrdini.Rows.Clear();
                int i = 0;
                foreach (Library.Ordine ordine in email.Ordini)
                {
                    dgOrdini.Rows.Add();
                    dgOrdini.Rows[i].Cells[0].Value = ordine.ID;
                    if (ordine.Executed)
                    {
                        dgOrdini.Rows[i].Cells[1].Value = (System.Drawing.Image)Properties.Resources.circle_green;
                    }
                    else if (ordine.ReadyToDispense)
                    {
                        dgOrdini.Rows[i].Cells[1].Value = (System.Drawing.Image)Properties.Resources.circle_orange;
                    }
                    else
                    {
                        dgOrdini.Rows[i].Cells[1].Value = (System.Drawing.Image)Properties.Resources.circle_32;
                    }

                    dgOrdini.Rows[i].Cells[2].Value = "(" + ordine.CIEL + ", " + ordine.CIEa + ", " + ordine.CIEb + ")";
                    dgOrdini.Rows[i].Cells[3].Value = ordine.Destinazione;

                    double[] xyz = Library.Colore.LAB_XYZ(ordine.CIEL, ordine.CIEa, ordine.CIEb);
                    double[] rgb = Library.Colore.XYZ_RGB(xyz[0], xyz[1], xyz[2]);
                    dgOrdini.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.FromArgb((int)rgb[0], (int)rgb[1], (int)rgb[2]);
                    i++;
                }
                dgOrdini.ClearSelection();

                //reset details
                lblCColori.Text = lang.GetWord("formula14") + " :" ;
                lblColor.Text = lang.GetWord("formula12") + " :";
                lblProdotto.Text = lang.GetWord("formula13") + " :";
                lblUso.Text = lang.GetWord("formula15") + " :";

                SetOrderOptionsEnabled(false);
                SetEmailOptionsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bEnableEvent = true;
            }
        }
        private void dgOrdini_SelectionChanged(object sender, EventArgs e)
        {
            if (!bEnableEvent) { return; }
            bEnableEvent = false;
            try
            {
                if (dgOrdini.SelectedRows.Count == 0) { return; }
                int idOrdine = Convert.ToInt32(dgOrdini.SelectedRows[0].Cells[0].Value.ToString());

                Library.Ordine ordine = new Library.Ordine(idOrdine);

                lblCColori.Text = lang.GetWord("formula14") + " : " + ordine.CColori;
                lblColor.Text = lang.GetWord("formula12") + " : " + ordine.Tinta;
                lblProdotto.Text = lang.GetWord("formula13") + " : " + ordine.Prodotto;
                lblUso.Text = lang.GetWord("formula15") + " : " + ordine.Uso;

                SetOrderOptionsEnabled(!ordine.Executed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bEnableEvent = true;
            }
        }
        private void markAsDispensedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgOrdini.SelectedRows.Count == 0) { return; }
                int idOrdine = Convert.ToInt32(dgOrdini.SelectedRows[0].Cells[0].Value.ToString());
                Library.Ordine ordine = new Library.Ordine(idOrdine);
                if (ordine.Executed) { return; }
                ordine.Executed = true;
                ordine.Save();
                dgOrdini.SelectedRows[0].Cells[1].Value = (System.Drawing.Image)Properties.Resources.circle_green;
                email = new Library.Email(email.ID, db);
                if (email.Executed)
                {
                    dgEmail.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Green;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (email == null) { return; }
                if (dgEmail.SelectedRows.Count == 0) { return; }
                
                email.DeleteEmail();

                dgOrdini.Rows.Clear();
                dgEmail.Rows.Remove(dgEmail.SelectedRows[0]);
                dgEmail.ClearSelection();
                email = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgEmail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }
        private void dgEmail_SizeChanged(object sender, EventArgs e)
        {
            int width = dgEmail.Width;
            dgEmail.Columns[1].Width = (65 * dgEmail.Width) / 100;
            dgEmail.Columns[2].Width = (35 * dgEmail.Width) / 100;
        }
        private void dgOrdini_SizeChanged(object sender, EventArgs e)
        {
            int width = dgOrdini.Width;
            dgOrdini.Columns[1].Width = (10 * dgOrdini.Width) / 100;
            dgOrdini.Columns[2].Width = (30 * dgOrdini.Width) / 100;
            dgOrdini.Columns[3].Width = (30 * dgOrdini.Width) / 100;
            dgOrdini.Columns[4].Width = (30 * dgOrdini.Width) / 100;
        }
        #endregion

        private void SetOrderOptionsEnabled(bool bEnabled)
        {
            markAsDispensedToolStripMenuItem.Visible = bEnabled;
        }
        private void SetEmailOptionsEnabled(bool bEnabled)
        {
            deleteEmailToolStripMenuItem.Visible = bEnabled;
        }

        private void dgOrdini_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgOrdini.SelectedRows.Count != 1) { return; }
                int idordine = Convert.ToInt32(dgOrdini.SelectedRows[0].Cells[0].Value.ToString());
                Library.Ordine ordine = new Library.Ordine(idordine);
                if (!ordine.ReadyToDispense) { return; }

                string sql = "SELECT id FROM formule WHERE system = '" + ordine.Prodotto + "' and colorcharts = '" + ordine.CColori + "' and use = '" + ordine.Uso + "' and colorname = '" + ordine.Tinta + "'";
                DataTable dt = db.SQLQuerySelect(sql);
                if (dt.Rows.Count == 0) { return; } //not found!

                _idformulaRequest = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
    }
}
