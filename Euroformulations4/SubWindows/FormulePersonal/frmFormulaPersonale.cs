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
using Euroformulations4.SubWindows.Clienti;

namespace Euroformulations4.SubWindows.FormulePersonal
{
    public enum ePage
    {
        formula_selection = 0,
        formule_personali = 1,
        view_formule_personali = 2
    }
    public partial class frmFormulaPersonale : Form
    {
        ePage ePageFrom = ePage.formule_personali;
        private Library.Formulation.Formula formula = null;
        private Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
        private Library.Data.DBSettings settings = new Library.Data.DBSettings();
        private Language lang = Language.GetInstance();
        private bool bEditAsOunce = false;
        private Button[] buttonOunce = new Button[5];
        private Library.Data.Database.DBConnector db;
        private static int R, G, B = 0;
        private static double X, Y, Z, CieL, Ciea, Cieb = 0;
        private ToolTip tp = new ToolTip();
        private bool bGoViewSavedFormula = false;
        private int IDFormulaPersView = -1;
        private bool bModificato = false;
        private int iPreSelected_IDCustomer = -1;
        private List<double> dCostiCol = new List<double>();
        private double dCostoBase = 0d;
        private string sValuta = "";
        private Dictionary<string, string> dicNomeColCode;
        private Dictionary<string, double> dicCodeColDensita;
        
        int iCifreDecimali = -1;

        public frmFormulaPersonale(Library.Formulation.Formula formula, ePage ePageFrom)
        {
            InitializeComponent();

            this.formula = formula;
            this.ePageFrom = ePageFrom;

            db = new Library.Data.Database.DBConnector();
            dicNomeColCode = new Dictionary<string, string>();
            dicCodeColDensita = new Dictionary<string, double>();
            for (int i = 0; i < buttonOunce.Length; i++)
            {
                Button b = new Button();
                b.Text = "oz " + (i + 1).ToString();
                b.Size = new Size(70, 30);
                b.Tag = i.ToString();
                buttonOunce[i] = b;
                b.MouseEnter += (s, e) => b.Cursor = Cursors.Hand;
                b.MouseLeave += (s, e) => b.Cursor = Cursors.Default;
                b.EnabledChanged += new EventHandler(OzButton_EnabledChanged);
                b.Enabled = false;
            }
        }

        #region PROPERTIES
        public bool GoViewSavedFormula
        {
            get { return bGoViewSavedFormula; }
        }
        public bool EditAsOunce { set { this.bEditAsOunce = value; } }
        public int PreSelected_IDCustomer
        {
            set { this.iPreSelected_IDCustomer = value; }
        }
        public int IDFormulaPersonaleView
        {
            get { return IDFormulaPersView; }
        }
        #endregion

        private void frmFormulaPersonale_Load(object sender, EventArgs e)
        {
            #region Traduzioni
            label2.Text = lang.GetWord("fper02");
            label3.Text = lang.GetWord("fper03");
            label4.Text = lang.GetWord("fper04");
            groupBox2.Text = lang.GetWord("fper05");
            lblBaseName.Text = lang.GetWord("fper70");
            lblBaseQuantity.Text = lang.GetWord("fper46");
            lblBaseUM.Text = lang.GetWord("fper71");
            label10.Text = lang.GetWord("fper72");
            ql1.Text = lang.GetWord("fper08");
            ql2.Text = lang.GetWord("fper08");
            ql3.Text = lang.GetWord("fper08");
            ql4.Text = lang.GetWord("fper08");
            ql5.Text = lang.GetWord("fper08");
            label7.Text = lang.GetWord("fper09");
            label8.Text = lang.GetWord("fper10");
            label9.Text = lang.GetWord("fper11");
            label11.Text = lang.GetWord("fper12");
            label12.Text = lang.GetWord("fper13");
            label17.Text = lang.GetWord("fper14");
            groupBox3.Text = lang.GetWord("fper39");
            SaveFormula.Text = lang.GetWord("save");
            label1.Text = lang.GetWord("fper40");
            gbCurrent.Text = lang.GetWord("fper48");
            gbAdd.Text = lang.GetWord("fper49");
            btnDispenseAdd.Text = lang.GetWord("fper52");
            label16.Text = lang.GetWord("fper57");
            btnSQC.Text = lang.GetWord("fper61");
            tabColorants.Text = lang.GetWord("fper66");
            tabBase.Text = lang.GetWord("fper67");
            gbCost.Text = lang.GetWord("fper68");
            lblUso.Text = lang.GetWord("fper73");
            btnSelezioneRGB.Text = lang.GetWord("fper74");
            btnLeggiRGB.Text = lang.GetWord("fper75");
            btnNewCustomer.Text = lang.GetWord("fper76");
            gbCosti.Text = lang.GetWord("formula30");
            #endregion

            #region Combo
            //default machine
            string sDefaultMacchina = "";
            Library.Data.DBSettings dbSettings = new Library.Data.DBSettings();
            if (dbSettings.HasKey("drivermachine"))
            {
                sDefaultMacchina = dbSettings.GetValue("drivermachine");
            }

            //combo dispenser
            int iDefaultMacchina = -1;
            Dictionary<int, string> dicMacchine = new Dictionary<int, string>();
            dicMacchine.Add(-1, "");
            string sql = Library.Data.Machine.SQLSelectMachines();
            DataTable dt = db.SQLQuerySelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                string sNomeMacchina = dr["name"].ToString();
                if (sDefaultMacchina != "" && sNomeMacchina.Trim() == sDefaultMacchina.Trim())
                {
                    iDefaultMacchina = Convert.ToInt32(dr["id_machine"]);
                }
                dicMacchine.Add(Convert.ToInt32(dr["id_machine"]), sNomeMacchina);
            }

            cmbMacchine.DataSource = new BindingSource(dicMacchine, null);
            cmbMacchine.DisplayMember = "Value";
            cmbMacchine.ValueMember = "Key";
            cmbMacchine.SelectedValue = iDefaultMacchina;

            //combo cliente
            updateCMBClienti();
            if (iPreSelected_IDCustomer != -1)
            {
                cmbCustomer.SelectedValue = iPreSelected_IDCustomer;
            }

            //combo uso
            dt = db.SQLQuerySelect("SELECT DISTINCT(use) as INTEXT FROM formule");
            cmbUse.Items.Add("");
            foreach (DataRow dr in dt.Rows)
            {
                cmbUse.Items.Add(dr["INTEXT"].ToString());
            }
            if ((formula != null) && (formula.Use != "PERSONAL"))
            {
                cmbUse.Text = formula.Use;
            }
            else
            {
                cmbUse.Text = "";
            }
            #endregion

            btnSQC.Visible = GVar.attivazioni.Act_QualityControl;
            p1.Items.Add(""); p2.Items.Add(""); p3.Items.Add(""); p4.Items.Add(""); p5.Items.Add("");

            #region POPOLAMENTO COMBOX PIGMENTI
            foreach (var pair in GVar.ListaPigmenti)
            {
                string[] ListaPig = pair.Key.ToString().Split('/');
                dicNomeColCode.Add(ListaPig[0], ListaPig[1]);
                dicCodeColDensita.Add(ListaPig[1], pair.Value);
                p1.Items.Add(ListaPig[0]);
                p2.Items.Add(ListaPig[0]);
                p3.Items.Add(ListaPig[0]);
                p4.Items.Add(ListaPig[0]);
                p5.Items.Add(ListaPig[0]);
            }
            #endregion

            #region POPOLANDO COMBOBOX BASE
            for (int i = 0; i < GVar.ListaBasi.Count; i++)
            {
                PBase.Items.Add(GVar.ListaBasi[i]);
            }
            #endregion

            #region POPOLANDO DIRECTORY BOX
            string sql2 = "SELECT DISTINCT(directory_txt) as DIR FROM formule_personali WHERE directory_txt != ''";
            DataTable dt2 = db.SQLQuerySelect(sql2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                directory.Items.Add(dr2["DIR"].ToString());
            }
            #endregion

            #region TOOLTIP TEXT
            tp.SetToolTip(btnSelezioneRGB, lang.GetWord("fper15"));
            tp.SetToolTip(btnLeggiRGB, lang.GetWord("fper16"));
            #endregion

            if (GVar.attivazioni.Act_ColorSearch || GVar.attivazioni.Act_QualityControl)
            {
                btnLeggiRGB.Visible = true;
            }

            lblColCost01.Text = "";
            lblColCost02.Text = "";
            lblColCost03.Text = "";
            lblColCost04.Text = "";
            lblColCost05.Text = "";
            lblTotalCost.Text = "";
            lblBaseCost.Text = "";
            lblColorantCost.Text = "";
            dCostiCol.Add(0d); dCostiCol.Add(0d); dCostiCol.Add(0d); dCostiCol.Add(0d); dCostiCol.Add(0d);

            if (ePageFrom == ePage.formule_personali)
            {
                // posizionamenti tab
                TabPage tabTempColoranti = tabColorants;
                TabPage tabTempBasi = tabBase;
                tabControl1.Controls.RemoveAt(0);
                tabControl1.Controls.RemoveAt(0);
                tabControl1.Controls.Add(tabTempBasi);
                tabControl1.Controls.Add(tabTempColoranti);
                //

                gbCost.Visible = false;
                gbAdd.Visible = false;
                gbCost.Location = gbAdd.Location;
                btnDispenseAdd.Visible = false;
                SetDispenserSQCVisibility(false);
                cmbCustomer.SelectedValue = -1;

                #region Event For Cost Calculation
                q1.KeyUp += new KeyEventHandler(UpdateCosti);
                q2.KeyUp += new KeyEventHandler(UpdateCosti);
                q3.KeyUp += new KeyEventHandler(UpdateCosti);
                q4.KeyUp += new KeyEventHandler(UpdateCosti);
                q5.KeyUp += new KeyEventHandler(UpdateCosti);
                QBase.KeyUp += new KeyEventHandler(UpdateCosti);
                #endregion

                #region oz button
                this.gbCurrent.Controls.Add(buttonOunce[0]);
                this.gbCurrent.Controls.Add(buttonOunce[1]);
                this.gbCurrent.Controls.Add(buttonOunce[2]);
                this.gbCurrent.Controls.Add(buttonOunce[3]);
                this.gbCurrent.Controls.Add(buttonOunce[4]);
                buttonOunce[0].Location = new Point(q1.Location.X, q1.Location.Y - 5);
                buttonOunce[1].Location = new Point(q2.Location.X, q2.Location.Y - 5);
                buttonOunce[2].Location = new Point(q3.Location.X, q3.Location.Y - 5);
                buttonOunce[3].Location = new Point(q4.Location.X, q4.Location.Y - 5);
                buttonOunce[4].Location = new Point(q5.Location.X, q5.Location.Y - 5);
                buttonOunce[0].Visible = false;
                buttonOunce[1].Visible = false;
                buttonOunce[2].Visible = false;
                buttonOunce[3].Visible = false;
                buttonOunce[4].Visible = false;
                #endregion
            }
            else
            {
                if (formula == null) { throw new Exception("formula must be set"); }
                btnDispenseAdd.Enabled = true;

                #region Disabled Control And Event For Cost Calculation
                p1.Enabled = false;
                p2.Enabled = false;
                p3.Enabled = false;
                p4.Enabled = false;
                p5.Enabled = false;
                q1.Enabled = false;
                q2.Enabled = false;
                q3.Enabled = false;
                q4.Enabled = false;
                q5.Enabled = false;
                txtAdd1.Enabled = false;
                txtAdd2.Enabled = false;
                txtAdd3.Enabled = false;
                txtAdd4.Enabled = false;
                txtAdd5.Enabled = false;
                QuantityPig.Enabled = false;
                PBase.Enabled = false;
                QBase.Enabled = false;
                UnitBase.Enabled = false;
                label15.Visible = false;
                label13.Visible = false;

                txtAdd1.KeyUp += new KeyEventHandler(UpdateCosti);
                txtAdd2.KeyUp += new KeyEventHandler(UpdateCosti);
                txtAdd3.KeyUp += new KeyEventHandler(UpdateCosti);
                txtAdd4.KeyUp += new KeyEventHandler(UpdateCosti);
                txtAdd5.KeyUp += new KeyEventHandler(UpdateCosti);
                #endregion

                if (ePageFrom == ePage.view_formule_personali)
                {
                    bEditAsOunce = formula.LoadedInOunce;
                    formula.EditFormulaUnit = formula.ColorantsUnit;

                    #region EDIT DA VIEW FORMULA
                    switch (formula.EditFormulaUnit)
                    {
                        case Library.Formulation.eUnita.gr:
                        case Library.Formulation.eUnita.KG:
                            {
                                ql1.Text = "gr";
                                ql2.Text = "gr";
                                ql3.Text = "gr";
                                ql4.Text = "gr";
                                ql5.Text = "gr";
                                QuantityPig.Text = "GRAMS";
                                break;
                            }
                        case Library.Formulation.eUnita.LT:
                        case Library.Formulation.eUnita.ml:
                            {
                                ql1.Text = "ml";
                                ql2.Text = "ml";
                                ql3.Text = "ml";
                                ql4.Text = "ml";
                                ql5.Text = "ml";
                                QuantityPig.Text = "MILLILITER";
                                break;
                            }
                    }
                    int iCifreDecimali = Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"));
                    switch (formula.BaseUnita)
                    {
                        case Library.Formulation.eUnita.gr:
                        case Library.Formulation.eUnita.KG:
                            {
                                double qta = Library.Formulation.Formula.ConvertValue(formula.BaseQta, formula.BaseUnita, Library.Formulation.eUnita.KG, formula.BaseDensita);
                                QBase.Text = Math.Round(qta, iCifreDecimali).ToString();
                                UnitBase.Text = "KG";
                                break;
                            }
                        case Library.Formulation.eUnita.LT:
                        case Library.Formulation.eUnita.ml:
                            {
                                double qta = Library.Formulation.Formula.ConvertValue(formula.BaseQta, formula.BaseUnita, Library.Formulation.eUnita.LT, formula.BaseDensita);
                                QBase.Text = Math.Round(qta, iCifreDecimali).ToString();
                                UnitBase.Text = "L";
                                break;
                            }
                    }
                    Pcolorname.Text = formula.FormulaName;
                    CreatedBy.Text = formula.Personal_CreatedBy;
                    directory.Text = formula.Personal_Directory;
                    Pnote.Text = formula.Note;
                    PBase.Text = formula.BaseName;
                    R = Convert.ToInt32(formula.RGB_R);
                    G = Convert.ToInt32(formula.RGB_G);
                    B = Convert.ToInt32(formula.RGB_B);
                    CieL = formula.CIEL;
                    Ciea = formula.CIEa;
                    Cieb = formula.CIEb;
                    if (formula.Personal_IDCustomer != -1)
                    {
                        cmbCustomer.SelectedValue = formula.Personal_IDCustomer;
                    }
                    if (formula.Use != "PERSONAL")
                    {
                        cmbUse.Text = formula.Use;
                    }
                    panColor.BackColor = System.Drawing.Color.FromArgb((int)formula.RGB_R, (int)formula.RGB_G, (int)formula.RGB_B);
                    SetPigmentiQta();
                    #endregion
                }
                else if (ePageFrom == ePage.formula_selection)
                {
                    #region EDIT DA FORMULA SELECTION
                    switch (formula.EditFormulaUnit)
                    {
                        case Library.Formulation.eUnita.gr:
                        case Library.Formulation.eUnita.KG:
                            {
                                QuantityPig.Text = "GRAMS";
                                ql1.Text = "gr";
                                ql2.Text = "gr";
                                ql3.Text = "gr";
                                ql4.Text = "gr";
                                ql5.Text = "gr";
                                break;
                            }
                        case Library.Formulation.eUnita.LT:
                        case Library.Formulation.eUnita.ml:
                            {
                                QuantityPig.Text = "MILLILITER";
                                ql1.Text = "ml";
                                ql2.Text = "ml";
                                ql3.Text = "ml";
                                ql4.Text = "ml";
                                ql5.Text = "ml";
                                break;
                            }
                    }
                    int iCifreDecimali = Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"));
                    switch (formula.BaseUnita)
                    {
                        case Library.Formulation.eUnita.gr:
                        case Library.Formulation.eUnita.KG:
                            {
                                double qta = Library.Formulation.Formula.ConvertValue(formula.BaseQta, formula.BaseUnita, Library.Formulation.eUnita.KG, formula.BaseDensita);
                                QBase.Text = Math.Round(qta, iCifreDecimali).ToString();
                                UnitBase.Text = "KG";
                                break;
                            }
                        case Library.Formulation.eUnita.LT:
                        case Library.Formulation.eUnita.ml:
                            {
                                double qta = Library.Formulation.Formula.ConvertValue(formula.BaseQta, formula.BaseUnita, Library.Formulation.eUnita.LT, formula.BaseDensita);
                                QBase.Text = Math.Round(qta, iCifreDecimali).ToString();
                                UnitBase.Text = "L";
                                break;
                            }
                    }
                    Pcolorname.Text = formula.FormulaName + " personal";
                    PBase.Text = formula.BaseName;
                    R = Convert.ToInt32(formula.RGB_R);
                    G = Convert.ToInt32(formula.RGB_G);
                    B = Convert.ToInt32(formula.RGB_B);

                    panColor.BackColor = System.Drawing.Color.FromArgb(R, G, B);
                    SetPigmentiQta();

                    
                    #endregion
                }
                UpdateCosti(null, null);

                #region Oz button
                if (bEditAsOunce)
                {
                    QuantityPig.Text = "OUNCE";
                    this.gbAdd.Controls.Add(buttonOunce[0]);
                    this.gbAdd.Controls.Add(buttonOunce[1]);
                    this.gbAdd.Controls.Add(buttonOunce[2]);
                    this.gbAdd.Controls.Add(buttonOunce[3]);
                    this.gbAdd.Controls.Add(buttonOunce[4]);
                    ladd1.Visible = false;
                    ladd2.Visible = false;
                    ladd3.Visible = false;
                    ladd4.Visible = false;
                    ladd5.Visible = false;
                    buttonOunce[0].Visible = true;
                    buttonOunce[1].Visible = true;
                    buttonOunce[2].Visible = true;
                    buttonOunce[3].Visible = true;
                    buttonOunce[4].Visible = true;
                    txtAdd1.Visible = false;
                    txtAdd2.Visible = false;
                    txtAdd3.Visible = false;
                    txtAdd4.Visible = false;
                    txtAdd5.Visible = false;
                    buttonOunce[0].Location = new Point(txtAdd1.Location.X, txtAdd1.Location.Y - 5);
                    buttonOunce[1].Location = new Point(txtAdd2.Location.X, txtAdd2.Location.Y - 5);
                    buttonOunce[2].Location = new Point(txtAdd3.Location.X, txtAdd3.Location.Y - 5);
                    buttonOunce[3].Location = new Point(txtAdd4.Location.X, txtAdd4.Location.Y - 5);
                    buttonOunce[4].Location = new Point(txtAdd5.Location.X, txtAdd5.Location.Y - 5);
                }
                #endregion
            }

            #region Event User Data Changed
            Pcolorname.TextChanged += new EventHandler(UserDataChanged);
            panColor.BackColorChanged += new EventHandler(UserDataChanged);
            CreatedBy.TextChanged += new EventHandler(UserDataChanged);
            directory.TextChanged += new EventHandler(UserDataChanged);
            cmbCustomer.SelectedIndexChanged += new EventHandler(UserDataChanged);
            cmbCustomer.SelectedIndexChanged += new EventHandler(CustomerIndexChanged);
            Pnote.TextChanged += new EventHandler(UserDataChanged);
            PBase.SelectedIndexChanged += new EventHandler(UserDataChanged);
            QBase.TextChanged += new EventHandler(UserDataChanged);
            UnitBase.SelectedIndexChanged += new EventHandler(UserDataChanged);
            QuantityPig.SelectedIndexChanged += new EventHandler(UserDataChanged);
            p1.SelectedIndexChanged += new EventHandler(UserDataChanged);
            p2.SelectedIndexChanged += new EventHandler(UserDataChanged);
            p3.SelectedIndexChanged += new EventHandler(UserDataChanged);
            p4.SelectedIndexChanged += new EventHandler(UserDataChanged);
            p5.SelectedIndexChanged += new EventHandler(UserDataChanged);
            q1.TextChanged += new EventHandler(UserDataChanged);
            q2.TextChanged += new EventHandler(UserDataChanged);
            q3.TextChanged += new EventHandler(UserDataChanged);
            q4.TextChanged += new EventHandler(UserDataChanged);
            q5.TextChanged += new EventHandler(UserDataChanged);
            #endregion

            #region Oz Event Click
            foreach (Button b in buttonOunce)
            {
                b.Click += new EventHandler(OzPressed_1);
            }
            #endregion
        }

        public void PreviewColor_Search(ref Label lCurUnit, ref Label lAddUnit, ref Label lblPlus, ref TextBox txtAdd, ref Panel panPreview, string nomepigmentofull, Button bOunce)
        {
            foreach (var pair in GVar.ListaPigmenti)
            {
                string[] ListaPig = pair.Key.ToString().Split('/');
                if (nomepigmentofull == "")
                {
                    panPreview.BackColor = System.Drawing.Color.Transparent;
                    lblPlus.Visible = false;
                    txtAdd.Text = "";
                    txtAdd.Enabled = false;
                    if (this.bEditAsOunce || this.ePageFrom == ePage.formule_personali)
                    {
                        bOunce.Enabled = false;
                    }
                    else
                    {
                        lAddUnit.Visible = false;
                    }
                }
                else
                {
                    if (ListaPig[0] == nomepigmentofull)
                    {
                        panPreview.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(ListaPig[2].ToString()), Convert.ToInt32(ListaPig[3].ToString()), Convert.ToInt32(ListaPig[4].ToString()));
                        lblPlus.Visible = true;
                        txtAdd.Enabled = true;
                        if (this.bEditAsOunce || this.ePageFrom == ePage.formule_personali)
                        {
                            bOunce.Enabled = false;
                            bOunce.Enabled = true;
                        }
                        else
                        {
                            lAddUnit.Visible = true;
                        }
                    }
                }
            }
        }

        #region EDIT OUNCE BUTTON MANAGER
        private void OzPressed_1(object sender, EventArgs e)
        {
            try
            {
                int IDManuale = Convert.ToInt32(settings.GetValue("IDMachineOunceEdit"));
                if (IDManuale == -1){   throw new Exception(lang.GetWord("formula69"));    }

                Button b = (Button)sender;
                TextBox txti = null;
                TextBox qi = null;
                switch (b.Tag.ToString())
                {
                    case "0":
                        {
                            txti = txtAdd1;
                            qi = q1;
                            break;
                        }
                    case "1":
                        {
                            txti = txtAdd2;
                            qi = q2;
                            break;
                        }
                    case "2":
                        {
                            txti = txtAdd3;
                            qi = q3;
                            break;
                        }
                    case "3":
                        {
                            txti = txtAdd4;
                            qi = q4;
                            break;
                        }
                    case "4":
                        {
                            txti = txtAdd5;
                            qi = q5;
                            break;
                        }
                }

                if (!b.Enabled) { return; }
                string data = txti.Text;
                if (this.ePageFrom == ePage.formule_personali) { data = GetTXTValue(qi); }
                double dMl = 0d;
                if (data.Trim() != "") { dMl = Convert.ToDouble(data.Replace(",", "."), CultureInfo.InvariantCulture); }
                frmEditManuale frm = new frmEditManuale(dMl);
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(GVar.AppLocation_X + 260, GVar.AppLocation_Y + 350);
                frm.ShowDialog();
                dMl = frm.MilliliterValue;
                if (dMl == -1d) { return; }
                if (this.ePageFrom == ePage.formule_personali)
                {
                    SetTXTValue(qi, frm.MilliliterValue);
                    b.Enabled = false;
                    b.Enabled = qi.Text.Trim() != "";
                }
                else
                {
                    txti.Text = frm.MilliliterValue.ToString();
                    b.Enabled = false;
                    b.Enabled = txti.Text.Trim() != "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OzButton_EnabledChanged(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Enabled)
            {
                TextBox txti = null;
                TextBox qi = null;
                switch (b.Tag.ToString())
                {
                    case "0":
                    {
                        txti = txtAdd1;
                        qi = q1;
                        break;
                    }
                    case "1":
                    {
                        txti = txtAdd2;
                        qi = q3;
                        break;
                    }
                    case "2":
                    {
                        txti = txtAdd3;
                        qi = q4;
                        break;
                    }
                    case "3":
                    {
                        txti = txtAdd4;
                        qi = q4;
                        break;
                    }
                    case "4":
                    {
                        txti = txtAdd5;
                        qi = q5;
                        break;
                    }
                }
                
                double dMl = 0d;
                if (this.ePageFrom == ePage.formule_personali)
                {
                    if (GetTXTValue(qi).Trim() != "") { dMl = Convert.ToDouble(GetTXTValue(qi).Replace(",", "."), CultureInfo.InvariantCulture); }
                }
                else
                {
                    if (txti.Text.Trim() != "") { dMl = Convert.ToDouble(txti.Text.Replace(",", "."), CultureInfo.InvariantCulture); }
                }

                if (dMl == 0d)
                {
                    b.BackColor = System.Drawing.Color.White; //attivato non assegnato
                    b.ForeColor = System.Drawing.Color.FromArgb(0, 149, 66);
                }
                else
                {
                    b.BackColor = System.Drawing.Color.FromArgb(0, 149, 66); //attivato assegnato
                    b.ForeColor = System.Drawing.Color.White;
                }
                    
            }
            else
            {
                b.BackColor = System.Drawing.Color.White; //disattivato
                b.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        private void UserDataChanged(object sender, EventArgs e)
        {
            bModificato = true;
        }
        private void SetPigmentiQta()
        {
            
            Library.Formulation.eUnita unitaCol = formula.EditFormulaUnit;
            switch (unitaCol)
            {
                case Library.Formulation.eUnita.KG:
                    {
                        unitaCol = Library.Formulation.eUnita.gr; break;
                    }
                case Library.Formulation.eUnita.LT:
                    {
                        unitaCol = Library.Formulation.eUnita.ml; break;
                    }
            }
            if (formula.ColorantsCount >= 1)
            {
                p1.Text = formula.ColorantName(0);
                double dq = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(0), formula.ColorantsUnit, unitaCol, formula.ColorantDensita(0));
                SetTXTValue(q1, dq);
            }
            else { p1.Enabled = true; }
            if (formula.ColorantsCount >= 2)
            {
                p2.Text = formula.ColorantName(1);
                double dq = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(1), formula.ColorantsUnit, unitaCol, formula.ColorantDensita(1));
                SetTXTValue(q2, dq);
            }
            else { p2.Enabled = true; }
            if (formula.ColorantsCount >= 3)
            {
                p3.Text = formula.ColorantName(2);
                double dq = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(2), formula.ColorantsUnit, unitaCol, formula.ColorantDensita(2));
                SetTXTValue(q3, dq);
            }
            else { p3.Enabled = true; }
            if (formula.ColorantsCount >= 4)
            {
                p4.Text = formula.ColorantName(3);
                double dq = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(3), formula.ColorantsUnit, unitaCol, formula.ColorantDensita(3));
                SetTXTValue(q4, dq);
            }
            else { p4.Enabled = true; }
            if (formula.ColorantsCount >= 5)
            {
                p5.Text = formula.ColorantName(4);
                double dq = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(4), formula.ColorantsUnit, unitaCol, formula.ColorantDensita(4));
                SetTXTValue(q5, dq);
            }
            else { p5.Enabled = true; }
        }

        private void frmFormulaPersonale_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (bModificato && !bGoViewSavedFormula)
                {
                    DialogResult dialogResult = MessageBox.Show(lang.GetWord("save_message"), lang.GetWord("save_header"), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveFormulaExecute(false);
                        bGoViewSavedFormula = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        #region PREVIEW COLORE PIGMENTI
        private void p1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewColor_Search(ref ql1, ref ladd1, ref plus1, ref txtAdd1, ref pp1, p1.SelectedItem.ToString(), buttonOunce[0]);
        }
        private void p2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewColor_Search(ref ql2, ref ladd2, ref plus2, ref txtAdd2, ref pp2, p2.SelectedItem.ToString(), buttonOunce[1]);
        }
        private void p3_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewColor_Search(ref ql3, ref ladd3, ref plus3, ref txtAdd3, ref pp3, p3.SelectedItem.ToString(), buttonOunce[2]);
        }
        private void p4_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewColor_Search(ref ql4, ref ladd4, ref plus4, ref txtAdd4, ref pp4, p4.SelectedItem.ToString(), buttonOunce[3]);
        }
        private void p5_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreviewColor_Search(ref ql5, ref ladd5, ref plus5, ref txtAdd5, ref pp5, p5.SelectedItem.ToString(), buttonOunce[4]);
        }
        #endregion

        private void QuantityPig_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (QuantityPig.SelectedItem.ToString())
            {
                case "MILLILITER":
                    {
                        q1.Visible = true; q2.Visible = true; q3.Visible = true; q4.Visible = true; q5.Visible = true;
                        ql1.Visible = true; ql2.Visible = true; ql3.Visible = true; ql4.Visible = true; ql5.Visible = true;
                        for (int i = 0; i < buttonOunce.Length; i++) { buttonOunce[i].Visible = false; }
                        ql1.Text = "ml";
                        ql2.Text = "ml";
                        ql3.Text = "ml";
                        ql4.Text = "ml";
                        ql5.Text = "ml";
                        ladd1.Text = "ml";
                        ladd2.Text = "ml";
                        ladd3.Text = "ml";
                        ladd4.Text = "ml";
                        ladd5.Text = "ml";
                        break;
                    }
                case "GRAMS":
                    {
                        q1.Visible = true; q2.Visible = true; q3.Visible = true; q4.Visible = true; q5.Visible = true;
                        ql1.Visible = true; ql2.Visible = true; ql3.Visible = true; ql4.Visible = true; ql5.Visible = true;
                        for (int i = 0; i < buttonOunce.Length; i++) { buttonOunce[i].Visible = false; }
                        ql1.Text = "g.";
                        ql2.Text = "g.";
                        ql3.Text = "g.";
                        ql4.Text = "g.";
                        ql5.Text = "g.";
                        ladd1.Text = "g.";
                        ladd2.Text = "g.";
                        ladd3.Text = "g.";
                        ladd4.Text = "g.";
                        ladd5.Text = "g.";
                        break;
                    }
                case "OUNCE":
                    {
                        if (this.ePageFrom == ePage.formule_personali)
                        {
                            q1.Visible = false; q2.Visible = false; q3.Visible = false; q4.Visible = false; q5.Visible = false;
                            ql1.Visible = false; ql2.Visible = false; ql3.Visible = false; ql4.Visible = false; ql5.Visible = false;
                        }

                        for (int i = 0; i < buttonOunce.Length; i++) 
                        {
                            buttonOunce[i].Visible = true;
                            //buttonOunce[i].Enabled = false;
                           // buttonOunce[i].Enabled = true;
                        }
                        buttonOunce[0].Enabled = p1.Text.Trim() != "";
                        buttonOunce[1].Enabled = p2.Text.Trim() != "";
                        buttonOunce[2].Enabled = p3.Text.Trim() != "";
                        buttonOunce[3].Enabled = p4.Text.Trim() != "";
                        buttonOunce[4].Enabled = p5.Text.Trim() != "";

                        break;
                    }
            }

        }

        private void SaveFormula_Click(object sender, EventArgs e)
        {
            SaveFormula.Enabled = false;
            SaveFormulaExecute(true);
            SaveFormula.Enabled = true;
        }

        private void SaveFormulaExecute(bool bDisplayAndClose)
        {
            try
            {
                bool bEditFormula = false;
                if (formula != null)
                {
                    if (formula.TableName == "formule_personali") { bEditFormula = true; }
                }

                //validazione input
                if (Pcolorname.Text.Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (PBase.Text.Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (QBase.Text.Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (UnitBase.Text.Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (QuantityPig.Text.Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (p1.Text.Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (bEditFormula && GetTXTValue(q1).Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (!bEditFormula && q1.Text.Trim().Length == 0) { throw new Exception(lang.GetWord("fper22")); }
                if (Convert.ToDouble(QBase.Text.Replace(',', '.'), CultureInfo.InvariantCulture) <= 0) { throw new Exception(lang.GetWord("fper22")); }
                if (bEditFormula && Convert.ToDouble(GetTXTValue(q1).Replace(',', '.'), CultureInfo.InvariantCulture) <= 0) { throw new Exception(lang.GetWord("fper22")); }
                if (!bEditFormula && Convert.ToDouble(q1.Text.Replace(',', '.'), CultureInfo.InvariantCulture) <= 0) { throw new Exception(lang.GetWord("fper22")); }

                string q1p = "", q2p = "", q3p = "", q4p = "", q5p = "";

                if (bEditFormula)
                {
                    q1p = ValidazionePigQta(p1.Text, GetTXTValue(q1));//0 = non inserire; else: inserire
                    q2p = ValidazionePigQta(p2.Text, GetTXTValue(q2));//0 = non inserire; else: inserire
                    q3p = ValidazionePigQta(p3.Text, GetTXTValue(q3));//0 = non inserire; else: inserire
                    q4p = ValidazionePigQta(p4.Text, GetTXTValue(q4));//0 = non inserire; else: inserire
                    q5p = ValidazionePigQta(p5.Text, GetTXTValue(q5));//0 = non inserire; else: inserire
                }
                else
                {
                    q1p = ValidazionePigQta(p1.Text, q1.Text);//0 = non inserire; else: inserire
                    q2p = ValidazionePigQta(p2.Text, q2.Text);//0 = non inserire; else: inserire
                    q3p = ValidazionePigQta(p3.Text, q3.Text);//0 = non inserire; else: inserire
                    q4p = ValidazionePigQta(p4.Text, q4.Text);//0 = non inserire; else: inserire
                    q5p = ValidazionePigQta(p5.Text, q5.Text);//0 = non inserire; else: inserire
                }

                //data corrente
                DateTime NowDateTMP = DateTime.Now;
                string NowDate = NowDateTMP.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                //query
                Dictionary<string, string> dicColumnValue = new Dictionary<string, string>();
                dicColumnValue.Add("colorname", "'" + Pcolorname.Text.Replace("'", "''") + "'");
                dicColumnValue.Add("base", "'" + PBase.Text + "'");
                dicColumnValue.Add("unit", "'" + QuantityPig.Text + "'");
                dicColumnValue.Add("formulasize", "'" + QBase.Text.Replace(",", ".") + "-" + UnitBase.Text + "'");
                if (cmbCustomer.SelectedValue != null)
                {
                    int iIDCustomer = Convert.ToInt32(cmbCustomer.SelectedValue);
                    if (iIDCustomer != -1) { dicColumnValue.Add("client_id", iIDCustomer.ToString()); }
                }
                dicColumnValue.Add("r", R.ToString());
                dicColumnValue.Add("g", G.ToString());
                dicColumnValue.Add("b", B.ToString());
                dicColumnValue.Add("ciel", CieL.ToString().Replace(",", "."));
                dicColumnValue.Add("ciea", Ciea.ToString().Replace(",", "."));
                dicColumnValue.Add("cieb", Cieb.ToString().Replace(",", "."));
                dicColumnValue.Add("createdby", "'" + CreatedBy.Text.Replace("'", "''") + "'");
                dicColumnValue.Add("directory_txt", "'" + directory.Text.Replace("'", "''") + "'");
                dicColumnValue.Add("notetxt", "'" + Pnote.Text.Replace("'", "''") + "'");
                if (cmbUse.Text.Trim() != "")
                {
                    dicColumnValue.Add("use", "'" + cmbUse.Text + "'");
                }
                else
                {
                    dicColumnValue.Add("use", "'PERSONAL'");
                }

                if (q1p != "0")
                {
                    dicColumnValue.Add("p1", "'" + p1.Text + "'");
                    dicColumnValue.Add("q1", q1p);
                }
                if (q2p != "0")
                {
                    dicColumnValue.Add("p2", "'" + p2.Text + "'");
                    dicColumnValue.Add("q2", q2p);
                }
                if (q3p != "0")
                {
                    dicColumnValue.Add("p3", "'" + p3.Text + "'");
                    dicColumnValue.Add("q3", q3p);
                }
                if (q4p != "0")
                {
                    dicColumnValue.Add("p4", "'" + p4.Text + "'");
                    dicColumnValue.Add("q4", q4p);
                }
                if (q5p != "0")
                {
                    dicColumnValue.Add("p5", "'" + p5.Text + "'");
                    dicColumnValue.Add("q5", q5p);
                }
                
                if (bEditFormula)
                {
                    Dictionary<string, object> data2 = new Dictionary<string, object>();
                    foreach (KeyValuePair<string, string> entry in dicColumnValue)
                    {
                        data2.Add(entry.Key, entry.Value);
                    }
                    if (db.QueryUpdate("formule_personali", data2, "idp = " + formula.IDFormula) == -1) return;
                }
                else
                {
                    #region Salvataggio formula nuova
                    dicColumnValue.Add("dateformula", "'" + NowDate + "'");
                    dicColumnValue.Add("colorcharts", "'PERSONAL CHARTS'");
                    dicColumnValue.Add("system", "'" + GetProductName(PBase.Text) + "'");
                    dicColumnValue.Add("cloud", "'no'");

                    object oInsert = db.QueryInsert("formule_personali", dicColumnValue, "idp");
                    if (oInsert == null) return;
                    try
                    {
                        IDFormulaPersView = Convert.ToInt32(oInsert.ToString());
                    }
                    catch (Exception) { }
                    #endregion
                }

                //saved
                bGoViewSavedFormula = true;

                if (bDisplayAndClose)
                {
                    string textMessage = lang.GetWord("fper21");
                    if (bEditFormula)
                    {
                        textMessage = lang.GetWord("fper62");
                    }
                    MessageBox.Show(textMessage, lang.GetWord("fper18"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, lang.GetWord("fper18"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidazionePigQta(string sPigmento, string sQuantita)
        {
            if (sPigmento.Trim().Length == 0) return "0";
            if (sQuantita.Trim().Length == 0) return "0";
            if (sQuantita.Trim() == "0") return "0";
            return sQuantita.Replace(",", ".");
        }

        private void QBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Controllo solo numeri
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            #endregion
        }

        private void TxtKeyPress(object sender, KeyPressEventArgs e)
        {
            #region Controllo solo numeri
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            else
            {

            }
            #endregion
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnDispenseAdd_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstFullColoranti = new List<string>();
                List<Color> lstPreview = new List<Color>();
                List<double> lstQta = new List<double>();
                string sUnitaMisuraCode = QuantityPig.Text;
                int IDMacchina = -1;

                //init lists
                double d = TextBox2Double(txtAdd1, txtAdd1);
                if (d != 0)
                {
                    lstPreview.Add(pp1.BackColor);
                    lstFullColoranti.Add(p1.Text);
                    lstQta.Add(d);
                }
                d = TextBox2Double(txtAdd2, txtAdd2);
                if (d != 0)
                {
                    lstPreview.Add(pp2.BackColor);
                    lstFullColoranti.Add(p2.Text);
                    lstQta.Add(d);
                }
                d = TextBox2Double(txtAdd3, txtAdd3);
                if (d != 0)
                {
                    lstPreview.Add(pp3.BackColor);
                    lstFullColoranti.Add(p3.Text);
                    lstQta.Add(d);
                }
                d = TextBox2Double(txtAdd4, txtAdd4);
                if (d != 0)
                {
                    lstPreview.Add(pp4.BackColor);
                    lstFullColoranti.Add(p4.Text);
                    lstQta.Add(d);
                }
                d = TextBox2Double(txtAdd5, txtAdd5);
                if (d != 0)
                {
                    lstPreview.Add(pp5.BackColor);
                    lstFullColoranti.Add(p5.Text);
                    lstQta.Add(d);
                }
                if (lstFullColoranti.Count == 0) { throw new Exception(lang.GetWord("fper54")); }

                if (cmbMacchine.SelectedValue == null) { throw new Exception(lang.GetWord("fper55")); }
                IDMacchina = Convert.ToInt32(cmbMacchine.SelectedValue);
                if (IDMacchina == -1) { throw new Exception(lang.GetWord("fper55")); }

                DialogResult dialogResult = MessageBox.Show(lang.GetWord("fper59"), lang.GetWord("fper58"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) return;

                //dispense
                DataTable dt = db.SQLQuerySelect("SELECT * FROM machine WHERE name = '" + cmbMacchine.Text.Trim() + "'");
                DataRow dr = dt.Rows[0];
                Library.Data.Machine.eMacchina machine_type = (Library.Data.Machine.eMacchina)dr["machine_type"];
                string onceType = dr["oncetype"].ToString().Replace(".", ",");

                try
                {
                    if (Library.Data.Machine.ContainsManual(machine_type))
                    {
                        Library.Formulation.eUnita unitaColoranti = Library.Formulation.eUnita.ml;
                        if (sUnitaMisuraCode == "GRAMS")
                        {
                            unitaColoranti = Library.Formulation.eUnita.gr;
                        }
                        List<double> lstQtaMl = new List<double>();
                        for (int i = 0; i < lstQta.Count; i++)
                        {
                            lstQtaMl.Add(Library.Formulation.Formula.ConvertValue(lstQta[i], unitaColoranti, Library.Formulation.eUnita.ml, GetDensita(lstFullColoranti[i], db)));
                        }

                        //erogazione aggiunta su manuale
                        FormulaSelection.frmOunceDispensing OnceDispensing = new FormulaSelection.frmOunceDispensing(machine_type, Convert.ToDouble(onceType), lstFullColoranti,
                            lstQtaMl, dCostiCol, lstPreview, "", "", Pcolorname.Text, "PERSONAL CHARTS", cmbUse.Text, PBase.Text, QBase.Text + " " + UnitBase.Text, 0d, sValuta);
                        OnceDispensing.ShowDialog();
                    }
                    else
                    {
                        List<string> lstDispenseCodeColorant = new List<string>();
                        List<double> lstDensitaCol = new List<double>();
                        foreach (string sFullName in lstFullColoranti)
                        {
                            lstDispenseCodeColorant.Add(dicNomeColCode[sFullName]);
                            lstDensitaCol.Add(dicCodeColDensita[dicNomeColCode[sFullName]]);
                        }

                        string sUnita = "M";
                        if (sUnitaMisuraCode == "GRAMS")
                        {
                            sUnita = "G";
                        }

                        string sql = "SELECT * FROM machine WHERE id_machine = " + IDMacchina.ToString();
                        DataTable dtmachine = db.SQLQuerySelect(sql);
                        if (dtmachine.Rows.Count == 0) { throw new Exception("machine not found (id " + IDMacchina.ToString() + ")"); }
                        DataRow drmachine = dtmachine.Rows[0];
                        int tipoMacchina = Convert.ToInt32(drmachine["machine_type"].ToString());
                        Library.Data.Machine.eMacchina eMacchina = (Library.Data.Machine.eMacchina)tipoMacchina;
                        string sPathFormula = drmachine["pathfile"].ToString();
                        string sPathExe = drmachine["exefile"].ToString();
                        sql = "SELECT density FROM base WHERE base = '" + PBase.Text + "'";
                        DataTable dtDensitaBase = db.SQLQuerySelect(sql);
                        if (dtDensitaBase.Rows.Count == 0) { throw new Exception("density not found (base " + PBase.Text + ")"); }
                        DataRow drDensitaBase = dtDensitaBase.Rows[0];
                        double dDensitaBase = Convert.ToDouble(drDensitaBase["density"].ToString());

                        string sQtaBase = QBase.Text.Trim();
                        string sUnitaBase = UnitBase.Text;
                        if (UnitBase.Text.Trim().ToUpper() == "L" || UnitBase.Text.Trim().ToUpper() == "LT")
                        {
                            sUnitaBase = "LT";
                        }
                        else
                        {
                            sUnitaBase = "KG";
                        }

                        string sError = Library.Formulation.StaticDispenser.SendCustom2AutomaticDispenser(lstDispenseCodeColorant, lstQta, lstDensitaCol, sUnita, Pcolorname.Text, PBase.Text, sQtaBase, sUnitaBase, dDensitaBase, GetProductName(PBase.Text), eMacchina, sPathFormula, sPathExe);
                        if (sError != "") { throw new Exception(sError); }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, lang.GetWord("error"));
                    return;
                }

                //update quantity
                d = TextBox2Double(txtAdd1, txtAdd1);
                if (d != 0)
                {
                    d += Convert.ToDouble(GetTXTValue(q1).Replace(",", "."), CultureInfo.InvariantCulture);
                    SetTXTValue(q1, d);
                    txtAdd1.Clear();
                }
                d = TextBox2Double(txtAdd2, txtAdd2);
                if (d != 0)
                {
                    d += Convert.ToDouble(GetTXTValue(q2).Replace(",", "."), CultureInfo.InvariantCulture);
                    SetTXTValue(q2, d);
                    txtAdd2.Clear();
                }
                d = TextBox2Double(txtAdd3, txtAdd3);
                if (d != 0)
                {
                    d += Convert.ToDouble(GetTXTValue(q3).Replace(",", "."), CultureInfo.InvariantCulture);
                    SetTXTValue(q3, d);
                    txtAdd3.Clear();
                }
                d = TextBox2Double(txtAdd4, txtAdd4);
                if (d != 0)
                {
                    d += Convert.ToDouble(GetTXTValue(q4).Replace(",", "."), CultureInfo.InvariantCulture);
                    SetTXTValue(q4, d);
                    txtAdd4.Clear();
                }
                d = TextBox2Double(txtAdd5, txtAdd5);
                if (d != 0)
                {
                    d += Convert.ToDouble(GetTXTValue(q5).Replace(",", "."), CultureInfo.InvariantCulture);
                    SetTXTValue(q5, d);
                    txtAdd5.Clear();
                }

                if (this.bEditAsOunce)
                {
                    for (int i = 0; i < buttonOunce.Length; i++)
                    {
                        if (buttonOunce[i].Enabled)
                        {
                            buttonOunce[i].Enabled = false;
                            buttonOunce[i].Enabled = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, lang.GetWord("error"));
            }
        }

        private double GetDensita(string sPigmento, Library.Data.Database.DBConnector db)
        {
            string sql = "Select * From pigmenti where code = '" + sPigmento + "' or fullname = '" + sPigmento + "'";
            DataTable dt = db.SQLQuerySelect(sql);
            if (dt.Rows.Count == 0) { return 0d; }
            DataRow dr = dt.Rows[0];
            return Convert.ToDouble(dr["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
        }

        private double TextBox2Double(TextBox txtEnabledControl, TextBox txt)
        {
            if (!txtEnabledControl.Enabled) return 0;
            if (txt.Text.Trim() == "") return 0;
            double d;
            if (!double.TryParse(Convert.ToDouble(txt.Text.Replace(",", "."), CultureInfo.InvariantCulture).ToString(), out d))
            {
                txt.Focus();
                throw new Exception(lang.GetWord("fper53"));
            }
            if (d < 0) { throw new Exception(lang.GetWord("fper53")); }
            return d;
        }

        private void btnSQC_Click(object sender, EventArgs e)
        {
            try
            {
                Qualita.frmQualita frmSQC = new Qualita.frmQualita();
                frmSQC.MinimumSize = frmSQC.Size;
                frmSQC.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region UTILITIES
        private void updateCMBClienti()
        {
            Dictionary<int, string> dicClienti = new Dictionary<int, string>();
            dicClienti.Add(-1, "");
            string sql = "SELECT id, nome, cognome, azienda, tipo FROM clienti ORDER BY nome";
            System.Data.DataTable dt = db.SQLQuerySelect(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string name = dr["nome"].ToString() + " " + dr["cognome"].ToString();
                    if (dr["tipo"].ToString() == "1")
                    {
                        name = dr["azienda"].ToString();
                    }
                    dicClienti.Add(Convert.ToInt32(dr["id"].ToString()), name);
                }
            }

            cmbCustomer.DataSource = new BindingSource(dicClienti, null);
            cmbCustomer.DisplayMember = "Value";
            cmbCustomer.ValueMember = "Key";
        }
        private string GetProductName(string basename)
        {
            try
            {
                string sql = "SELECT system AS prodotto FROM ( " +
                                "select DISTINCT base, system " +
                                "from formule " +
                                "where base = '" + basename + "' " +
                             ") AS temp_base_system";
                System.Data.DataTable dt = db.SQLQuerySelect(sql);
                DataRow dr = dt.Rows[0];
                string sNomeProdotto = dr["prodotto"].ToString();
                return sNomeProdotto;
            }
            catch (Exception)
            {
                return "PERSONAL";
            }
        }
        #endregion

        private void UpdateCosti(object sender, KeyEventArgs e)
        {
            try
            {
                //read listino customer: if empty -> return;
                int IDCustomer = Convert.ToInt32(cmbCustomer.SelectedValue);
                if (IDCustomer == -1)
                {
                    gbCost.Visible = false;
                    lblTotalCost.Visible = false;
                    lblBaseCost.Visible = false;
                    lblColorantCost.Visible = false;
                    dCostoBase = 0d;
                    lblColCost01.Text = "0"; dCostiCol[0] = 0d;
                    lblColCost02.Text = "0"; dCostiCol[1] = 0d;
                    lblColCost03.Text = "0"; dCostiCol[2] = 0d;
                    lblColCost04.Text = "0"; dCostiCol[3] = 0d;
                    lblColCost05.Text = "0"; dCostiCol[4] = 0d;
                    lblTotalCost.Text = lang.GetWord("fper69") + ": 0";
                    lblBaseCost.Text = lang.GetWord("formula43") + ": 0";
                    lblColorantCost.Text = lang.GetWord("formula44") + ": 0";
                    return;
                }
                else
                {
                    gbCost.Visible = true;
                    lblTotalCost.Visible = true;
                    lblBaseCost.Visible = true;
                    lblColorantCost.Visible = true;
                }

                string sql = "SELECT nome_listino, valuta FROM listino WHERE id_list = (SELECT idlistino FROM clienti WHERE id = " + IDCustomer + ")";
                DataTable dt = db.SQLQuerySelect(sql);
                if (dt.Rows.Count == 0) return;
                DataRow dr = dt.Rows[0];

                string sNomeListino = dr["nome_listino"].ToString();
                this.sValuta = dr["valuta"].ToString();

                List<string> lstP = new List<string>();
                List<double> lstQTot = new List<double>();
                List<double> lstQ = new List<double>();

                Euroformulations4.SubWindows.FormulePersonal.Formula formulaTotale = new Formula();
                Euroformulations4.SubWindows.FormulePersonal.Formula formula = new Formula();
                formulaTotale.Clear();
                formula.Clear();

                if (p1.Text.Length > 0 && GetTXTValue(q1).Length > 0)
                {
                    lstP.Add(p1.Text);
                    double qt1 = Convert.ToDouble(GetTXTValue(q1).Replace(",", "."), CultureInfo.InvariantCulture);
                    lstQ.Add(qt1);
                    if (txtAdd1.Text.Trim() != "")
                    {
                        qt1 += Convert.ToDouble(txtAdd1.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    lstQTot.Add(qt1);
                }

                if (p2.Text.Length > 0 && GetTXTValue(q2).Length > 0)
                {
                    lstP.Add(p2.Text);
                    double qt2 = Convert.ToDouble(GetTXTValue(q2).Replace(",", "."), CultureInfo.InvariantCulture);
                    lstQ.Add(qt2);
                    if (txtAdd2.Text.Trim() != "")
                    {
                        qt2 += Convert.ToDouble(txtAdd2.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    lstQTot.Add(qt2);
                }

                if (p3.Text.Length > 0 && GetTXTValue(q3).Length > 0)
                {
                    lstP.Add(p3.Text);
                    double qt3 = Convert.ToDouble(GetTXTValue(q3).Replace(",", "."), CultureInfo.InvariantCulture);
                    lstQ.Add(qt3);
                    if (txtAdd3.Text.Trim() != "")
                    {
                        qt3 += Convert.ToDouble(txtAdd3.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    lstQTot.Add(qt3);
                }

                if (p4.Text.Length > 0 && GetTXTValue(q4).Length > 0)
                {
                    lstP.Add(p4.Text);
                    double qt4 = Convert.ToDouble(GetTXTValue(q4).Replace(",", "."), CultureInfo.InvariantCulture);
                    lstQ.Add(qt4);
                    if (txtAdd4.Text.Trim() != "")
                    {
                        qt4 += Convert.ToDouble(txtAdd4.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    lstQTot.Add(qt4);
                }

                if (p5.Text.Length > 0 && GetTXTValue(q5).Length > 0)
                {
                    lstP.Add(p5.Text);
                    double qt5 = Convert.ToDouble(GetTXTValue(q5).Replace(",", "."), CultureInfo.InvariantCulture);
                    lstQ.Add(qt5);
                    if (txtAdd5.Text.Trim() != "")
                    {
                        qt5 += Convert.ToDouble(txtAdd5.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    lstQTot.Add(qt5);
                }

                //execute
                if (lstP.Count > 0 && QuantityPig.Text.Length > 0 && PBase.Text.Length > 0 && QBase.Text.Length > 0)
                {
                    formulaTotale.LattUnit = UnitBase.Text;
                    formula.LattUnit = UnitBase.Text;
                    formulaTotale.LattValue = Convert.ToDouble(QBase.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                    formula.LattValue = formulaTotale.LattValue;
                    formulaTotale.ReadDbCustom(lstP, lstQTot, QuantityPig.Text, "31.24/384", Pcolorname.Text, PBase.Text);
                    formula.ReadDbCustom(lstP, lstQ, QuantityPig.Text, "31.24/384", Pcolorname.Text, PBase.Text);
                    formulaTotale.ReadCost(sNomeListino);
                    formula.ReadCost(sNomeListino);
                    formulaTotale.CostCalculation();
                    formula.CostCalculation();

                    lblColCost01.Text = "";
                    lblColCost02.Text = "";
                    lblColCost03.Text = "";
                    lblColCost04.Text = "";
                    lblColCost05.Text = "";

                    dCostoBase = formulaTotale.costo_base;

                    if (formulaTotale.costo1 > 0) { dCostiCol[0] = (formulaTotale.costo1 - formula.costo1); lblColCost01.Text = ((decimal)formulaTotale.costo1).ToString("0.00") + " " + sValuta; }
                    if (formulaTotale.costo2 > 0) { dCostiCol[1] = (formulaTotale.costo2 - formula.costo2); lblColCost02.Text = ((decimal)formulaTotale.costo2).ToString("0.00") + " " + sValuta; }
                    if (formulaTotale.costo3 > 0) { dCostiCol[2] = (formulaTotale.costo3 - formula.costo3); lblColCost03.Text = ((decimal)formulaTotale.costo3).ToString("0.00") + " " + sValuta; }
                    if (formulaTotale.costo4 > 0) { dCostiCol[3] = (formulaTotale.costo4 - formula.costo4); lblColCost04.Text = ((decimal)formulaTotale.costo4).ToString("0.00") + " " + sValuta; }
                    if (formulaTotale.costo5 > 0) { dCostiCol[4] = (formulaTotale.costo5 - formula.costo5); lblColCost05.Text = ((decimal)formulaTotale.costo5).ToString("0.00") + " " + sValuta; }

                    decimal dCostoColoranti = ((decimal)formulaTotale.costo1) +
                        ((decimal)formulaTotale.costo2) +
                        ((decimal)formulaTotale.costo3) +
                        ((decimal)formulaTotale.costo4) +
                        ((decimal)formulaTotale.costo5);

                    decimal totale = ((decimal)formulaTotale.costo_base) + dCostoColoranti;

                    gbCost.Visible = true;
                    lblTotalCost.Visible = true;
                    lblBaseCost.Visible = true;
                    lblColorantCost.Visible = true;

                    lblBaseCost.Text = lang.GetWord("formula43") + ": " + Math.Round((formulaTotale.costo_base), 2).ToString() + " " + sValuta;
                    lblColorantCost.Text = lang.GetWord("formula44") + ": " + Math.Round(dCostoColoranti, 2).ToString() + " " + sValuta;
                    lblTotalCost.Text = lang.GetWord("fper69") + ": " + totale.ToString("0.00") + " " + sValuta;
                }
                else
                {
                    gbCost.Visible = false;
                    lblTotalCost.Visible = false;
                    lblColorantCost.Visible = false;
                    lblBaseCost.Visible = false;
                    lblColCost01.Text = "0 " + sValuta; ;
                    lblColCost02.Text = "0 " + sValuta; ;
                    lblColCost03.Text = "0 " + sValuta; ;
                    lblColCost04.Text = "0 " + sValuta; ;
                    lblColCost05.Text = "0 " + sValuta; ;
                    lblTotalCost.Text = lang.GetWord("fper69") + ": 0";
                    lblBaseCost.Text = lang.GetWord("formula43") + ": 0";
                    lblColorantCost.Text = lang.GetWord("formula44") + ": 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CustomerIndexChanged(object sender, EventArgs e)
        {
            UpdateCosti(null, null);
            this.ActiveControl = SaveFormula;
        }

        private void SetDispenserSQCVisibility(bool visibility)
        {
            btnSQC.Visible = visibility;
            if (btnSQC.Visible)
            {
                btnSQC.Visible = GVar.attivazioni.Act_QualityControl;
            }
            btnDispenseAdd.Visible = visibility;
            cmbMacchine.Visible = visibility;
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frmClienteEdit frmNewClient = new frmClienteEdit();
            frmNewClient.ShowDialog();
            updateCMBClienti();
            cmbCustomer.SelectedValue = frmNewClient.IDCliente;
        }

        private void btnSelezioneRGB_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                panColor.BackColor = colorDialog1.Color;

                R = Convert.ToInt32(colorDialog1.Color.R.ToString());
                G = Convert.ToInt32(colorDialog1.Color.G.ToString());
                B = Convert.ToInt32(colorDialog1.Color.B.ToString());
            }
        }

        private void btnLeggiRGB_Click(object sender, EventArgs e)
        {
            try
            {
                Library.Data.Dispositivi.DispositivoBase disp = Library.Data.Dispositivi.DispositiviManager.GetDispositivo();

                if (!disp.Calibrato())
                {
                    DialogResult dialogResult = MessageBox.Show(lang.GetWord("calibration_message"), lang.GetWord("infoMessage"), MessageBoxButtons.YesNo);
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

                ColorSearch.frmGetColor frmColor = new ColorSearch.frmGetColor();
                frmColor.ShowDialog();
                if (!frmColor.LetturaEseguita) { return; }

                CieL = frmColor.CIEL;
                Ciea = frmColor.CIEa;
                Cieb = frmColor.CIEb;
                double[] xyz = Library.Colore.LAB_XYZ(CieL, Ciea, Cieb);
                X = xyz[0];
                Y = xyz[1];
                Z = xyz[2];
                double[] rgb = Colore.XYZ_RGB(X, Y, Z);
                R = (int)rgb[0];
                G = (int)rgb[1];
                B = (int)rgb[2];
                panColor.BackColor = System.Drawing.Color.FromArgb(R, G, B);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDispenseAdd_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void SetTXTValue(TextBox txtValue, double value)
        {
            if (iCifreDecimali == -1)
            {
                iCifreDecimali = Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"));
            }
            txtValue.Text = Math.Round(value, iCifreDecimali).ToString();
            txtValue.Tag = value;
        }
        private string GetTXTValue(TextBox txtValue)
        {
            return txtValue.Tag.ToString();
        }
    }
}