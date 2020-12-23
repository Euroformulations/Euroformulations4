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
using System.Threading;

namespace Euroformulations4.SubWindows.ColorSearch
{
    public partial class frmRicercaColore : Form
    {
        private Library.Data.Database.DBConnector db = null;
        private static Library.Language lang = Library.Language.GetInstance();
        private bool bChkDeviceEvent = false;
        private bool bChkKeyboardEvent = false;
        private bool bLoadEnded = false;
        private int IDFORMULA_REQUEST = -1;
        private Euroformulations4.Menu.MenuManager menu = null;
        private double l = -1, a = -1, b = -1;
        bool bInternalEnabled = true, bExternalEnabled = true;
        private ToolTip tp = new ToolTip();
        private TabPage tabTempGeneral = null;
        private TabPage tabTempCartelle = null;

        public frmRicercaColore()
        {
            InitializeComponent();
        }
        private void frmRicercaColore_Load(object sender, EventArgs e)
        {
            try
            {
                db = new Library.Data.Database.DBConnector();

                //prodotti
                foreach (KeyValuePair<int, string> pair in Library.GVar.dicProducts)
                {
                    rblProdotti.Items.Add(pair.Value.ToString());
                }

                //cartelle colori
                if (Library.Data.Dispositivi.DispositiviManager.DispositivoCurrentTipo() == Library.Data.Dispositivi.eDispositiviTipo.Cube)
                {
                    DataTable dt = db.SQLQuerySelect("select distinct colorcharts from formule where ciel_cubecc is not null");
                    foreach (DataRow dr in dt.Rows)
                    {
                        clbCColori.Items.Add(dr["colorcharts"].ToString());
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, string> pair in Library.GVar.dicColorcharts)
                    {
                        clbCColori.Items.Add(pair.Value);
                    }
                }
                btnAllCharts_Click(null, null);

                #region TRADUZIONI
                gbInputType.Text = lang.GetWord("search32");
                chkDevice.Text = lang.GetWord("spectro");
                chkKeyboard.Text = lang.GetWord("keyboard");
                groupBox1.Text = lang.GetWord("search01");
                btnLeggiColore.Text = lang.GetWord("search02");
                GroupBox3.Text = lang.GetWord("search04");
                tabGeneral.Text = lang.GetWord("search05");
                tabProducts.Text = lang.GetWord("search06");
                groupBox4.Text = lang.GetWord("search08");
                chkInternal.Text = lang.GetWord("search11");
                chkExternal.Text = lang.GetWord("search12");
                GroupBox6.Text = lang.GetWord("search16");
                dgDati.Columns[1].HeaderText = lang.GetWord("search17");
                dgDati.Columns[2].HeaderText = lang.GetWord("search18");
                dgDati.Columns[3].HeaderText = lang.GetWord("search19");
                dgDati.Columns[4].HeaderText = lang.GetWord("search20");
                dgDati.Columns[5].HeaderText = lang.GetWord("search21");
                dgDati.Columns[6].HeaderText = lang.GetWord("search22");
                dgDati.Columns[7].HeaderText = lang.GetWord("search36");
                tabColorchart.Text = lang.GetWord("search30");
                tp.SetToolTip(pbHelp, lang.GetWord("help01"));
                gbListino.Text = lang.GetWord("settings48");
                btnAllCharts.Text = lang.GetWord("search37");
                btnNoneCharts.Text = lang.GetWord("search38");
                #endregion

                #region TAB
                tabTempGeneral = tabGeneral;
                TabPage tabTempProdotti = tabProducts;
                tabTempCartelle = tabColorchart;
                tabFiltri.Controls.RemoveAt(0);
                tabFiltri.Controls.RemoveAt(0);
                tabFiltri.Controls.RemoveAt(0);
                tabFiltri.Controls.Add(tabTempProdotti);
                #endregion

                #region LISTINI
                Dictionary<int, ItemListino> dicListini = new Dictionary<int, ItemListino>();
                dicListini.Add(-1, new ItemListino("", ""));
                DataTable dt2 = db.SQLQuerySelect("SELECT * FROM listino");
                foreach (DataRow dr in dt2.Rows)
                {
                    dicListini.Add(Convert.ToInt32(dr["id_list"].ToString()), new ItemListino(dr["nome_listino"].ToString(), dr["valuta"].ToString()));
                }
                cmbListino.DataSource = new BindingSource(dicListini, null);
                cmbListino.DisplayMember = "Value";
                cmbListino.ValueMember = "Key";
                #endregion

                bChkDeviceEvent = true;
                bChkKeyboardEvent = true;
                SetButtonColor(btnLeggiColore);
                SetButtonColor(btnSalvaStandard);

                dgDati_SizeChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            bLoadEnded = true;
        }
        private void frmRicercaColore_FormClosing(object sender, FormClosingEventArgs e)
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

        #region PROPERTY
        public int REQUEST_IDFormula{
            get { return IDFORMULA_REQUEST; }
        }
        public Euroformulations4.Menu.MenuManager SetMenu
        {
            set { this.menu = value; }
        }
        #endregion

        #region GRAPHICAL EVENT
        private void dgDati_SizeChanged(object sender, EventArgs e)
        {
            int width = dgDati.Width;
            dgDati.Columns[1].Width = (5 * dgDati.Width) / 100;
            dgDati.Columns[2].Width = (12 * dgDati.Width) / 100;
            dgDati.Columns[3].Width = (10 * dgDati.Width) / 100;
            dgDati.Columns[4].Width = (18 * dgDati.Width) / 100;
            dgDati.Columns[5].Width = (19 * dgDati.Width) / 100;
            dgDati.Columns[6].Width = (18 * dgDati.Width) / 100;
            dgDati.Columns[7].Width = (15 * dgDati.Width) / 100;

        }
        private void dgDati_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDati.SelectedRows.Count == 1)
            {
                IDFORMULA_REQUEST = Convert.ToInt32(dgDati.SelectedRows[0].Cells[0].Value.ToString());
                this.Close();
            }
        }
        private void InternalChanged(object sender, EventArgs e)
        {
            if (!bInternalEnabled) return;
            bExternalEnabled = false;
            chkExternal.Checked = !chkInternal.Checked;
            bExternalEnabled = true;
        }
        private void ExternalChanged(object sender, EventArgs e)
        {
            if (!bExternalEnabled) return;
            bInternalEnabled = false;
            chkInternal.Checked = !chkExternal.Checked;
            bInternalEnabled = true;
        }
        private void rblProdotti_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLeggiColore.Enabled = clbCColori.CheckedItems.Count > 0;
            if (tabFiltri.Controls.Count == 1)
            {
                rblProdotti.SuspendLayout();
                tabFiltri.Controls.Add(tabTempGeneral);
                tabFiltri.Controls.Add(tabTempCartelle);
                rblProdotti.ResumeLayout();
            }
            tabFiltri.SelectedTab = tabFiltri.TabPages[1];
        }
        private void btnAllCharts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCColori.Items.Count; i++)
            {
                clbCColori.SetItemChecked(i, true);
            }
        }
        private void btnNoneCharts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCColori.Items.Count; i++)
            {
                clbCColori.SetItemChecked(i, false);
            }
        }
        private void chkDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (!bChkDeviceEvent) return;
            bChkKeyboardEvent = false;
            chkKeyboard.Checked = !chkDevice.Checked;
            bChkKeyboardEvent = true;
        }
        private void chkKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (!bChkKeyboardEvent) return;
            bChkDeviceEvent = false;
            chkDevice.Checked = !chkKeyboard.Checked;
            bChkDeviceEvent = true;
        }
        private void dgDati_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgDati_CellDoubleClick(null, null);
            }
        }
        private void btnSalvaStandard_EnabledChanged(object sender, EventArgs e)
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
        private void clbCColori_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!bLoadEnded) { return; }
            int sCount = clbCColori.CheckedItems.Count;
            if (e.NewValue == CheckState.Checked) { ++sCount; }
            if (e.NewValue == CheckState.Unchecked) { --sCount; }
            btnLeggiColore.Enabled = sCount > 0;
        }
        #endregion

        private void btnLeggiColore_Click_1(object sender, EventArgs e)
        {
            btnLeggiColore.Enabled = false;

            try
            {
                bool bLetturaCube = false;

                #region Lettura valori CIELab
                if (chkDevice.Checked)
                {
                    Library.Data.Dispositivi.DispositivoBase disp = Library.Data.Dispositivi.DispositiviManager.GetDispositivo();

                    if (!disp.Calibrato())
                    {
                        DialogResult dialogResult = MessageBox.Show(lang.GetWord("calibration_message"), lang.GetWord("search27"), MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                        System.Windows.Forms.Form frmDevideDetail = disp.GetWindowManager(true, false);
                        if (frmDevideDetail != null)
                        {
                            frmDevideDetail.ShowDialog();
                        }

                        return;
                    }

                    frmGetColor frmColor = new frmGetColor();
                    frmColor.StartPosition = FormStartPosition.Manual;
                    frmColor.Location = new Point(GVar.AppLocation_X + 260, GVar.AppLocation_Y + 145);
                    frmColor.ShowDialog();
                    if (!frmColor.LetturaEseguita) { return; }
                    this.l = frmColor.CIEL;
                    this.a = frmColor.CIEa;
                    this.b = frmColor.CIEb;

                    if (Library.Data.Dispositivi.DispositiviManager.DispositivoCurrentTipo() == Library.Data.Dispositivi.eDispositiviTipo.Cube)
                    {
                        bLetturaCube = true;
                    }
                }
                else
                {
                    frmGetManualColor frmManualColor = new frmGetManualColor();
                    frmManualColor.StartPosition = FormStartPosition.Manual;
                    frmManualColor.Location = new Point(GVar.AppLocation_X + 260, GVar.AppLocation_Y + 145);
                    frmManualColor.ShowDialog();
                    if (!frmManualColor.Readed) { return; }
                    this.l = frmManualColor.CIEL;
                    this.a = frmManualColor.CIEa;
                    this.b = frmManualColor.CIEb;
                    bLetturaCube = frmManualColor.ReadedWithCube;
                }
                #endregion

                dgDati.Rows.Clear();

                int iProdotto = GVar.dicProducts.FirstOrDefault(x => x.Value == rblProdotti.SelectedItem.ToString()).Key;
                List<int> iCartelle = new List<int>();
                foreach (var item in clbCColori.CheckedItems)
                {
                    iCartelle.Add(GVar.dicColorcharts.FirstOrDefault(x => x.Value == item.ToString()).Key);
                }

                int iMatchRows = 10;
                Library.RicercaColore search = new RicercaColore();
                search.Preset_LAB(this.l, this.a, this.b);
                search.Preset_SearchFromCubeCC(bLetturaCube);
                search.ResultNumbers = iMatchRows;
                search.Filter_Interior = chkInternal.Checked;
                search.Filter_DEStandard = true;
                search.Filter_Products = new List<int> { iProdotto };
                search.Filter_CartellaColori = iCartelle;

                SortedDictionary<double, int> resultMatch = search.ColorSearchExecute();

                //datagrid populate
                string prevText = dgDati.Columns["Delta"].HeaderText;
                dgDati.Columns["Delta"].HeaderText = lang.GetWord("search19");
                if (dgDati.Columns["Delta"].HeaderText != prevText) dgDati_SizeChanged(null, null);

                dgDati.Visible = false;
                for (int i = 0; i < iMatchRows; i++)
                {
                    if (i < resultMatch.Count)
                    {

                        int indexColor = resultMatch[resultMatch.ElementAt(i).Key];
                        double DeltaColor = resultMatch.ElementAt(i).Key;

                        Colore c = Library.GVar.lstColoriFull[indexColor];
                        dgDati.Rows.Add();
                        dgDati.Rows[i].Height = 44;
                        dgDati.Rows[i].Cells[0].Value = c.ID.ToString();
                        dgDati.Rows[i].Cells[1].Value = (i + 1).ToString();
                        dgDati.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(c.R), Convert.ToInt32(c.G), Convert.ToInt32(c.B));
                        dgDati.Rows[i].Cells[3].Value = String.Format("{0:0.00}", Math.Sqrt(DeltaColor));
                        dgDati.Rows[i].Cells[4].Value = GVar.dicProducts[c.CodProdotto];
                        dgDati.Rows[i].Cells[5].Value = GVar.dicColorcharts[c.CodCartellaColori];
                        dgDati.Rows[i].Cells[6].Value = c.Nome;
                        dgDati.Rows[i].Cells[7].Value = "-";

                        object oListino = cmbListino.SelectedValue;
                        if (oListino != null)
                        {
                            int idlistino = Convert.ToInt32(oListino);
                            if (idlistino != -1)
                            {
                                KeyValuePair<int, ItemListino> selectedEntry = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
                                ItemListino listino = selectedEntry.Value;
                                dgDati.Rows[i].Cells[7].Value = GetFormulaCost(c.ID, idlistino) + " " + listino.valuta;
                            }
                        }

                        if (bLetturaCube && c.DEFormula > 2d)
                        {
                            dgDati.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.OrangeRed;
                            dgDati.Rows[i].Cells[1].ToolTipText = lang.GetWord("search33");
                            dgDati.Rows[i].Cells[2].ToolTipText = lang.GetWord("search33");
                            dgDati.Rows[i].Cells[3].ToolTipText = lang.GetWord("search33");
                            dgDati.Rows[i].Cells[4].ToolTipText = lang.GetWord("search33");
                            dgDati.Rows[i].Cells[5].ToolTipText = lang.GetWord("search33");
                            dgDati.Rows[i].Cells[6].ToolTipText = lang.GetWord("search33");
                            dgDati.Rows[i].Cells[7].ToolTipText = lang.GetWord("search33");
                        }
                        else
                        {
                            dgDati.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                        }

                        dgDati.Rows[i].Cells[2].Selected = false;
                    }
                }

                dgDati.Visible = true;
                dgDati_SizeChanged(null, null);
                btnSalvaStandard.Enabled = true;
                this.ActiveControl = dgDati;
            }
            catch (Exception ex)
            {
                this.l = -1;
                this.a = -1;
                this.b = -1;
                btnSalvaStandard.Enabled = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnLeggiColore.Enabled = true;
            }
        }
        private void btnSalvaStandard_Click(object sender, EventArgs e)
        {
            try
            {
                double[] xyz = Library.Colore.LAB_XYZ(this.l, this.a, this.b);
                Colore c = new Colore(this.l, this.a, this.b, xyz[0], xyz[1], xyz[2]);
                Qualita.frmQualitaColori frmSalva = new Qualita.frmQualitaColori(c);
                frmSalva.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetFormulaCost(int IDFormula, int IDListino)
        {
            Library.Formulation.Formula formula = Library.Formulation.Formula.InitFormula_From_formule(IDFormula);
            formula = formula.ChangeBase(1d, Library.Formulation.eUnita.LT, false, "");
            double dCostoCol = 0d;
            for (int i = 0; i < formula.ColorantsCount; i++)
            {
                dCostoCol += formula.GetCost_Colorant(i, IDListino);
            }

            return Math.Round(dCostoCol, 2).ToString("0.00");
        }

        class ItemListino
        {
            public string nome;
            public string valuta;

            public ItemListino(string nome, string valuta) { this.nome = nome; this.valuta = valuta; }

            public override string ToString()
            {
                return nome;
            }
        }

        
    }
}