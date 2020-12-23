using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;


namespace Euroformulations4.Library.Data
{
    public enum eMacchinaTipo
    {
        Automatica = 0,
        Manuale = 1
    }

    public enum eStandardOncia
    {
        Americano = 0,
        Europeo = 1
    }

    public class Machine
    {
        public enum eMacchina
        {
            Auto_Hero = 0,
            Auto_Edel = 1,
            Auto_Corob = 2,
            Auto_Tecmec = 3,
            Auto_Santint = 4,
            Auto_FastFluid = 5,
            Manual_Y_48_192 = 6,
            Manual_Y_48_384 = 7,
            Manual_Y_96_192 = 8,
            Manual_Y_96_384 = 9,
            Manual_Y_48 = 10,
            Manual_Y_96 = 11,
            Manual_Y_192 = 12,
            Manual_Y_48_drops8 = 13,
            Manual_Y_96_drops8 = 14,
            Manual_Y_48_drops4 = 15,
            Manual_Y_96_drops4 = 16,
            Manual_Y_384 = 17,
            Auto_Dromont = 18,
            Manual_Y_48_96 = 19,
            Manual_Y_32_128 = 20
        }

        public static Dictionary<eMacchina, string> dicNomiMacchine = new Dictionary<eMacchina, string>
        {
            {eMacchina.Auto_Hero, "Automatic Hero"},
            {eMacchina.Auto_Edel, "Automatic Edel"},
            {eMacchina.Auto_Corob, "Automatic Corob"},
            {eMacchina.Auto_Tecmec, "Automatic Tecmec"},
            {eMacchina.Auto_Santint, "Automatic Santint"},
            {eMacchina.Auto_FastFluid, "Automatic Fast&Fluid"},
            {eMacchina.Manual_Y_48_192, "Manual Y - 1/48 - 1/192"},
            {eMacchina.Manual_Y_48_384, "Manual Y - 1/48 - 1/384"},
            {eMacchina.Manual_Y_96_192, "Manual Y - 1/96 - 1/192"},
            {eMacchina.Manual_Y_96_384, "Manual Y - 1/96 - 1/384"},
            {eMacchina.Manual_Y_48, "Manual Y - 1/48"},
            {eMacchina.Manual_Y_96, "Manual Y - 1/96"},
            {eMacchina.Manual_Y_192, "Manual Y - 1/192"},
            {eMacchina.Manual_Y_48_drops8, "Manual Y - 1/48 - drops8"},
            {eMacchina.Manual_Y_96_drops8, "Manual Y - 1/96 - drops8"},
            {eMacchina.Manual_Y_48_drops4, "Manual Y - 1/48 - drops4"},
            {eMacchina.Manual_Y_96_drops4, "Manual Y - 1/96 - drops4"},
            {eMacchina.Manual_Y_384, "Manual Y - 1/384"},
            {eMacchina.Auto_Dromont, "Automatic Dromont"},
            {eMacchina.Manual_Y_48_96, "Manual Y - 1/48 - 1/96" },
            {eMacchina.Manual_Y_32_128, "Manual Y - 1/32 - 1/128" }
        };

        public static List<eMacchina> lstMacchineAutomatiche = new List<eMacchina>
        {
            {eMacchina.Auto_Hero},
            {eMacchina.Auto_Edel},
            {eMacchina.Auto_Corob},
            {eMacchina.Auto_Tecmec},
            {eMacchina.Auto_Santint},
            {eMacchina.Auto_FastFluid},
            {eMacchina.Auto_Dromont}
        };

        public static List<eMacchina> lstMacchineManuali = new List<eMacchina>
        {
            {eMacchina.Manual_Y_48_192},
            {eMacchina.Manual_Y_48_384},
            {eMacchina.Manual_Y_96_192},
            {eMacchina.Manual_Y_96_384},
            {eMacchina.Manual_Y_48},
            {eMacchina.Manual_Y_96},
            {eMacchina.Manual_Y_192},
            {eMacchina.Manual_Y_48_drops8},
            {eMacchina.Manual_Y_96_drops8},
            {eMacchina.Manual_Y_48_drops4},
            {eMacchina.Manual_Y_96_drops4},
            {eMacchina.Manual_Y_384},
            {eMacchina.Manual_Y_48_96 },
            {eMacchina.Manual_Y_32_128}
        };

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>


        private static Dictionary<eStandardOncia, double> ounceType = new Dictionary<eStandardOncia, double>()
        {
            {eStandardOncia.Americano, 29.57},
            {eStandardOncia.Europeo, 31.24}
        };

        public static Dictionary<eStandardOncia, double> OunceType
        {
            get { return ounceType; }
        }

        public static List<eMacchina> Drivers
        {
            get
            {
                if (GVar.attivazioni.Act__MacchineAutomatiche)
                {
                    List<eMacchina> lstAllDriver = new List<eMacchina>();
                    lstAllDriver.AddRange(lstMacchineAutomatiche);
                    lstAllDriver.AddRange(lstMacchineManuali);
                    return lstAllDriver;
                }
                else
                {
                    return lstMacchineManuali;
                }
            }
        }

        public static bool ContainsAuto(eMacchina machine)
        {
            return lstMacchineAutomatiche.Contains(machine);
        }
        public static bool ContainsManual(eMacchina machine)
        {
            return lstMacchineManuali.Contains(machine);
        }
        public static string SQLSelectMachines()
        {
            string sql = "SELECT * FROM machine";
            if (!GVar.attivazioni.Act__MacchineAutomatiche)
            {
                sql += " WHERE tipo = " + (int)Library.Data.eMacchinaTipo.Manuale;
            }
            sql += " ORDER BY name";
            return sql;
        }

        public static Dictionary<string, string> AutoConfigureDriver(eMacchina macchina)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("path", "");
            data.Add("exe", "");
            switch (macchina)
            {
                case eMacchina.Auto_Hero:
                    {
                        if (File.Exists(@"C:\HERO_SW\bin\MAIN\HERO_Main.exe"))
                        {
                            data["path"] = Application.StartupPath + @"\include\driver\heroformula.txt";
                            data["exe"] = @"C:\HERO_SW\bin\MAIN\HERO_Main.exe";

                            IniFile conf = new IniFile(@"C:\HERO_SW\Data\MAIN\AppData\NIT_Config.ini");
                            conf.IniWriteValue("Settings", "FormName", "TintWise Powered by EuroFormulations4");
                            conf.IniWriteValue("Settings", "ExtEnable", "-1");
                            conf.IniWriteValue("Settings", "ExtFileName", "heroformula.txt");
                            conf.IniWriteValue("Settings", "ExtFormat", "");
                            conf.IniWriteValue("Settings", "ExtPath", Application.StartupPath + @"\include\driver\");
                            conf.IniWriteValue("Settings", "ExtReduce", "-1");
                            conf.IniWriteValue("Settings", "ExtCmdEnable", "-1");
                            conf.IniWriteValue("Settings", "ShowRemoveCanMsg", "0");
                            conf.IniWriteValue("Settings", "ManageCustomer", "0");
                            conf.IniWriteValue("Settings", "AlwaysAskCustomerConfirm", "0");
                            conf.IniWriteValue("Units", "Components", "1");
                            conf.IniWriteValue("Units", "Bases", "3");
                            conf.IniWriteValue("Units", "Levels", "3");
                            conf.IniWriteValue("Units", "Fill", "3");
                            conf.IniWriteValue("Units", "Capacity", "3");
                        }
                        break;
                    }
                case eMacchina.Auto_Corob:
                    {
                        if (File.Exists(@"C:\wuser\CorobDRIVER\CorobDRIVER.exe"))
                        {
                            data["path"] = Application.StartupPath + @"\include\driver\corobformula.dat";
                            data["exe"] = @"C:\wuser\CorobDRIVER\CorobDRIVER.exe";
                        }
                        break;
                    }
                case eMacchina.Auto_Tecmec:
                    {
                        if (File.Exists(@"C:\Tecmec\Tecmec Driver\Config.xml"))
                        {
                            XmlAttributes(@"C:\Tecmec\Tecmec Driver\Config.xml", "//Item[@Name='DispensingUnit']", "mL");
                            XmlAttributes(@"C:\Tecmec\Tecmec Driver\Config.xml", "//Item[@Name='DisplayDecimals']", "2"); //Decimali
                            XmlAttributes(@"C:\Tecmec\Tecmec Driver\Config.xml", "//Item[@Name='FormulaFilePath']", Application.StartupPath + @"\include\driver\formula.txt");
                            XmlAttributes(@"C:\Tecmec\Tecmec Driver\Config.xml", "//Item[@Name='FormulaUnit']", "Auto");
                            data["path"] = Application.StartupPath + @"\include\driver\formula.txt";
                            data["exe"] = @"C:\Tecmec\Tecmec Driver\TecmecDriver.exe";
                        }
                        break;
                    }
            }
            return data;
        }
        public static bool bMachineAutoConfigurable(eMacchina macchina)
        {
            if (macchina == eMacchina.Auto_Hero || macchina == eMacchina.Auto_Corob || macchina == eMacchina.Auto_Tecmec)
            {
                return true;
            }

            return false;
        }

        private static void XmlAttributes(string XmlPath, string SearchAttributes, string SetAttributes)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlPath);
            XPathNavigator nav = doc.CreateNavigator();
            string sXPath = SearchAttributes;
            XPathNavigator nav2 = nav.SelectSingleNode(sXPath);
            nav2.SetValue(SetAttributes);
            string s = nav.OuterXml;
            System.IO.File.WriteAllText(XmlPath, s);
        }

    }
}
