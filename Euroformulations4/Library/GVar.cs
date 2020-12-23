using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library
{
    public static class GVar
    {
        #region VARIABILI CONFIGURAZIONI INIZIALI
        public static string Database;
        public static string ServerIP;
        public static Attivazioni attivazioni;
        public static int AppLocation_X = 0, AppLocation_Y = 0;
        #endregion

        public static bool appIsRunning;

        #region VARIABILI USATE NEL frmFormula
        public static Dictionary<string, double> ListaPigmenti = new Dictionary<string, double>();
        public static List<string> lstNomiFullColoranti = new List<string>();
        public static List<string> ListaBasi = new List<string>();
        #endregion

        #region VARIABILI USATE NEL frmRicercaColore
        public static Dictionary<int, string> dicProducts = new Dictionary<int, string>();
        public static Dictionary<int, string> dicColorcharts = new Dictionary<int, string>();
        public static List<Colore> lstColoriFull = new List<Colore>();
        public static bool bLoadFormuleEnded = false;
        #endregion

        public static void Flush()
        {
            ListaPigmenti.Clear();
            ListaBasi.Clear();
            dicProducts.Clear();
            dicColorcharts.Clear();
            lstColoriFull.Clear();
            bLoadFormuleEnded = false;
            lstNomiFullColoranti.Clear();
        }

    }
}
