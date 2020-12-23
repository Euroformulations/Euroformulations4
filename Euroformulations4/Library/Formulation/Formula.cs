using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Globalization;

namespace Euroformulations4.Library.Formulation
{
    public enum eUnita
    { 
        gr = 0,
        KG = 1,
        ml = 2,
        LT = 3
    }
    public class Formula
    {
        private string name;
        private string colorChart;
        private string sProdotto;
        private string use;
        private double dR, dG, dB, dCIEL, dCIEA, dCIEB;
        private int id;
        private string tableName;
        private string note;
        private string nw;
        private double de;
        private string sBarcode;
        private string sPersonal_CreatedBy = "";
        private string sPersonal_Directory = "";
        private int iPersonal_IDCustomer = -1;
        private int colorantPercentage = 100;
        private eUnita eEditFormula_Methos = eUnita.gr;

        private static Dictionary<string, double> dicBaseDensita = null;
        private static Dictionary<string, double> dicBaseFattoreCorrettivo = null;
        private static Dictionary<string, double> dicColorantCodeDensity = null;
        private static Dictionary<string, string> dicColorantCodeName = null;
        private static Dictionary<string, Color> dicColorantCodeRGB = null;
        public static bool bForceReloadStaticDic = false;

        private string sBase;
        private double qtaBase;
        private eUnita unitaBase;
        private bool bFormulaSavedInOunce = false;
        private double densitaBase;
        private bool bLatta = false;

        private List<string> lstColoranti;
        private List<string> lstColorantCode;
        private List<double> lstDensita;
        private List<double> lstQuantita;
        private List<Color> lstAnteprima;
        private eUnita unitaColoranti;



        private Formula(string name, string colorChart, string use, string sBase, double quantitaBase, eUnita unitaBase, bool bLatta, double densitaBase, eUnita unitaColoranti, string note, string nw, double de, string sBaseBarCode, string sProdotto, double dR, double dG, double dB, double dCIEL, double dCIEA, double dCIEB, int id, string tableName, bool bFormulaSavedInOunce)
        {
            this.colorChart = colorChart;
            this.name = name;
            this.use = use;
            this.sBase = sBase;
            this.sBarcode = sBaseBarCode;
            this.qtaBase = quantitaBase;
            this.unitaBase = unitaBase;
            this.densitaBase = densitaBase;
            this.unitaColoranti = unitaColoranti;
            this.bLatta = bLatta;
            this.sProdotto = sProdotto;
            lstColoranti = new List<string>();
            lstColorantCode = new List<string>();
            lstDensita = new List<double>();
            lstQuantita = new List<double>();
            lstAnteprima = new List<Color>();
            this.note = note;
            this.nw = nw;
            this.de = de;
            this.dR = dR;
            this.dG = dG;
            this.dB = dB;
            this.dCIEL = dCIEL;
            this.dCIEA = dCIEA;
            this.dCIEB = dCIEB;
            this.id = id;
            this.tableName = tableName;
            this.bFormulaSavedInOunce = bFormulaSavedInOunce;
        }
        private Formula(Formula formula, eUnita unitaBase, eUnita unitaColoranti)
        {
            this.name = formula.name;
            this.colorChart = formula.colorChart;
            this.use = formula.use;
            this.unitaBase = unitaBase;
            this.sBase = formula.sBase;
            this.densitaBase = formula.densitaBase;
            this.sBarcode = formula.sBarcode;
            this.unitaColoranti = unitaColoranti;
            this.qtaBase = ConvertValue(formula.qtaBase, formula.unitaBase, unitaBase, formula.densitaBase);
            this.bLatta = formula.bLatta;
            this.sProdotto = formula.sProdotto;
            this.sPersonal_CreatedBy = formula.Personal_CreatedBy;
            this.sPersonal_Directory = formula.sPersonal_Directory;
            this.iPersonal_IDCustomer = formula.iPersonal_IDCustomer;

            this.lstColoranti = new List<string>(formula.lstColoranti);
            this.lstColorantCode = new List<string>(formula.lstColorantCode);
            this.lstDensita = new List<double>(formula.lstDensita);
            this.lstAnteprima = new List<Color>(formula.lstAnteprima);
            this.lstQuantita = new List<double>();
            int i=0;
            foreach (double oldQuantita in formula.lstQuantita)
            {
                lstQuantita.Add(ConvertValue(oldQuantita, formula.unitaColoranti, unitaColoranti, lstDensita[i]));
                i++;
            }
            this.note = formula.note;
            this.nw = formula.nw;
            this.de = formula.de;
            this.dR = formula.dR;
            this.dG = formula.dG;
            this.dB = formula.dB;
            this.dCIEL = formula.dCIEL;
            this.dCIEA = formula.dCIEA;
            this.dCIEB = formula.dCIEB;
            this.id = formula.id;
            this.tableName = formula.tableName;
            this.bFormulaSavedInOunce = formula.bFormulaSavedInOunce;
        }
        public Formula(Formula formula)
        {
            this.name = formula.name;
            this.colorChart = formula.colorChart;
            this.use = formula.use;
            this.unitaBase = formula.unitaBase;
            this.sBase = formula.sBase;
            this.densitaBase = formula.densitaBase;
            this.sBarcode = formula.sBarcode;
            this.unitaColoranti = formula.unitaColoranti;
            this.qtaBase = formula.qtaBase;
            this.bLatta = formula.bLatta;
            this.sProdotto = formula.sProdotto;
            this.sPersonal_CreatedBy = formula.Personal_CreatedBy;
            this.sPersonal_Directory = formula.sPersonal_Directory;
            this.iPersonal_IDCustomer = formula.iPersonal_IDCustomer;

            this.lstColoranti = new List<string>(formula.lstColoranti);
            this.lstColorantCode = new List<string>(formula.lstColorantCode);
            this.lstDensita = new List<double>(formula.lstDensita);
            this.lstAnteprima = new List<Color>(formula.lstAnteprima);
            this.lstQuantita = new List<double>();
            int i = 0;
            foreach (double qtaCol in formula.lstQuantita)
            {
                lstQuantita.Add(qtaCol);
                i++;
            }
            this.note = formula.note;
            this.nw = formula.nw;
            this.de = formula.de;
            this.dR = formula.dR;
            this.dG = formula.dG;
            this.dB = formula.dB;
            this.dCIEL = formula.dCIEL;
            this.dCIEA = formula.dCIEA;
            this.dCIEB = formula.dCIEB;
            this.id = formula.id;
            this.tableName = formula.tableName;
            this.bFormulaSavedInOunce = formula.bFormulaSavedInOunce;
        }
        public void AddColorante(string codeColorant, double quantita)
        {
            codeColorant = codeColorant.Trim();
            if (lstColorantCode.Contains(codeColorant))
            {
                //update
                int index = lstColorantCode.IndexOf(codeColorant);
                lstQuantita[index] = quantita;
            }
            else
            { 
                //new
                lstColoranti.Add(dicColorantCodeName[codeColorant]);
                lstColorantCode.Add(codeColorant);
                lstDensita.Add(dicColorantCodeDensity[codeColorant]);
                lstQuantita.Add(quantita);
                lstAnteprima.Add(dicColorantCodeRGB[codeColorant]);
            }
        }
        public int SaveToHistory(Library.Data.Database.DBConnector db, int idcustomer)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("de", this.de.ToString().Replace(",", "."));
            data.Add("nw", this.nw.ToString());
            data.Add("dateformula", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
            data.Add("noteTxt", this.note);
            data.Add("colorname", this.name);
            data.Add("base", this.sBase);
            data.Add("densita", this.densitaBase.ToString().Replace(",", "."));
            switch (this.unitaBase)
            {
                case eUnita.gr: 
                    {
                        double valueKg = ConvertValue(this.BaseQta, this.unitaBase, eUnita.KG, this.densitaBase);
                        data.Add("formulasize", valueKg.ToString().Replace(",", ".") + "-KG");
                        break;
                    }
                case eUnita.KG:
                    {
                        data.Add("formulasize", this.BaseQta.ToString().Replace(",", ".") + "-KG");
                        break;
                    }
                case eUnita.LT:
                    {
                        data.Add("formulasize", this.BaseQta.ToString().Replace(",", ".") + "-LT");
                        break;
                    }
                case eUnita.ml:
                    {
                        double valueLt = ConvertValue(this.BaseQta, this.unitaBase, eUnita.LT, this.densitaBase);
                        data.Add("formulasize", valueLt.ToString().Replace(",", ".") + "-LT");
                        break;
                    }
            }

            eUnita unitaColToSave = eUnita.gr;
            data.Add("unit", "GRAMS");
            if (this.unitaColoranti == eUnita.ml || this.unitaColoranti == eUnita.LT) { unitaColToSave = eUnita.ml; data["unit"] = "MILLILITERS"; }

            for (int i = 0; i < lstColoranti.Count; i++)
            {
                string pi = "p" + (i + 1).ToString();
                string qi = "q" + (i + 1).ToString();
                data.Add(pi, lstColorantCode[i]);
                data.Add(qi, ConvertValue(lstQuantita[i], unitaColoranti, unitaColToSave, lstDensita[i]).ToString().Replace(",", "."));
            }

            data.Add("colorcharts", colorChart);
            data.Add("system", sProdotto);
            data.Add("use", use);
            data.Add("r", dR.ToString().Replace(",", "."));
            data.Add("g", dG.ToString().Replace(",", "."));
            data.Add("b", dB.ToString().Replace(",", "."));
            data.Add("ciel", dCIEL.ToString().Replace(",", "."));
            data.Add("ciea", dCIEA.ToString().Replace(",", "."));
            data.Add("cieb", dCIEB.ToString().Replace(",", "."));
            data.Add("cloud", "no");
            double dPercentage = ((double)colorantPercentage) / 100;
            data.Add("riempimento", dPercentage.ToString("0.00").Replace(",", "."));
            if (idcustomer != -1)
            {
                data.Add("idcliente", idcustomer.ToString());
                DataTable dt = db.SQLQuerySelect("SELECT idcloud FROM clienti WHERE id = " + idcustomer);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["idcloud"].ToString().Trim() != "")
                    {
                        data.Add("idcloudcliente", dt.Rows[0]["idcloud"].ToString());
                    }
                }
            }

            object oId = db.QueryInsert("history", data, "id");
            if (db.LastQueryError.Trim() != "") { throw new Exception(db.LastQueryError); }
            return Convert.ToInt32(oId);
        }

        #region SET / GET DATA
        public string FormulaName { get { return name; } }
        public string ColorChart { get { return colorChart; } }
        public string Use { get { return use; } }
        public string BaseName { get { return sBase; } }
        public double BaseQta { get { return qtaBase; } }
        public eUnita BaseUnita { get { return unitaBase; } }
        public double BaseDensita { get { return densitaBase; } }
        public string Barcode { get { return sBarcode; } }
        public string BaseProdotto { get { return sProdotto; } }
        public bool IsLattaggio { get { return bLatta; } }
        public bool LoadedInOunce { get { return bFormulaSavedInOunce; } }
        public int ColorantsCount { get { return lstColoranti.Count; } }
        public int ColorantIndex(string name) { return lstColoranti.IndexOf(name); }
        public string ColorantName(int index){return lstColoranti[index];}
        public string ColorantCode(int index) { return lstColorantCode[index]; }
        public double ColorantDensita(int index) { return lstDensita[index]; }
        public double ColorantQta(int index) { return lstQuantita[index]; }
        public Color ColorantPreview(int index) { return lstAnteprima[index]; }
        public eUnita ColorantsUnit { get { return unitaColoranti; } }
        public double DeltaE { get { return de; } }
        public string Note { get { return note; } }
        public string NW { get { return nw; } }
        public double RGB_R { get { return dR; } }
        public double RGB_G { get { return dG; } }
        public double RGB_B { get { return dB; } }
        public double CIEL { get { return this.dCIEL; } }
        public double CIEa { get { return this.dCIEA; } }
        public double CIEb { get { return this.dCIEB; } }
        public int IDFormula { get { return id; } }
        public string TableName { get { return tableName; } }
        public string Personal_CreatedBy { get { return sPersonal_CreatedBy; } }
        public string Personal_Directory { get { return sPersonal_Directory; } }
        public int Personal_IDCustomer { get { return iPersonal_IDCustomer; } }
        public eUnita EditFormulaUnit { get { return eEditFormula_Methos; } set { this.eEditFormula_Methos = value; } }
        #endregion

        #region NEW FORMULA: ROUND/REFILL/UPDATE BASE
        public Formula GetFormulaRounded()
        {
            if(bLatta) { throw new Exception("rounding from packaging size is not possible"); }

            Formula rounded = new Formula(this, this.unitaBase, this.unitaBase);
            
            //fattore moltiplicativo
            double somma_nuova = rounded.qtaBase;
            double somma_vecchia = rounded.qtaBase;
            foreach(double qtaColorante in rounded.lstQuantita)
            {
                somma_vecchia += qtaColorante;
            }

            //applicazione round
            rounded.qtaBase = (somma_nuova * rounded.qtaBase) / somma_vecchia;
            for (int i = 0; i < rounded.lstQuantita.Count; i++)
            {
                rounded.lstQuantita[i] = (somma_nuova * rounded.lstQuantita[i]) / somma_vecchia;
            }

            return rounded;
        }
        public Formula GetFormulaRefilled(int percentage)
        {
            if(!bLatta) { throw new Exception("refilling out from packaging size is not possible"); }

            if (percentage < 0) percentage = 0;

            Formula refilled = new Formula(this, unitaBase, unitaColoranti);
            
            //change refilled quantities
            //refilled.qtaBase = (refilled.qtaBase * percentage) / 100d;  //NO!
            for (int i = 0; i < refilled.lstQuantita.Count; i++)
            {
                refilled.lstQuantita[i] = (refilled.lstQuantita[i] * percentage) / 100d;
            }
            refilled.colorantPercentage = percentage;

            return refilled;
        }
        public Formula ChangeBase(double quantitaBase, eUnita unitaBase, bool bLatta, string sBarcode)
        {
            Formula formula = new Formula(this.name, this.colorChart, this.use, this.sBase, quantitaBase, unitaBase, bLatta, this.densitaBase, this.unitaColoranti, this.note, this.nw, this.de, sBarcode, this.sProdotto, this.dR, this.dG, this.dB, this.dCIEL, this.dCIEA, this.dCIEB, this.id, this.tableName, this.bFormulaSavedInOunce);
            formula.sPersonal_CreatedBy = this.sPersonal_CreatedBy;
            formula.sPersonal_Directory = this.sPersonal_Directory;
            formula.iPersonal_IDCustomer = this.iPersonal_IDCustomer;

            //this.qtaBase: precedente valore qta base
            double qtaBaseNew = Library.Formulation.Formula.ConvertValue(quantitaBase, unitaBase, this.unitaBase, this.densitaBase);

            formula.lstColoranti = new List<string>(this.lstColoranti);
            formula.lstColorantCode = new List<string>(this.lstColorantCode);
            formula.lstDensita = new List<double>(this.lstDensita);
            formula.lstAnteprima = new List<Color>(this.lstAnteprima);
            
            formula.lstQuantita = new List<double>();
            int i = 0;
            foreach (double oldQuantita in this.lstQuantita)
            {
                double dNuovaQta = (this.lstQuantita[i] * qtaBaseNew) / qtaBase;
                formula.lstQuantita.Add(dNuovaQta);
                i++;
            }

            return formula;
        }
        #endregion

        #region COST FORMULA
        public double GetCost_Base(int IDListino)
        {
            Library.Data.Database.DBConnector db = new Data.Database.DBConnector();
            Library.Formulation.CostCalculator calculator = new CostCalculator(db, IDListino);
            double costo = 0d;

            if (bLatta)
            {
                costo = calculator.GetCostoLatta(sBase, qtaBase, unitaBase);
            }
            else
            {
                costo = calculator.GetCostoBase(sBase, qtaBase, densitaBase, unitaBase);
            }
            
            db.CloseConnection();
            return costo;
        }
        public double GetCost_Colorant(int indexColorant, int IDListino)
        {
            Library.Data.Database.DBConnector db = new Data.Database.DBConnector();
            Library.Formulation.CostCalculator calculator = new CostCalculator(db, IDListino);
            double costo = calculator.GetCostoColorante(lstColoranti[indexColorant], lstQuantita[indexColorant], lstDensita[indexColorant], unitaColoranti);
            db.CloseConnection();
            return costo;
        }    
        #endregion

        #region FUNCTION
        public static double ConvertValue(double oldvalue, eUnita oldUnita, eUnita NuovaUnita, double densita)
        {
            if (oldUnita == NuovaUnita) { return oldvalue; }

            switch (NuovaUnita)
            { 
                case eUnita.gr:
                        {
                            if (oldUnita == eUnita.KG) { return oldvalue * 1000; } //KG -> G
                            else if (oldUnita == eUnita.LT) 
                            {
                                double qK = oldvalue * densita; return qK * 1000; //Lt -> g
                            }
                            else if (oldUnita == eUnita.ml)
                            {
                                return oldvalue * densita; //ml -> g
                            }
                            break;
                        }
                    case eUnita.KG:
                        {
                            if (oldUnita == eUnita.gr) { return oldvalue / 1000; } //G -> KG
                            else if (oldUnita == eUnita.LT)
                            {
                                 return oldvalue * densita; //Lt -> KG
                            }
                            else if (oldUnita == eUnita.ml)
                            {
                                double qg = oldvalue * densita; return qg / 1000; //ml -> KG
                            }
                            break;
                        }
                    case eUnita.ml:
                        {
                            if (oldUnita == eUnita.LT) { return oldvalue * 1000; }
                            else if (oldUnita == eUnita.KG) 
                            {
                                double lt = oldvalue / densita; return lt * 1000; //Lt -> ml
                            }
                            else if (oldUnita == eUnita.gr){return oldvalue / densita;} //gr -> ml
                            break;
                        }
                    case eUnita.LT:
                        {
                            if (oldUnita == eUnita.ml) { return oldvalue / 1000; } //ml -> lt
                            else if (oldUnita == eUnita.KG){return oldvalue / densita;} //kg -> lt
                            else if (oldUnita == eUnita.gr) 
                            {
                                double ml = oldvalue / densita; return ml / 1000; //gr -> lt
                            }
                            break;
                        }
            }

            throw new Exception("conversion request not implemented");
        }
        private static void InitDictionary(Library.Data.Database.DBConnector db)
        {
            if (dicBaseDensita == null || bForceReloadStaticDic)
            {
                dicBaseDensita = new Dictionary<string, double>();
                dicBaseFattoreCorrettivo = new Dictionary<string, double>();
                string sql2 = "SELECT * FROM base";
                DataTable dtDensitaBase = db.SQLQuerySelect(sql2);
                foreach (DataRow dr2 in dtDensitaBase.Rows)
                {
                    dicBaseDensita.Add(dr2["base"].ToString(), Convert.ToDouble(dr2["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture));
                    dicBaseFattoreCorrettivo.Add(dr2["base"].ToString(), Convert.ToDouble(dr2["fcbase"].ToString().Replace(",", "."), CultureInfo.InvariantCulture));
                }

            }
            if (dicColorantCodeDensity == null || bForceReloadStaticDic)
            {
                dicColorantCodeDensity = new Dictionary<string, double>();
                dicColorantCodeName = new Dictionary<string, string>();
                dicColorantCodeRGB = new Dictionary<string, Color>();
                string sql2 = "SELECT * FROM pigmenti";
                DataTable dtColoranti = db.SQLQuerySelect(sql2);
                foreach (DataRow dr2 in dtColoranti.Rows)
                {
                    dicColorantCodeDensity.Add(dr2["code"].ToString(), Convert.ToDouble(dr2["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture));
                    dicColorantCodeName.Add(dr2["code"].ToString(), dr2["fullname"].ToString());
                    dicColorantCodeRGB.Add(dr2["code"].ToString(), Color.FromArgb(Convert.ToInt32(dr2["pr"].ToString()), Convert.ToInt32(dr2["pg"].ToString()), Convert.ToInt32(dr2["pb"].ToString())));
                }
            }
            bForceReloadStaticDic = false;
        }
        public static Formula InitFormula_From_formule(int idformula)
        {
            return InitFormula_From_Table(idformula, "formule", "id");
        }

        public static Formula InitFormula_From_formulePrev(int idformula)
        {
            return InitFormula_From_Table(idformula, "formule_prev", "id");
        }
        public static Formula InitFormula_From_formulePersonali(int idformula)
        {
            return InitFormula_From_Table(idformula, "formule_personali", "idp");
        }
        public static Formula InitFormula_From_history(int idformula)
        {
            return InitFormula_From_Table(idformula, "history", "id");
        }
        private static Formula InitFormula_From_Table(int idformula, string tablename, string sIDColumn)
        {
            Library.Data.Database.DBConnector db = new Data.Database.DBConnector();
            InitDictionary(db);

            string sql = "SELECT * FROM " + tablename + " WHERE " + sIDColumn + " = " + idformula;

            DataTable dt = db.SQLQuerySelect(sql);
            if (dt.Rows.Count == 0) { return null; }
            DataRow dr = dt.Rows[0];

            string sBase = dr["base"].ToString();
            string[] formulasize = dr["formulasize"].ToString().ToUpper().Split('-');
            double baseSize = Convert.ToDouble(formulasize[0].Replace(",", "."), CultureInfo.InvariantCulture);
            eUnita unitaBase = eUnita.KG;
            if (formulasize[1].ToUpper() == "L" || formulasize[1].ToUpper() == "LT")
            {
                unitaBase = eUnita.LT;
            }
            string sColorantUnit = dr["unit"].ToString().ToUpper().Trim();
            bool bFormulaSavedInOunce = false;
            if (sColorantUnit == "ONCE" || sColorantUnit == "OUNCE") { bFormulaSavedInOunce = true; }
            eUnita unitaColoranti = eUnita.gr;
            if (sColorantUnit != "GRAMS")
            {
                unitaColoranti = eUnita.ml;
            }

            double de = -1;
            if (dr["de"].ToString().Trim() != "")
            { 
                de = Convert.ToDouble(dr["de"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            }

            double dR = Convert.ToDouble(dr["r"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            double dG = Convert.ToDouble(dr["g"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            double dB = Convert.ToDouble(dr["b"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            double dCIEL = Convert.ToDouble(dr["ciel"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            double dCIEA = Convert.ToDouble(dr["ciea"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            double dCIEB = Convert.ToDouble(dr["cieb"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);

            Formula formula = new Formula(dr["colorname"].ToString(), dr["colorcharts"].ToString(), dr["use"].ToString(), sBase, baseSize, unitaBase, false, dicBaseDensita[sBase], unitaColoranti, dr["notetxt"].ToString(), dr["nw"].ToString(), de, "", dr["system"].ToString(), dR, dG, dB, dCIEL, dCIEA, dCIEB, idformula, tablename, bFormulaSavedInOunce);

            if (tablename == "formule_personali")
            {
                formula.sPersonal_Directory = dr["directory_txt"].ToString();
                formula.sPersonal_CreatedBy = dr["createdby"].ToString();
                string sIDCustomer = dr["client_id"].ToString();
                if (sIDCustomer.Trim() != "") { formula.iPersonal_IDCustomer = Convert.ToInt32(sIDCustomer); }
            }

            for (int i = 1; i < 6; i++)
            {
                string pi = dr["p" + i.ToString()].ToString();

                if (pi.Trim() != "")
                {
                    if (tablename == "formule_personali")
                    {
                        string sql2 = "SELECT * FROM pigmenti WHERE fullname = '" + pi + "'";
                        DataTable dt2 = db.SQLQuerySelect(sql2);
                        DataRow dr2 = dt2.Rows[0];
                        pi = dr2["code"].ToString();
                    }
                    double qi = 0d;
                    if (dr["q" + i.ToString()].ToString().Trim() != "")
                    { 
                        qi = Convert.ToDouble(dr["q" + i.ToString()].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    if (sColorantUnit == "ONCE" || sColorantUnit == "OUNCE")
                    {
                        string oncetypeText = dr["oncetype"].ToString();
                        if (oncetypeText.Trim() != "")
                        {
                            string[] oncetype = dr["oncetype"].ToString().Split('/');
                            double t1 = Convert.ToDouble(oncetype[0].Replace(',', '.'), CultureInfo.InvariantCulture);
                            double t2 = Convert.ToDouble(oncetype[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                            qi = (qi * t1) / t2;
                        }
                        //else qi in ml
                    }

                    //fattore correttivo per qi
                    if (tablename == "formule" && Library.GVar.attivazioni.Act_FattoreCorrettivo)
                    {
                        qi *= dicBaseFattoreCorrettivo[sBase];

                        string sql_fc = "SELECT fcor FROM fcpig WHERE basi = '" + sBase + "' AND coloranti='"+ pi +"';";
                        DataTable dtfc = db.SQLQuerySelect(sql_fc);
                        if (dtfc.Rows.Count > 0)
                        {
                            qi *= Convert.ToDouble(dtfc.Rows[0]["fcor"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        }
                    }

                    formula.AddColorante(pi, qi);
                }
            }

            db.CloseConnection();
            return formula;
        }
        public static void ResetStaticData()
        { 
            dicBaseDensita = null;
            dicBaseFattoreCorrettivo = null;
            dicColorantCodeDensity = null;
            dicColorantCodeName = null;
            dicColorantCodeRGB = null;
            bForceReloadStaticDic = false;
        }
        #endregion
    }
}
