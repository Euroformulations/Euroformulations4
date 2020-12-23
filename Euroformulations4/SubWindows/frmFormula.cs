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
using Npgsql;
using System.Globalization;


namespace Euroformulations4.SubWindows
{
    public partial class frmFormula : Form
    {
        private Language lang = Language.GetInstance();
        DBConnect_Npgsql dbc = new DBConnect_Npgsql();
        Formula calcolaFormula = new Formula();
        AutoCompleteStringCollection datalist = new AutoCompleteStringCollection();
        NpgsqlDataReader risultatiole;
        private int Pre_IDFormula = -1;
        private bool actrounding = false;
        private static int IDCLIENTE = -1;
        int id_formula = 0;
        string doveSono = "MAINFORMULA";
        private TabPage pageColor = null;
        private static string TxtBaseFor = null;

        public frmFormula(int idFormula, string DV)
        {
            Pre_IDFormula = idFormula;
            doveSono = DV;
            InitializeComponent();
        }

        public frmFormula()
        {
            InitializeComponent();
        }

        public void Cleartxt()
        {
            btxt.Text = "";
            lattP.Visible = false;
            lattP.Text = "";
            Latt.Enabled = false;
            txtcustomer.Text = lang.GetWord("relatedTo");
            customer.Visible = false;
            listformularealeD.Rows.Clear();
            costototale.Text = "";
            txtcustomer.Visible = false;
            FormulaRounding.Visible = false;
            txtrounding.Visible = false;
        }

        private void MainFormula_Load(object sender, EventArgs e)
        {
            try
            {
                product.Text = lang.GetWord("formula01");
                Color.Text = lang.GetWord("formula02");
                TabPage2.Text = lang.GetWord("formula03");
                TabPage3.Text = lang.GetWord("formula04");
                history.Text = lang.GetWord("formula05");
                Label2.Text = lang.GetWord("formula06");
                Label3.Text = lang.GetWord("formula07");
                Label4.Text = lang.GetWord("formula08");
                Label5.Text = lang.GetWord("formula09");
                BSearch.Text = lang.GetWord("formula10");
                SearchAllItem.Columns[1].Text = lang.GetWord("formula11");
                SearchAllItem.Columns[2].Text = lang.GetWord("formula12");
                SearchAllItem.Columns[3].Text = lang.GetWord("formula13");
                SearchAllItem.Columns[4].Text = lang.GetWord("formula14");
                SearchAllItem.Columns[5].Text = lang.GetWord("formula15");
                Label6.Text = lang.GetWord("formula16");
                historylist.Columns[1].Text = lang.GetWord("formula11");
                historylist.Columns[2].Text = lang.GetWord("formula17");
                historylist.Columns[3].Text = lang.GetWord("formula12");
                historylist.Columns[4].Text = lang.GetWord("formula18");
                historylist.Columns[5].Text = lang.GetWord("formula13");
                historylist.Columns[6].Text = lang.GetWord("formula14");
                historylist.Columns[7].Text = lang.GetWord("formula15");
                Label1.Text = lang.GetWord("formula10");
                listcolor.Columns[0].Text = lang.GetWord("formula11");
                listcolor.Columns[1].Text = lang.GetWord("formula19");
                label7.Text = lang.GetWord("formula20");
                label8.Text = lang.GetWord("formula21");
                groupBox1.Text = lang.GetWord("formula22");
                label9.Text = lang.GetWord("formula13");
                label11.Text = lang.GetWord("formula23");
                label10.Text = lang.GetWord("formula24");
                label12.Text = lang.GetWord("formula25");
                listformularealeD.Columns[1].HeaderText = lang.GetWord("formula26");
                listformularealeD.Columns[2].HeaderText = lang.GetWord("formula27");
                listformularealeD.Columns[3].HeaderText = lang.GetWord("formula28");
                listformularealeD.Columns[4].HeaderText = lang.GetWord("formula29");
                listformularealeD.Columns[5].HeaderText = lang.GetWord("formula30");
                PrintFormula.Text = lang.GetWord("formula31");
                SendToDispenser.Text = lang.GetWord("formula32");
                Dispenser.Text = lang.GetWord("formula33");
                txtcustomer.Text = lang.GetWord("relatedTo");

                #region LINGUA
                TxtBaseFor = lang.GetWord("for");
                #endregion

                #region LICENZA
                if (GVar.attivazioni.Act__formulationRelatedTo) { customer.Visible = true; txtcustomer.Visible = true; } else { customer.Visible = false; txtcustomer.Visible = false; }
                if (!GVar.attivazioni.Act_CustomQuantityFormulation) { Latt.Items[0].Remove(); }
                if (!GVar.attivazioni.Act_History) { TabProductSelection.TabPages.Remove(history); };
                #endregion

                IniFile conf = new IniFile();

                Library.Data.Settings settings = new Library.Data.Settings();

                PriceListSelect.Text = settings.GetValue("listinoformulativo");

                if (settings.HasKey("stampa"))
                {
                    TypePrint.Text = settings.GetValue("stampa");
                }
                if (settings.HasKey("drivermachine"))
                {
                    Dispenser.Text = settings.GetValue("drivermachine");
                }

                GVar.DecimalNumber = Convert.ToInt32(settings.GetValue("DecimalNumber"));
                GVar.HistoryRecord = Convert.ToInt32(settings.GetValue("HistoryView"));
                TxtBaseFor = "for";
                Cleartxt();
                dbc.connect(Library.GVar.Database);
                pageColor = Color;
                if (Pre_IDFormula == -1 && doveSono == "MAINFORMULA")
                {
                    dbc.sqlview_ErrorSafe("SELECT DISTINCT(system) as PRODUCT, ordersystem FROM formule ORDER BY system", ref risultatiole);
                    while (risultatiole.Read())
                    {
                        selprodotto.Items.Add(risultatiole["PRODUCT"].ToString());
                    }
                    risultatiole.Close();

                    tabmain.TabPages.Remove(Color);
                }
                else
                {
                    if (doveSono == "RICERCACOLORE" || doveSono == "VISUALIZZACLIENTE_FORMULA")
                    {
                        #region ID formula dato da Esterno
                        id_formula = Pre_IDFormula;
                        ListViewItem itemexternalclick;

                        listcolor.Items.Clear();

                        dbc.sqlview_ErrorSafe("Select * From formule where id = " + id_formula, ref risultatiole);

                        risultatiole.Read();
                        string colornamePre_tmo = risultatiole["colorname"].ToString();
                        string systemPre_tmp = risultatiole["system"].ToString();
                        string colorchartsPre_tmp = risultatiole["colorcharts"].ToString();
                        string usePre_tmp = risultatiole["use"].ToString();
                        TxtProduct.Text = systemPre_tmp;
                        TxtColorcharts.Text = colorchartsPre_tmp;
                        TxtUse.Text = usePre_tmp;

                        selprodotto.Items.Clear();
                        risultatiole.Close();
                        dbc.sqlview_ErrorSafe("SELECT DISTINCT(system) as PRODUCT, ordersystem FROM formule ORDER BY ordersystem ASC", ref risultatiole);
                        while (risultatiole.Read())
                        {
                            selprodotto.Items.Add(risultatiole["PRODUCT"].ToString());
                        }
                        selprodotto.Text = systemPre_tmp;
                        risultatiole.Close();

                        selcharts.Items.Clear();
                        dbc.sqlview_ErrorSafe("SELECT DISTINCT(colorcharts) as CHARTS FROM formule WHERE system = '" + systemPre_tmp + "'", ref risultatiole);
                        while (risultatiole.Read())
                        {
                            selcharts.Items.Add(risultatiole["CHARTS"]);
                        }
                        selcharts.Text = colorchartsPre_tmp;
                        risultatiole.Close();

                        seluse.Items.Clear();
                        dbc.sqlview_ErrorSafe("SELECT DISTINCT(use) as INTEXT FROM formule WHERE system = '" + systemPre_tmp + "' AND colorcharts = '" + colorchartsPre_tmp + "'", ref risultatiole);
                        while (risultatiole.Read())
                        {
                            {
                                seluse.Items.Add(risultatiole["INTEXT"]);
                            }
                        }
                        seluse.Text = usePre_tmp;
                        risultatiole.Close();

                        dbc.sqlview_ErrorSafe("Select * From formule where system = '" + systemPre_tmp + "' and colorcharts = '" + colorchartsPre_tmp + "' and use = '" + usePre_tmp + "'", ref risultatiole);
                        while (risultatiole.Read())
                        {
                            string[] values = { "             ", risultatiole["colorname"].ToString(), "     ", risultatiole["id"].ToString(), risultatiole["base"].ToString() };
                            itemexternalclick = new ListViewItem(values);
                            listcolor.Items.Add(itemexternalclick);
                            listcolor.Items[listcolor.Items.Count - 1].UseItemStyleForSubItems = false;
                            listcolor.Items[listcolor.Items.Count - 1].SubItems[0].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
                        }
                        risultatiole.Close();
                        listcolor.Items[listcolor.FindItemWithText(colornamePre_tmo).Index].Selected = true;
                        listcolor.TopItem = listcolor.FindItemWithText(colornamePre_tmo);
                        if (!tabmain.TabPages.Contains(Color))
                        {
                            tabmain.TabPages.Add(Color);
                        }
                        tabmain.SelectTab(1);
                        listformularealeD.ClearSelection();
                        #endregion
                    }
                    else if (doveSono == "FORMULAPERSONALE")
                    {
                        #region ID formula dato da FORMULA PERSONALE

                        tabmain.TabPages.Remove(product);

                        id_formula = Pre_IDFormula;
                        ListViewItem itemexternalclick;

                        listcolor.Items.Clear();

                        dbc.sqlview_ErrorSafe("Select * From formule_personali where idp = " + id_formula, ref risultatiole);

                        risultatiole.Read();
                        string colornamePre_tmo = risultatiole["colorname"].ToString();
                        string systemPre_tmp = risultatiole["system"].ToString();
                        string colorchartsPre_tmp = risultatiole["colorcharts"].ToString();
                        string usePre_tmp = risultatiole["use"].ToString();
                        TxtProduct.Text = systemPre_tmp;
                        TxtColorcharts.Text = colorchartsPre_tmp;
                        TxtUse.Text = usePre_tmp;

                        selprodotto.Items.Clear();
                        risultatiole.Close();

                        dbc.sqlview_ErrorSafe("Select * From formule_personali where idp = " + id_formula, ref risultatiole);
                        while (risultatiole.Read())
                        {
                            string[] values = { "             ", risultatiole["colorname"].ToString(), "     ", risultatiole["idp"].ToString(), risultatiole["base"].ToString() };
                            itemexternalclick = new ListViewItem(values);
                            listcolor.Items.Add(itemexternalclick);
                            listcolor.Items[listcolor.Items.Count - 1].UseItemStyleForSubItems = false;
                            listcolor.Items[listcolor.Items.Count - 1].SubItems[0].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
                        }
                        risultatiole.Close();
                        listcolor.Items[listcolor.FindItemWithText(colornamePre_tmo).Index].Selected = true;
                        listcolor.TopItem = listcolor.FindItemWithText(colornamePre_tmo);

                        if (!tabmain.TabPages.Contains(Color))
                        {
                            tabmain.TabPages.Add(Color);
                        }
                        //tabmain.SelectTab(1);
                        customer.Visible = false;
                        txtcustomer.Visible = false;
                        listformularealeD.ClearSelection();
                        #endregion
                    }
                }

                #region POPOLAZIONE DEI LISTINI
                dbc.sqlview_ErrorSafe("SELECT * FROM listino ORDER BY nome_listino", ref risultatiole);
                while (risultatiole.Read())
                {
                    PriceListSelect.Items.Add(risultatiole["nome_listino"].ToString());
                }
                risultatiole.Close();
                #endregion

                #region POPOLAZIONE DEI DRIVER MACCHINA INSERITI
                dbc.sqlview_ErrorSafe("SELECT * FROM machine ORDER BY id_machine", ref risultatiole);
                while (risultatiole.Read())
                {
                    Dispenser.Items.Add(risultatiole["name"].ToString());
                }
                risultatiole.Close();
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selprodotto_Click(object sender, EventArgs e)
        {
            try
            {
                selcharts.Items.Clear();
                seluse.Items.Clear();
                dbc.sqlview_ErrorSafe("SELECT DISTINCT(colorcharts) as CHARTS FROM formule WHERE system = '" + selprodotto.Text + "' ORDER BY colorcharts", ref risultatiole);
                while (risultatiole.Read())
                {
                    selcharts.Items.Add(risultatiole["CHARTS"].ToString());
                }
                risultatiole.Close();

                if (tabmain.TabPages.Contains(Color))
                {
                    tabmain.TabPages.Remove(Color);
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
                dbc.sqlview_ErrorSafe("SELECT DISTINCT(use) as INTEXT FROM formule WHERE system = '" + selprodotto.Text + "' AND colorcharts = '" + selcharts.Text + "' ORDER BY use", ref risultatiole);
                while (risultatiole.Read())
                {
                    {
                        seluse.Items.Add(risultatiole["INTEXT"]);
                    }
                }
                risultatiole.Close();

                if (tabmain.TabPages.Contains(Color))
                {
                    tabmain.TabPages.Remove(Color);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //PROBLEMA DI LENTEZZA CON L'AUTOCOMPLETAMENTO
        private void seluse_Click(object sender, EventArgs e)
        {
            try
            {
                if (seluse.Text != "")
                {
                    this.Cursor = Cursors.WaitCursor;
                    ListViewItem itemricerca;
                    int tmp_item;
                    tmp_item = 0;

                    #region IMPOSTAZIONI CLEAR E DATA
                    datalist.Clear();
                    listcolor.Items.Clear();
                    TxtColorcharts.Text = selcharts.Text.ToString();
                    TxtProduct.Text = selprodotto.Text.ToString();
                    TxtUse.Text = seluse.Text.ToString();
                    #endregion

                    dbc.sqlview_ErrorSafe("SELECT * FROM formule WHERE system = '" + selprodotto.Text + "' AND colorcharts = '" + selcharts.Text + "' AND use = '" + seluse.Text + "' order by colorname", ref risultatiole);
                    while (risultatiole.Read())
                    {
                        string[] values = { "         ", risultatiole["colorname"].ToString(), "     ", risultatiole["id"].ToString(), risultatiole["base"].ToString() };
                        itemricerca = new ListViewItem(values);
                        listcolor.Items.Add(itemricerca);
                        listcolor.Items[tmp_item].UseItemStyleForSubItems = false;
                        listcolor.Items[tmp_item].SubItems[0].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
                        tmp_item = tmp_item + 1;
                        datalist.Add(risultatiole["colorname"].ToString());
                    }
                    risultatiole.Close();
                    Cleartxt();

                    //searchitem.AutoCompleteCustomSource = datalist;
                    this.Cursor = Cursors.Default;
                    if (tabmain.TabPages.Count == 1)
                        tabmain.TabPages.Add(this.pageColor);
                    tabmain.SelectTab(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cleartxt();

            if (listcolor.SelectedItems.Count > 0)
            {
                calcolaFormula.Clear();

                id_formula = Convert.ToInt32(listcolor.SelectedItems[0].SubItems[3].Text.ToString());

                Latt.Enabled = true;
                lattP.Visible = false;

                PriceListSelect.Enabled = true;

                if (doveSono == "FORMULAPERSONALE")
                {
                    calcolaFormula.ReadDb(id_formula, "formule_personali");
                }
                else
                {
                    calcolaFormula.ReadDb(id_formula); //Lettura VALORI FORMULA
                }
                //Valori Temporali per Lista pigmenti
                GVar.TMPcolorcharts = calcolaFormula.colorcharts;
                GVar.TMPsystem = calcolaFormula.system;
                GVar.TMPuse = calcolaFormula.use;
                GVar.TMPbase = calcolaFormula.sbase;

                //POPOLAZIONE MASCHERA CON CONTROLLO DATI PRESENTI
                nttxt.Text = calcolaFormula.colorname;
                btxt.Text = calcolaFormula.sbase;
                txtcustomer.Text = lang.GetWord("relatedTo");
                txtcustomer.Visible = true;
                customer.Visible = true;

                #region MASCHERA NOTE DA FARE
                Library.Data.Settings settings = new Library.Data.Settings();

                if (settings.GetValue("DeltaWarning") == "1")
                {
                    NoteTxt.Text = "DELTA: " + calcolaFormula.de.ToString();
                    if (calcolaFormula.note.Length > 0) { NoteTxt.Text = NoteTxt.Text + Environment.NewLine + lang.GetWord("formula41") + " " + calcolaFormula.note; }
                    if (calcolaFormula.nw == "NW") { NoteTxt.Text = NoteTxt.Text + Environment.NewLine + lang.GetWord("formula42"); }
                }
                #endregion

                if (calcolaFormula.fullp1 != "")
                {
                    listformularealeD.Rows.Add("", calcolaFormula.fullp1.ToString(), "", "", "", "");
                    listformularealeD.Rows[0].Cells[0].Style.BackColor = calcolaFormula.pr1;
                }
                if (calcolaFormula.fullp2 != "")
                {
                    listformularealeD.Rows.Add("", calcolaFormula.fullp2.ToString(), "", "", "", "");
                    listformularealeD.Rows[1].Cells[0].Style.BackColor = calcolaFormula.pr2;
                }
                if (calcolaFormula.fullp3 != "")
                {
                    listformularealeD.Rows.Add("", calcolaFormula.fullp3.ToString(), "", "", "", "");
                    listformularealeD.Rows[2].Cells[0].Style.BackColor = calcolaFormula.pr3;
                }
                if (calcolaFormula.fullp4 != "")
                {
                    listformularealeD.Rows.Add("", calcolaFormula.fullp4.ToString(), "", "", "", "");
                    listformularealeD.Rows[3].Cells[0].Style.BackColor = calcolaFormula.pr4;
                }
                if (calcolaFormula.fullp5 != "")
                {
                    listformularealeD.Rows.Add("", calcolaFormula.fullp5.ToString(), "", "", "", "");
                    listformularealeD.Rows[4].Cells[0].Style.BackColor = calcolaFormula.pr5;
                }

                cp.BackColor = listcolor.SelectedItems[0].SubItems[0].BackColor;
                this.Text = calcolaFormula.colorname; //Imposto il titolo della finestra

                #region LETTURA LATTAGGI SE PRESENTE UN LISTINO SELEZIONATO
                Latt.Items.Clear();

                #region GESTIONE LICENZA
                if (GVar.attivazioni.Act_CustomQuantityFormulation) { Latt.Items.Add("[ . . . ]"); Latt.Items[0].ImageIndex = 0; }
                #endregion

                if (PriceListSelect.Text.Length > 0)
                {
                    try
                    {
                        #region RECUPERO ID LISTINO
                        int ID_LISTINO = -1;
                        dbc.sqlview_ErrorSafe("SELECT * FROM listino WHERE nome_listino = '" + PriceListSelect.Text.Replace("'", "''") + "'", ref risultatiole);
                        risultatiole.Read();
                        ID_LISTINO = Convert.ToInt32(risultatiole["id_list"].ToString());
                        risultatiole.Close();
                        #endregion

                        if (ID_LISTINO != -1)
                        {
                            dbc.sqlview("Select * From lattaggi where id_listino = " + ID_LISTINO + " and nome_base_latt = '" + GVar.TMPbase + "'", ref risultatiole);
                            while (risultatiole.Read())
                            {
                                //string[] values = { risultatiole["lattaggio"].ToString() + " " + risultatiole["unita_lattaggio"].ToString() };
                                //listLatt = new ListViewItem(values);
                                Latt.Items.Add(risultatiole["lattaggio"].ToString() + " " + risultatiole["unita_lattaggio"].ToString());
                                Latt.Items[Latt.Items.Count - 1].ImageIndex = 1;
                            }
                            risultatiole.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                #endregion

                #region LICENZA
                if (GVar.attivazioni.Act__formulationRelatedTo) { customer.Visible = true; txtcustomer.Visible = true; } else { customer.Visible = false; txtcustomer.Visible = false; }
                if (GVar.attivazioni.Act_CustomQuantityFormulation) { Latt.Items[0].Text = "[ . . . ]"; }
                #endregion

                listformularealeD.ClearSelection();
            }

        }

        private void Latt_Click(object sender, EventArgs e)
        {
            if (Latt.FocusedItem.Index == 0 && GVar.attivazioni.Act_CustomQuantityFormulation)
            {
                lattP.Visible = true;
                lattP.Text = "[ . . . ]";
                lattP.Select(0, 10);
                lattP.Focus();
            }
            else
            {
                if (GVar.attivazioni.Act_CustomQuantityFormulation)
                {
                    lattP.Visible = false;
                    Latt.Items[0].SubItems[0].Text = "[ . . . ]";
                }
                string ls = "";
                ls = Latt.SelectedItems[0].SubItems[0].Text.ToString();
                if (ls.Contains("L"))
                {
                    ls = ls.Replace(" L", "").Trim().Replace(",", ".");
                    calcolaFormula.LattValue = Convert.ToDouble(ls.Replace(" L", "").Trim().Replace(",", "."), CultureInfo.InvariantCulture);
                    calcolaFormula.LattUnit = "LT";
                }
                else
                {
                    ls = ls.Replace(" KG", "").Trim().Replace(",", ".");
                    calcolaFormula.LattValue = Convert.ToDouble(ls.Replace(" KG", "").Trim().Replace(",", "."), CultureInfo.InvariantCulture);
                    calcolaFormula.LattUnit = "KG";
                }

                #region FORMULAZIONE DA LATTAGGI
                calcolaFormula.Formulation();
                btxt.Text = calcolaFormula.sbase + " " + TxtBaseFor + " " + calcolaFormula.LattValue + " " + calcolaFormula.LattUnit.Replace("LT", "L");

                if (calcolaFormula.p1 != "")
                {
                    listformularealeD.Rows[0].Cells[2].Value = Math.Round(calcolaFormula.qg1, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[0].Cells[3].Value = Math.Round(calcolaFormula.qml1, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[0].Cells[4].Value = Math.Round(calcolaFormula.qonce1, 0).ToString();
                }
                if (calcolaFormula.p2 != "")
                {
                    listformularealeD.Rows[1].Cells[2].Value = Math.Round(calcolaFormula.qg2, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[1].Cells[3].Value = Math.Round(calcolaFormula.qml2, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[1].Cells[4].Value = Math.Round(calcolaFormula.qonce2, 0).ToString();
                }
                if (calcolaFormula.p3 != "")
                {
                    listformularealeD.Rows[2].Cells[2].Value = Math.Round(calcolaFormula.qg3, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[2].Cells[3].Value = Math.Round(calcolaFormula.qml3, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[2].Cells[4].Value = Math.Round(calcolaFormula.qonce3, 0).ToString();
                }
                if (calcolaFormula.p4 != "")
                {
                    listformularealeD.Rows[3].Cells[2].Value = Math.Round(calcolaFormula.qg4, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[3].Cells[3].Value = Math.Round(calcolaFormula.qml4, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[3].Cells[4].Value = Math.Round(calcolaFormula.qonce4, 0).ToString();
                }
                if (calcolaFormula.p5 != "")
                {
                    listformularealeD.Rows[4].Cells[2].Value = Math.Round(calcolaFormula.qg5, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[4].Cells[3].Value = Math.Round(calcolaFormula.qml5, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[4].Cells[4].Value = Math.Round(calcolaFormula.qonce5, 0).ToString();
                }

                #endregion

                //Controllo che esista un listino
                if (PriceListSelect.Text.Length > 0)
                {
                    #region CALCOLO COSTI
                    calcolaFormula.ReadCost(PriceListSelect.Text.Replace("'", "''"), "lattaggio");
                    calcolaFormula.CostCalculation();
                    if (calcolaFormula.p1 != "")
                    {
                        listformularealeD.Rows[0].Cells[5].Value = Math.Round(calcolaFormula.costo1, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p2 != "")
                    {
                        listformularealeD.Rows[1].Cells[5].Value = Math.Round(calcolaFormula.costo2, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p3 != "")
                    {
                        listformularealeD.Rows[2].Cells[5].Value = Math.Round(calcolaFormula.costo3, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p4 != "")
                    {
                        listformularealeD.Rows[3].Cells[5].Value = Math.Round(calcolaFormula.costo4, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p5 != "")
                    {
                        listformularealeD.Rows[4].Cells[5].Value = Math.Round(calcolaFormula.costo5, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }

                    costototale.Text = lang.GetWord("formula43") + " " + Math.Round(calcolaFormula.costo_base, 2).ToString() + " " + calcolaFormula.costo_valuta + " " +
                        lang.GetWord("formula44") + " " + Math.Round((calcolaFormula.costo1 + calcolaFormula.costo2 + calcolaFormula.costo3 + calcolaFormula.costo4 + calcolaFormula.costo5), 2).ToString() + ""
                        + " " + calcolaFormula.costo_valuta + " " + lang.GetWord("formula45") + " " + Math.Round((calcolaFormula.costo_base + (calcolaFormula.costo1 + calcolaFormula.costo2 + calcolaFormula.costo3 + calcolaFormula.costo4 + calcolaFormula.costo5)), 2).ToString() + " " + calcolaFormula.costo_valuta;
                    #endregion
                }
            }
        }

        private void lattP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int ErrorValue = 0;
                if (e.KeyChar == Convert.ToChar(13))
                {
                    string TXT_tmp = "";
                    if (lattP.Text.ToUpper().Contains("LT"))
                    {
                        TXT_tmp = lattP.Text.Trim().Replace("lt", "");
                        TXT_tmp = TXT_tmp.Trim().Replace("Lt", "");
                        calcolaFormula.LattValue = Convert.ToDouble(TXT_tmp.Trim().Replace(".", ","));
                        calcolaFormula.LattUnit = "L";
                        TXT_tmp = TXT_tmp + " L";
                        Latt.Items[0].Text = TXT_tmp;
                        ErrorValue = 1;
                        btxt.Text = calcolaFormula.sbase + " " + TxtBaseFor + " " + TXT_tmp;
                    }
                    else if (lattP.Text.ToUpper().Contains("L"))
                    {
                        TXT_tmp = lattP.Text.Trim().Replace("l", "");
                        TXT_tmp = TXT_tmp.Trim().Replace("L", "");
                        calcolaFormula.LattValue = Convert.ToDouble(TXT_tmp.Trim().Replace(".", ","));
                        calcolaFormula.LattUnit = "L";
                        TXT_tmp = TXT_tmp + " L";
                        Latt.Items[0].Text = TXT_tmp;
                        ErrorValue = 1;
                        GVar.TMPqbase = TXT_tmp;
                        btxt.Text = calcolaFormula.sbase + " " + TxtBaseFor + " " + TXT_tmp;
                    }
                    else if (lattP.Text.ToUpper().Contains("KG") || lattP.Text.ToUpper().Contains("K"))
                    {
                        TXT_tmp = lattP.Text.Trim().Replace("kg", "");
                        TXT_tmp = TXT_tmp.Trim().Replace("KG", "");
                        TXT_tmp = TXT_tmp.Trim().Replace("K", "");
                        TXT_tmp = TXT_tmp.Trim().Replace("k", "");
                        calcolaFormula.LattValue = Convert.ToDouble(TXT_tmp.Trim().Replace(".", ","));
                        calcolaFormula.LattUnit = "KG";
                        TXT_tmp = TXT_tmp + " KG";
                        Latt.Items[0].Text = TXT_tmp;
                        ErrorValue = 1;

                        btxt.Text = calcolaFormula.sbase + " " + TxtBaseFor + " " + TXT_tmp;
                    }
                    else if (lattP.Text == "[ . . . ]")
                    {
                        btxt.Text = calcolaFormula.sbase;
                        TXT_tmp = "";
                        ErrorValue = 0;
                    }
                    else
                    {
                        MessageBox.Show(lang.GetWord("formula34"));
                        btxt.Text = calcolaFormula.sbase;
                        ErrorValue = 0;
                    }

                }

                if (Convert.ToBoolean(ErrorValue))
                {
                    lattP.Visible = false;
                    calcolaFormula.Formulation();

                    if (calcolaFormula.p1 != "")
                    {
                        listformularealeD.Rows[0].Cells[2].Value = Math.Round(calcolaFormula.qg1, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[0].Cells[3].Value = Math.Round(calcolaFormula.qml1, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[0].Cells[4].Value = Math.Round(calcolaFormula.qonce1, 0).ToString();
                    }
                    if (calcolaFormula.p2 != "")
                    {
                        listformularealeD.Rows[1].Cells[2].Value = Math.Round(calcolaFormula.qg2, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[1].Cells[3].Value = Math.Round(calcolaFormula.qml2, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[1].Cells[4].Value = Math.Round(calcolaFormula.qonce2, 0).ToString();
                    }
                    if (calcolaFormula.p3 != "")
                    {
                        listformularealeD.Rows[2].Cells[2].Value = Math.Round(calcolaFormula.qg3, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[2].Cells[3].Value = Math.Round(calcolaFormula.qml3, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[2].Cells[4].Value = Math.Round(calcolaFormula.qonce3, 0).ToString();
                    }
                    if (calcolaFormula.p4 != "")
                    {
                        listformularealeD.Rows[3].Cells[2].Value = Math.Round(calcolaFormula.qg4, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[3].Cells[3].Value = Math.Round(calcolaFormula.qml4, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[3].Cells[4].Value = Math.Round(calcolaFormula.qonce4, 0).ToString();
                    }
                    if (calcolaFormula.p5 != "")
                    {
                        listformularealeD.Rows[4].Cells[2].Value = Math.Round(calcolaFormula.qg5, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[4].Cells[3].Value = Math.Round(calcolaFormula.qml5, GVar.DecimalNumber).ToString();
                        listformularealeD.Rows[4].Cells[4].Value = Math.Round(calcolaFormula.qonce5, 0).ToString();
                    }

                    #region AZZERAMENTO COSTI
                    costototale.Text = "";
                    if (calcolaFormula.p1 != "") { listformularealeD.Rows[0].Cells[5].Value = ""; }
                    if (calcolaFormula.p2 != "") { listformularealeD.Rows[1].Cells[5].Value = ""; }
                    if (calcolaFormula.p3 != "") { listformularealeD.Rows[2].Cells[5].Value = ""; }
                    if (calcolaFormula.p4 != "") { listformularealeD.Rows[3].Cells[5].Value = ""; }
                    if (calcolaFormula.p5 != "") { listformularealeD.Rows[4].Cells[5].Value = ""; }
                    #endregion

                    //Controllo che esista un listino
                    if (PriceListSelect.Text.Length > 0)
                    {
                        #region CALCOLO COSTI
                        calcolaFormula.ReadCost(PriceListSelect.Text.Replace("'", "''"));
                        calcolaFormula.CostCalculation();
                        if (calcolaFormula.p1 != "")
                        {
                            listformularealeD.Rows[0].Cells[5].Value = Math.Round(calcolaFormula.costo1, 2).ToString() + " " + calcolaFormula.costo_valuta;
                        }
                        if (calcolaFormula.p2 != "")
                        {
                            listformularealeD.Rows[1].Cells[5].Value = Math.Round(calcolaFormula.costo2, 2).ToString() + " " + calcolaFormula.costo_valuta;
                        }
                        if (calcolaFormula.p3 != "")
                        {
                            listformularealeD.Rows[2].Cells[5].Value = Math.Round(calcolaFormula.costo3, 2).ToString() + " " + calcolaFormula.costo_valuta;
                        }
                        if (calcolaFormula.p4 != "")
                        {
                            listformularealeD.Rows[3].Cells[5].Value = Math.Round(calcolaFormula.costo4, 2).ToString() + " " + calcolaFormula.costo_valuta;
                        }
                        if (calcolaFormula.p5 != "")
                        {
                            listformularealeD.Rows[4].Cells[5].Value = Math.Round(calcolaFormula.costo5, 2).ToString() + " " + calcolaFormula.costo_valuta;
                        }

                        costototale.Text = lang.GetWord("formula43") + " " + Math.Round(calcolaFormula.costo_base, 2).ToString() + " " + calcolaFormula.costo_valuta + " " +
                            lang.GetWord("formula44") + " " + Math.Round((calcolaFormula.costo1 + calcolaFormula.costo2 + calcolaFormula.costo3 + calcolaFormula.costo4 + calcolaFormula.costo5), 2).ToString() +
                            " " + calcolaFormula.costo_valuta + " " + lang.GetWord("formula45") + " " + Math.Round((calcolaFormula.costo_base + (calcolaFormula.costo1 + calcolaFormula.costo2 + calcolaFormula.costo3 + calcolaFormula.costo4 + calcolaFormula.costo5)), 2).ToString() + " " + calcolaFormula.costo_valuta;
                        #endregion
                    }
                    //ATTIVO IL Formula ROUNDING
                    FormulaRounding.Visible = true;
                    txtrounding.Visible = true;
                    actrounding = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("formula34"));
            }

        }

        private void TabProductSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (TabProductSelection.SelectedIndex + 1)
                {
                    case 3:
                        #region HISTORY TAB SELECTION
                        ListViewItem itemhistory;
                        dbc.sqlview_ErrorSafe("Select * From history order by id DESC LIMIT " + GVar.HistoryRecord, ref risultatiole);
                        historylist.Items.Clear();
                        while (risultatiole.Read())
                        {
                            string[] values = { risultatiole["id"].ToString(), "       ", risultatiole["dateformula"].ToString(), risultatiole["colorname"].ToString(), risultatiole["formulasize"].ToString().Replace(".", ",").Replace("-", " "), risultatiole["system"].ToString(), risultatiole["colorcharts"].ToString(), risultatiole["use"].ToString() };
                            itemhistory = new ListViewItem(values);
                            historylist.Items.Add(itemhistory);
                            historylist.Items[historylist.Items.Count - 1].UseItemStyleForSubItems = false;
                            historylist.Items[historylist.Items.Count - 1].SubItems[1].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
                        }
                        risultatiole.Close();
                        break;
                        #endregion

                    case 4:
                        #region FORMULE PERSONALI TAB
                        /*
                        ListViewItem PersonalF;
                        dbc.sqlview_ErrorSafe("Select * From formule_personali order by id DESC", ref risultatiole);
                        PersonalFormulations.Items.Clear();
                        while (risultatiole.Read())
                        {
                            string[] values = { risultatiole["id"].ToString(), "       ", risultatiole["dateformula"].ToString(), risultatiole["colorname"].ToString(), risultatiole["formulasize"].ToString().Replace(".", ",").Replace("-", " "), risultatiole["system"].ToString(), risultatiole["colorcharts"].ToString(), risultatiole["use"].ToString() };
                            PersonalF = new ListViewItem(values);
                            PersonalFormulations.Items.Add(PersonalF);
                            PersonalFormulations.Items[PersonalFormulations.Items.Count - 1].UseItemStyleForSubItems = false;
                            PersonalFormulations.Items[PersonalFormulations.Items.Count - 1].SubItems[1].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
                        }
                        risultatiole.Close();*/
                        break;
                        #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendToDispenser_Click(object sender, EventArgs e)
        {

            Library.Data.Settings settings = new Library.Data.Settings();

            string tipo_dispenser = "NULL";
            string filepath = "NULL";
            string exefile = "NULL";

            if (settings.GetValue("BarCodeStatus") == "SI")
            {
                string Response = Interaction.InputBox(lang.GetWord("formula47"), lang.GetWord("formula46"), " ");
                if (calcolaFormula.barcode == Response)
                {
                    if (calcolaFormula.LattUnit != "")
                    {
                        SendToDispenser.Enabled = false;

                        #region history
                        string TmpSql;
                        TmpSql = calcolaFormula.SaveHistory("MILLILITER", "", calcolaFormula.LattValue + "-" + calcolaFormula.LattUnit);
                        #endregion

                        #region MACHINE
                        #region read configuration machine

                        dbc.sqlview_ErrorSafe("SELECT * FROM machine WHERE name = '" + Dispenser.Text + "'", ref risultatiole);
                        while (risultatiole.Read())
                        {
                            tipo_dispenser = risultatiole["tipo_driver"].ToString();
                            filepath = risultatiole["pathfile"].ToString();
                            exefile = risultatiole["exefile"].ToString();
                        }
                        risultatiole.Close();
                        #endregion
                        calcolaFormula.SendToDispenser(tipo_dispenser, filepath, exefile);

                        MessageBox.Show(lang.GetWord("formula36"), lang.GetWord("formula35"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion

                        SendToDispenser.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(lang.GetWord("formula37"), lang.GetWord("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(lang.GetWord("formula38"), lang.GetWord("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (calcolaFormula.LattUnit != "")
                {
                    SendToDispenser.Enabled = false;

                    #region history
                    string TmpSql;
                    TmpSql = calcolaFormula.SaveHistory("MILLILITER", "", calcolaFormula.LattValue + "-" + calcolaFormula.LattUnit);
                    #endregion

                    #region MACHINE
                    #region read configuration machine

                    dbc.sqlview_ErrorSafe("SELECT * FROM machine WHERE name = '" + Dispenser.Text + "'", ref risultatiole);
                    while (risultatiole.Read())
                    {
                        tipo_dispenser = risultatiole["tipo_driver"].ToString();
                        filepath = risultatiole["pathfile"].ToString();
                        exefile = risultatiole["exefile"].ToString();
                    }
                    risultatiole.Close();
                    #endregion
                    calcolaFormula.SendToDispenser(tipo_dispenser, filepath, exefile);

                    MessageBox.Show(lang.GetWord("formula36"), lang.GetWord("formula35"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endregion

                    SendToDispenser.Enabled = true;
                }
                else
                {
                    MessageBox.Show(lang.GetWord("formula37"), lang.GetWord("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void historylist_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                id_formula = Convert.ToInt32(historylist.SelectedItems[0].SubItems[0].Text.ToString());
                ListViewItem itemhystoriclick;

                listcolor.Items.Clear();

                dbc.sqlview_ErrorSafe("Select * From formule where system = '" + historylist.SelectedItems[0].SubItems[5].Text.ToString() + "' and colorcharts = '" + historylist.SelectedItems[0].SubItems[6].Text.ToString() + "' and use = '" + historylist.SelectedItems[0].SubItems[7].Text.ToString() + "'", ref risultatiole);

                string systemPre_tmp = historylist.SelectedItems[0].SubItems[5].Text.ToString();
                string colorchartsPre_tmp = historylist.SelectedItems[0].SubItems[6].Text.ToString();
                string usePre_tmp = historylist.SelectedItems[0].SubItems[7].Text.ToString();
                TxtProduct.Text = systemPre_tmp;
                TxtColorcharts.Text = colorchartsPre_tmp;
                TxtUse.Text = usePre_tmp;

                while (risultatiole.Read())
                {
                    string[] values = { "             ", risultatiole["colorname"].ToString(), "     ", risultatiole["id"].ToString(), risultatiole["base"].ToString() };
                    itemhystoriclick = new ListViewItem(values);
                    listcolor.Items.Add(itemhystoriclick);
                    listcolor.Items[listcolor.Items.Count - 1].UseItemStyleForSubItems = false;
                    listcolor.Items[listcolor.Items.Count - 1].SubItems[0].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
                }
                risultatiole.Close();
                listcolor.Items[listcolor.FindItemWithText(historylist.SelectedItems[0].SubItems[3].Text.ToString()).Index].Selected = true;
                listcolor.TopItem = listcolor.FindItemWithText(historylist.SelectedItems[0].SubItems[3].Text.ToString());

                if (tabmain.TabPages.Count == 1)
                    tabmain.TabPages.Add(this.pageColor);
                tabmain.SelectTab(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BSearch_Click(object sender, EventArgs e)
        {

            if (searchcolor.Text.Length > 0)
            {
                ListViewItem Itemricerca;
                SearchAllItem.Items.Clear();

                dbc.sqlview_ErrorSafe("SELECT * FROM formule where LOWER(colorname) LIKE '%" + searchcolor.Text.ToLower() + "%'", ref risultatiole);
                while (risultatiole.Read())
                {
                    string[] values = { risultatiole["id"].ToString(), "             ", risultatiole["colorname"].ToString(), risultatiole["system"].ToString(), risultatiole["colorcharts"].ToString(), risultatiole["use"].ToString(), risultatiole["base"].ToString(), risultatiole["R"].ToString(), risultatiole["G"].ToString(), risultatiole["B"].ToString() };
                    Itemricerca = new ListViewItem(values);
                    SearchAllItem.Items.Add(Itemricerca);
                    SearchAllItem.Items[SearchAllItem.Items.Count - 1].UseItemStyleForSubItems = false;
                    SearchAllItem.Items[SearchAllItem.Items.Count - 1].SubItems[1].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
                }
                risultatiole.Close();
            }
        }

        private void SearchAllItem_DoubleClick(object sender, EventArgs e)
        {
            #region ID formula dato da Esterno
            id_formula = Convert.ToInt32(SearchAllItem.SelectedItems[0].SubItems[0].Text.ToString());
            ListViewItem itemexternalclick;

            listcolor.Items.Clear();

            dbc.sqlview_ErrorSafe("Select * From formule where id = " + id_formula, ref risultatiole);

            risultatiole.Read();
            string colornamePre_tmo = risultatiole["colorname"].ToString();
            string systemPre_tmp = risultatiole["system"].ToString();
            string colorchartsPre_tmp = risultatiole["colorcharts"].ToString();
            string usePre_tmp = risultatiole["use"].ToString();
            TxtProduct.Text = systemPre_tmp;
            TxtColorcharts.Text = colorchartsPre_tmp;
            TxtUse.Text = usePre_tmp;

            selprodotto.Items.Clear();
            risultatiole.Close();
            dbc.sqlview_ErrorSafe("SELECT DISTINCT(system) as PRODUCT, ordersystem FROM formule ORDER BY ordersystem ASC", ref risultatiole);
            while (risultatiole.Read())
            {
                selprodotto.Items.Add(risultatiole["PRODUCT"].ToString());
            }
            selprodotto.Text = systemPre_tmp;
            risultatiole.Close();

            selcharts.Items.Clear();
            dbc.sqlview_ErrorSafe("SELECT DISTINCT(colorcharts) as CHARTS FROM formule WHERE system = '" + systemPre_tmp + "'", ref risultatiole);
            while (risultatiole.Read())
            {
                selcharts.Items.Add(risultatiole["CHARTS"]);
            }
            selcharts.Text = colorchartsPre_tmp;
            risultatiole.Close();

            seluse.Items.Clear();
            dbc.sqlview_ErrorSafe("SELECT DISTINCT(use) as INTEXT FROM formule WHERE system = '" + systemPre_tmp + "' AND colorcharts = '" + colorchartsPre_tmp + "'", ref risultatiole);
            while (risultatiole.Read())
            {
                {
                    seluse.Items.Add(risultatiole["INTEXT"]);
                }
            }
            seluse.Text = usePre_tmp;
            risultatiole.Close();

            dbc.sqlview_ErrorSafe("Select * From formule where system = '" + systemPre_tmp + "' and colorcharts = '" + colorchartsPre_tmp + "' and use = '" + usePre_tmp + "'", ref risultatiole);
            while (risultatiole.Read())
            {
                string[] values = { "             ", risultatiole["colorname"].ToString(), "     ", risultatiole["id"].ToString(), risultatiole["base"].ToString() };
                itemexternalclick = new ListViewItem(values);
                listcolor.Items.Add(itemexternalclick);
                listcolor.Items[listcolor.Items.Count - 1].UseItemStyleForSubItems = false;
                listcolor.Items[listcolor.Items.Count - 1].SubItems[0].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(risultatiole["R"].ToString()), Convert.ToInt32(risultatiole["G"].ToString()), Convert.ToInt32(risultatiole["B"].ToString()));
            }
            risultatiole.Close();
            listcolor.Items[listcolor.FindItemWithText(colornamePre_tmo).Index].Selected = true;
            listcolor.TopItem = listcolor.FindItemWithText(colornamePre_tmo);

            if (tabmain.TabPages.Count == 1)
                tabmain.TabPages.Add(this.pageColor);
            tabmain.SelectTab(1);
            #endregion
        }

        private void ButtonMouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = null;
            btn.BackColor = System.Drawing.Color.LightGray;
        }

        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Euroformulations4.Properties.Resources.button_content_lightblu;
            btn.BackColor = System.Drawing.Color.Transparent;
        }

        private void searchitem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listcolor.Items[listcolor.FindItemWithText(searchitem.Text).Index].Selected = true;
                listcolor.TopItem = listcolor.FindItemWithText(searchitem.Text);
            }
            catch (Exception)
            {
                //TO DO - DA RICONTROLLARE
            }
        }

        //DA IMPLEMENTARE
        private void PrintFormula_Click(object sender, EventArgs e)
        {
            if (PrintDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Library.GVar.TabAperta = 1;
                PrintPreviewDialog1.Document = PrintTablep;
                PrintPreviewDialog1.ShowDialog();
            }
            /*
            var label = DYMO.Label.Framework.Label.Open(System.Windows.Forms.Application.StartupPath + "/layout/41x89_logoef4.label");

            label.SetObjectText("barcode", "801349163255");
            label.SetObjectText("nometinta", nttxt.Text);
            label.SetObjectText("system", TxtProduct.Text);
            label.SetObjectText("colorcharts", TxtColorcharts.Text);
            label.SetObjectText("use", TxtUse.Text);
            label.Print("DYMO LabelWriter 450");
            */

        }

        private void customer_Click(object sender, EventArgs e)
        {
            #region RELETED TO
            string NowDate = null;
            DateTime NowDateTMP = DateTime.Now;
            NowDate = NowDateTMP.ToString("yyyy-MM-dd HH:mm:ss");
            int Error_Insert = -1;
            string Sql;
            try
            {
                Clienti.frmVisualizzaCliente form = new Clienti.frmVisualizzaCliente("MAIN FORMULA");
                form.ShowDialog();
                IDCLIENTE = form.REQUEST_IDCliente;

                dbc.sqlview_ErrorSafe("SELECT * FROM clienti WHERE id = " + IDCLIENTE, ref risultatiole);
                while (risultatiole.Read())
                {
                    txtcustomer.Text = risultatiole["nome"].ToString() + " " + risultatiole["cognome"].ToString();
                }

                Sql = "INSERT INTO clienti_seq (id_cliente,id_fdefault,date_seq,size)";
                Sql = Sql + "VALUES (" + IDCLIENTE + "," + calcolaFormula.idFormula + ",'" + NowDate + "','" + calcolaFormula.LattValue + "-" + calcolaFormula.LattUnit + "')";
                Error_Insert = dbc.SQLExe_ErrorSafe_Int(Sql);

                if (Error_Insert == -1)
                {
                    MessageBox.Show(lang.GetWord("formula40"), lang.GetWord("formula39"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                risultatiole.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void PriceListSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Lettura lattaggi
            Latt.Items.Clear();

            #region LICENZA
            if (GVar.attivazioni.Act_CustomQuantityFormulation)
            {
                Latt.Items.Add("[ . . . ]");
                Latt.Items[0].ImageIndex = 2;
            }
            #endregion

            if (PriceListSelect.Text.Length > 0)
            {
                #region RECUPERO ID LISTINO
                int ID_LISTINO = -1;
                dbc.sqlview_ErrorSafe("SELECT * FROM listino WHERE nome_listino = '" + PriceListSelect.Text.Replace("'", "''") + "'", ref risultatiole);
                risultatiole.Read();
                ID_LISTINO = Convert.ToInt32(risultatiole["id_list"].ToString());
                risultatiole.Close();
                #endregion

                if (ID_LISTINO != -1)
                {
                    dbc.sqlview_ErrorSafe("Select * From lattaggi where id_listino = " + ID_LISTINO + " and nome_base_latt = '" + GVar.TMPbase + "'", ref risultatiole);
                    while (risultatiole.Read())
                    {
                        //string[] values = { risultatiole["lattaggio"].ToString() + " " + risultatiole["unita_lattaggio"].ToString() };
                        //listLatt = new ListViewItem(values);
                        Latt.Items.Add(risultatiole["lattaggio"].ToString() + " " + risultatiole["unita_lattaggio"].ToString());
                        Latt.Items[Latt.Items.Count - 1].ImageIndex = 3;
                    }
                    risultatiole.Close();
                }
            }
            #endregion

            #region AZZERAMENTO COSTI
            costototale.Text = "";
            if (calcolaFormula.p1 != "") { listformularealeD.Rows[0].Cells[5].Value = ""; }
            if (calcolaFormula.p2 != "") { listformularealeD.Rows[1].Cells[5].Value = ""; }
            if (calcolaFormula.p3 != "") { listformularealeD.Rows[2].Cells[5].Value = ""; }
            if (calcolaFormula.p4 != "") { listformularealeD.Rows[3].Cells[5].Value = ""; }
            if (calcolaFormula.p5 != "") { listformularealeD.Rows[4].Cells[5].Value = ""; }
            #endregion

            #region SALVATAGGIO IN SETTINGS
            Library.Data.Settings settings = new Library.Data.Settings();
            settings.SetValue("listinoformulativo", PriceListSelect.Text.Replace("'", "''"));
            #endregion
        }

        private void frmFormula_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbc.disconnect();
        }

        private void PrintTablep_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font FontB = new Font("Conforta", 14, FontStyle.Bold);
            Font FontBn = new Font("Conforta", 14, FontStyle.Regular);
            Font FontNb = new Font("Conforta", 12, FontStyle.Bold);
            Font FontN = new Font("Conforta", 12);

            if (TypePrint.Text == "A4 Print Formula")
            {

                System.Drawing.Image img = System.Drawing.Image.FromFile(Application.StartupPath + "\\mylogo.png");
                Point loc = new Point(50, 50);
                e.Graphics.DrawImage(img, loc);

                e.Graphics.DrawString(lang.GetWord("formula48") + " ", FontNb, Brushes.Black, 50, 150);
                e.Graphics.DrawString(calcolaFormula.sbase, FontN, Brushes.Black, 250, 150);
                e.Graphics.DrawString(Math.Round(calcolaFormula.LattValue, 2) + " " + calcolaFormula.LattUnit, FontN, Brushes.Black, 500, 150);
                e.Graphics.DrawString(Math.Round(calcolaFormula.costo_base, 2) + " " + calcolaFormula.costo_valuta, FontN, Brushes.Black, 650, 150);

                if (calcolaFormula.fullp1.Length > 0)
                {
                    e.Graphics.DrawString(lang.GetWord("formula49") + " ", FontNb, Brushes.Black, 50, 200);
                    e.Graphics.DrawString(calcolaFormula.fullp1, FontN, Brushes.Black, 250, 200);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.qg1, 2) + " gr.", FontN, Brushes.Black, 500, 200);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.costo1, 2) + " " + calcolaFormula.costo_valuta, FontN, Brushes.Black, 650, 200);
                }
                if (calcolaFormula.fullp2.Length > 0)
                {
                    e.Graphics.DrawString(lang.GetWord("formula50") + " ", FontNb, Brushes.Black, 50, 230);
                    e.Graphics.DrawString(calcolaFormula.fullp2, FontN, Brushes.Black, 250, 230);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.qg2, 2) + " gr.", FontN, Brushes.Black, 500, 230);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.costo2, 2) + " " + calcolaFormula.costo_valuta, FontN, Brushes.Black, 650, 230);
                }
                if (calcolaFormula.fullp3.Length > 0)
                {
                    e.Graphics.DrawString(lang.GetWord("formula51") + " ", FontNb, Brushes.Black, 50, 260);
                    e.Graphics.DrawString(calcolaFormula.fullp3, FontN, Brushes.Black, 250, 260);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.qg3, 2) + " gr.", FontN, Brushes.Black, 500, 260);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.costo3, 2) + " " + calcolaFormula.costo_valuta, FontN, Brushes.Black, 650, 260);
                }
                if (calcolaFormula.fullp4.Length > 0)
                {
                    e.Graphics.DrawString(lang.GetWord("formula52") + " ", FontNb, Brushes.Black, 50, 290);
                    e.Graphics.DrawString(calcolaFormula.fullp4, FontN, Brushes.Black, 250, 290);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.qg4, 2) + " gr.", FontN, Brushes.Black, 500, 290);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.costo4, 2) + " " + calcolaFormula.costo_valuta, FontN, Brushes.Black, 650, 290);
                }
                if (calcolaFormula.fullp5.Length > 0)
                {
                    e.Graphics.DrawString(lang.GetWord("formula53") + " ", FontNb, Brushes.Black, 50, 320);
                    e.Graphics.DrawString(calcolaFormula.fullp5, FontN, Brushes.Black, 250, 320);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.qg5, 2) + " gr.", FontN, Brushes.Black, 500, 320);
                    e.Graphics.DrawString(Math.Round(calcolaFormula.costo5, 2) + " " + calcolaFormula.costo_valuta, FontN, Brushes.Black, 650, 320);
                }

                //TOTALE COSTO e SOMMA PIGMENTI
                e.Graphics.DrawString(lang.GetWord("formula54") + " ", FontNb, Brushes.Black, 50, 350);
                e.Graphics.DrawString(Math.Round(calcolaFormula.qg1 + calcolaFormula.qg2 + calcolaFormula.qg3 + calcolaFormula.qg4 + calcolaFormula.qg5, 2) + " gr.", FontN, Brushes.Black, 500, 350);
                e.Graphics.DrawString(Math.Round(calcolaFormula.costo1 + calcolaFormula.costo2 + calcolaFormula.costo3 + calcolaFormula.costo4 + calcolaFormula.costo5 + calcolaFormula.costo_base, 2) + " " + calcolaFormula.costo_valuta, FontN, Brushes.Black, 650, 350);

            }

        }

        private void TypePrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region SALVATAGGIO IN SETTINGS
            Library.Data.Settings settings = new Library.Data.Settings();
            settings.SetValue("stampa", TypePrint.Text);
            #endregion
        }

        private void Dispenser_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region SALVATAGGIO IN SETTINGS
            Library.Data.Settings settings = new Library.Data.Settings();
            settings.SetValue("drivermachine", Dispenser.Text);
            #endregion
        }

        private void listformularealeD_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 1)
                e.Cancel = true;
        }

        private void FormulaRounding_Click(object sender, EventArgs e)
        {
            if (actrounding)
            {
                calcolaFormula.FormulationRounding();

                if (calcolaFormula.p1 != "")
                {
                    listformularealeD.Rows[0].Cells[2].Value = Math.Round(calcolaFormula.qg1, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[0].Cells[3].Value = Math.Round(calcolaFormula.qml1, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[0].Cells[4].Value = Math.Round(calcolaFormula.qonce1, 0).ToString();
                }
                if (calcolaFormula.p2 != "")
                {
                    listformularealeD.Rows[1].Cells[2].Value = Math.Round(calcolaFormula.qg2, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[1].Cells[3].Value = Math.Round(calcolaFormula.qml2, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[1].Cells[4].Value = Math.Round(calcolaFormula.qonce2, 0).ToString();
                }
                if (calcolaFormula.p3 != "")
                {
                    listformularealeD.Rows[2].Cells[2].Value = Math.Round(calcolaFormula.qg3, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[2].Cells[3].Value = Math.Round(calcolaFormula.qml3, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[2].Cells[4].Value = Math.Round(calcolaFormula.qonce3, 0).ToString();
                }
                if (calcolaFormula.p4 != "")
                {
                    listformularealeD.Rows[3].Cells[2].Value = Math.Round(calcolaFormula.qg4, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[3].Cells[3].Value = Math.Round(calcolaFormula.qml4, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[3].Cells[4].Value = Math.Round(calcolaFormula.qonce4, 0).ToString();
                }
                if (calcolaFormula.p5 != "")
                {
                    listformularealeD.Rows[4].Cells[2].Value = Math.Round(calcolaFormula.qg5, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[4].Cells[3].Value = Math.Round(calcolaFormula.qml5, GVar.DecimalNumber).ToString();
                    listformularealeD.Rows[4].Cells[4].Value = Math.Round(calcolaFormula.qonce5, 0).ToString();
                }

                #region AZZERAMENTO COSTI
                costototale.Text = "";
                if (calcolaFormula.p1 != "") { listformularealeD.Rows[0].Cells[5].Value = ""; }
                if (calcolaFormula.p2 != "") { listformularealeD.Rows[1].Cells[5].Value = ""; }
                if (calcolaFormula.p3 != "") { listformularealeD.Rows[2].Cells[5].Value = ""; }
                if (calcolaFormula.p4 != "") { listformularealeD.Rows[3].Cells[5].Value = ""; }
                if (calcolaFormula.p5 != "") { listformularealeD.Rows[4].Cells[5].Value = ""; }
                #endregion

                //Controllo che esista un listino
                if (PriceListSelect.Text.Length > 0)
                {
                    #region CALCOLO COSTI
                    calcolaFormula.ReadCost(PriceListSelect.Text.Replace("'", "''"));
                    calcolaFormula.CostCalculation();
                    if (calcolaFormula.p1 != "")
                    {
                        listformularealeD.Rows[0].Cells[5].Value = Math.Round(calcolaFormula.costo1, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p2 != "")
                    {
                        listformularealeD.Rows[1].Cells[5].Value = Math.Round(calcolaFormula.costo2, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p3 != "")
                    {
                        listformularealeD.Rows[2].Cells[5].Value = Math.Round(calcolaFormula.costo3, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p4 != "")
                    {
                        listformularealeD.Rows[3].Cells[5].Value = Math.Round(calcolaFormula.costo4, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }
                    if (calcolaFormula.p5 != "")
                    {
                        listformularealeD.Rows[4].Cells[5].Value = Math.Round(calcolaFormula.costo5, 2).ToString() + " " + calcolaFormula.costo_valuta;
                    }

                    costototale.Text = lang.GetWord("formula43") + " " + Math.Round(calcolaFormula.costo_base, 2).ToString() + " " + calcolaFormula.costo_valuta + " " +
                        lang.GetWord("formula44") + " " + Math.Round((calcolaFormula.costo1 + calcolaFormula.costo2 + calcolaFormula.costo3 + calcolaFormula.costo4 + calcolaFormula.costo5), 2).ToString() +
                        " " + calcolaFormula.costo_valuta + " " + lang.GetWord("formula45") + " " + Math.Round((calcolaFormula.costo_base + (calcolaFormula.costo1 + calcolaFormula.costo2 + calcolaFormula.costo3 + calcolaFormula.costo4 + calcolaFormula.costo5)), 2).ToString() + " " + calcolaFormula.costo_valuta;
                    #endregion
                }
                btxt.Text = calcolaFormula.sbase + " " + TxtBaseFor + " " + Math.Round(calcolaFormula.LattValue, GVar.DecimalNumber).ToString() + " " + calcolaFormula.LattUnit;
                actrounding = false;
            }
        }

    }
}
