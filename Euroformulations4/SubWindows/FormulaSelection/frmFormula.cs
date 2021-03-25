using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Euroformulations4.Library;
using System.Globalization;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Euroformulations4.SubWindows.FormulaSelection
{
    public partial class frmFormula : Form
    {
        public enum ePage
        { 
            formula_selection = 0,
            color_search = 1,
            formula_personale = 2,
            history = 3,
            anywhere = 4,
        }
        private int initIDFormula = -1;
        private ePage eFrom = ePage.formula_selection;
        private ePage eTo = ePage.anywhere;
        private Library.Formulation.Formula formula_originale = null;
        private Library.Formulation.Formula formula = null;
        private bool bEditFormulaMLAsOunce = false;
        private System.Drawing.Color cFormulaWithPrev = System.Drawing.Color.Red;
        
        private int idcustomer = -1;
        private string sCustomerName = "";
        private string sCustomerPhone = "";
        private TabPage pageColor = null;
        private string sNumFormat = "N0";

        private Language lang = Language.GetInstance();
        private Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
        private Library.Data.DBSettings dbSettings = new Library.Data.DBSettings();
        private Library.Data.Database.DBConnector db;

        public frmFormula(int idFormula, ePage eFrom)
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
            this.eFrom = eFrom;
            this.initIDFormula = idFormula;
        }
        public frmFormula()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        private void frmFormula_Load(object sender, EventArgs e)
        {
            try
            {
                #region Traduzioni
                tabProduct.Text = lang.GetWord("formula01") + " template";
                tabViewFormula.Text = lang.GetWord("formula65") + " template";
                Label2.Text = lang.GetWord("formula06");
                Label3.Text = lang.GetWord("formula07");
                Label4.Text = lang.GetWord("formula08");
                gbSearch.Text = lang.GetWord("formula10");
                dgTinte.Columns[1].HeaderText = lang.GetWord("formula11");
                gbAnteprima.Text = lang.GetWord("formula11");
                dgTinte.Columns[3].HeaderText = lang.GetWord("formula19");
                gbColorInfo.Text = lang.GetWord("formula22");
                SetDetailText("", "", "");
                gbListino.Text = lang.GetWord("settings48");
                dgFormula.Columns[0].HeaderText = lang.GetWord("formula11");
                dgFormula.Columns[1].HeaderText = lang.GetWord("formula26");
                dgFormula.Columns[2].HeaderText = lang.GetWord("formula27");
                dgFormula.Columns[3].HeaderText = lang.GetWord("formula28");
                dgFormula.Columns[4].HeaderText = lang.GetWord("formula30");
                btnDispense.Text = lang.GetWord("formula32");
                btnRelatedTo.Text = lang.GetWord("relatedTo");
                btnEditFormula.Text = lang.GetWord("formula55");
                btnColoriArmonici.Text = lang.GetWord("formula62");
                gbCosti.Text = lang.GetWord("formula30");
                tabProduct.Text = lang.GetWord("formula01");
                tabViewFormula.Text = lang.GetWord("formula65");
                tROunceToolStripMenuItem.Text = lang.GetWord("formula29");
                gramsToolStripMenuItem.Text = lang.GetWord("formula70");
                milliliterToolStripMenuItem.Text = lang.GetWord("formula71");
                #endregion

                #region CONTROLLI LICENZA
                if (!GVar.attivazioni.Act__formulationRelatedTo) { btnRelatedTo.Visible = false;}
                if (!GVar.attivazioni.Act_CustomQuantityFormulation) { listLatte.Items[0].Remove(); }
                if (GVar.attivazioni.Act_PersonalFormula) { btnEditFormula.Visible = true; } else { btnEditFormula.Visible = false; }
                #endregion

                IniFile conf = new IniFile();
                Cleartxt();

                pageColor = tabViewFormula;
                dgTinte.Columns[2].Visible = sharedSettings.GetValue("DeltaWarning") == "1";

                int iDecimals = Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"));
                if (iDecimals > 0)
                { 
                    sNumFormat = "N" + iDecimals.ToString();
                }

                #region Listini
                Dictionary<int, ItemListino> dicListini = new Dictionary<int, ItemListino>();
                dicListini.Add(-1, new ItemListino(-1, "", ""));
                string sql = "SELECT * FROM listino ORDER BY id_list LIMIT 1";
                if (GVar.attivazioni.Act_ListiniUnlimited)
                {
                    sql = "SELECT * FROM listino ORDER BY nome_listino";
                }
                DataTable dt = db.SQLQuerySelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    int idlistino = Convert.ToInt32(dr["id_list"].ToString());
                    string nomelistino = dr["nome_listino"].ToString();
                    string valuta = dr["valuta"].ToString();
                    dicListini.Add(idlistino, new ItemListino(idlistino, nomelistino, valuta));
                }
                cmbListino.DataSource = new BindingSource(dicListini, null);
                cmbListino.DisplayMember = "Value";
                cmbListino.ValueMember = "Key";

                int iListinoDefault = GetListinoDefault();
                if (dicListini.ContainsKey(iListinoDefault))
                {
                    cmbListino.SelectedValue = iListinoDefault;
                }
                #endregion

                switch (this.eFrom)
                {
                    case ePage.formula_selection:
                        {
                            #region FORMULA SELECTION
                            sql = "SELECT DISTINCT(system) as PRODUCT, ordersystem FROM formule ORDER BY ordersystem, system";
                            DataTable dtselect = db.SQLQuerySelect(sql);
                            foreach (DataRow dr in dtselect.Rows)
                            {
                                selprodotto.Items.Add(dr["PRODUCT"].ToString());
                            }
                            tabmain.TabPages.Remove(tabViewFormula);
                            #endregion
                            break;
                        }
                    case ePage.color_search:
                        {
                            Formula_Esterna(this.initIDFormula);
                            break;
                        }
                    case ePage.formula_personale:
                        {
                            #region FORMULE PERSONALI
                            SetComplementariVisibility(false);
                            tabmain.TabPages.Remove(tabProduct);

                            formula_originale = Library.Formulation.Formula.InitFormula_From_formulePersonali(initIDFormula);
                            formula = new Library.Formulation.Formula(formula_originale);
                            string colornamePre_tmo = formula.FormulaName;
                            string systemPre_tmp = formula.BaseProdotto;
                            string colorchartsPre_tmp = formula.ColorChart;
                            string usePre_tmp = formula.Use;

                            sql = "SELECT * FROM formule_personali WHERE idp = " + initIDFormula;
                            DataTable dtselect = db.SQLQuerySelect(sql);
                            DataRow dr = dtselect.Rows[0];

                            string sIDCustomer = dr["client_id"].ToString();
                            SetDetailText(systemPre_tmp, colorchartsPre_tmp, usePre_tmp);
                            selprodotto.Items.Clear();

                            dgTinte.SelectionChanged -= new EventHandler(listcolor2_SelectionChanged);
                            dgTinte.Rows.Clear();
                            dgTinte.Rows.Add();
                            dgTinte.Rows[0].Cells[0].Value = initIDFormula;
                            dgTinte.Rows[0].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(formula.RGB_R), Convert.ToInt32(formula.RGB_G), Convert.ToInt32(formula.RGB_B));
                            dgTinte.Rows[0].Cells[3].Value = formula.FormulaName;
                            dgTinte.Rows[0].Cells[4].Value = 0;
                            
                            //NO WARNING SULLE FORMULE PERSONALI

                            dgTinte.ClearSelection();
                            dgTinte.SelectionChanged += new EventHandler(listcolor2_SelectionChanged);

                            dgTinte.Rows[0].Selected = true;

                            if (!tabmain.TabPages.Contains(tabViewFormula))
                            {
                                tabmain.TabPages.Add(tabViewFormula);
                            }
                            dgFormula.ClearSelection();

                            if (GVar.attivazioni.Act__formulationRelatedTo && sIDCustomer.Trim() != "")
                            {
                                SetRelatedTo(Convert.ToInt32(sIDCustomer));
                            }
                            #endregion
                            break;
                        }
                    case ePage.history:
                        {
                            #region HISTORY
                            SetComplementariVisibility(false);
                            tabmain.TabPages.Remove(tabProduct);

                            formula_originale = Library.Formulation.Formula.InitFormula_From_history(initIDFormula);
                            formula = new Library.Formulation.Formula(formula_originale);
                            string colornamePre_tmo = formula.FormulaName;
                            string systemPre_tmp = formula.BaseProdotto;
                            string colorchartsPre_tmp = formula.ColorChart;
                            string usePre_tmp = formula.Use;

                            sql = "SELECT * FROM history WHERE id = " + initIDFormula;
                            DataTable dtselect = db.SQLQuerySelect(sql);
                            DataRow dr = dtselect.Rows[0];
                            string sIDCliente = dr["idcliente"].ToString();

                            SetDetailText(systemPre_tmp, colorchartsPre_tmp, usePre_tmp);
                            selprodotto.Items.Clear();

                            dgTinte.SelectionChanged -= new EventHandler(listcolor2_SelectionChanged);
                            dgTinte.Rows.Clear();
                            dgTinte.Rows.Add();
                            dgTinte.Rows[0].Cells[0].Value = formula.IDFormula.ToString();
                            dgTinte.Rows[0].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(formula.RGB_R), Convert.ToInt32(formula.RGB_G), Convert.ToInt32(formula.RGB_B));
                            dgTinte.Rows[0].Cells[3].Value = formula.FormulaName;
                            dgTinte.Rows[0].Cells[4].Value = 0;
                            if (sharedSettings.GetValue("DeltaWarning") == "1")
                            {
                                bool bNW = dr["nw"].ToString().Contains("NW");
                                string note = dr["notetxt"].ToString();
                                double de = Convert.ToDouble(dr["de"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                                double deLimit = 3d;
                                try
                                { 
                                    deLimit = Convert.ToDouble(dbSettings.GetValue("DEFormulaLimit").Replace(",", "."), CultureInfo.InvariantCulture);
                                }
                                catch(Exception ){MessageBox.Show(dbSettings.GetValue("DEFormulaLimit") + " is not valid DE limit.");}

                                if (bNW || note.Trim() != "" || de >= deLimit)
                                {
                                    dgTinte.Rows[0].Cells[4].Value = 1;
                                    if (bNW) { dgTinte.Rows[0].Cells[2].ToolTipText = lang.GetWord("formula42") + ". "; }
                                    if (note.Trim() != "") { dgTinte.Rows[0].Cells[2].ToolTipText += lang.GetWord("formula41") + " " + note + ". "; }
                                    if (de >= deLimit) { dgTinte.Rows[0].Cells[2].ToolTipText += "DE: " + de.ToString(); }
                                }

                            }

                            dgTinte.ClearSelection();
                            dgTinte.SelectionChanged += new EventHandler(listcolor2_SelectionChanged);

                            dgTinte.Rows[0].Selected = true;

                            if (!tabmain.TabPages.Contains(tabViewFormula))
                            {
                                tabmain.TabPages.Add(tabViewFormula);
                            }
                            dgFormula.ClearSelection();

                            if (GVar.attivazioni.Act__formulationRelatedTo && sIDCliente.Trim() != "")
                            {
                                SetRelatedTo(Convert.ToInt32(sIDCliente));
                            }
                            #endregion
                            break;
                        }
                }
                
                #region POPOLAZIONE DEI DRIVER MACCHINA INSERITI
                DataTable dtmachine = db.SQLQuerySelect("SELECT * FROM machine ORDER BY id_machine");
                foreach (DataRow dr in dtmachine.Rows)
                {
                    cmbDispenser.Items.Add(dr["name"].ToString());
                }

                if (dbSettings.HasKey("drivermachine"))
                {
                    cmbDispenser.Text = dbSettings.GetValue("drivermachine");
                }
                #endregion

              

                #region COLORI COMPLEMENTARI
                if (!GVar.attivazioni.Act_ComplementaryColors)
                {
                    SetComplementariVisibility(false);
                }
                #endregion
                
                SetButtonColor(btnEditFormula);
                SetButtonColor(btnDispense);
                SetButtonColor(btnRoundFormula);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region PROPERTIES
        public ePage REQUEST_DvSono
        {
            get { return eTo; }
        }
        public ePage PageTo 
        {
            set { this.eTo = value; }
            get { return this.eTo; }
        }
        public int IDCustomer
        {
            get { return this.idcustomer; }
        }
        public bool EditFormulaMLAsOunce { get { return bEditFormulaMLAsOunce; } }
        public Euroformulations4.Library.Formulation.Formula CurrentFormula { get { return this.formula; } }
        #endregion

        #region TAB 1 - EVENTS
        private void selprodotto_Click(object sender, EventArgs e)
        {
            try
            {
                selcharts.Items.Clear();
                seluse.Items.Clear();
                string sql = "SELECT DISTINCT(colorcharts) as CHARTS FROM formule WHERE system = '" + selprodotto.Text + "' ORDER BY colorcharts";
                DataTable dt = db.SQLQuerySelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    selcharts.Items.Add(dr["CHARTS"].ToString());
                }

                if (tabmain.TabPages.Contains(tabViewFormula))
                {
                    tabmain.TabPages.Remove(tabViewFormula);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void selcharts_Click(object sender, MouseEventArgs e)
        {
            try
            {
                seluse.Items.Clear();
                string sql = "SELECT DISTINCT(use) as INTEXT FROM formule WHERE system = '" + selprodotto.Text + "' AND colorcharts = '" + selcharts.Text + "' ORDER BY use";
                DataTable dt = db.SQLQuerySelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    seluse.Items.Add(dr["INTEXT"]);
                }

                if (tabmain.TabPages.Contains(tabViewFormula))
                {
                    tabmain.TabPages.Remove(tabViewFormula);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void seluse_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (seluse.Text != "")
                {
                    dgTinte.SelectionChanged -= new EventHandler(listcolor2_SelectionChanged);
                    dgTinte.Rows.Clear();

                    this.formula = null;
                    this.formula_originale = null;
                    SetDetailText(selprodotto.Text, selcharts.Text, seluse.Text);
                    int iRow = 0;

                    string sql = "SELECT * FROM formule WHERE system = '" + selprodotto.Text + "' AND colorcharts = '" + selcharts.Text + "' AND use = '" + seluse.Text + "' order by colorname";
                    DataTable dt = db.SQLQuerySelect(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgTinte.Rows.Add();
                        dgTinte.Rows[iRow].Cells[0].Value = dr["id"].ToString();
                        dgTinte.Rows[iRow].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["R"].ToString()), Convert.ToInt32(dr["G"].ToString()), Convert.ToInt32(dr["B"].ToString()));
                        string name = dr["colorname"].ToString();
                        dgTinte.Rows[iRow].Cells[4].Value = 0;
                        if (sharedSettings.GetValue("DeltaWarning") == "1")
                        {
                            bool bNW = dr["nw"].ToString() == "NW";
                            string note = dr["notetxt"].ToString();
                            double de = Convert.ToDouble(dr["de"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                            double deLimit = 3d;
                            try
                            {
                                deLimit = Convert.ToDouble(dbSettings.GetValue("DEFormulaLimit").Replace(",", "."), CultureInfo.InvariantCulture);
                            }
                            catch (Exception) { MessageBox.Show(dbSettings.GetValue("DEFormulaLimit") + " is not valid DE limit."); }
                            if (bNW || note.Trim() != "" || de >= deLimit)
                            {
                                dgTinte.Rows[iRow].Cells[4].Value = 1;
                                if (bNW) { dgTinte.Rows[iRow].Cells[2].ToolTipText = lang.GetWord("formula42") + ". "; }
                                if (note.Trim() != "") { dgTinte.Rows[iRow].Cells[2].ToolTipText += lang.GetWord("formula41") + " " + note + ". "; }
                                if (de >= deLimit) { dgTinte.Rows[iRow].Cells[2].ToolTipText += "DE: " + de.ToString(); }
                            }
                            
                        }
                        dgTinte.Rows[iRow].Cells[3].Value = name;

                        if (HasHistory(selprodotto.Text, name, seluse.Text))
                        {
                            dgTinte.Rows[iRow].Cells[3].Style.BackColor = cFormulaWithPrev;
                        }

                        iRow++;
                    }
                    Cleartxt();

                    if (!tabmain.TabPages.Contains(this.pageColor))
                    {
                        tabmain.TabPages.Add(this.pageColor);
                    }
                    SelectTabViewFormula();

                    dgTinte.ClearSelection();
                    dgTinte.SelectionChanged += new EventHandler(listcolor2_SelectionChanged);
                }
            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                MessageBox.Show(ex.Message + ": " + lineNumber);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void dgTinte_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                if ((e.PaintParts & DataGridViewPaintParts.Background) != DataGridViewPaintParts.None)
                {
                    System.Drawing.Color colorBackground = System.Drawing.Color.WhiteSmoke;
                    if (e.RowIndex % 2 == 0)
                    {
                        colorBackground = System.Drawing.Color.White;
                    }
                    using (System.Drawing.Brush brush = new SolidBrush(colorBackground))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }
                    System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.SystemColors.ControlDark, 2);
                    e.Graphics.DrawLine(pen, new Point(e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y), new Point(e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y + +e.CellBounds.Height));
                    e.Graphics.DrawLine(pen, new Point(e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height), new Point(e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y + +e.CellBounds.Height));

                    if (dgTinte.Rows[e.RowIndex].Cells[4].Value != null)
                    {
                        if (dgTinte.Rows[e.RowIndex].Cells[4].Value.ToString() == "1")
                        {
                            Rectangle r = e.CellBounds;
                            r.X = r.X + (e.CellBounds.Size.Width - 16) / 2;
                            r.Y = r.Y + 3;
                            r.Width = 16;
                            r.Height = 16;
                            e.Graphics.DrawImage(Properties.Resources.info28, r);
                        }
                    }
                }
                if (!e.Handled)
                {
                    e.Handled = true;
                    e.PaintContent(e.CellBounds);
                }
            }
            else if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                System.Drawing.Color cTinta = dgTinte.Rows[e.RowIndex].Cells[1].Style.BackColor;
                using (System.Drawing.Brush brush = new SolidBrush(cTinta))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }
                if (!e.Handled)
                {
                    e.Handled = true;
                    e.PaintContent(e.CellBounds);
                }
            }
        }
        #endregion

        #region TAB 2 - EVENTS

        #region lista tinte
        private void listcolor2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Cleartxt();

                if (dgTinte.SelectedRows.Count == 0) { return; }

                listLatte.Enabled = true;
                txtBaseCustom.Visible = false;
                cmbListino.Enabled = true;

                int id_formula = Convert.ToInt32(dgTinte.SelectedRows[0].Cells[0].Value.ToString());
                gbColorInfo.Text = (dgTinte.SelectedRows[0].Cells[3].Value.ToString());
                gbColorInfo.ForeColor = System.Drawing.Color.FromArgb(0, 149, 66);

                switch (eFrom)
                {
                    case ePage.formula_personale:
                        {
                            formula_originale = Library.Formulation.Formula.InitFormula_From_formulePersonali(id_formula);
                            break;
                        }
                    case ePage.history:
                        {
                            formula_originale = Library.Formulation.Formula.InitFormula_From_history(id_formula);
                            break;
                        }
                    default:
                        {
                            formula_originale = Library.Formulation.Formula.InitFormula_From_formule(id_formula);
                            break;
                        }
                }

                ExecuteAfter_formulaOriginale_selected(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExecuteAfter_formulaOriginale_selected()
        {
            if (eFrom == ePage.formula_personale || eFrom == ePage.history) { SetComplementariVisibility(false); }
            else { SetComplementariVisibility(true); }

            formula = new Library.Formulation.Formula(formula_originale);
            txtTinta.BackColor = System.Drawing.Color.FromArgb((int)formula.RGB_R, (int)formula.RGB_G, (int)formula.RGB_B);
            btxt.Text = formula.BaseName;

            for (int i = 0; i < formula.ColorantsCount; i++)
            {
                dgFormula.Rows.Add("", formula.ColorantName(i), "", "", "", "");
                dgFormula.Rows[i].Cells[0].Style.BackColor = formula.ColorantPreview(i);
            }

            //lattaggi
            listLatte.Items.Clear();
            if (GVar.attivazioni.Act_CustomQuantityFormulation)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "[ . . . ]";
                item.Tag = 1d;
                item.ImageIndex = 0;
                listLatte.Items.Add(item);
            }
            object oListino = cmbListino.SelectedValue;
            if (oListino != null)
            {
                int idlistino = Convert.ToInt32(oListino);
                if (idlistino != -1)
                {
                    string sql = "Select * From lattaggi where id_listino = " + idlistino + " and nome_base_latt = '" + formula.BaseName + "' ORDER BY lattaggio";
                    DataTable dt = db.SQLQuerySelect(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        string sLattaggio = dr["unita_lattaggio"].ToString();
                        if (sLattaggio == "L") { sLattaggio = "LT"; }
                        item.Text = dr["lattaggio"].ToString() + " " + sLattaggio;
                        string riempimento = dr["riempimento"].ToString();
                        if (riempimento.Trim() == "" || !GVar.attivazioni.Act_RefillCustom) { riempimento = "1"; }
                        item.Tag = Convert.ToDouble(riempimento) + ";" + dr["barcode"].ToString();
                        item.ImageIndex = 1;

                        listLatte.Items.Add(item);
                    }
                }
            }

            dgFormula.ClearSelection();
        }

        private void searchitem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sText = txtSearchTinte.Text.Trim();
                for (int i = 0; i < dgTinte.Rows.Count; i++)
                {
                    if (sText == "")
                    {
                        dgTinte.Rows[i].Visible = true;
                    }
                    else
                    {
                        if (dgTinte.Rows[i].Cells[3].Value.ToString().ToUpper().Contains(sText.ToUpper()))
                        {
                            dgTinte.Rows[i].Visible = true;
                        }
                        else
                        {
                            dgTinte.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region lattaggi
        private void Latt_Click(object sender, EventArgs e)
        {
            string sTagData2 = listLatte.SelectedItems[0].Tag.ToString();
            try
            {
                bool bClickSuLattaCustom = listLatte.FocusedItem.Index == 0;

                if (bClickSuLattaCustom && GVar.attivazioni.Act_CustomQuantityFormulation)
                {
                    txtBaseCustom.Visible = true;
                    txtBaseCustom.Text = "";
                    txtBaseCustom.Select(0, 10);
                    txtBaseCustom.Focus();
                }
                else
                {
                    if (GVar.attivazioni.Act_CustomQuantityFormulation){txtBaseCustom.Visible = false;}

                    PackagePreProcessor packageprocessor = new PackagePreProcessor(listLatte.SelectedItems[0].SubItems[0].Text.ToString());
                    string[] sTagData = listLatte.SelectedItems[0].Tag.ToString().Split(';');
                    if (packageprocessor.bError) { throw new Exception(lang.GetWord("formula34")); }
                    Library.Formulation.eUnita unitaBase = packageprocessor.unitaBase;
                    string subLabel = packageprocessor.subLabel;
                    double qtaBase = packageprocessor.qtaBase;

                    formula = formula_originale.ChangeBase(qtaBase, unitaBase, true, sTagData[1]);

                    double refill = (Convert.ToDouble(sTagData[0])) * 100;
                    formula = formula.GetFormulaRefilled((int) refill);
                    btxt.Text = formula.BaseName + " " + lang.GetWord("for") + " " + qtaBase.ToString() + " " + subLabel;

                    for (int i = 0; i < formula.ColorantsCount; i++)
                    {
                        double qml = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, Library.Formulation.eUnita.ml, formula.ColorantDensita(i));
                        double qgr = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, Library.Formulation.eUnita.gr, formula.ColorantDensita(i));

                        dgFormula.Rows[i].Cells[2].Value = Math.Round(qgr, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);
                        dgFormula.Rows[i].Cells[3].Value = Math.Round(qml, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);
                        dgFormula.Rows[i].Cells[4].Value = "";
                    }

                    //calcolo costi
                    object oListino = cmbListino.SelectedValue;
                    if (oListino != null)
                    {
                        int idlistino = (int)oListino;
                        if (idlistino != -1)
                        {
                            KeyValuePair<int, ItemListino> kvp = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
                            ItemListino itemList = (ItemListino)kvp.Value;

                            double dCostoBase = formula.GetCost_Base(idlistino);
                            double dCostoColoranti = 0;
                            for (int i = 0; i < formula.ColorantsCount; i++)
                            {
                                double dCostoColorante = formula.GetCost_Colorant(i, idlistino);
                                dgFormula.Rows[i].Cells[4].Value = Math.Round(dCostoColorante, 2).ToString("0.00") + " " + itemList.valuta;
                                dCostoColoranti += dCostoColorante;
                            }

                            SetCost(dCostoBase, dCostoColoranti, itemList.valuta);
                        }
                    }

                    btnEditFormula.Enabled = true;
                    btnDispense.Enabled = true;
                    btnRoundFormula.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + sTagData2);
            }
        }
        private void lattP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != Convert.ToChar(13)) { return; }
                string sData = txtBaseCustom.Text.Trim();
                PackagePreProcessor packageprocessor = new PackagePreProcessor(sData);
                if (packageprocessor.bError){ throw new Exception(lang.GetWord("formula34")); }

                Library.Formulation.eUnita unitaBase = packageprocessor.unitaBase;
                string subLabel = packageprocessor.subLabel;
                double qtaBase = packageprocessor.qtaBase;

                formula = formula_originale.ChangeBase(qtaBase, unitaBase, false, "");

                btxt.Text = formula.BaseName + " " + lang.GetWord("for") + " " + qtaBase.ToString() + " " + subLabel;
                txtBaseCustom.Visible = false;
                listLatte.Items[0].Text = qtaBase.ToString() + " " + subLabel;
                lblBaseCost.Text = "";
                lblColorantCost.Text = "";
                lblTotalCost.Text = "";
                gbCosti.Update();
                gbCosti.Refresh();

                for (int i = 0; i < formula.ColorantsCount; i++)
                {
                    double qml = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, Library.Formulation.eUnita.ml, formula.ColorantDensita(i));
                    double qgr = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, Library.Formulation.eUnita.gr, formula.ColorantDensita(i));

                    dgFormula.Rows[i].Cells[2].Value = Math.Round(qgr, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);
                    dgFormula.Rows[i].Cells[3].Value = Math.Round(qml, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);
                    dgFormula.Rows[i].Cells[4].Value = "";
                }

                //calcolo costi
                object oListino = cmbListino.SelectedValue;
                if (oListino != null)
                {
                    int idlistino = (int)oListino;
                    if (idlistino != -1)
                    {
                        KeyValuePair<int, ItemListino> kvp = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
                        ItemListino itemList = (ItemListino)kvp.Value;

                        double dCostoBase = formula.GetCost_Base(idlistino);
                        double dCostoColoranti = 0;
                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            double dCostoColorante = formula.GetCost_Colorant(i, idlistino);
                            dgFormula.Rows[i].Cells[4].Value = Math.Round(dCostoColorante, 2).ToString("0.00") + " " + itemList.valuta;
                            dCostoColoranti += dCostoColorante;
                        }
                        SetCost(dCostoBase, dCostoColoranti, itemList.valuta);
                    }
                }
                
                btnRoundFormula.Enabled = true;    
                btnEditFormula.Enabled = true;
                btnDispense.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
        #region related to
        private void btnRelatedTo_Click(object sender, EventArgs e)
        {
            try
            {
                Clienti.frmVisualizzaCliente form = new Clienti.frmVisualizzaCliente("MAIN FORMULA");
                form.ShowDialog();
                SetRelatedTo(form.REQUEST_IDCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region listini
        private void cmbListino_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                object oItem = cmbListino.SelectedItem;
                if (oItem == null) { return; }
                KeyValuePair<int, ItemListino> kvp = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
                int idlistino = kvp.Key;

                listLatte.Items.Clear();
                if (GVar.attivazioni.Act_CustomQuantityFormulation)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "[ . . . ]";
                    item.Tag = 1d;
                    item.ImageIndex = 0;
                    listLatte.Items.Add(item);
                }

                //set formula originale + reset
                if (formula_originale != null)
                {
                    formula = new Library.Formulation.Formula(formula_originale);
                    btxt.Text = formula.BaseName;
                    for (int i = 0; i < formula.ColorantsCount; i++)
                    {
                        dgFormula.Rows[i].Cells[2].Value = "";
                        dgFormula.Rows[i].Cells[3].Value = "";
                        dgFormula.Rows[i].Cells[4].Value = "";
                    }
                }
                dgFormula.ClearSelection();

                //lettura lattaggi
                if (idlistino != -1 && formula != null)
                {
                    string sql = "Select * From lattaggi where id_listino = " + idlistino + " and nome_base_latt = '" + formula.BaseName + "' ORDER BY lattaggio";
                    DataTable dt = db.SQLQuerySelect(sql);
                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        string sLattaggio = dr["unita_lattaggio"].ToString();
                        if (sLattaggio == "L") { sLattaggio = "LT"; }
                        item.Text = dr["lattaggio"].ToString() + " " + sLattaggio;
                        string riempimento = dr["riempimento"].ToString();
                        if (riempimento.Trim() == "" || !GVar.attivazioni.Act_RefillCustom) { riempimento = "1"; }
                        item.Tag = Convert.ToDouble(riempimento) + ";" + dr["barcode"].ToString();
                        item.ImageIndex = 1;
                        
                        listLatte.Items.Add(item);
                    }
                }

                lblBaseCost.Text = "";
                lblColorantCost.Text = "";
                lblTotalCost.Text = "";
                btnEditFormula.Enabled = false;
                btnDispense.Enabled = false;
                gbCosti.Update();
                gbCosti.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region dispense
        private void Dispenser_SelectedIndexChanged(object sender, EventArgs e)
        { 
            dbSettings.SetValue("drivermachine", cmbDispenser.Text);
        }     
        private void SendToDispenser_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDispenser.Text.Trim() == "") { return; }
                btnDispense.Enabled = false;

                //NUMERO EROGAZIONI
                int nErogazioni = 1;
                if (sharedSettings.GetValue("MultiErogazione") != "0")
                {
                    frmNumErogazioni numErogazioni = new frmNumErogazioni();
                    numErogazioni.ShowDialog();
                    nErogazioni = numErogazioni.Erogazioni;
                }

                //GET MACHINE INFO
                DataTable dt = db.SQLQuerySelect("SELECT * FROM machine WHERE name = '" + cmbDispenser.Text.Trim() + "'");
                DataRow dr = dt.Rows[0];
                Library.Data.Machine.eMacchina machine_type = (Library.Data.Machine.eMacchina)dr["machine_type"];
                string pathFile = dr["pathfile"].ToString();
                string exeFile = dr["exefile"].ToString();
                string onceType = dr["oncetype"].ToString().Replace(".", ",");

                if (Library.Data.Machine.ContainsManual(machine_type))
                {
                    #region EROGAZIONE SU MANUALE
                    int id_history = formula.SaveToHistory(db, idcustomer);
                    for (int i = 1; i < nErogazioni; i++)
                    {
                        id_history = formula.SaveToHistory(db, idcustomer);
                    }

                    List<string> lstColorantiNomi = new List<string>();
                    List<double> lstColorantiCosto = new List<double>();
                    List<double> lstColorantiQtaML = new List<double>();
                    List<System.Drawing.Color> lstColorantiPreview = new List<System.Drawing.Color>();
                    for (int i = 0; i < formula.ColorantsCount; i++)
                    {
                        lstColorantiNomi.Add(formula.ColorantName(i));
                        lstColorantiCosto.Add(0d);
                        lstColorantiPreview.Add(formula.ColorantPreview(i));
                        lstColorantiQtaML.Add(Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, Library.Formulation.eUnita.ml, formula.ColorantDensita(i)));
                    }
                    
                    string sBaseQta = Math.Round(formula.BaseQta, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString() + " " + formula.BaseUnita.ToString();

                    double dPrezzoBase = 0d;
                    string sUnitaCosto = "";
                    object oListino = cmbListino.SelectedValue;
                    if (oListino != null)
                    {
                        int idlistino = (int)oListino;
                        if (idlistino != -1)
                        {
                            for (int i = 0; i < formula.ColorantsCount; i++)
                            {
                                lstColorantiCosto[i] = Math.Round(formula.GetCost_Colorant(i, idlistino), 2);
                            }

                            dPrezzoBase = Math.Round(formula.GetCost_Base(idlistino), 2);
                            KeyValuePair<int, ItemListino> kvp = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
                            ItemListino itemList = (ItemListino)kvp.Value;
                            sUnitaCosto = itemList.valuta;
                        }
                    }
                    
                    FormulaSelection.frmOunceDispensing OnceDispensing = new frmOunceDispensing(machine_type, Convert.ToDouble(onceType.Replace(",", "."), CultureInfo.InvariantCulture), lstColorantiNomi, lstColorantiQtaML, lstColorantiCosto, lstColorantiPreview,
                        sCustomerName, sCustomerPhone, formula.FormulaName, formula.ColorChart, formula.Use, formula.BaseName, sBaseQta, dPrezzoBase, sUnitaCosto);
                    OnceDispensing.ShowDialog();
                    #endregion
                }
                else
                {
                    #region EROGAZIONE SU AUTOMATICA
                    for (int i = 0; i < nErogazioni; i++)
                    {
                        bool bContinua = true;

                        //MESSAGGIO
                        if (i > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show((i + 1) + "/" + nErogazioni + " - " + lang.GetWord("formula68"), "", MessageBoxButtons.OKCancel);
                            if (dialogResult != DialogResult.OK)
                            {
                                bContinua = false;
                            }
                        }

                        if (bContinua)
                        {
                            #region CONTROLLO_BARCODE
                            if (GVar.attivazioni.Act_Barcode && (sharedSettings.GetValue("BarCodeStatus") == "SI") && formula.Barcode.Trim() != "")
                            {
                                bool bCheckBarcode = true;
                                while (bCheckBarcode)
                                {
                                    frmInputBox inputBarcode = new frmInputBox(lang.GetWord("formula46"), lang.GetWord("formula47"));
                                    inputBarcode.ShowDialog();
                                    if (!inputBarcode.OKPressed) { return; }
                                    string sUserBarcode = inputBarcode.InputText;
                                    if (formula.Barcode.Trim() != sUserBarcode.Trim())
                                    {
                                        MessageBox.Show(lang.GetWord("formula38"));
                                    }
                                    else
                                    {
                                        bCheckBarcode = false;
                                    }
                                }
                            }
                            #endregion

                            //SAVE TO HISTORY
                            int id_history = formula.SaveToHistory(db, idcustomer);

                            //DISPENSE
                            Library.Formulation.StaticDispenser.SendFormula2AutomaticDispenser(formula, machine_type, pathFile, exeFile);
                        }
                        else
                        {
                            i = nErogazioni;
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnDispense.Enabled = true;
            }
        }     
        #endregion

        #region formula rounding
        private void btnRoundFormula_Click(object sender, EventArgs e)
        {
            try
            {
                formula = formula.GetFormulaRounded();

                for (int i = 0; i < formula.ColorantsCount; i++)
                {
                    double qml = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, Library.Formulation.eUnita.ml, formula.ColorantDensita(i));
                    double qgr = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, Library.Formulation.eUnita.gr, formula.ColorantDensita(i));

                    dgFormula.Rows[i].Cells[2].Value = Math.Round(qgr, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);
                    dgFormula.Rows[i].Cells[3].Value = Math.Round(qml, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);
                    dgFormula.Rows[i].Cells[4].Value = "";
                }

                //calcolo costi
                object oListino = cmbListino.SelectedValue;
                if (oListino != null)
                {
                    int idlistino = Convert.ToInt32(oListino);
                    if (idlistino != -1)
                    {
                        KeyValuePair<int, ItemListino> kvp = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
                        ItemListino itemList = (ItemListino)kvp.Value;

                        double dCostoBase = formula.GetCost_Base(idlistino);
                        double dCostoColoranti = 0;
                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            double dCostoColorante = formula.GetCost_Colorant(i, idlistino);
                            dgFormula.Rows[i].Cells[4].Value = Math.Round(dCostoColorante, 2).ToString("0.00") + " " + itemList.valuta;
                            dCostoColoranti += dCostoColorante;
                        }
                        SetCost(dCostoBase, dCostoColoranti, itemList.valuta);
                    }
                }

                btxt.Text = formula.BaseName + " " + lang.GetWord("for") + " " + Math.Round(formula.BaseQta, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString() + " " + formula.BaseUnita.ToString();
                btnRoundFormula.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region modifica formula
        private void btnEditFormula_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerRight = new Point(btnSender.Width, 0);
            ptLowerRight = btnSender.PointToScreen(ptLowerRight);
            EditFormulaMenu.Show(ptLowerRight);
        }
        private void gramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formula.EditFormulaUnit = Library.Formulation.eUnita.gr;
            this.eTo = ePage.formula_personale;
            this.Close();
        }
        private void milliliterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formula.EditFormulaUnit = Library.Formulation.eUnita.ml;
            this.eTo = ePage.formula_personale;
            this.Close();
        }
        private void OunceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IDManuale = Convert.ToInt32(dbSettings.GetValue("IDMachineOunceEdit"));
            if (IDManuale == -1)
            {
                MessageBox.Show(lang.GetWord("formula69"));
                return;
            }
            bEditFormulaMLAsOunce = true;
            formula.EditFormulaUnit = Library.Formulation.eUnita.ml;
            this.eTo = ePage.formula_personale;
            this.Close();
        }
        #endregion

        #region Colori armonici
        private void btnColoriArmonici_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgTinte.SelectedRows.Count == 0) { return; }

                if (!Euroformulations4.Library.GVar.bLoadFormuleEnded)
                {
                    throw new Exception(lang.GetWord("data_loading"));
                }

                int id_formula = Convert.ToInt32(dgTinte.SelectedRows[0].Cells[0].Value.ToString());
                frmComplementari formComplementari = new frmComplementari(id_formula);
                formComplementari.ShowDialog();
                int iIDColorSelected = formComplementari.IDSelectedColor;
                if (iIDColorSelected != -1)
                {
                    Formula_Esterna(iIDColorSelected, true, "formule", this.idcustomer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        
        #endregion

        #region UTILITIES
        private void Formula_Esterna(int id, bool bLockView = false, string sTableName = "formule", int idcustomer = -1)
        {
            if (bLockView)
            {
                this.Visible = false;
                Application.DoEvents();
            }

            bool bTableFormule = false;

            switch (sTableName)
            {
                case "formule_personali":
                    {
                        formula_originale = Library.Formulation.Formula.InitFormula_From_formulePersonali(id);
                        break;
                    }
                case "history":
                    {
                        formula_originale = Library.Formulation.Formula.InitFormula_From_history(id);
                        break;
                    }
                default:
                    {
                        formula_originale = Library.Formulation.Formula.InitFormula_From_formule(id);
                        bTableFormule = true;
                        break;
                    }
            }
            formula = new Library.Formulation.Formula(formula_originale);
            
            string colornamePre_tmo = formula.FormulaName;
            string systemPre_tmp = formula.BaseProdotto;
            string colorchartsPre_tmp = formula.ColorChart;
            string usePre_tmp = formula.Use;
            SetDetailText(systemPre_tmp, colorchartsPre_tmp, usePre_tmp);

            selprodotto.Items.Clear();
            string sql = "SELECT DISTINCT(system) as PRODUCT, ordersystem FROM  " + sTableName + "  ORDER BY ordersystem ASC";
            DataTable dt = db.SQLQuerySelect(sql);
            foreach (DataRow drp in dt.Rows)
            {
                selprodotto.Items.Add(drp["PRODUCT"].ToString());
            }
            selprodotto.Text = systemPre_tmp;

            selcharts.Items.Clear();
            sql = "SELECT DISTINCT(colorcharts) as CHARTS FROM " + sTableName + "  WHERE system = '" + systemPre_tmp + "'";
            dt = db.SQLQuerySelect(sql);
            foreach (DataRow drc in dt.Rows)
            {
                selcharts.Items.Add(drc["CHARTS"]);
            }
            selcharts.Text = colorchartsPre_tmp;

            seluse.Items.Clear();
            sql = "SELECT DISTINCT(use) as INTEXT FROM  " + sTableName + "  WHERE system = '" + systemPre_tmp + "' AND colorcharts = '" + colorchartsPre_tmp + "'";
            dt = db.SQLQuerySelect(sql);
            foreach (DataRow dru in dt.Rows)
            {
                seluse.Items.Add(dru["INTEXT"]);
            }
            seluse.Text = usePre_tmp;

            dgTinte.SelectionChanged -= new EventHandler(listcolor2_SelectionChanged);
            dgTinte.Rows.Clear();
            int iRows = 0;
            int iSelectedRow = -1;
            sql = "SELECT * FROM  " + sTableName + "  WHERE system = '" + systemPre_tmp + "' AND colorcharts = '" + colorchartsPre_tmp + "' AND use = '" + usePre_tmp + "'";
            dt = db.SQLQuerySelect(sql);
            foreach (DataRow dr2 in dt.Rows)
            {
                dgTinte.Rows.Add();
                int IDColor = Convert.ToInt32(dr2["id"].ToString());
                dgTinte.Rows[iRows].Cells[0].Value = IDColor.ToString();
                dgTinte.Rows[iRows].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr2["R"].ToString()), Convert.ToInt32(dr2["G"].ToString()), Convert.ToInt32(dr2["B"].ToString()));
                string sColorName = dr2["colorname"].ToString();
                dgTinte.Rows[iRows].Cells[3].Value = sColorName;
                dgTinte.Rows[iRows].Cells[4].Value = 0;

                if (sharedSettings.GetValue("DeltaWarning") == "1")
                {
                    bool bNW = dr2["nw"].ToString() == "NW";
                    string note = dr2["notetxt"].ToString();
                    double de = Convert.ToDouble(dr2["de"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    double deLimit = 3d;
                    try
                    {
                        deLimit = Convert.ToDouble(dbSettings.GetValue("DEFormulaLimit").Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    catch (Exception) { MessageBox.Show(dbSettings.GetValue("DEFormulaLimit") + " is not valid DE limit."); }
                    if (bNW || note.Trim() != "" || de >= deLimit)
                    {
                        dgTinte.Rows[iRows].Cells[4].Value = 1;
                        if (bNW) { dgTinte.Rows[iRows].Cells[2].ToolTipText = lang.GetWord("formula42") + ". "; }
                        if (note.Trim() != "") { dgTinte.Rows[iRows].Cells[2].ToolTipText += lang.GetWord("formula41") + " " + note + ". "; }
                        if (de >= deLimit) { dgTinte.Rows[iRows].Cells[2].ToolTipText += "DE: " + de.ToString(); }
                    }

                }

                if (formula.IDFormula == IDColor)
                {
                    iSelectedRow = iRows;
                }

                if (bTableFormule)
                {
                    if (HasHistory(systemPre_tmp, sColorName, usePre_tmp))
                    {
                        dgTinte.Rows[iRows].Cells[3].Style.BackColor = cFormulaWithPrev;
                    }
                }

                iRows++;
            }

            this.Visible = true;
            if (!tabmain.TabPages.Contains(tabViewFormula))
            {
                tabmain.TabPages.Add(tabViewFormula);
            }
            SelectTabViewFormula();
            dgFormula.ClearSelection();
            if (bLockView)
            {
                this.Visible = true;
                Application.DoEvents();
            }
            SetRelatedTo(idcustomer);
            dgTinte.ClearSelection();
            dgTinte.SelectionChanged += new EventHandler(listcolor2_SelectionChanged);
            if (iSelectedRow != -1)
            {
                dgTinte.Rows[iSelectedRow].Selected = true;
                dgTinte.FirstDisplayedScrollingRowIndex = dgTinte.SelectedRows[0].Index;
            }

            txtSearchTinte.Text = "";
        }
        private void SetDetailText(string product, string colorcharts, string use)
        {
            if (product.Trim() == "")
            {
                label9.Text = lang.GetWord("formula60");
            }
            else
            {
                label9.Text = lang.GetWord("formula60") + " " + product;
            }
            if (colorcharts.Trim() == "")
            {
                label11.Text = lang.GetWord("formula23");
            }
            else
            {
                label11.Text = lang.GetWord("formula23") + " " + colorcharts;
            }
            if (use.Trim() == "")
            {
                label10.Text = lang.GetWord("formula24");
            }
            else
            {
                label10.Text = lang.GetWord("formula24") + " " + use;
            }
        }
        private void Cleartxt()
        {
            btxt.Text = "";
            txtBaseCustom.Visible = false;
            txtBaseCustom.Text = "";
            listLatte.Enabled = false;
            dgFormula.Rows.Clear();
            lblBaseCost.Text = "";
            lblColorantCost.Text = "";
            lblTotalCost.Text = "";
            gbCosti.Update();
            gbCosti.Refresh();
            btnRoundFormula.Enabled = false;
            btnEditFormula.Enabled = false;
            btnDispense.Enabled = false;
            cmbListino.Enabled = false;
        }
        private int GetListinoDefault()
        {
            try
            {
                string sql = "";
                if (GVar.attivazioni.Act_ListiniUnlimited)
                {
                    string sID = dbSettings.GetValue("ListinoDefault");
                    return Convert.ToInt32(sID);
                }
                else
                {
                    sql = "SELECT * FROM listino LIMIT 1";
                }

                DataTable dt = db.SQLQuerySelect(sql);
                if (dt.Rows.Count == 0) { return -1; }

                return Convert.ToInt32(dt.Rows[0]["id_list"].ToString());
            }
            catch (Exception)
            {
                return -1;
            }
        }
        private static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
        private MemoryStream Image2Stream(Image image, System.Drawing.Imaging.ImageFormat formaw)
        {
            MemoryStream stream = new System.IO.MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }    
        private void SetRelatedTo(int idcustomer)
        {
            if (!GVar.attivazioni.Act__formulationRelatedTo) { this.idcustomer = -1; return; }
            this.idcustomer = idcustomer;
            if (idcustomer == -1) { return; }

            string sql = "SELECT * FROM clienti WHERE id = " + idcustomer;
            DataTable dt = db.SQLQuerySelect(sql);
            if (dt.Rows.Count == 0) { return; }
            DataRow dr = dt.Rows[0];

            string tipo = dr["tipo"].ToString();
            sCustomerName = dr["nome"].ToString() + " " + dr["cognome"].ToString();
            if (tipo == ((int)Library.Data.Clienti.eClientiTipo.Azienda).ToString())
            {
                sCustomerName = dr["azienda"].ToString();
            }
            sCustomerPhone = dr["tel1"].ToString();
            int idlistino = Convert.ToInt32(dr["idlistino"].ToString());

            btnRelatedTo.Text = sCustomerName;

            //get actual listino
            object oItem = cmbListino.SelectedItem;
            if (oItem == null) { return; }
            KeyValuePair<int, ItemListino> kvp = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
            int actualListino = kvp.Key;
            if (idlistino != -1 && idlistino !=actualListino)
            {
                cmbListino.SelectedValue = idlistino;
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
        private void SetComplementariVisibility(bool visibility)
        {
            btnColoriArmonici.Visible = visibility;
        }
        private void SelectTabViewFormula()
        {
            tabmain.SelectTab(1);
            if (!GVar.attivazioni.Act_CustomQuantityFormulation && cmbListino.Items.Count == 0)
            {
                MessageBox.Show(lang.GetWord("formula63"), lang.GetWord("formula64"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gbSearch_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tabmain_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.Clear(System.Drawing.Color.White);
            e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.White), e.Bounds);
            Rectangle r = e.Bounds;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Image img = TabImage32.Images[3];
            e.Graphics.DrawImage(img, 3, 3, img.Width, img.Height);

            StringFormat sf = new StringFormat();
            string text = lang.GetWord("formula01");
            Font f = new Font("Comfortaa", 12, FontStyle.Bold);
            e.Graphics.DrawString(text, f, new SolidBrush(System.Drawing.Color.FromArgb(0, 149, 66)), 40, 12, sf);

            if (e.Index == 1)
            {
                img = TabImage32.Images[4];
                e.Graphics.DrawImage(img, r.X + 3, r.Y + 3, img.Width, img.Height);
                e.Graphics.DrawString(lang.GetWord("formula65"), f, new SolidBrush(System.Drawing.Color.FromArgb(0, 149, 66)), r.X + img.Width + 12, 12, sf);
            }
        }
        private void SetCost(double dBase, double dColoranti, string sValuta)
        {
            lblBaseCost.Text = lang.GetWord("formula43") + ": " + Math.Round(dBase, 2).ToString() + " " + sValuta;
            lblColorantCost.Text = lang.GetWord("formula44") + ": " + Math.Round(dColoranti, 2).ToString() + " " + sValuta;
            lblTotalCost.Text = lang.GetWord("formula45") + ": " + (Math.Round(dBase, 2) + Math.Round(dColoranti, 2)).ToString() + " " + sValuta;
            gbCosti.Update();
            gbCosti.Refresh();
        }
        #endregion

        private void frmFormula_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception) { }
        }

        #region STRUCTURES
        class ItemListino
        {
            public int id;
            public string nome;
            public string valuta;
            public ItemListino(int id, string nome, string valuta)
            {
                this.id = id;
                this.nome = nome;
                this.valuta = valuta;
            }
            public override string ToString()
            {
                return nome;
            }
        }
        public class PackagePreProcessor
        {
            public double qtaBase;
            public string subLabel;
            public Library.Formulation.eUnita unitaBase;
            public bool bError = false;

            public PackagePreProcessor(string sData)
            {
                sData = sData.ToUpper();
                if (sData.EndsWith("LT"))
                {
                    sData = sData.Substring(0, sData.Length - 2);
                    unitaBase = Library.Formulation.eUnita.LT;
                    subLabel = "LT";
                }
                else if (sData.EndsWith("L"))
                {
                    sData = sData.Substring(0, sData.Length - 1);
                    unitaBase = Library.Formulation.eUnita.LT;
                    subLabel = "LT";
                }
                else if (sData.EndsWith("KG"))
                {
                    sData = sData.Substring(0, sData.Length - 2);
                    unitaBase = Library.Formulation.eUnita.KG;
                    subLabel = "KG";
                }
                else if (sData.EndsWith("K"))
                {
                    sData = sData.Substring(0, sData.Length - 1);
                    unitaBase = Library.Formulation.eUnita.KG;
                    subLabel = "KG";
                }
                else
                {
                    if (sData != "[ . . . ]")
                    {
                        bError = true;
                    }
                }

                if (!bError)
                {
                    qtaBase = Convert.ToDouble(sData.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
            }
        }

        #endregion

        private void dgTinte_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0)
                {
                    dgTinte.Cursor = Cursors.Default;
                    return;
                }
                if (e.ColumnIndex == 2 && dgTinte.Rows[e.RowIndex].Cells[4].Value.ToString() == "1")
                {
                    dgTinte.Cursor = Cursors.Hand;
                }
                else
                {
                    dgTinte.Cursor = Cursors.Default;
                }
            }
            catch (Exception)
            {
                dgTinte.Cursor = Cursors.Default;
            }   
        }

        /* CONTROLLER FORMULE PRECEDENTI */
        private Library.Formulation.Formula CheckForPrevFormula(Library.Formulation.Formula formula, bool bCheckHistory = true)
        {
            // controlla se esistono formule storiche
            if (bCheckHistory)
            {
                if (!HasHistory(formula.BaseProdotto, formula.FormulaName, formula.Use)) { return formula; }   
            }

            //apre una finestra dove le mostra e l'utente ne seleziona una
            frmFormulaPrev frmPrev = new frmFormulaPrev(formula.BaseProdotto, formula.FormulaName, formula.Use);
            frmPrev.ShowDialog();

            //si crea l'oggetto formula e lo si ritorna
            Library.Formulation.Formula selectedFormula = frmPrev.SelectedFormula;
            if (selectedFormula == null) { return formula; }
            return selectedFormula;
        }
        private bool HasHistory(string sProdotto, string sTinta, string sUso)
        {
            string sql = "SELECT COUNT(*) as numformule FROM formule_prev WHERE system = '" + sProdotto + "' AND colorname = '"+ sTinta +"' AND use = '"+ sUso +"'";
            DataTable dt = db.SQLQuerySelect(sql);
            int iNumFormule = Convert.ToInt32(dt.Rows[0]["numformule"].ToString());
            if (iNumFormule <= 0) { return false; }
            return true;
        }

        private void dgTinte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.eFrom != ePage.formula_selection && this.eFrom != ePage.color_search) { return; }
                if (!HasHistory(formula_originale.BaseProdotto, formula_originale.FormulaName, formula_originale.Use)) { return; }
                Library.Formulation.Formula current_formula_originale = formula_originale;
                formula_originale = CheckForPrevFormula(formula_originale, false);

                if (current_formula_originale != formula_originale)
                {
                    dgFormula.Rows.Clear();
                    ExecuteAfter_formulaOriginale_selected();
                    gbColorInfo.ForeColor = cFormulaWithPrev;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
