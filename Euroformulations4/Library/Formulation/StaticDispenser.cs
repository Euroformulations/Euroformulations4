using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Euroformulations4.Library.Formulation
{
    class StaticDispenser
    {
        public static void SendFormula2AutomaticDispenser(Formula formula, Library.Data.Machine.eMacchina machine_type, string PathFile, string ExeFile)
        {
            if (File.Exists(PathFile.ToString())){ File.Delete(PathFile.ToString()); }

            switch (machine_type)
            {
                case Data.Machine.eMacchina.Auto_Hero:
                    {
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            double qMl = Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, eUnita.ml, formula.ColorantDensita(i));
                            tw.WriteLine(formula.ColorantCode(i) + ";" + qMl.ToString().Replace(".", ","));
                        }
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_Corob:
                case Data.Machine.eMacchina.Auto_Santint:
                case Data.Machine.eMacchina.Auto_Dromont:
                    {
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine("@RUN");
                        tw.WriteLine("@PRD \"" + formula.BaseProdotto + "\"");
                        tw.WriteLine("@WGH 0");
                        tw.WriteLine("@UNT 29.57 384");
                        tw.WriteLine("@CLR \"Color: " + formula.FormulaName + "\"");
                        tw.WriteLine("@BAS \"" + formula.BaseName + "\"");
                        tw.WriteLine("@CAN \"" + formula.BaseQta + " " + formula.BaseUnita.ToString() + "\" " + formula.BaseQta * 1000);
                        tw.WriteLine("@FRM 0");

                        string TmpPig = "NULL";
                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            if (i == 0){TmpPig = "@CNT";}
                            double qMl = Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, eUnita.ml, formula.ColorantDensita(i));
                            double qOnce = Math.Round(((qMl * 384d) / 29.57d), 2);
                            TmpPig += " \"" + formula.ColorantCode(i) + "\" " + qOnce.ToString().Replace(",", ".");
                        }
                        tw.WriteLine(TmpPig);
                        tw.WriteLine("@END");
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_Edel:
                    {
                        //The calculation is: (65536 * Blue) + (256 * Green) + (Red)
                        int RGBIntero = (65536 * Convert.ToInt32(formula.RGB_B)) + (256 * Convert.ToInt32(formula.RGB_G)) + Convert.ToInt32(formula.RGB_R);

                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine("[FORMULA1]");
                        tw.WriteLine("NumColorants=" + formula.ColorantsCount.ToString());
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
                        /*
                        CONFIGURAZIONE PROPOSTA PER EDEL CON DATABASE INTERNO
                        tw.WriteLine("[FORMULA1]");
                        tw.WriteLine("NumColorants=" + formula.ColorantsCount.ToString());
                        tw.WriteLine("ColorName=");
                        tw.WriteLine("ColorNumber=");
                        tw.WriteLine("System=");
                        tw.WriteLine("Brand=");
                        tw.WriteLine("CanSize=2.500 Lt");
                        tw.WriteLine("DispenseUnit=Grams");
                        tw.WriteLine("FractionalPart=1");
                        tw.WriteLine("PartialShot=1");
                        tw.WriteLine("Base=TT");
                        tw.WriteLine("RGB=");
                        tw.WriteLine("CollectionName=");
                        tw.WriteLine("BaseAmount=");
                        tw.WriteLine("TypeID=");
                         */
                        tw.WriteLine("");
                        tw.WriteLine("[INGREDIENTS1]");
                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            double qMl = Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, eUnita.ml, formula.ColorantDensita(i));
                            tw.WriteLine(formula.ColorantCode(i) + "=" + qMl.ToString().Replace(",", "."));
                        }
                        tw.WriteLine("");
                        tw.WriteLine("[STATUS]");
                        tw.WriteLine("Cancel=0");
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_FastFluid:
                    {
                        /*
                         * rif. Alberto Sardi: Senior Service Coordinator F&FM Italy | Tel 0266 091467 | Fax 0266 091550
                         NOTE:
                         * macchine LEOLUX
                         * {
                         *      compatibilità: da verificare se tutte
                         *      NOTE: installare PrismaPro v.2.5.1.378
                         * }
                         * 
                         * macchine HARVIL
                         * {
                         *      compatibilità: small-medium(es.HA-24m)-large: molto vecchie, no ricambi, controllare scheda interna versione >=29 (se no non si può interfacciare con PrismaPro, cioè incompatibile con EF4)
                         *                     200-400-600: chiedere ad Alberto Sardi
                         *                     450-650: le + recenti (nessun problema)
                         *      NOTE: installare PP v.2.6.3.529
                         * }
                         * ****************************************************************************************************************
                         *                      INTERFACCIAMENTO CON TINTOMETRO
                         *               
                         * 1) procurarsi file .idd (è un file di testo, serve a PrismaPro per parlare con la macchina)
                         *      ->per crearlo occorre per ogni canestro: capacità canestro, capacità pompa(2 o 5 once), numero canestro, codice colorante)
                         * 
                         * 2) carica file .idd su PrismaPro (avvio in modalità simulata, caricare file .idd e riavviare);
                         *  nella modalità simulata il software PrismaPro NON PARLA con la macchina.
                         * 
                         * 3) procurarsi database per PrismaPro (quando il cliente non usa EF4)
                         *      -> del cliente, oppure per noi è solo un insieme di <codice componente, nome componente> + 1 formula (di test)
                         *      
                         *  ???   
                         * 
                         * 3) verificare il funzionamento di PrismaPro erogando la formula di esempio sul tintometro
                         * 
                         * 4) installare il nostro PrismaPro Driver (verificare l'invio di una formula da un file di test)
                         * 
                         * 5) installare EF4 (verificare l'invio di una formula di test)
                         * 
                         * 
                         */
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine(formula.BaseQta.ToString().Replace(".", ",") + ";" + formula.BaseUnita.ToString());
                        tw.WriteLine("MILLILITER");
                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            double qMl = Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, eUnita.ml, formula.ColorantDensita(i));
                            tw.WriteLine(formula.ColorantCode(i) + ";" + qMl.ToString().Replace(".", ","));
                        }
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_Tecmec:
                    {
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine("P, EuroFormulations 4");
                        tw.WriteLine("I,\"" + formula.FormulaName + "\"");
                        tw.WriteLine("I,\"" + formula.BaseProdotto + "\"");
                        tw.WriteLine("I,\"" + formula.BaseName + "\"");
                        double qtaBaseMl = Formula.ConvertValue(formula.BaseQta, formula.BaseUnita, eUnita.ml, formula.BaseDensita);
                        tw.WriteLine("T," + Math.Round(qtaBaseMl, 4).ToString().Replace(",", ".") + "," + formula.ColorantsCount); //ttoale base + color in ml
                        tw.WriteLine("L," + formula.BaseQta.ToString().Replace(",", ".") + ",0"); 
                        tw.WriteLine("R,\"" + formula.BaseName + "\", " + Math.Round(formula.BaseQta * 1000, 2).ToString().Replace(",", ".") + ",0");

                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            double qMl = Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, eUnita.ml, formula.ColorantDensita(i));
                            tw.WriteLine("C,\"" + formula.ColorantCode(i) + "\"," + Math.Round(formula.ColorantQta(i) / formula.BaseQta, 2).ToString().Replace(",", ".") + ",-1");
                        }
                        tw.WriteLine("U," + formula.BaseUnita.ToString() + ",0");
                        tw.WriteLine("D,0,-1");
                        tw.WriteLine("N,1,-1");
                        tw.WriteLine("V,1");
                        tw.Close();
                        break;
                    }
            }

            if (ExeFile.Trim() != "")
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ExeFile;
                Process exeProcess = Process.Start(startInfo);
            }
        }

        /*
            sUnit: G|M  -> (grams, milliliters)
            sUnitaBase:KG|LT -> (chili, litri)
        */
        public static string SendCustom2AutomaticDispenser(List<string> lstColorantCode, List<double> lstQta, List<double> lstDensita, string sUnit, string nometinta, string nomebase, string sQtaBase, string sUnitaBase, double dDensitaBase, string sNomeProdotto, Library.Data.Machine.eMacchina machine_type, string PathFile, string ExeFile)
        {
            string sErrors = "";
            string sNomeTinta = "custom_dispense";

            try
            {
                if (sUnit == "") { throw new Exception("formula unit not found"); }
                eUnita unitaCol = eUnita.ml;
                if (sUnit == "G") {unitaCol = eUnita.gr; }
                eUnita unitaBase = eUnita.KG;
                if (sUnitaBase == "LT"){ unitaBase = eUnita.LT; }
                
                if (File.Exists(PathFile.ToString())) { File.Delete(PathFile.ToString()); }

                switch (machine_type)
                {
                    case Data.Machine.eMacchina.Auto_Hero:
                        {
                            TextWriter tw = new StreamWriter(PathFile.ToString());
                            for (int i = 0; i < lstColorantCode.Count; i++)
                            {
                                double qMl = Formula.ConvertValue(lstQta[i], unitaCol, eUnita.ml, lstDensita[i]);
                                tw.WriteLine(lstColorantCode[i] + ";" + qMl.ToString().Replace(".", ","));
                            }
                            tw.Close();
                            break;
                        }
                    case Data.Machine.eMacchina.Auto_Corob:
                    case Data.Machine.eMacchina.Auto_Santint:
                        {
                            TextWriter tw = new StreamWriter(PathFile.ToString());
                            tw.WriteLine("@RUN");
                            tw.WriteLine("@PRD \"" + sNomeProdotto + "\"");
                            tw.WriteLine("@WGH 0");
                            tw.WriteLine("@UNT 29.57 384");
                            tw.WriteLine("@CLR \"Color: " + sNomeTinta + "\"");
                            tw.WriteLine("@BAS \"" + nomebase + "\"");
                            tw.WriteLine("@CAN \"" + sQtaBase.Replace(",", ".") + " " + unitaBase.ToString() + "\" " + Convert.ToDouble(sQtaBase) * 1000);
                            tw.WriteLine("@FRM 0");

                            string TmpPig = "NULL";
                            for (int i = 0; i < lstColorantCode.Count; i++)
                            {
                                if (i == 0) { TmpPig = "@CNT"; }
                                double qMl = Formula.ConvertValue(lstQta[i], unitaCol, eUnita.ml, lstDensita[i]);
                                double qOnce = Math.Round(((qMl * 384d) / 29.57d), 2);
                                TmpPig += " \"" + lstColorantCode[i] + "\" " + qOnce.ToString().Replace(",", ".");
                            }
                            tw.WriteLine(TmpPig);
                            tw.WriteLine("@END");
                            tw.Close();
                            break;
                        }
                    case Data.Machine.eMacchina.Auto_Edel:
                        {
                            //The calculation is: (65536 * Blue) + (256 * Green) + (Red)
                            int RGBIntero = (65536 * 255) + (256 * 255) + 255;

                            TextWriter tw = new StreamWriter(PathFile.ToString());
                            tw.WriteLine("[FORMULA1]");
                            tw.WriteLine("NumColorants=" + lstColorantCode.Count.ToString());
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
                            /*
                            CONFIGURAZIONE PROPOSTA PER EDEL CON DATABASE INTERNO
                            tw.WriteLine("[FORMULA1]");
                            tw.WriteLine("NumColorants=" + formula.ColorantsCount.ToString());
                            tw.WriteLine("ColorName=");
                            tw.WriteLine("ColorNumber=");
                            tw.WriteLine("System=");
                            tw.WriteLine("Brand=");
                            tw.WriteLine("CanSize=2.500 Lt");
                            tw.WriteLine("DispenseUnit=Grams");
                            tw.WriteLine("FractionalPart=1");
                            tw.WriteLine("PartialShot=1");
                            tw.WriteLine("Base=TT");
                            tw.WriteLine("RGB=");
                            tw.WriteLine("CollectionName=");
                            tw.WriteLine("BaseAmount=");
                            tw.WriteLine("TypeID=");
                             */
                            tw.WriteLine("");
                            tw.WriteLine("[INGREDIENTS1]");
                            for (int i = 0; i < lstColorantCode.Count; i++)
                            {
                                double qMl = Formula.ConvertValue(lstQta[i], unitaCol, eUnita.ml, lstDensita[i]);
                                tw.WriteLine(lstColorantCode[i] + "=" + qMl.ToString().Replace(",", "."));
                            }
                            tw.WriteLine("");
                            tw.WriteLine("[STATUS]");
                            tw.WriteLine("Cancel=0");
                            tw.Close();
                            break;
                        }
                    case Data.Machine.eMacchina.Auto_FastFluid:
                        {
                            TextWriter tw = new StreamWriter(PathFile.ToString());
                            tw.WriteLine(sQtaBase.Replace(".", ",") + ";" + unitaBase.ToString());
                            tw.WriteLine("MILLILITER");
                            for (int i = 0; i < lstColorantCode.Count; i++)
                            {
                                double qMl = Formula.ConvertValue(lstQta[i], unitaCol, eUnita.ml, lstDensita[i]);
                                tw.WriteLine(lstColorantCode[i] + ";" + qMl.ToString().Replace(".", ","));
                            }
                            tw.Close();
                            break;
                        }
                    case Data.Machine.eMacchina.Auto_Tecmec:
                        {
                            TextWriter tw = new StreamWriter(PathFile.ToString());
                            tw.WriteLine("P, EuroFormulations 4");
                            tw.WriteLine("I,\"" + sNomeTinta + "\"");
                            tw.WriteLine("I,\"" + sNomeProdotto + "\"");
                            tw.WriteLine("I,\"" + nomebase + "\"");
                            double qtaBaseMl = Formula.ConvertValue(Convert.ToDouble(sQtaBase), unitaBase, eUnita.ml, dDensitaBase);
                            tw.WriteLine("T," + Math.Round(qtaBaseMl, 4).ToString().Replace(",", ".") + "," + lstColorantCode.Count); //ttoale base + color in ml
                            tw.WriteLine("L," + sQtaBase.Replace(",", ".") + ",0");
                            tw.WriteLine("R,\"" + nomebase + "\", " + Math.Round(Convert.ToDouble(sQtaBase) * 1000, 2).ToString().Replace(",", ".") + ",0");

                            for (int i = 0; i < lstColorantCode.Count; i++)
                            {
                                double qMl = Formula.ConvertValue(lstQta[i], unitaCol, eUnita.ml, lstDensita[i]);
                                tw.WriteLine("C,\"" + lstColorantCode[i] + "\"," + Math.Round(lstQta[i] / Convert.ToDouble(sQtaBase), 2).ToString().Replace(",", ".") + ",-1");
                            }
                            tw.WriteLine("U," + unitaBase.ToString() + ",0");
                            tw.WriteLine("D,0,-1");
                            tw.WriteLine("N,1,-1");
                            tw.WriteLine("V,1");
                            tw.Close();
                            break;
                        }
                }

                if (ExeFile.Trim() != "")
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = ExeFile;
                    Process exeProcess = Process.Start(startInfo);
                }

            }
            catch (Exception ex)
            {
                sErrors = ex.Message;
            }

            return sErrors;
        }


        public static void SendColorant2AutomaticDispenser(String[,] colorant, Library.Data.Machine.eMacchina machine_type, string PathFile, string ExeFile , eUnita unita)
        {
            if (File.Exists(PathFile.ToString())) { File.Delete(PathFile.ToString()); }
            string[,] app;
            app = colorant;
            switch (machine_type)
            {
                case Data.Machine.eMacchina.Auto_Hero:
                    {
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        for (int i = 0; i < colorant.Length/8; i++)
                        {
                            double qMl = Formula.ConvertValue(Convert.ToDouble(colorant[i,7]) /*coloratnQta*/, unita, eUnita.ml, Convert.ToDouble(colorant[i,3]) /*densita*/);
                            tw.WriteLine(colorant[i,2] + ";" + qMl.ToString().Replace(".", ","));
                        }
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_Corob:
                case Data.Machine.eMacchina.Auto_Santint:
                case Data.Machine.eMacchina.Auto_Dromont:
                    {
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine("@RUN");
                        tw.WriteLine("@PRD \"" + "" + "\"");
                        tw.WriteLine("@WGH 0");
                        tw.WriteLine("@UNT 29.57 384");
                        tw.WriteLine("@CLR \"Color: " + "" + "\"");
                        tw.WriteLine("@BAS \"" + "" + "\"");
                        tw.WriteLine("@CAN \"" + "" + " " + "" + "\" " + "");
                        tw.WriteLine("@FRM 0");

                        string TmpPig = "NULL";
                        for (int i = 0; i < (colorant.Length/8) ; i++)
                        {
                            if (i == 0) { TmpPig = "@CNT"; }
                            double qMl = Formula.ConvertValue(Convert.ToDouble(colorant[i, 7]) /*coloratnQta*/, unita, eUnita.ml, Convert.ToDouble(colorant[i, 3]) /*densita*/);
                            double qOnce = Math.Round(((qMl * 384d) / 29.57d), 2);
                            TmpPig += " \"" + colorant[i, 2] + "\" " + qOnce.ToString().Replace(",", ".");
                        }
                        tw.WriteLine(TmpPig);
                        tw.WriteLine("@END");
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_Edel:
                    {
                        //The calculation is: (65536 * Blue) + (256 * Green) + (Red)
                        int RGBIntero = 0 /*(65536 * Convert.ToInt32(formula.RGB_B)) + (256 * Convert.ToInt32(formula.RGB_G)) + Convert.ToInt32(formula.RGB_R)*/;

                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine("[FORMULA1]");
                        tw.WriteLine("NumColorants=" + colorant.Length.ToString());
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
                        /*
                        CONFIGURAZIONE PROPOSTA PER EDEL CON DATABASE INTERNO
                        tw.WriteLine("[FORMULA1]");
                        tw.WriteLine("NumColorants=" + formula.ColorantsCount.ToString());
                        tw.WriteLine("ColorName=");
                        tw.WriteLine("ColorNumber=");
                        tw.WriteLine("System=");
                        tw.WriteLine("Brand=");
                        tw.WriteLine("CanSize=2.500 Lt");
                        tw.WriteLine("DispenseUnit=Grams");
                        tw.WriteLine("FractionalPart=1");
                        tw.WriteLine("PartialShot=1");
                        tw.WriteLine("Base=TT");
                        tw.WriteLine("RGB=");
                        tw.WriteLine("CollectionName=");
                        tw.WriteLine("BaseAmount=");
                        tw.WriteLine("TypeID=");
                         */
                        tw.WriteLine("");
                        tw.WriteLine("[INGREDIENTS1]");
                        for (int i = 0; i < (colorant.Length / 8); i++)
                        {
                            double qMl = Formula.ConvertValue(Convert.ToDouble(colorant[i, 7]) /*coloratnQta*/, unita, eUnita.ml, Convert.ToDouble(colorant[i, 3]) /*densita*/);
                            tw.WriteLine(colorant[i,2] + "=" + qMl.ToString().Replace(",", "."));
                        }
                        tw.WriteLine("");
                        tw.WriteLine("[STATUS]");
                        tw.WriteLine("Cancel=0");
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_FastFluid:
                    {
                        /*
                         * rif. Alberto Sardi: Senior Service Coordinator F&FM Italy | Tel 0266 091467 | Fax 0266 091550
                         NOTE:
                         * macchine LEOLUX
                         * {
                         *      compatibilità: da verificare se tutte
                         *      NOTE: installare PrismaPro v.2.5.1.378
                         * }
                         * 
                         * macchine HARVIL
                         * {
                         *      compatibilità: small-medium(es.HA-24m)-large: molto vecchie, no ricambi, controllare scheda interna versione >=29 (se no non si può interfacciare con PrismaPro, cioè incompatibile con EF4)
                         *                     200-400-600: chiedere ad Alberto Sardi
                         *                     450-650: le + recenti (nessun problema)
                         *      NOTE: installare PP v.2.6.3.529
                         * }
                         * ****************************************************************************************************************
                         *                      INTERFACCIAMENTO CON TINTOMETRO
                         *               
                         * 1) procurarsi file .idd (è un file di testo, serve a PrismaPro per parlare con la macchina)
                         *      ->per crearlo occorre per ogni canestro: capacità canestro, capacità pompa(2 o 5 once), numero canestro, codice colorante)
                         * 
                         * 2) carica file .idd su PrismaPro (avvio in modalità simulata, caricare file .idd e riavviare);
                         *  nella modalità simulata il software PrismaPro NON PARLA con la macchina.
                         * 
                         * 3) procurarsi database per PrismaPro (quando il cliente non usa EF4)
                         *      -> del cliente, oppure per noi è solo un insieme di <codice componente, nome componente> + 1 formula (di test)
                         *      
                         *  ???   
                         * 
                         * 3) verificare il funzionamento di PrismaPro erogando la formula di esempio sul tintometro
                         * 
                         * 4) installare il nostro PrismaPro Driver (verificare l'invio di una formula da un file di test)
                         * 
                         * 5) installare EF4 (verificare l'invio di una formula di test)
                         * 
                         * 
                         */
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine("BASE");
                        tw.WriteLine("MILLILITER");
                        for (int i = 0; i < (colorant.Length / 8); i++)
                        {
                            double qMl = Formula.ConvertValue(Convert.ToDouble(colorant[i, 7]) /*coloratnQta*/, unita, eUnita.ml, Convert.ToDouble(colorant[i, 3]) /*densita*/);
                            tw.WriteLine(colorant[i,2] + ";" + qMl.ToString().Replace(".", ","));
                        }
                        tw.Close();
                        break;
                    }
                case Data.Machine.eMacchina.Auto_Tecmec:
                    {
                        TextWriter tw = new StreamWriter(PathFile.ToString());
                        tw.WriteLine("P, EuroFormulations 4");
                        tw.WriteLine("I,\"" + "" + "\"");
                        tw.WriteLine("I,\"" + "" + "\"");
                        tw.WriteLine("I,\"" + "" + "\"");
                        tw.WriteLine("T," + 1.0 + colorant.Length); //ttoale base + color in ml
                        tw.WriteLine("L," + 1.0);
                        tw.WriteLine("R,\"" + "" + "\", " + Math.Round(1.0 * 1000, 2).ToString().Replace(",", ".") + ",0");

                        for (int i = 0; i < (colorant.Length / 8); i++)
                        {
                            double qMl = Formula.ConvertValue(Convert.ToDouble(colorant[i, 7]) /*coloratnQta*/, unita, eUnita.ml, Convert.ToDouble(colorant[i, 3]) /*densita*/);
                            tw.WriteLine("C,\"" + colorant[i,2] + "\"," + Math.Round(Convert.ToDouble(colorant[i, 7]) / 1.0, 2).ToString().Replace(",", ".") + ",-1");
                        }
                        tw.WriteLine("U," + "KG" + ",0");
                        tw.WriteLine("D,0,-1");
                        tw.WriteLine("N,1,-1");
                        tw.WriteLine("V,1");
                        tw.Close();
                        break;
                    }
            }

            if (ExeFile.Trim() != "")
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ExeFile;
                Process exeProcess = Process.Start(startInfo);
            }
        }
    }
}
