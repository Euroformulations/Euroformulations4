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
    public partial class frmStatBasi : Form
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

        public frmStatBasi()
        {
            InitializeComponent();
            GV.INIT_VAR();
        }

        private void frmStatistiche_Load(object sender, EventArgs e)
        {
            try
            {
                exeFilterBase.Text = lang.GetWord("search");
                btnGraphBasi.Text = lang.GetWord("stat05");
                gbProduct.Text = lang.GetWord("stat15");
                gbChart.Text = lang.GetWord("stat07");
                gbUse.Text = lang.GetWord("stat08");
                gbFrom.Text = lang.GetWord("stat09");
                gbTo.Text = lang.GetWord("stat10");
                belaborazione.Text = lang.GetWord("stat11");
                dgBasi.Columns[1].HeaderText = lang.GetWord("stat16");
                dgBasi.Columns[2].HeaderText = lang.GetWord("stat13");
                dgBasi.Columns[3].HeaderText = lang.GetWord("stat14");
                dgBasi.Columns[4].HeaderText = lang.GetWord("stat14");

                #region INPOSTAZIONE INTERNAZIONALE FILTRI COMPLETI
                FilterProduct.Items.Add(GV.TUTTIIPRODOTTI);
                filterChartsBase.Items.Add(GV.TUTTECARTELLECOLORI);
                filterUseBase.Items.Add(GV.TUTTIGLIUSI);
                FilterProduct.Text = GV.TUTTIIPRODOTTI;
                filterUseBase.Text = GV.TUTTIGLIUSI;
                filterChartsBase.Text = GV.TUTTECARTELLECOLORI;
                #endregion

                #region DATA CORRENTE INIZIALE
                System.DateTime dateAnno = System.DateTime.Now;
                BaseDal.Value = new DateTime(dateAnno.Year, 1, 1);
                BaseAl.Value = new DateTime(dateAnno.Year, 12, 31);
                #endregion;

                #region DISABILITAZIONE COMPONENTI INIZIALE
                btnGraphBasi.Enabled = false;
                #endregion

                #region FILTRI DEL DATABASE PER GLI USI - CARTELLE COLORI - SISTEMA - BASI
                DataTable dt = db.SQLQuerySelect("SELECT DISTINCT(use) as IntExt FROM history");
                foreach (DataRow dr in dt.Rows)
                {
                    filterUseBase.Items.Add(dr["IntExt"]);
                }

                dt = db.SQLQuerySelect("SELECT DISTINCT(colorcharts) as Color FROM history");
                foreach (DataRow dr in dt.Rows)
                {
                    filterChartsBase.Items.Add(dr["Color"]);
                }

                dt = db.SQLQuerySelect("SELECT DISTINCT(system) as Sys, ordersystem FROM history ORDER BY ordersystem");
                foreach (DataRow dr in dt.Rows)
                {
                    FilterProduct.Items.Add(dr["Sys"]);
                }
                #endregion

                SetButtonColor(btnGraphBasi);
                this.ActiveControl = dgBasi;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void exeFilterBase_Click(object sender, EventArgs e)
        {
            double quantita = 0;
            double quantitaAssoluta = 0;
            double QuantitaTot_filter = 0;
            double quantitaTot = 0;
            double QuantitaTot_filterKG = 0;
            double quantitaKG = 0;
            double quantitaAssolutaKG = 0;
            double quantitaTotKG = 0;
            string DataDalTmp = null;
            string DataAlTmp = null;

            #region IMPOSTAZIONE LIKE O VALORI REALI
            string DB_TUTTIIPRODOTTI = "system LIKE '%'";
            string DB_TUTTECARTELLECOLORI = "colorcharts LIKE '%'";
            string DB_TUTTIGLIUSI = "use LIKE '%'";
            if (FilterProduct.Text != GV.TUTTIIPRODOTTI)
            {
                DB_TUTTIIPRODOTTI = "system = '" + FilterProduct.Text + "'";
            }
            if (filterChartsBase.Text != GV.TUTTECARTELLECOLORI)
            {
                DB_TUTTECARTELLECOLORI = "colorcharts = '" + filterChartsBase.Text + "'";
            }
            if (filterUseBase.Text != GV.TUTTIGLIUSI)
            {
                DB_TUTTIGLIUSI = "use = '" + filterUseBase.Text + "'";
            }
            #endregion

            DataDalTmp = BaseDal.Value.Year + "/" + BaseDal.Value.Month + "/" + BaseDal.Value.Day;
            DataAlTmp = BaseAl.Value.Year + "/" + BaseAl.Value.Month + "/" + BaseAl.Value.Day;

            dgBasi.Rows.Clear();
            belaborazione.Visible = true;
            Application.DoEvents();

            //Azzero Valori quantità
            QuantitaTot_filter = 0;
            quantitaTot = 0;
            QuantitaTot_filterKG = 0;
            quantitaTotKG = 0;

            #region QUANTITA' TOTALE SENZA FILTRO
            string size = null;
            double Value = 0;
            double ValueKG = 0;
            string[] sv = null;
            string sql = "SELECT base, formulasize, densita FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' ORDER BY id ASC";
            DataTable dt = db.SQLQuerySelect(sql);
            foreach(DataRow dr in dt.Rows)
            {
                //Azzero variabile temporali        
                sv = dr["formulasize"].ToString().Split('-');
                size = sv[1].ToString();
                //DENSITA
                if (size == "KG")
                {
                    Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) / Convert.ToDouble(dr["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }
                else
                {
                    Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) * Convert.ToDouble(dr["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                }
                quantitaTot = quantitaTot + Value;
                quantitaTotKG = quantitaTotKG + ValueKG;
            }
            #endregion

            #region QUANTITA' TOTALE CON FILTRO
            if (FilterProduct.Text != GV.TUTTIIPRODOTTI || filterChartsBase.Text != GV.TUTTECARTELLECOLORI || filterUseBase.Text != GV.TUTTIGLIUSI)
            {
                sql = "SELECT base, formulasize, system, colorcharts, use, densita FROM history WHERE " + DB_TUTTIIPRODOTTI + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                dt = db.SQLQuerySelect(sql);
                foreach(DataRow dr in dt.Rows)
                {
                    sv = dr["formulasize"].ToString().Split('-');
                    size = sv[1].ToString();
                    //DENSITA
                    if (size == "KG")
                    {
                        Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) / Convert.ToDouble(dr["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) * Convert.ToDouble(dr["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    }
                    QuantitaTot_filter = QuantitaTot_filter + Value;
                    QuantitaTot_filterKG = QuantitaTot_filterKG + ValueKG;
                }
            }
            #endregion

            #region QUANTITA' PARZIALE CON I FILTRI - ELSE - SENZA FILTRI
            if (FilterProduct.Text != GV.TUTTIIPRODOTTI || filterChartsBase.Text != GV.TUTTECARTELLECOLORI || filterUseBase.Text != GV.TUTTIGLIUSI)
            {
                sql = "SELECT DISTINCT(base) as TmpBase, densita FROM history WHERE " + DB_TUTTIIPRODOTTI + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                dt = db.SQLQuerySelect(sql);
                foreach(DataRow dr in dt.Rows)
                {
                    quantitaAssoluta = 0;
                    quantitaAssolutaKG = 0;
                    //Azzero variabile temporali
                    string sql2 = "SELECT formulasize, base, dateformula, system, densita FROM history WHERE " + DB_TUTTIIPRODOTTI + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' and base ='" + dr["TmpBase"] + "'";
                    DataTable dt2 = db.SQLQuerySelect(sql2);
                    foreach(DataRow dr2 in dt2.Rows)
                    {
                        sv = dr2["formulasize"].ToString().Split('-');
                        size = sv[1].ToString();
                        //DENSITA
                        if (size == "KG")
                        {
                            Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) / Convert.ToDouble(dr2["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                            ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                            ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) * Convert.ToDouble(dr2["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        }
                        quantitaAssoluta = quantitaAssoluta + Value;
                        quantitaAssolutaKG = quantitaAssolutaKG + ValueKG;
                    }
                    quantita = (100 * quantitaAssoluta) / QuantitaTot_filter;
                    quantitaKG = (100 * quantitaAssolutaKG) / QuantitaTot_filterKG;
                    dgBasi.Rows.Add("Not", dr["TmpBase"], Math.Round(quantita, 2), Math.Round(quantitaAssoluta, 2) + " Lt", Math.Round(quantitaAssolutaKG, 2) + " Kg");
                }
            }
            else
            {
                sql = "SELECT DISTINCT(base) as TmpBase, densita FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                dt = db.SQLQuerySelect(sql);
                foreach(DataRow dr in dt.Rows)
                {
                    quantitaAssoluta = 0;
                    quantitaAssolutaKG = 0;
                    
                    string sql2 = "SELECT formulasize, base, dateformula, system, densita FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' and base = '" + dr["TmpBase"] + "'";
                    DataTable dt2 = db.SQLQuerySelect(sql2);
                    foreach(DataRow dr2 in dt2.Rows)
                    {
                        sv = dr2["formulasize"].ToString().Split('-');
                        size = sv[1].ToString();
                        //DENSITA
                        if (size == "KG")
                        {
                            Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) / Convert.ToDouble(dr["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                            ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            Value = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                            ValueKG = Convert.ToDouble(sv[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture) * Convert.ToDouble(dr["densita"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                        }
                        QuantitaTot_filter = QuantitaTot_filter + Value;
                        quantitaAssoluta = quantitaAssoluta + Value;
                        QuantitaTot_filterKG = QuantitaTot_filterKG + ValueKG;
                        quantitaAssolutaKG = quantitaAssolutaKG + ValueKG;
                    }
                    quantita = (100 * quantitaAssoluta) / quantitaTot;
                    quantitaKG = (100 * quantitaAssolutaKG) / QuantitaTot_filterKG;
                    dgBasi.Rows.Add("Not", dr["TmpBase"], Math.Round(quantita, 2), Math.Round(quantitaAssoluta, 2) + " Lt", Math.Round(quantitaAssolutaKG, 2) + " Kg");
                }
            }
            #endregion

            //Abilito il grafico e stampa
            btnGraphBasi.Enabled = true;
            belaborazione.Visible = false;
        }

        private void btnBasesGraph_Click(object sender, EventArgs e)
        {
            string[,] sData = new string[dgBasi.Rows.Count, 2];

            for (int y = 0; y < dgBasi.Rows.Count; y++)
            {
                sData[y, 0] = dgBasi.Rows[y].Cells[1].Value.ToString();
                sData[y, 1] = dgBasi.Rows[y].Cells[2].Value.ToString();
            }

            Statistiche.frmGrafico grafico = new Statistiche.frmGrafico(Statistiche.frmGrafico.eTipoGrafico.Basi, FilterProduct.Text);
            grafico.Data = sData;
            grafico.ShowDialog();
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

        private void frmStatBasi_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
