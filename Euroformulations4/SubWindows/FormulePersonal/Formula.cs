using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.SubWindows.FormulePersonal
{
    using System.Net;
    using System.IO;
    using System.Text;
    using Npgsql;
    using System.Globalization;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public class Formula
    {
        public int idFormula;
        #region Informazioni Base della formula
        public double de = 0;
        public double decmc;
        public string nw;
        public string template;
        public string dateformula;
        public string note;
        public string colorname;
        public string sbase;
        public double dbase;
        public string unit;
        public string oncetype;
        public string formulasize;
        public string barcode;
        #endregion
        #region Nome completo del pigmento
        public string fullp1;
        public string fullp2;
        public string fullp3;
        public string fullp4;
        public string fullp5;
        #endregion
        #region Nome pigmento - Quantità pigmento
        public string p1;
        public double q1;
        public string p2;
        public double q2;
        public string p3;
        public double q3;
        public string p4;
        public double q4;
        public string p5;
        public double q5;
        public string codep1;
        public string codep2;
        public string codep3;
        public string codep4;
        public string codep5;
        #endregion
        #region Densità dei pigmenti
        public double d1;
        public double d2;
        public double d3;
        public double d4;
        public double d5;
        public string colorcharts;
        public string system;
        public string use;
        #endregion
        #region RGB della Tinta
        public string R;
        public string G;
        public string B;
        #endregion
        #region CieLab della formula
        public string CieL;
        public string CieA;
        public string CieB;
        #endregion
        #region RGB del pigmento per la preview
        public System.Drawing.Color pr1;
        public System.Drawing.Color pr2;
        public System.Drawing.Color pr3;
        public System.Drawing.Color pr4;
        public System.Drawing.Color pr5;
        #endregion
        #region Lattaggio Selezionato
        public string LattUnit;
        public double LattValue;
        public double RefillBasePaint;
        #endregion
        #region Valori in grammi pigmenti
        public double qg1;
        public double qg2;
        public double qg3;
        public double qg4;
        public double qg5;
        public double qgt;
        public double qgt_base;
        #endregion
        #region Valori in millilitri pigmenti
        public double qml1;
        public double qml2;
        public double qml3;
        public double qml4;
        public double qml5;
        public double qmlt;
        public double qmlt_Base;
        #endregion
        #region Valori in once
        public double qonce1;
        public double qonce2;
        public double qonce3;
        public double qonce4;
        public double qonce5;
        public double qoncet;
        public double qoncePersonal1;
        public double qoncePersonal2;
        public double qoncePersonal3;
        public double qoncePersonal4;
        public double qoncePersonal5;
        public double qoncePersonalt;
        #endregion
        #region DataReader del Database
        NpgsqlDataReader TabPigment, TabCosti;
        #endregion
        #region Definizione dei costi
        public int ID_LISTINO;
        public double costoDb1, costoDb2, costoDb3, costoDb4, costoDb5, costo_baseDb;
        public string costoUDb1, costoUDb2, costoUDb3, costoUDb4, costoUDb5, costo_baseUDb;
        public double costo1, costo2, costo3, costo4, costo5, costo_base;
        public string costo_valuta, type_cost;
        #endregion
        #region Macchine manuali
        public string divisore2 = "NULL";
        public string divisore3 = "NULL";
        #endregion

        public void Clear()
        {
            try
            {
                idFormula = -1;
                de = 0;
                decmc = 0;
                nw = "";
                template = "";
                dateformula = "1/1/1900";
                note = "";
                colorname = "";
                sbase = "";
                dbase = 0;
                unit = "";
                oncetype = "";
                formulasize = "";
                fullp1 = "";
                fullp2 = "";
                fullp3 = "";
                fullp4 = "";
                fullp5 = "";
                p1 = "";
                q1 = 0;
                p2 = "";
                q2 = 0;
                p3 = "";
                q3 = 0;
                p4 = "";
                q4 = 0;
                p5 = "";
                q5 = 0;
                d1 = 0;
                d2 = 0;
                d3 = 0;
                d4 = 0;
                d5 = 0;
                costoDb1 = 0;
                costoDb2 = 0;
                costoDb3 = 0;
                costoDb4 = 0;
                costoDb5 = 0;
                costoUDb1 = "";
                costoUDb2 = "";
                costoUDb3 = "";
                costoUDb4 = "";
                costoUDb5 = "";
                codep1 = "";
                codep2 = "";
                codep3 = "";
                codep4 = "";
                codep5 = "";
                costo1 = 0;
                costo2 = 0;
                costo3 = 0;
                costo4 = 0;
                costo5 = 0;
                ID_LISTINO = -1;
                RefillBasePaint = 1;
                colorcharts = "";
                system = "";
                use = "";
                R = "";
                G = "";
                B = "";
                CieL = "";
                CieA = "";
                CieB = "";
                LattUnit = "";
                LattValue = 0;
                qg1 = 0;
                qg2 = 0;
                qg3 = 0;
                qg4 = 0;
                qg5 = 0;
                qgt = 0;
                qgt_base = 0;
                qml1 = 0;
                qml2 = 0;
                qml3 = 0;
                qml4 = 0;
                qml5 = 0;
                qmlt = 0;
                qmlt_Base = 0;
                qonce1 = 0;
                qonce2 = 0;
                qonce3 = 0;
                qonce4 = 0;
                qonce5 = 0;
                qoncet = 0;
                qoncePersonal1 = 0;
                qoncePersonal2 = 0;
                qoncePersonal3 = 0;
                qoncePersonal4 = 0;
                qoncePersonal5 = 0;
                qoncePersonalt = 0;
                divisore2 = "NULL";
                divisore3 = "NULL";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Clear Formula error: " + ex.Message);
            }
        }
        
        /*
        public void ReadDb(int id, string DB = "formule")
        {
            try
            {
                Library.Data.Database.DBConnect_Npgsql dbc = new Library.Data.Database.DBConnect_Npgsql();

                dbc.connect(GVar.Database);
                //1 Connessione per le formule

                if (DB == "formule")
                    dbc.sqlview_ErrorSafe("Select * From " + DB + " where id =" + id, ref TabFormule);
                else if (DB == "formule_personali")
                    dbc.sqlview_ErrorSafe("Select * From " + DB + " where idp =" + id, ref TabFormule);
                else if (DB == "history")
                    dbc.sqlview_ErrorSafe("Select * From " + DB + " where id =" + id, ref TabFormule);

                #region LETTURA VALORI DB STD
                TabFormule.Read();

                //CLASS
                //Aggiunta informazioni BASE alla classe Formula
                this.idFormula = id;
                this.nw = TabFormule["nw"].ToString().ToUpper();
                //DATA 
                string[] DataTMPP = TabFormule["dateformula"].ToString().Split(' ');
                this.dateformula = DataTMPP[0].Trim();
                this.note = TabFormule["noteTxt"].ToString();
                this.colorname = TabFormule["colorname"].ToString();
                this.sbase = TabFormule["base"].ToString();
                this.unit = TabFormule["unit"].ToString().ToUpper();
                this.oncetype = TabFormule["oncetype"].ToString().ToUpper();
                this.formulasize = TabFormule["formulasize"].ToString().ToUpper();
                this.colorcharts = TabFormule["colorcharts"].ToString();
                this.system = TabFormule["system"].ToString();
                this.use = TabFormule["use"].ToString();
                //'Aggiunta informazioni codice PIGMENTI alla classe Formula
                this.p1 = TabFormule["p1"].ToString();
                this.p2 = TabFormule["p2"].ToString();
                this.p3 = TabFormule["p3"].ToString();
                this.p4 = TabFormule["p4"].ToString();
                this.p5 = TabFormule["p5"].ToString();
                //'Aggiunta informazioni quantità PIGMENTI alla classe Formula
                if (TabFormule["q1"].ToString().Trim() != "" && TabFormule["q1"].ToString().Trim() != "0")
                {
                    this.q1 = Convert.ToDouble(TabFormule["q1"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (TabFormule["q2"].ToString().Trim() != "" && TabFormule["q2"].ToString().Trim() != "0")
                {
                    this.q2 = Convert.ToDouble(TabFormule["q2"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (TabFormule["q3"].ToString().Trim() != "" && TabFormule["q3"].ToString().Trim() != "0")
                {
                    this.q3 = Convert.ToDouble(TabFormule["q3"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (TabFormule["q4"].ToString().Trim() != "" && TabFormule["q4"].ToString().Trim() != "0")
                {
                    this.q4 = Convert.ToDouble(TabFormule["q4"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (TabFormule["q5"].ToString().Trim() != "" && TabFormule["q5"].ToString().Trim() != "0")
                {
                    this.q5 = Convert.ToDouble(TabFormule["q5"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }

                //'Aggiunta informazioni DELTA alla classe Formula
                if (TabFormule["de"].ToString().Trim() != "")
                {
                    this.de = Convert.ToDouble(TabFormule["de"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }
                if (TabFormule["decmc"].ToString().Trim() != "")
                {
                    this.decmc = Convert.ToDouble(TabFormule["decmc"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }

                //'Aggiunta informazioni RGB alla classe Formula
                if (TabFormule["R"].ToString().Trim() != "")
                {
                    this.R = TabFormule["R"].ToString();
                }
                if (TabFormule["G"].ToString().Trim() != "")
                {
                    this.G = TabFormule["G"].ToString();
                }
                if (TabFormule["B"].ToString().Trim() != "")
                {
                    this.B = TabFormule["B"].ToString();
                }

                //'Aggiunta informazioni CieLab alla classe Formula
                if (TabFormule["CieL"].ToString().Trim() != "")
                {
                    this.CieL = TabFormule["CieL"].ToString();
                }
                if (TabFormule["CieA"].ToString().Trim() != "")
                {
                    this.CieA = TabFormule["CieA"].ToString();
                }
                if (TabFormule["CieB"].ToString().Trim() != "")
                {
                    this.CieB = TabFormule["CieB"].ToString();
                }

                TabFormule.Close();
                //'Aggiunta informazioni DENSITA' e NOME COMPLETO PIGMENTI e RGB alla classe Formula
                //Pigmento1
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p1 + "' or fullname = '" + this.p1 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp1 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d1 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr1 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep1 = TabPigment["code"].ToString();

                    }
                }
                TabPigment.Close();
                //Pigmento2
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p2 + "' or fullname = '" + this.p2 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp2 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d2 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr2 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep2 = TabPigment["code"].ToString();

                    }
                }
                TabPigment.Close();
                //Pigmento3
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p3 + "' or fullname = '" + this.p3 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp3 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d3 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr3 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep3 = TabPigment["code"].ToString();

                    }
                }
                TabPigment.Close();
                //Pigmento4
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p4 + "' or fullname = '" + this.p4 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp4 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d4 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr4 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep4 = TabPigment["code"].ToString();
                    }
                }
                TabPigment.Close();
                //Pigmento5
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p5 + "' or fullname = '" + this.p5 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp5 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d5 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr5 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep5 = TabPigment["code"].ToString();
                    }
                }
                TabPigment.Close();

                //Densità base
                dbc.sqlview_ErrorSafe("Select * From base where base = '" + this.sbase + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.dbase = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.barcode = TabPigment["barcode"].ToString();
                    }
                }
                TabPigment.Close();
                #endregion

                dbc.disconnect();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Core Error ReadDb: " + ex.Message);
            }
        }
        */
        public void ReadDbCustom(List<string> colorant, List<double> quantity, string unit, string ounceManual = "31.24/384", string nometinta = "PERSONAL", string nomebase = "PERSONAL")
        {
            try
            {
                this.colorname = nometinta;
                this.sbase = nomebase;
                string[] DivTMP_O = ounceManual.Split('/');
                double Div = Convert.ToDouble(DivTMP_O[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) / Convert.ToDouble(DivTMP_O[1].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                this.colorcharts = "PERSONAL CHARTS";
                this.system = "PERSONAL";
                this.use = "PERSONAL";

                int NColorant = colorant.Count();

                #region LETTURA NOME PIGMENTI E QUANTITA
                if (NColorant >= 1) { p1 = colorant[0]; fullp1 = colorant[0]; q1 = quantity[0]; }
                if (NColorant >= 2) { p2 = colorant[1]; fullp2 = colorant[1]; q2 = quantity[1]; }
                if (NColorant >= 3) { p3 = colorant[2]; fullp3 = colorant[2]; q3 = quantity[2]; }
                if (NColorant >= 4) { p4 = colorant[3]; fullp4 = colorant[3]; q4 = quantity[3]; }
                if (NColorant >= 5) { p5 = colorant[4]; fullp5 = colorant[4]; q5 = quantity[4]; }
                #endregion

                #region LETTURA VALORI DENSITA'
                Library.Data.Database.DBConnect_Npgsql dbc = new Library.Data.Database.DBConnect_Npgsql();
                dbc.connect(Library.GVar.Database);
                //1 Connessione per le formule
                //'Aggiunta informazioni DENSITA' e NOME COMPLETO PIGMENTI e RGB alla classe Formula
                //Densità Base
                dbc.sqlview_ErrorSafe("Select * From base where base = '" + nomebase + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.dbase = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                }
                TabPigment.Close();
                //Pigmento1
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p1 + "' or fullname = '" + this.p1 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp1 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d1 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr1 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep1 = TabPigment["code"].ToString();
                    }
                }
                TabPigment.Close();
                //Pigmento2
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p2 + "' or fullname = '" + this.p2 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp2 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d2 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr2 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep2 = TabPigment["code"].ToString();

                    }
                }
                TabPigment.Close();
                //Pigmento3
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p3 + "' or fullname = '" + this.p3 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp3 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d3 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr3 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep3 = TabPigment["code"].ToString();

                    }
                }
                TabPigment.Close();
                //Pigmento4
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p4 + "' or fullname = '" + this.p4 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp4 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d4 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr4 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep4 = TabPigment["code"].ToString();
                    }
                }
                TabPigment.Close();
                //Pigmento5
                dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p5 + "' or fullname = '" + this.p5 + "'", ref TabPigment);
                while (TabPigment.Read())
                {
                    this.fullp5 = TabPigment["fullname"].ToString();
                    if (TabPigment["density"].ToString().Trim() != "")
                    {
                        this.d5 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        this.pr5 = System.Drawing.Color.FromArgb(Convert.ToInt32(TabPigment["pR"].ToString()), Convert.ToInt32(TabPigment["pG"].ToString()), Convert.ToInt32(TabPigment["pB"].ToString()));
                        this.codep5 = TabPigment["code"].ToString();
                    }
                }
                TabPigment.Close();
                dbc.disconnect();
                #endregion

                #region Valori inseriti in GRAMMI
                if (unit == "GRAMS")
                {
                    if (NColorant >= 1) { qg1 = quantity[0]; qml1 = quantity[0] / d1; qonce1 = qml1 / (31.24 / 384); }
                    if (NColorant >= 2) { qg2 = quantity[1]; qml2 = quantity[1] / d2; qonce2 = qml2 / (31.24 / 384); }
                    if (NColorant >= 3) { qg3 = quantity[2]; qml3 = quantity[2] / d3; qonce3 = qml3 / (31.24 / 384); }
                    if (NColorant >= 4) { qg4 = quantity[3]; qml4 = quantity[3] / d4; qonce4 = qml4 / (31.24 / 384); }
                    if (NColorant >= 5) { qg5 = quantity[4]; qml5 = quantity[4] / d5; qonce5 = qml5 / (31.24 / 384); }
                }
                #endregion

                #region Valori inseriti in MILLILITER
                if (unit == "MILLILITER")
                {
                    if (NColorant >= 1) { qml1 = quantity[0]; qg1 = quantity[0] * d1; qonce1 = qml1 / (31.24 / 384); }
                    if (NColorant >= 2) { qml2 = quantity[1]; qg2 = quantity[1] * d2; qonce1 = qml1 / (31.24 / 384); }
                    if (NColorant >= 3) { qml3 = quantity[2]; qg3 = quantity[2] * d3; qonce1 = qml1 / (31.24 / 384); }
                    if (NColorant >= 4) { qml4 = quantity[3]; qg4 = quantity[3] * d4; qonce1 = qml1 / (31.24 / 384); }
                    if (NColorant >= 5) { qml5 = quantity[4]; qg5 = quantity[4] * d5; qonce1 = qml1 / (31.24 / 384); }
                }
                #endregion

                #region Valori inseriti in OUNCE
                if (unit == "ONCE")
                {
                    if (NColorant >= 1) { qonce1 = quantity[0]; qml1 = quantity[0] * Div; qg1 = qml1 * d1; }
                    if (NColorant >= 2) { qonce2 = quantity[1]; qml2 = quantity[1] * Div; qg2 = qml2 * d2; }
                    if (NColorant >= 3) { qonce3 = quantity[2]; qml3 = quantity[2] * Div; qg3 = qml3 * d3; }
                    if (NColorant >= 4) { qonce4 = quantity[3]; qml4 = quantity[3] * Div; qg4 = qml4 * d4; }
                    if (NColorant >= 5) { qonce5 = quantity[4]; qml5 = quantity[4] * Div; qg5 = qml5 * d5; }
                }
                #endregion
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Core Error ReadDb: " + ex.Message);
            }
        }
        public void ReadCost(string nomelistino = "DEFAULT", string type = "DEFAULT")
        {
            try
            {
                if (nomelistino != "DEFAULT" && nomelistino.Length <= 0) return;
                Library.Data.Database.DBConnect_Npgsql dbc = new Library.Data.Database.DBConnect_Npgsql();
                dbc.connect(Library.GVar.Database);

                #region LETTURA ID LISTINO
                dbc.sqlview_ErrorSafe("Select * From listino WHERE nome_listino = '" + nomelistino + "'", ref TabCosti);
                TabCosti.Read();
                this.ID_LISTINO = Convert.ToInt32(TabCosti["id_list"].ToString());
                this.costo_valuta = TabCosti["valuta"].ToString();
                TabCosti.Close();
                #endregion

                #region LETTURA COSTI PIGMENTI
                //costo1
                dbc.sqlview_ErrorSafe("Select * From pig_costi where nome_pigmento = '" + this.fullp1 + "' and id_listino = " + this.ID_LISTINO, ref TabCosti);
                while (TabCosti.Read())
                {
                    this.costoDb1 = Convert.ToDouble(TabCosti["costo"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    this.costoUDb1 = TabCosti["unita"].ToString();
                }
                TabCosti.Close();

                //costo2
                dbc.sqlview_ErrorSafe("Select * From pig_costi where nome_pigmento = '" + this.fullp2 + "' and id_listino = " + this.ID_LISTINO, ref TabCosti);
                while (TabCosti.Read())
                {
                    this.costoDb2 = Convert.ToDouble(TabCosti["costo"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    this.costoUDb2 = TabCosti["unita"].ToString();
                }
                TabCosti.Close();

                //costo3
                dbc.sqlview_ErrorSafe("Select * From pig_costi where nome_pigmento = '" + this.fullp3 + "' and id_listino = " + this.ID_LISTINO, ref TabCosti);
                while (TabCosti.Read())
                {
                    this.costoDb3 = Convert.ToDouble(TabCosti["costo"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    this.costoUDb3 = TabCosti["unita"].ToString();
                }
                TabCosti.Close();

                //costo4
                dbc.sqlview_ErrorSafe("Select * From pig_costi where nome_pigmento = '" + this.fullp4 + "' and id_listino = " + this.ID_LISTINO, ref TabCosti);
                while (TabCosti.Read())
                {
                    this.costoDb4 = Convert.ToDouble(TabCosti["costo"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    this.costoUDb4 = TabCosti["unita"].ToString();
                }
                TabCosti.Close();

                //costo5
                dbc.sqlview_ErrorSafe("Select * From pig_costi where nome_pigmento = '" + this.fullp5 + "' and id_listino = " + this.ID_LISTINO, ref TabCosti);
                while (TabCosti.Read())
                {
                    this.costoDb5 = Convert.ToDouble(TabCosti["costo"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    this.costoUDb5 = TabCosti["unita"].ToString();
                }
                TabCosti.Close();
                #endregion

                //costo_BASE

                if (type == "DEFAULT")
                {
                    #region LETTURA COSTI BASE DEFAULT
                    this.type_cost = "DEFAULT";
                    dbc.sqlview_ErrorSafe("Select * From base_costi where nome_base = '" + this.sbase + "' and id_listino = " + this.ID_LISTINO, ref TabCosti);
                    while (TabCosti.Read())
                    {
                        this.costo_baseDb = Convert.ToDouble(TabCosti["costo_base"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        this.costo_baseUDb = TabCosti["unita_base"].ToString();
                        this.barcode = "NO BARCODE";
                    }
                    TabCosti.Close();
                    #endregion
                }
                else
                {
                    #region LETTURA COSTI BASE lattaggi
                    //costo_BASE_LATTAGGIO
                    this.type_cost = "lattaggio";
                    dbc.sqlview_ErrorSafe("Select * From lattaggi where nome_base_latt = '" + this.sbase + "' and lattaggio = " + this.LattValue.ToString().Replace(',', '.') + " and unita_lattaggio = '" + this.LattUnit.Replace("LT", "L") + "' and id_listino = " + this.ID_LISTINO, ref TabCosti);
                    while (TabCosti.Read())
                    {
                        this.costo_baseDb = Convert.ToDouble(TabCosti["costo_lattaggio"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        this.costo_baseUDb = TabCosti["unita_lattaggio"].ToString();
                        this.RefillBasePaint = Convert.ToDouble(TabCosti["riempimento"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        if (TabCosti["barcode"].ToString().Trim().Length > 0)
                        {
                            this.barcode = TabCosti["barcode"].ToString().Trim();
                        }
                        else
                        {
                            this.barcode = "NO BARCODE";
                        }
                    }
                    TabCosti.Close();
                    #endregion
                }
                dbc.disconnect();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Core Error ReadCost: " + ex.Message);
            }

        }
        
        /*
        public void Formulation(string OunceDivisionPersonal, double RefillBase = 1)
        {
            try
            {
                
                double Divp = 0;
                string[] DivTMP_P = OunceDivisionPersonal.Split('/');
                Divp = Convert.ToDouble(DivTMP_P[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) / Convert.ToDouble(DivTMP_P[1].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                //Valore formulazise
                string[] SizeTMP_O = this.formulasize.Split('-');
                double ValorePezzatura = 0;
                ValorePezzatura = Convert.ToDouble(SizeTMP_O[0].Replace(',', '.'), CultureInfo.InvariantCulture);
                string UnitaPezzatura = null;
                UnitaPezzatura = SizeTMP_O[1];

                //Select Case dell'unità della formula
                switch (this.unit)
                {
                    case "ONCE":
                    case "OUNCE":
                        #region FORMULAZIONE IN ONCE
                        //trovo il valore di ml dell'oncia
                        string[] DivTMP_O = this.oncetype.Split('/');
                        double Div = 0;
                        Div = Convert.ToDouble(DivTMP_O[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) / Convert.ToDouble(DivTMP_O[1].ToString().Replace(",", "."), CultureInfo.InvariantCulture);

                        //Valore ml dell'oncia
                        //Trovo gli ml dei singoli coloranti
                        qml1 = q1 * Div;
                        qml2 = q2 * Div;
                        qml3 = q3 * Div;
                        qml4 = q4 * Div;
                        qml5 = q5 * Div;
                        //Trovo i grammi dei singoli coloranti
                        qg1 = qml1 * d1;
                        qg2 = qml2 * d2;
                        qg3 = qml3 * d3;
                        qg4 = qml4 * d4;
                        qg5 = qml5 * d5;
                        //Trovo le once
                        qonce1 = q1;
                        qonce2 = q2;
                        qonce3 = q3;
                        qonce4 = q4;
                        qonce5 = q5;
                        //Trovo le once personali
                        qoncePersonal1 = qml1 / Divp;
                        qoncePersonal2 = qml2 / Divp;
                        qoncePersonal3 = qml3 / Divp;
                        qoncePersonal4 = qml4 / Divp;
                        qoncePersonal5 = qml5 / Divp;
                        break;
                        #endregion
                    case "GRAMS":
                        #region FORMULAZIONE IN GRAMMI
                        //Controllo i lattaggi
                        //Il cliente vuole in KG
                        //Trovo gli ml dei singoli coloranti
                        qml1 = q1 / d1;
                        qml2 = q2 / d2;
                        qml3 = q3 / d3;
                        qml4 = q4 / d4;
                        qml5 = q5 / d5;
                        //Trovo i grammi dei singoli coloranti
                        qg1 = q1;
                        qg2 = q2;
                        qg3 = q3;
                        qg4 = q4;
                        qg5 = q5;
                        //Trovo le once
                        qonce1 = qml1 / (31.24 / 384);
                        qonce2 = qml2 / (31.24 / 384);
                        qonce3 = qml3 / (31.24 / 384);
                        qonce4 = qml4 / (31.24 / 384);
                        qonce5 = qml5 / (31.24 / 384);
                        //Trovo le once personali
                        qoncePersonal1 = qml1 / Divp;
                        qoncePersonal2 = qml2 / Divp;
                        qoncePersonal3 = qml3 / Divp;
                        qoncePersonal4 = qml4 / Divp;
                        qoncePersonal5 = qml5 / Divp;
                        break;
                        #endregion
                    case "MILLILITER":
                    case "MILLILITERS":
                        #region FORMULAZIONE IN MILLILITRI
                        //Controllo i lattaggi
                        //Il cliente vuole in KG
                        //Trovo gli ml dei singoli coloranti
                        qml1 = q1;
                        qml2 = q2;
                        qml3 = q3;
                        qml4 = q4;
                        qml5 = q5;
                        //Trovo i grammi dei singoli coloranti
                        qg1 = q1 * d1;
                        qg2 = q2 * d2;
                        qg3 = q3 * d3;
                        qg4 = q4 * d4;
                        qg5 = q5 * d5;
                        //Trovo le once
                        qonce1 = qml1 / (31.24 / 384);
                        qonce2 = qml2 / (31.24 / 384);
                        qonce3 = qml3 / (31.24 / 384);
                        qonce4 = qml4 / (31.24 / 384);
                        qonce5 = qml5 / (31.24 / 384);
                        //Trovo le once personali
                        qoncePersonal1 = qml1 / Divp;
                        qoncePersonal2 = qml2 / Divp;
                        qoncePersonal3 = qml3 / Divp;
                        qoncePersonal4 = qml4 / Divp;
                        qoncePersonal5 = qml5 / Divp;
                        break;
                        #endregion
                    default:
                        Console.WriteLine("Error UNIT DATABASE");
                        break;
                }

                #region Controllo dei lattaggi e relativa riproporzione
                if (LattUnit == "KG")
                {
                    if (UnitaPezzatura == "KG")
                    {
                        qml1 = (qml1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml2 = (qml2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml3 = (qml3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml4 = (qml4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml5 = (qml5 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg1 = (qg1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg2 = (qg2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg3 = (qg3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg4 = (qg4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg5 = (qg5 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce1 = (qonce1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce2 = (qonce2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce3 = (qonce3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce4 = (qonce4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce5 = (qonce5 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal1 = (qoncePersonal1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal2 = (qoncePersonal2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal3 = (qoncePersonal3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal4 = (qoncePersonal4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal5 = (qoncePersonal5 * (LattValue * RefillBase)) / ValorePezzatura;
                    }
                    else
                    {
                        qml1 = (qml1 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qml2 = (qml2 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qml3 = (qml3 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qml4 = (qml4 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qml5 = (qml5 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qg1 = (qg1 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qg2 = (qg2 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qg3 = (qg3 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qg4 = (qg4 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qg5 = (qg5 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qonce1 = (qonce1 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qonce2 = (qonce2 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qonce3 = (qonce3 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qonce4 = (qonce4 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qonce5 = (qonce5 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qoncePersonal1 = (qoncePersonal1 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qoncePersonal2 = (qoncePersonal2 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qoncePersonal3 = (qoncePersonal3 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qoncePersonal4 = (qoncePersonal4 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                        qoncePersonal5 = (qoncePersonal5 * (LattValue * RefillBase)) / (ValorePezzatura * dbase);
                    }
                    //Vuol dire il cliente vuole in Litri
                }
                else
                {
                    if (UnitaPezzatura == "KG")
                    {
                        qml1 = (qml1 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qml2 = (qml2 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qml3 = (qml3 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qml4 = (qml4 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qml5 = (qml5 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qg1 = (qg1 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qg2 = (qg2 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qg3 = (qg3 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qg4 = (qg4 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qg5 = (qg5 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qonce1 = (qonce1 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qonce2 = (qonce2 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qonce3 = (qonce3 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qonce4 = (qonce4 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qonce5 = (qonce5 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qoncePersonal1 = (qoncePersonal1 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qoncePersonal2 = (qoncePersonal2 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qoncePersonal3 = (qoncePersonal3 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qoncePersonal4 = (qoncePersonal4 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                        qoncePersonal5 = (qoncePersonal5 * (LattValue * RefillBase)) / (ValorePezzatura / dbase);
                    }
                    else
                    {
                        qml1 = (qml1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml2 = (qml2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml3 = (qml3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml4 = (qml4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qml5 = (qml5 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg1 = (qg1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg2 = (qg2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg3 = (qg3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg4 = (qg4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qg5 = (qg5 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce1 = (qonce1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce2 = (qonce2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce3 = (qonce3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce4 = (qonce4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qonce5 = (qonce5 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal1 = (qoncePersonal1 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal2 = (qoncePersonal2 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal3 = (qoncePersonal3 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal4 = (qoncePersonal4 * (LattValue * RefillBase)) / ValorePezzatura;
                        qoncePersonal5 = (qoncePersonal5 * (LattValue * RefillBase)) / ValorePezzatura;
                    }
                }
                #endregion

                #region Pulizia valori Nulli delle quantità
                if (this.p1.Trim().Length <= 0 && q1 == 0) { p1 = ""; qml1 = 0; qg1 = 0; qonce1 = 0; qoncePersonal1 = 0; }
                if (this.p2.Trim().Length <= 0 && q2 == 0) { p2 = ""; qml2 = 0; qg2 = 0; qonce2 = 0; qoncePersonal2 = 0; }
                if (this.p3.Trim().Length <= 0 && q3 == 0) { p3 = ""; qml3 = 0; qg3 = 0; qonce3 = 0; qoncePersonal3 = 0; }
                if (this.p4.Trim().Length <= 0 && q4 == 0) { p4 = ""; qml4 = 0; qg4 = 0; qonce4 = 0; qoncePersonal4 = 0; }
                if (this.p5.Trim().Length <= 0 && q5 == 0) { p5 = ""; qml5 = 0; qg5 = 0; qonce5 = 0; qoncePersonal5 = 0; }
                #endregion

                #region SOMME QUANTITA'
                qgt = qg1 + qg2 + qg3 + qg4 + qg5;
                qmlt = qml1 + qml2 + qml3 + qml4 + qml5;
                qoncet = qonce1 + qonce2 + qonce3 + qonce4 + qonce5;
                qoncePersonalt = qoncePersonal1 + qoncePersonal2 + qoncePersonal3 + qoncePersonal4 + qoncePersonal5;
                qgt_base = qgt + LattValue * 1000; 
                qmlt_Base = qmlt + LattValue * 1000; 
                #endregion
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Core Error Formulation: " + ex.Message);
            }
        }
        
        public void FormulationRounding()
        {
            try
            {
                #region RIPROPORZIONE VALORI PER ROUDING
                if (LattUnit == "KG")
                {
                    #region rounding KG
                    double fcsommag = (1 * this.LattValue * 1000) / (this.LattValue * 1000 + qgt);
                    qml1 = qml1 * fcsommag;
                    qml2 = qml2 * fcsommag;
                    qml3 = qml3 * fcsommag;
                    qml4 = qml4 * fcsommag;
                    qml5 = qml5 * fcsommag;
                    qg1 = qg1 * fcsommag;
                    qg2 = qg2 * fcsommag;
                    qg3 = qg3 * fcsommag;
                    qg4 = qg4 * fcsommag;
                    qg5 = qg5 * fcsommag;
                    qonce1 = qonce1 * fcsommag;
                    qonce2 = qonce2 * fcsommag;
                    qonce3 = qonce3 * fcsommag;
                    qonce4 = qonce4 * fcsommag;
                    qonce5 = qonce5 * fcsommag;
                    qoncePersonal1 = qoncePersonal1 * fcsommag;
                    qoncePersonal2 = qoncePersonal2 * fcsommag;
                    qoncePersonal3 = qoncePersonal3 * fcsommag;
                    qoncePersonal4 = qoncePersonal4 * fcsommag;
                    qoncePersonal5 = qoncePersonal5 * fcsommag;
                    LattValue = LattValue * fcsommag;
                    #endregion
                }
                else
                {
                    #region rounding L
                    double fcsommaml = (1 * this.LattValue * 1000) / (this.LattValue * 1000 + qmlt);
                    qml1 = qml1 * fcsommaml;
                    qml2 = qml2 * fcsommaml;
                    qml3 = qml3 * fcsommaml;
                    qml4 = qml4 * fcsommaml;
                    qml5 = qml5 * fcsommaml;
                    qg1 = qg1 * fcsommaml;
                    qg2 = qg2 * fcsommaml;
                    qg3 = qg3 * fcsommaml;
                    qg4 = qg4 * fcsommaml;
                    qg5 = qg5 * fcsommaml;
                    qonce1 = qonce1 * fcsommaml;
                    qonce2 = qonce2 * fcsommaml;
                    qonce3 = qonce3 * fcsommaml;
                    qonce4 = qonce4 * fcsommaml;
                    qonce5 = qonce5 * fcsommaml;
                    qoncePersonal1 = qoncePersonal1 * fcsommaml;
                    qoncePersonal2 = qoncePersonal2 * fcsommaml;
                    qoncePersonal3 = qoncePersonal3 * fcsommaml;
                    qoncePersonal4 = qoncePersonal4 * fcsommaml;
                    qoncePersonal5 = qoncePersonal5 * fcsommaml;
                    LattValue = LattValue * fcsommaml;
                    #endregion
                }
                #endregion

                #region Pulizia valori Nulli delle quantità
                if (this.p1.Trim().Length <= 0 && q1 == 0) { p1 = ""; qml1 = 0; qg1 = 0; qonce1 = 0; qoncePersonal1 = 0; }
                if (this.p2.Trim().Length <= 0 && q2 == 0) { p2 = ""; qml2 = 0; qg2 = 0; qonce2 = 0; qoncePersonal2 = 0; }
                if (this.p3.Trim().Length <= 0 && q3 == 0) { p3 = ""; qml3 = 0; qg3 = 0; qonce3 = 0; qoncePersonal3 = 0; }
                if (this.p4.Trim().Length <= 0 && q4 == 0) { p4 = ""; qml4 = 0; qg4 = 0; qonce4 = 0; qoncePersonal4 = 0; }
                if (this.p5.Trim().Length <= 0 && q5 == 0) { p5 = ""; qml5 = 0; qg5 = 0; qonce5 = 0; qoncePersonal5 = 0; }
                #endregion

                #region SOMME QUANTITA'
                qgt = qg1 + qg2 + qg3 + qg4 + qg5;
                qmlt = qml1 + qml2 + qml3 + qml4 + qml5;
                qoncet = qonce1 + qonce2 + qonce3 + qonce4 + qonce5;
                qoncePersonalt = qoncePersonal1 + qoncePersonal2 + qoncePersonal3 + qoncePersonal4 + qoncePersonal5;
                if (LattUnit == "KG") { qgt_base = qgt + LattValue * 1000; }
                if (LattUnit == "L" || LattUnit == "LT") { qmlt_Base = qmlt + LattValue * 1000; }
                #endregion

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Core Error Formulation: " + ex.Message);
            }
        }
        */
        public void CostCalculation()
        {
            try
            {
                #region Calcolo Costo pigmento 1
                if (this.fullp1 != null)
                {
                    if (this.fullp1.Trim().Length > 0)
                    {
                        if (this.costoUDb1 == "L")
                        {
                            this.costo1 = ((this.costoDb1 / this.d1) / 1000) * this.qg1;
                        }
                        else
                        {
                            this.costo1 = (this.costoDb1 / 1000) * this.qg1;
                        }
                    }
                }
                #endregion

                #region Calcolo Costo pigmento 2
                if (this.fullp2 != null)
                {
                    if (this.fullp2.Trim().Length > 0)
                    {
                        if (this.costoUDb2 == "L")
                        {
                            this.costo2 = ((this.costoDb2 / this.d2) / 1000) * this.qg2;
                        }
                        else
                        {
                            this.costo2 = (this.costoDb2 / 1000) * this.qg2;
                        }
                    }
                }
                #endregion

                #region Calcolo Costo pigmento 3
                if (this.fullp3 != null)
                {
                    if (this.fullp3.Trim().Length > 0)
                    {
                        if (this.costoUDb3 == "L")
                        {
                            this.costo3 = ((this.costoDb3 / this.d3) / 1000) * this.qg3;
                        }
                        else
                        {
                            this.costo3 = (this.costoDb3 / 1000) * this.qg3;
                        }
                    }
                }
                #endregion

                #region Calcolo Costo pigmento 4
                if (this.fullp4 != null)
                {
                    if (this.fullp4.Trim().Length > 0)
                    {
                        if (this.costoUDb4 == "L")
                        {
                            this.costo4 = ((this.costoDb4 / this.d4) / 1000) * this.qg4;
                        }
                        else
                        {
                            this.costo4 = (this.costoDb4 / 1000) * this.qg4;
                        }
                    }
                }
                #endregion

                #region Calcolo Costo pigmento 5
                if (this.fullp5 != null)
                {
                    if (this.fullp5.Trim().Length > 0)
                    {
                        if (this.costoUDb5 == "L")
                        {
                            this.costo5 = ((this.costoDb5 / this.d5) / 1000) * this.qg5;
                        }
                        else
                        {
                            this.costo5 = (this.costoDb5 / 1000) * this.qg5;
                        }
                    }
                }
                #endregion

                if (this.type_cost == "DEFAULT" || this.type_cost == "")
                {
                    #region Calcolo Costo base STD
                    if (this.costo_baseUDb == "L")
                    {
                        if (this.LattUnit.Replace("LT", "L").Trim() == "L")
                        {
                            this.costo_base = this.costo_baseDb * this.LattValue;
                        }
                        else
                        {
                            this.costo_base = (this.costo_baseDb / this.dbase) * this.LattValue;
                        }
                    }
                    else
                    {
                        if (this.LattUnit == "KG")
                        {
                            this.costo_base = this.costo_baseDb * this.LattValue;
                        }
                        else
                        {
                            this.costo_base = (this.costo_baseDb * this.dbase) * this.LattValue;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Calcolo Costo base lattaggio
                    if (this.costo_baseUDb == "L")
                    {
                        this.costo_base = this.costo_baseDb;
                    }
                    else
                    {
                        this.costo_base = this.costo_baseDb;
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Core Error CostCalculation: " + ex.Message);
            }

        }
        
        /*
        public string SaveHistory(string Vunit, string Voncetype, string Vformulasize, int id_cliente = -1)
        {
            Library.Data.Database.DBConnect_Npgsql dbch = new Library.Data.Database.DBConnect_Npgsql();
            string NowDate = null;
            DateTime NowDateTMP = DateTime.Now;
            NowDate = NowDateTMP.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            dbch.connect(GVar.Database);
            //1 Connessione per salvataggio History

            //Controllo se è una formula personale inserisco i codici al posto dei nomi completi.
            string Sql = null;
            Sql = "";

            if (id_cliente != -1)
            {
                if (Vunit == "GRAMS")
                {
                    Sql = "INSERT INTO history (de,decmc,nw,template,dateformula,noteTxt,colorname,base,densita,unit,oncetype,formulasize,p1,q1,p2,q2,p3,q3,p4,q4,p5,q5,colorcharts,system,use,R,G,B,CieL,CieA,CieB,cloud,idcliente) ";
                    Sql = Sql + "VALUES (" + this.de.ToString().Replace(",", ".") + "," + this.decmc.ToString().Replace(",", ".") + ",'" + nw + "','" + this.template + "','" + NowDate + "','" + this.note + "','" + this.colorname + "','" + this.sbase + "'," + this.dbase.ToString().Replace(",", ".") + ",'" + Vunit + "','" + Voncetype + "','" + Vformulasize + "','" + this.codep1 + "'," + this.qg1.ToString().Replace(",", ".") + ",'" + this.codep2 + "'," + this.qg2.ToString().Replace(",", ".") + ",'" + this.codep3 + "'," + this.qg3.ToString().Replace(",", ".") + ",'" + this.codep4 + "'," + this.qg4.ToString().Replace(",", ".") + ",'" + this.codep5 + "'," + this.qg5.ToString().Replace(",", ".") + ",'" + this.colorcharts + "','" + this.system + "','" + this.use + "'," + this.R.ToString().Replace(",", ".") + "," + this.G.ToString().Replace(",", ".") + "," + this.B.ToString().Replace(",", ".") + "," + this.CieL.ToString().Replace(",", ".") + "," + this.CieA.ToString().Replace(",", ".") + "," + this.CieB.ToString().Replace(",", ".") + ",'no'," + id_cliente + ")";
                }
                if (Vunit == "MILLILITER")
                {
                    Sql = "INSERT INTO history (de,decmc,nw,template,dateformula,noteTxt,colorname,base,densita,unit,oncetype,formulasize,p1,q1,p2,q2,p3,q3,p4,q4,p5,q5,colorcharts,system,use,R,G,B,CieL,CieA,CieB,cloud,idcliente) ";
                    Sql = Sql + "VALUES (" + this.de.ToString().Replace(",", ".") + "," + this.decmc.ToString().Replace(",", ".") + ",'" + nw + "','" + this.template + "','" + NowDate + "','" + this.note + "','" + this.colorname + "','" + this.sbase + "'," + this.dbase.ToString().Replace(",", ".") + ",'" + Vunit + "','" + Voncetype + "','" + Vformulasize + "','" + this.codep1 + "'," + this.qml1.ToString().Replace(",", ".") + ",'" + this.codep2 + "'," + this.qml2.ToString().Replace(",", ".") + ",'" + this.codep3 + "'," + this.qml3.ToString().Replace(",", ".") + ",'" + this.codep4 + "'," + this.qml4.ToString().Replace(",", ".") + ",'" + this.codep5 + "'," + this.qml5.ToString().Replace(",", ".") + ",'" + this.colorcharts + "','" + this.system + "','" + this.use + "'," + this.R.ToString().Replace(",", ".") + "," + this.G.ToString().Replace(",", ".") + "," + this.B.ToString().Replace(",", ".") + "," + this.CieL.ToString().Replace(",", ".") + "," + this.CieA.ToString().Replace(",", ".") + "," + this.CieB.ToString().Replace(",", ".") + ",'no'," + id_cliente + ")";
                }
                if (Vunit == "ONCE")
                {
                    Sql = "INSERT INTO history (de,decmc,nw,template,dateformula,noteTxt,colorname,base,densita,unit,oncetype,formulasize,p1,q1,p2,q2,p3,q3,p4,q4,p5,q5,colorcharts,system,use,R,G,B,CieL,CieA,CieB,cloud,idcliente) ";
                    Sql = Sql + "VALUES (" + this.de.ToString().Replace(",", ".") + "," + this.decmc.ToString().Replace(",", ".") + ",'" + nw + "','" + this.template + "','" + NowDate + "','" + this.note + "','" + this.colorname + "','" + this.sbase + "'," + this.dbase.ToString().Replace(",", ".") + ",'" + Vunit + "','" + Voncetype + "','" + Vformulasize + "','" + this.codep1 + "'," + this.qonce1.ToString().Replace(",", ".") + ",'" + this.codep2 + "'," + this.qonce2.ToString().Replace(",", ".") + ",'" + this.codep3 + "'," + this.qonce3.ToString().Replace(",", ".") + ",'" + this.codep4 + "'," + this.qonce4.ToString().Replace(",", ".") + ",'" + this.codep5 + "'," + this.qonce5.ToString().Replace(",", ".") + ",'" + this.colorcharts + "','" + this.system + "','" + this.use + "'," + this.R.ToString().Replace(",", ".") + "," + this.G.ToString().Replace(",", ".") + "," + this.B.ToString().Replace(",", ".") + "," + this.CieL.ToString().Replace(",", ".") + "," + this.CieA.ToString().Replace(",", ".") + "," + this.CieB.ToString().Replace(",", ".") + ",'no'," + id_cliente + ")";
                }
            }
            else
            {
                //Inizializzo la variabile
                if (Vunit == "GRAMS")
                {
                    Sql = "INSERT INTO history (de,decmc,nw,template,dateformula,noteTxt,colorname,base,densita,unit,oncetype,formulasize,p1,q1,p2,q2,p3,q3,p4,q4,p5,q5,colorcharts,system,use,R,G,B,CieL,CieA,CieB,cloud) ";
                    Sql = Sql + "VALUES (" + this.de.ToString().Replace(",", ".") + "," + this.decmc.ToString().Replace(",", ".") + ",'" + nw + "','" + this.template + "','" + NowDate + "','" + this.note + "','" + this.colorname + "','" + this.sbase + "'," + this.dbase.ToString().Replace(",", ".") + ",'" + Vunit + "','" + Voncetype + "','" + Vformulasize + "','" + this.codep1 + "'," + this.qg1.ToString().Replace(",", ".") + ",'" + this.codep2 + "'," + this.qg2.ToString().Replace(",", ".") + ",'" + this.codep3 + "'," + this.qg3.ToString().Replace(",", ".") + ",'" + this.codep4 + "'," + this.qg4.ToString().Replace(",", ".") + ",'" + this.codep5 + "'," + this.qg5.ToString().Replace(",", ".") + ",'" + this.colorcharts + "','" + this.system + "','" + this.use + "'," + this.R.ToString().Replace(",", ".") + "," + this.G.ToString().Replace(",", ".") + "," + this.B.ToString().Replace(",", ".") + "," + this.CieL.ToString().Replace(",", ".") + "," + this.CieA.ToString().Replace(",", ".") + "," + this.CieB.ToString().Replace(",", ".") + ",'no')";
                }
                if (Vunit == "MILLILITER")
                {
                    Sql = "INSERT INTO history (de,decmc,nw,template,dateformula,noteTxt,colorname,base,densita,unit,oncetype,formulasize,p1,q1,p2,q2,p3,q3,p4,q4,p5,q5,colorcharts,system,use,R,G,B,CieL,CieA,CieB,cloud) ";
                    Sql = Sql + "VALUES (" + this.de.ToString().Replace(",", ".") + "," + this.decmc.ToString().Replace(",", ".") + ",'" + nw + "','" + this.template + "','" + NowDate + "','" + this.note + "','" + this.colorname + "','" + this.sbase + "'," + this.dbase.ToString().Replace(",", ".") + ",'" + Vunit + "','" + Voncetype + "','" + Vformulasize + "','" + this.codep1 + "'," + this.qml1.ToString().Replace(",", ".") + ",'" + this.codep2 + "'," + this.qml2.ToString().Replace(",", ".") + ",'" + this.codep3 + "'," + this.qml3.ToString().Replace(",", ".") + ",'" + this.codep4 + "'," + this.qml4.ToString().Replace(",", ".") + ",'" + this.codep5 + "'," + this.qml5.ToString().Replace(",", ".") + ",'" + this.colorcharts + "','" + this.system + "','" + this.use + "'," + this.R.ToString().Replace(",", ".") + "," + this.G.ToString().Replace(",", ".") + "," + this.B.ToString().Replace(",", ".") + "," + this.CieL.ToString().Replace(",", ".") + "," + this.CieA.ToString().Replace(",", ".") + "," + this.CieB.ToString().Replace(",", ".") + ",'no')";
                }
                if (Vunit == "ONCE")
                {
                    Sql = "INSERT INTO history (de,decmc,nw,template,dateformula,noteTxt,colorname,base,densita,unit,oncetype,formulasize,p1,q1,p2,q2,p3,q3,p4,q4,p5,q5,colorcharts,system,use,R,G,B,CieL,CieA,CieB,cloud) ";
                    Sql = Sql + "VALUES (" + this.de.ToString().Replace(",", ".") + "," + this.decmc.ToString().Replace(",", ".") + ",'" + nw + "','" + this.template + "','" + NowDate + "','" + this.note + "','" + this.colorname + "','" + this.sbase + "'," + this.dbase.ToString().Replace(",", ".") + ",'" + Vunit + "','" + Voncetype + "','" + Vformulasize + "','" + this.codep1 + "'," + this.qonce1.ToString().Replace(",", ".") + ",'" + this.codep2 + "'," + this.qonce2.ToString().Replace(",", ".") + ",'" + this.codep3 + "'," + this.qonce3.ToString().Replace(",", ".") + ",'" + this.codep4 + "'," + this.qonce4.ToString().Replace(",", ".") + ",'" + this.codep5 + "'," + this.qonce5.ToString().Replace(",", ".") + ",'" + this.colorcharts + "','" + this.system + "','" + this.use + "'," + this.R.ToString().Replace(",", ".") + "," + this.G.ToString().Replace(",", ".") + "," + this.B.ToString().Replace(",", ".") + "," + this.CieL.ToString().Replace(",", ".") + "," + this.CieA.ToString().Replace(",", ".") + "," + this.CieB.ToString().Replace(",", ".") + ",'no')";
                }
            }

            dbch.SQLExe_ErrorSafe(Sql);
            dbch.disconnect();

            return Sql;
        }
        public string OnceDispensig(double mlColorant, double OnceType = 29.57)
        {
            #region VARIABILI LOCALI
            string risultato = "";
            string stopformula = "AVANTI";
            double ml_Totali = -1;
            double oncia = -1;
            #endregion

            ml_Totali = mlColorant;

            //Calcolo del primo divisore che è Y
            oncia = (int)(ml_Totali / OnceType);
            risultato += oncia + " ";

            //Calcolo del secondo divisore impostato dal cliente
            int div1 = 0;
            if (divisore3 != "NULL")
            {
                div1 = (int)((ml_Totali - (oncia * OnceType)) / (OnceType / Convert.ToInt32(divisore2)));
                risultato += div1 + " ";
            }
            else
            {
                if (stopformula != "STOP")
                {
                    div1 = (int)Math.Round((ml_Totali - (oncia * OnceType)) / (OnceType / Convert.ToInt32(divisore2)), 0);
                    risultato += div1 + " ";
                    stopformula = "STOP";
                }
            }

            int div2 = 0;
            if (stopformula != "STOP" && divisore3 != "drops4" && divisore3 != "drops8")
            {
                div2 = (int)Math.Round((ml_Totali - (oncia * OnceType)) + (OnceType / Convert.ToInt32(divisore2)) / (OnceType / Convert.ToInt32(divisore3)), 0);
                risultato += div2 + " ";
                stopformula = "STOP";
            }
            else if (stopformula != "STOP" && divisore3 == "drops8")
            {
                div2 = (int)Math.Round(((ml_Totali - ((oncia * OnceType) + (div1 * OnceType / Convert.ToInt32(divisore2)))) / (OnceType / 384)), 0);
                switch (div2)
                {
                    case 0:
                        risultato += "0";
                        break;
                    case 1:
                        risultato += "1/8";
                        break;
                    case 2:
                        risultato += "1/4";
                        break;
                    case 3:
                        risultato += "3/8";
                        break;
                    case 4:
                        risultato += "1/2";
                        break;
                    case 5:
                        risultato += "5/8";
                        break;
                    case 6:
                        risultato += "3/4";
                        break;
                    case 7:
                        risultato += "7/8";
                        break;
                    default:
                        risultato += "7/8*";
                        break;
                }
            }
            else if (stopformula != "STOP" && divisore3 == "drops4")
            {
                div2 = (int)Math.Round(((ml_Totali - ((oncia * OnceType) + (div1 * OnceType / Convert.ToInt32(divisore2)))) / (OnceType / 384)), 0);
                switch (div2)
                {

                    case 0:
                        risultato += "0";
                        break;
                    case 1:
                    case 2:
                        risultato += "1/4";
                        break;
                    case 3:
                    case 4:
                        risultato += "1/2";
                        break;
                    case 5:
                    case 6:
                        risultato += "3/4";
                        break;
                    default:
                        risultato += "3/4*";
                        break;
                }
            }
            return risultato;
        }
        public void SendToDispenser(string TypeMachine, string PathFile, string ExeFile)
        {
            try
            {
                if (File.Exists(PathFile.ToString()))
                {
                    File.Delete(PathFile.ToString());
                }

                if (TypeMachine == "Hero standard driver")
                {
                    TextWriter tw = new StreamWriter(PathFile.ToString());
                    if (this.p1.Length > 0) { tw.WriteLine(this.codep1 + ";" + this.qml1.ToString().Replace(".", ",")); }
                    if (this.p2.Length > 0) { tw.WriteLine(this.codep2 + ";" + this.qml2.ToString().Replace(".", ",")); }
                    if (this.p3.Length > 0) { tw.WriteLine(this.codep3 + ";" + this.qml3.ToString().Replace(".", ",")); }
                    if (this.p4.Length > 0) { tw.WriteLine(this.codep4 + ";" + this.qml4.ToString().Replace(".", ",")); }
                    if (this.p5.Length > 0) { tw.WriteLine(this.codep5 + ";" + this.qml5.ToString().Replace(".", ",")); }
                    tw.Close();
                }
                else if (TypeMachine == "Corob FLINK standard" || TypeMachine == "Santint Driver")
                {
                    string TmpPig = "NULL";
                    TextWriter tw = new StreamWriter(PathFile.ToString());
                    tw.WriteLine("@RUN");
                    tw.WriteLine("@PRD \"" + this.system + "\"");
                    tw.WriteLine("@WGH 0");
                    tw.WriteLine("@UNT 31.24 384");
                    tw.WriteLine("@CLR \"Color: " + this.colorname + "\"");
                    tw.WriteLine("@BAS \"" + this.sbase + "\"");
                    tw.WriteLine("@CAN \"" + this.LattValue + " " + this.LattUnit + "\" " + this.LattValue * 1000);
                    tw.WriteLine("@FRM 0");

                    if (this.p1.Length > 0) { TmpPig = "@CNT \"" + this.codep1 + "\" " + this.qonce1.ToString().Replace(",", "."); }
                    if (this.p2.Length > 0) { TmpPig = TmpPig + " \"" + this.codep2 + "\" " + this.qonce2.ToString().Replace(",", "."); }
                    if (this.p3.Length > 0) { TmpPig = TmpPig + " \"" + this.codep3 + "\" " + this.qonce3.ToString().Replace(",", "."); }
                    if (this.p4.Length > 0) { TmpPig = TmpPig + " \"" + this.codep4 + "\" " + this.qonce4.ToString().Replace(",", "."); }
                    if (this.p5.Length > 0) { TmpPig = TmpPig + " \"" + this.codep5 + "\" " + this.qonce5.ToString().Replace(",", "."); }

                    tw.WriteLine(TmpPig);
                    tw.WriteLine("@END");
                    tw.Close();
                }
                else if (TypeMachine == "Edel Painter Driver")
                {
                    //Calcolo numero ingredienti
                    int NColorant = 0;
                    if (this.p1.Length > 0) { NColorant++; }
                    if (this.p2.Length > 0) { NColorant++; }
                    if (this.p3.Length > 0) { NColorant++; }
                    if (this.p4.Length > 0) { NColorant++; }
                    if (this.p5.Length > 0) { NColorant++; }

                    //The calculation is: (65536 * Blue) + (256 * Green) + (Red)
                    int RGBIntero = (65536 * Convert.ToInt32(this.B)) + (256 * Convert.ToInt32(this.G)) + Convert.ToInt32(this.R);

                    TextWriter tw = new StreamWriter(PathFile.ToString());
                    tw.WriteLine("[FORMULA1]");
                    tw.WriteLine("NumColorants=" + NColorant.ToString());
                    tw.WriteLine("ColorName=");
                    tw.WriteLine("ColorNumber=");
                    tw.WriteLine("System=");
                    tw.WriteLine("Brand=");
                    tw.WriteLine("CanSize=STANDARD");
                    tw.WriteLine("DispenseUnit=cc");
                    tw.WriteLine("FractionalPart=1");
                    tw.WriteLine("PartialShot=1");
                    tw.WriteLine("Base=STANDARD");
                    tw.WriteLine("RGB=" + RGBIntero.ToString());
                    tw.WriteLine("CollectionName=");
                    tw.WriteLine("BaseAmount=");
                    tw.WriteLine("TypeID=");

                    tw.WriteLine("");
                    tw.WriteLine("[INGREDIENTS1]");
                    if (this.p1.Length > 0) { tw.WriteLine(this.codep1 + "=" + this.qml1.ToString().Replace(",",".")); }
                    if (this.p2.Length > 0) { tw.WriteLine(this.codep2 + "=" + this.qml2.ToString().Replace(",", ".")); }
                    if (this.p3.Length > 0) { tw.WriteLine(this.codep3 + "=" + this.qml3.ToString().Replace(",", ".")); }
                    if (this.p4.Length > 0) { tw.WriteLine(this.codep4 + "=" + this.qml4.ToString().Replace(",", ".")); }
                    if (this.p5.Length > 0) { tw.WriteLine(this.codep5 + "=" + this.qml5.ToString().Replace(",", ".")); }

                    tw.WriteLine("");
                    tw.WriteLine("[STATUS]");
                    tw.WriteLine("Cancel=0");
                    tw.Close();
                }
                else if (TypeMachine == "Fast & Fluid PPD")
                {
                                   
                    TextWriter tw = new StreamWriter(PathFile.ToString());
                    tw.WriteLine(this.LattValue.ToString().Replace(".",",") + ";" + this.LattUnit);
                    tw.WriteLine("MILLILITER");
                    if (this.p1.Length > 0) { tw.WriteLine(this.codep1 + ";" + this.qml1.ToString().Replace(".", ",")); }
                    if (this.p2.Length > 0) { tw.WriteLine(this.codep2 + ";" + this.qml2.ToString().Replace(".", ",")); }
                    if (this.p3.Length > 0) { tw.WriteLine(this.codep3 + ";" + this.qml3.ToString().Replace(".", ",")); }
                    if (this.p4.Length > 0) { tw.WriteLine(this.codep4 + ";" + this.qml4.ToString().Replace(".", ",")); }
                    if (this.p5.Length > 0) { tw.WriteLine(this.codep5 + ";" + this.qml5.ToString().Replace(".", ",")); }

                    tw.Close();
                }
                else if (TypeMachine == "Tecmec Driver 4")
                {
                    //Calcolo numero ingredienti
                    int NColorant = 0;
                    if (this.p1.Length > 0) { NColorant++; }
                    if (this.p2.Length > 0) { NColorant++; }
                    if (this.p3.Length > 0) { NColorant++; }
                    if (this.p4.Length > 0) { NColorant++; }
                    if (this.p5.Length > 0) { NColorant++; }


                    TextWriter tw = new StreamWriter(PathFile.ToString());
                    tw.WriteLine("P, EuroFormulations 4");
                    tw.WriteLine("I,\"" + this.colorname.ToString() + "\"");
                    tw.WriteLine("I,\"" + this.system.ToString() + "\"");
                    tw.WriteLine("I,\"" + this.sbase.ToString() + "\"");
                    tw.WriteLine("T," +  Math.Round(this.qmlt_Base,4).ToString().Replace(",",".") + "," + NColorant.ToString());
                    tw.WriteLine("L," + this.LattValue.ToString().Replace(",", ".") + ",0");
                    tw.WriteLine("R,\"" + this.sbase.ToString() + "\", " + Math.Round(this.LattValue * 1000, 2).ToString().Replace(",", ".") + ",0");
                    if (this.p1.Length > 0) { tw.WriteLine("C,\"" + this.codep1 + "\"," + Math.Round(this.qml1 / this.LattValue, 2).ToString().Replace(",", ".") + ",-1"); }
                    if (this.p2.Length > 0) { tw.WriteLine("C,\"" + this.codep2 + "\"," + Math.Round(this.qml2 / this.LattValue, 2).ToString().Replace(",", ".") + ",-1"); }
                    if (this.p3.Length > 0) { tw.WriteLine("C,\"" + this.codep3 + "\"," + Math.Round(this.qml3 / this.LattValue, 2).ToString().Replace(",", ".") + ",-1"); }
                    if (this.p4.Length > 0) { tw.WriteLine("C,\"" + this.codep4 + "\"," + Math.Round(this.qml4 / this.LattValue, 2).ToString().Replace(",", ".") + ",-1"); }
                    if (this.p5.Length > 0) { tw.WriteLine("C,\"" + this.codep5 + "\"," + Math.Round(this.qml5 / this.LattValue, 2).ToString().Replace(",", ".") + ",-1"); }
                    tw.WriteLine("U," + this.LattUnit + ",0");
                    tw.WriteLine("D,0,-1");
                    tw.WriteLine("N,1,-1");
                    tw.WriteLine("V,1");
                    tw.Close();
                }
                
            }
            catch (Exception) { }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ExeFile;
                Process exeProcess = Process.Start(startInfo);
            }
            catch (Exception) { }
        }
        
        
        public void SendToDispenser_Custom(List<string> colorant, List<double> quantity, string unit, int IdMachine, string ounceManual = "31.24/384", string nometinta = "PERSONAL", string nomebase = "PERSONAL")
        {
            this.Clear();

            Library.Data.Database.DBConnect_Npgsql dbc = new Library.Data.Database.DBConnect_Npgsql();
            dbc.connect(GVar.Database);

            int NColorant = colorant.Count();
            string[] DivTMP_O = ounceManual.Split('/');
            string TypeMachine_;
            string PathFile_;
            string ExeFile_;
            double Div = 0;
            this.sbase = nomebase;
            this.colorname = nometinta;
            Div = Convert.ToDouble(DivTMP_O[0].Replace(',', '.'), CultureInfo.InvariantCulture) / Convert.ToDouble(DivTMP_O[1].Replace(',', '.'), CultureInfo.InvariantCulture);

            #region LETTURA NOME PIGMENTI
            if (NColorant >= 1) { p1 = colorant[0]; }
            if (NColorant >= 2) { p2 = colorant[1]; }
            if (NColorant >= 3) { p3 = colorant[2]; }
            if (NColorant >= 4) { p4 = colorant[3]; }
            if (NColorant >= 5) { p5 = colorant[4]; }
            #endregion

            #region LETTURA DENSITA'
            //Pigmento1
            dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p1 + "' or fullname = '" + this.p1 + "'", ref TabPigment);
            while (TabPigment.Read())
            {
                this.fullp1 = TabPigment["fullname"].ToString();
                if (TabPigment["density"].ToString().Trim() != "")
                {
                    this.d1 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    this.codep1 = TabPigment["code"].ToString();
                }
            }
            TabPigment.Close();
            //Pigmento2
            dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p2 + "' or fullname = '" + this.p2 + "'", ref TabPigment);
            while (TabPigment.Read())
            {
                this.fullp2 = TabPigment["fullname"].ToString();
                if (TabPigment["density"].ToString().Trim() != "")
                {
                    this.d2 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    this.codep2 = TabPigment["code"].ToString();
                }
            }
            TabPigment.Close();
            //Pigmento3
            dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p3 + "' or fullname = '" + this.p3 + "'", ref TabPigment);
            while (TabPigment.Read())
            {
                this.fullp3 = TabPigment["fullname"].ToString();
                if (TabPigment["density"].ToString().Trim() != "")
                {
                    this.d3 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    this.codep3 = TabPigment["code"].ToString();
                }
            }
            TabPigment.Close();
            //Pigmento4
            dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p4 + "' or fullname = '" + this.p4 + "'", ref TabPigment);
            while (TabPigment.Read())
            {
                this.fullp4 = TabPigment["fullname"].ToString();
                if (TabPigment["density"].ToString().Trim() != "")
                {
                    this.d4 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    this.codep4 = TabPigment["code"].ToString();
                }
            }
            TabPigment.Close();
            //Pigmento5
            dbc.sqlview_ErrorSafe("Select * From pigmenti where code = '" + this.p5 + "' or fullname = '" + this.p5 + "'", ref TabPigment);
            while (TabPigment.Read())
            {
                this.fullp5 = TabPigment["fullname"].ToString();
                if (TabPigment["density"].ToString().Trim() != "")
                {
                    this.d5 = Convert.ToDouble(TabPigment["density"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    this.codep5 = TabPigment["code"].ToString();
                }
            }
            TabPigment.Close();
            #endregion

            #region Valori inseriti in GRAMMI
            if (unit == "GRAMS")
            {
                if (NColorant >= 1) { qg1 = quantity[0]; qml1 = quantity[0] / d1; qonce1 = qml1 / (31.24 / 384); }
                if (NColorant >= 2) { qg2 = quantity[1]; qml2 = quantity[1] / d2; qonce2 = qml2 / (31.24 / 384); }
                if (NColorant >= 3) { qg3 = quantity[2]; qml3 = quantity[2] / d3; qonce3 = qml3 / (31.24 / 384); }
                if (NColorant >= 4) { qg4 = quantity[3]; qml4 = quantity[3] / d4; qonce4 = qml4 / (31.24 / 384); }
                if (NColorant >= 5) { qg5 = quantity[4]; qml5 = quantity[4] / d5; qonce5 = qml5 / (31.24 / 384); }
            }
            #endregion

            #region Valori inseriti in MILLILITER
            if (unit == "MILLILITER")
            {
                if (NColorant >= 1) { qml1 = quantity[0]; qg1 = quantity[0] * d1; qonce1 = qml1 / (31.24 / 384); }
                if (NColorant >= 2) { qml2 = quantity[1]; qg2 = quantity[1] * d2; qonce1 = qml1 / (31.24 / 384); }
                if (NColorant >= 3) { qml3 = quantity[2]; qg3 = quantity[2] * d3; qonce1 = qml1 / (31.24 / 384); }
                if (NColorant >= 4) { qml4 = quantity[3]; qg4 = quantity[3] * d4; qonce1 = qml1 / (31.24 / 384); }
                if (NColorant >= 5) { qml5 = quantity[4]; qg5 = quantity[4] * d5; qonce1 = qml1 / (31.24 / 384); }
            }
            #endregion

            #region Valori inseriti in OUNCE
            if (unit == "ONCE")
            {
                if (NColorant >= 1) { qonce1 = quantity[0]; qml1 = quantity[0] * Div; qg1 = qml1 * d1; }
                if (NColorant >= 2) { qonce2 = quantity[1]; qml2 = quantity[1] * Div; qg2 = qml2 * d2; }
                if (NColorant >= 3) { qonce3 = quantity[2]; qml3 = quantity[2] * Div; qg3 = qml3 * d3; }
                if (NColorant >= 4) { qonce4 = quantity[3]; qml4 = quantity[3] * Div; qg4 = qml4 * d4; }
                if (NColorant >= 5) { qonce5 = quantity[4]; qml5 = quantity[4] * Div; qg5 = qml5 * d5; }
            }
            #endregion

            #region LETTURA TIPO MACCHINA
            dbc.sqlview_ErrorSafe("Select * From machine where id_machine = " + IdMachine, ref TabPigment);
            TabPigment.Read();
            TypeMachine_ = TabPigment["tipo_driver"].ToString();
            PathFile_ = TabPigment["pathfile"].ToString();
            ExeFile_ = TabPigment["exefile"].ToString();
            TabPigment.Close();
            #endregion

            SendToDispenser(TypeMachine_, PathFile_, ExeFile_);

            dbc.disconnect();
        }
         * */
    }
}
