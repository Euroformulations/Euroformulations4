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
using System.Diagnostics;
using System.IO;

namespace Euroformulations4.SubWindows.Statistiche
{
    public partial class frmStatCol : Form
    {
        private Language lang = Language.GetInstance();
        private Library.Data.Database.DBConnector db = new Library.Data.Database.DBConnector();

        public class GV
        {
            private static Language lang = Language.GetInstance();

            //Variabili Globali
            public static string TUTTELEBASE;
            public static string TUTTIIPRODOTTI;
            public static string TUTTECARTELLECOLORI;
            public static string TUTTIGLIUSI;

            public static void INIT_VAR()
            {
                TUTTELEBASE = lang.GetWord("stat17");
                TUTTIIPRODOTTI = lang.GetWord("stat18");
                TUTTECARTELLECOLORI = lang.GetWord("stat19");
                TUTTIGLIUSI = lang.GetWord("stat20");
            }
        }

        public frmStatCol()
        {
            InitializeComponent();
            GV.INIT_VAR();
        }

        private void frmStatistiche_Load(object sender, EventArgs e)
        {
            exeFilter.Text = lang.GetWord("search");
            btnGraphColoranti.Text = lang.GetWord("stat05");
            btnPrintColoranti.Text = lang.GetWord("printTable");
            gbPaints.Text = lang.GetWord("stat06");
            gbChart.Text = lang.GetWord("stat07");
            gbUse.Text = lang.GetWord("stat08");
            gbFrom.Text = lang.GetWord("stat09");
            gbTo.Text = lang.GetWord("stat10");
            inelaborazione.Text = lang.GetWord("stat11");
            dgColoranti.Columns[1].HeaderText = lang.GetWord("stat12");
            dgColoranti.Columns[2].HeaderText = lang.GetWord("stat13");
            dgColoranti.Columns[3].HeaderText = lang.GetWord("stat14");

            #region IMPOSTAZIONE INTERNAZIONALE FILTRI COMPLETI
            FilterBase.Items.Add(GV.TUTTELEBASE);           
            FilterColorCharts.Items.Add(GV.TUTTECARTELLECOLORI);           
            FilterUse.Items.Add(GV.TUTTIGLIUSI);
            
            //PrimoValore
            FilterBase.Text = GV.TUTTELEBASE;           
            FilterColorCharts.Text = GV.TUTTECARTELLECOLORI;
            FilterUse.Text = GV.TUTTIGLIUSI;
            #endregion

            #region DATA CORRENTE INIZIALE
            System.DateTime dateAnno = System.DateTime.Now;
            DalDate.Value = new DateTime(dateAnno.Year, 1, 1);
            AlDate.Value = new DateTime(dateAnno.Year, 12, 31);
            #endregion;

            #region DISABILITAZIONE COMPONENTI INIZIALE
            btnGraphColoranti.Enabled = false;
            btnPrintColoranti.Enabled = false;
            #endregion

            #region FILTRI DEL DATABASE PER GLI USI - CARTELLE COLORI - SISTEMA - BASI
            DataTable dt = db.SQLQuerySelect("SELECT DISTINCT(base) as baseB FROM history");
            foreach (DataRow dr in dt.Rows)
            {
                FilterBase.Items.Add(dr["baseB"]);
            }

            dt = db.SQLQuerySelect("SELECT DISTINCT(use) as IntExt FROM history");
            foreach (DataRow dr in dt.Rows)
            {
                FilterUse.Items.Add(dr["IntExt"]);
            }

            dt = db.SQLQuerySelect("SELECT DISTINCT(colorcharts) as Color FROM history");
            foreach (DataRow dr in dt.Rows)
            {
                FilterColorCharts.Items.Add(dr["Color"]);
            }
            #endregion

            SetButtonColor(btnGraphColoranti);
            SetButtonColor(btnPrintColoranti);
            this.ActiveControl = dgColoranti;
        }

        private void exeFilter_Click(object sender, EventArgs e)
        {
            double quantita = 0;
            string quantitaAssoluta = null;
            string NomeEsteso = null;
            double QuantitaTot_filter = 0;
            double quantitaTot = 0;
            string DataDalTmp = null;
            string DataAlTmp = null;

            #region IMPOSTAZIONE LIKE O VALORI REALI
            string DB_TUTTELEBASE = "base LIKE '%'";
            string DB_TUTTECARTELLECOLORI = "colorcharts LIKE '%'";
            string DB_TUTTIGLIUSI = "use LIKE '%'";
            if (FilterBase.Text != GV.TUTTELEBASE)
            {
                DB_TUTTELEBASE = "base = '" + FilterBase.Text + "'";
            }
            if (FilterColorCharts.Text != GV.TUTTECARTELLECOLORI)
            {
                DB_TUTTECARTELLECOLORI = "colorcharts = '" + FilterColorCharts.Text + "'";
            }
            if (FilterUse.Text != GV.TUTTIGLIUSI)
            {
                DB_TUTTIGLIUSI = "use = '" + FilterUse.Text + "'";
            }
            #endregion

            DataDalTmp = DalDate.Value.Year.ToString() + "/" + DalDate.Value.Month.ToString() + "/" + DalDate.Value.Day.ToString();
            DataAlTmp = AlDate.Value.Year.ToString() + "/" + AlDate.Value.Month.ToString() + "/" + AlDate.Value.Day.ToString();

            dgColoranti.Rows.Clear();
            inelaborazione.Visible = true;
            Application.DoEvents();

            QuantitaTot_filter = 0;
            quantitaTot = 0;

            #region  QUANTITA TOTALE SENZA FILTRO
            string sql = "SELECT SUM(q1) AS P1QS, SUM(q2) AS P2QS, SUM(q3) AS P3QS, SUM(q4) AS P4QS, SUM(q5) AS P5QS FROM  (SELECT * FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "') AS derivedTable";
            DataTable dt = db.SQLQuerySelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["p1qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(dr["p1qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
                if (dr["p2qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(dr["p2qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
                if (dr["p3qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(dr["p3qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
                if (dr["p4qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(dr["p4qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
                if (dr["p5qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(dr["p5qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
            }
            #endregion

            #region  QUANTITA FILTRO
            if (FilterBase.Text != GV.TUTTELEBASE || FilterUse.Text != GV.TUTTIGLIUSI || FilterColorCharts.Text != GV.TUTTECARTELLECOLORI)
            {
                string sql2 = "SELECT SUM(q1) as P1QS, SUM(q2) as P2QS, SUM(q3) as P3QS, SUM(q4) as P4QS, SUM(q5) as P5QS  FROM history WHERE " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                DataTable dt2 = db.SQLQuerySelect(sql2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    if (dr2["p1qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(dr2["p1qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    if (dr2["p2qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(dr2["p2qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    if (dr2["p3qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(dr2["p3qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    if (dr2["p4qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(dr2["p4qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    if (dr2["p5qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(dr2["p5qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                }
            }
            #endregion

            string sql3 = "SELECT DISTINCT nome FROM (SELECT p1 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p2 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p3 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p4 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p5 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "') as derived WHERE char_length(nome) > 0";
            DataTable dt3 = db.SQLQuerySelect(sql3);
            foreach(DataRow dr3 in dt3.Rows)
            {
                quantita = 0;

                #region QUANTITA' PIGMENTO 1
                string sqlp1 = "SELECT SUM(q1) as P1QS FROM history WHERE p1 = '" + dr3["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and  dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    sqlp1 = "SELECT SUM(q1) as P1QS FROM history WHERE p1 = '" + dr3["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                }
                quantita += GetQuantity(sqlp1, "P1QS");
                #endregion
                #region QUANTITA' PIGMENTO 2
                string sqlp2 = "SELECT SUM(q2) as P2QS FROM history WHERE p2 = '" + dr3["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    sqlp2 = "SELECT SUM(q2) as P2QS FROM history WHERE p2 = '" + dr3["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                }
                quantita += GetQuantity(sqlp2, "p2qs");
                #endregion
                #region QUANTITA' PIGMENTO 3
                string sqlp3 = "SELECT SUM(q3) as P3QS FROM history WHERE p3 = '" + dr3["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    sqlp3 = "SELECT SUM(q3) as P3QS FROM history WHERE p3 = '" + dr3["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                }
                quantita += GetQuantity(sqlp3, "p3qs");
                #endregion
                #region QUANTITA' PIGMENTO 4
                string sqlp4 = "SELECT SUM(q4) as P4QS FROM history WHERE p4 = '" + dr3["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    sqlp4 = "SELECT SUM(q4) as P4QS FROM history WHERE p4 = '" + dr3["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                }
                quantita += GetQuantity(sqlp4, "p4qs");
                #endregion
                #region QUANTITA' PIGMENTO 5
                string sqlp5 = "SELECT SUM(q5) as P5QS FROM history WHERE p5 = '" + dr3["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    sqlp5 = "SELECT SUM(q5) as P5QS FROM history WHERE p5 = '" + dr3["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                }
                quantita += GetQuantity(sqlp5, "p5qs");
                #endregion

                string sqlName = "SELECT * FROM pigmenti WHERE code = '" + dr3["nome"].ToString() + "'";
                DataTable dtNome = db.SQLQuerySelect(sqlName);
                if (dtNome.Rows.Count > 0)
                {
                    NomeEsteso = dtNome.Rows[0]["fullname"].ToString();
                }

                #region POPOLAZIONE DATAGRID
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    if (Math.Round(quantita, 3) > 0)
                    {
                        quantitaAssoluta = quantita.ToString();
                        quantita = (100 * quantita) / quantitaTot;
                        if (Convert.ToDouble(quantitaAssoluta.Replace(',', '.'), CultureInfo.InvariantCulture) > 1000)
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble((Convert.ToDouble(quantitaAssoluta.Replace(',', '.'), CultureInfo.InvariantCulture) / 1000)), 2) + " Lt";
                            dgColoranti.Rows.Add("Not", NomeEsteso, Math.Round(quantita, 2), quantitaAssoluta);
                            dgColoranti.Rows[dgColoranti.Rows.Count - 1].Cells[3].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble(quantitaAssoluta.Replace(',', '.'), CultureInfo.InvariantCulture), 2) + " ml";
                            dgColoranti.Rows.Add("Not", NomeEsteso, Math.Round(quantita, 2), quantitaAssoluta);
                        }
                    }
                }
                else
                {
                    if (Math.Round(quantita, 3) > 0)
                    {
                        quantitaAssoluta = quantita.ToString();
                        quantita = (100 * quantita) / (QuantitaTot_filter);
                        if (Convert.ToDouble(quantitaAssoluta.Replace(',', '.'), CultureInfo.InvariantCulture) > 1000)
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble((Convert.ToDouble(quantitaAssoluta.Replace(',', '.'), CultureInfo.InvariantCulture) / 1000)), 2) + " Lt";
                            dgColoranti.Rows.Add("Not", NomeEsteso, Math.Round(quantita, 2), quantitaAssoluta);
                            dgColoranti.Rows[dgColoranti.Rows.Count - 1].Cells[3].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble(quantitaAssoluta.Replace(',', '.'), CultureInfo.InvariantCulture), 2) + " ml";
                            dgColoranti.Rows.Add("Not", NomeEsteso, Math.Round(quantita, 2), quantitaAssoluta);
                        }
                    }
                }
                #endregion
            }

            btnGraphColoranti.Enabled = true;
            btnPrintColoranti.Enabled = true;
            inelaborazione.Visible = false;
        }

        private void btnColorantsGraph_Click(object sender, EventArgs e)
        {
            string[,] sData = new string[dgColoranti.Rows.Count, 2];

            for (int y = 0; y < dgColoranti.Rows.Count; y++)
            {
                sData[y, 0] = dgColoranti.Rows[y].Cells[1].Value.ToString();
                sData[y, 1] = dgColoranti.Rows[y].Cells[2].Value.ToString();
            }

            Statistiche.frmGrafico grafico = new Statistiche.frmGrafico(Statistiche.frmGrafico.eTipoGrafico.Coloranti, FilterBase.Text);
            grafico.Data = sData;
            grafico.ShowDialog();
        }

        private double GetQuantity(string sql, string fieldName)
        {
            double qta = 0d;
            DataTable dt = db.SQLQuerySelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[fieldName].ToString().Length > 0)
                {
                    qta += Convert.ToDouble(dr[fieldName].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
            }
            return qta;
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

        private void frmStatCol_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception) { }
        }
    }
}
