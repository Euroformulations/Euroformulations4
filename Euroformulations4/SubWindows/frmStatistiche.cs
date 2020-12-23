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
using Npgsql;

namespace Euroformulations4.SubWindows
{
    public partial class frmStatistiche : Form
    {
        DBConnect_Npgsql dbc = new DBConnect_Npgsql();
        DBConnect_Npgsql dbc2 = new DBConnect_Npgsql();
        DBConnect_Npgsql dbc3 = new DBConnect_Npgsql();
        NpgsqlDataReader risultatiole;
        NpgsqlDataReader risqpig;
        NpgsqlDataReader risqd;

        public class GV
        {
            //Variabili Globali
            public static string TUTTELEBASE = "ALL BASE PAINTS";
            public static string TUTTIIPRODOTTI = "ALL PRODUCTS";
            public static string TUTTECARTELLECOLORI = "ALL COLORCHARTS";
            public static string TUTTIGLIUSI = "ALL USE";
        }

        public frmStatistiche()
        {
            InitializeComponent();
        }

        private void frmStatistiche_Load(object sender, EventArgs e)
        {
            #region INPOSTAZIONE INTERNAZIONALE FILTRI COMPLETI
            FilterBase.Items.Add(GV.TUTTELEBASE);
            FilterProduct.Items.Add(GV.TUTTIIPRODOTTI);
            filterproductColor.Items.Add(GV.TUTTIIPRODOTTI);
            FilterColorCharts.Items.Add(GV.TUTTECARTELLECOLORI);
            filterChartsBase.Items.Add(GV.TUTTECARTELLECOLORI);
            FilterUse.Items.Add(GV.TUTTIGLIUSI);
            filterUseBase.Items.Add(GV.TUTTIGLIUSI);
            //PrimoValore
            FilterBase.Text = GV.TUTTELEBASE;
            FilterProduct.Text = GV.TUTTIIPRODOTTI;
            filterproductColor.Text = GV.TUTTIIPRODOTTI;
            FilterColorCharts.Text = GV.TUTTECARTELLECOLORI;
            FilterUse.Text = GV.TUTTIGLIUSI;
            filterUseBase.Text = GV.TUTTIGLIUSI;
            filterChartsBase.Text = GV.TUTTECARTELLECOLORI;
            #endregion

            #region DATA CORRENTE INIZIALE
            System.DateTime dateAnno = System.DateTime.Now;
            DalDate.Value = new DateTime(dateAnno.Year, 1, 1);
            AlDate.Value = new DateTime(dateAnno.Year, 12, 31);
            BaseDal.Value = new DateTime(dateAnno.Year, 1, 1);
            BaseAl.Value = new DateTime(dateAnno.Year, 12, 31);
            ColorDal.Value = new DateTime(dateAnno.Year, 1, 1);
            ColorAl.Value = new DateTime(dateAnno.Year, 12, 31);
            #endregion;

            #region DISABILITAZIONE COMPONENTI INIZIALE
            GraficoStat.Enabled = false;
            PrintTablePigment.Enabled = false;
            GraficoStatb.Enabled = false;
            bPrintTableBase.Enabled = false;
            #endregion

            #region FILTRI DEL DATABASE PER GLI USI - CARTELLE COLORI - SISTEMA - BASI
            dbc.connect(Library.GVar.Database);

            dbc.sqlview("SELECT DISTINCT(base) as baseB FROM history", ref risultatiole);
            while (risultatiole.Read())
            {
                FilterBase.Items.Add(risultatiole["baseB"]);
            }
            risultatiole.Close();

            dbc.sqlview("SELECT DISTINCT(use) as IntExt FROM history", ref risultatiole);
            while (risultatiole.Read())
            {
                FilterUse.Items.Add(risultatiole["IntExt"]);
                filterUseBase.Items.Add(risultatiole["IntExt"]);
            }
            risultatiole.Close();

            dbc.sqlview("SELECT DISTINCT(colorcharts) as Color FROM history", ref risultatiole);
            while (risultatiole.Read())
            {
                FilterColorCharts.Items.Add(risultatiole["Color"]);
                filterChartsBase.Items.Add(risultatiole["Color"]);
            }
            risultatiole.Close();

            dbc.sqlview("SELECT DISTINCT(system) as Sys, ordersystem FROM history ORDER BY ordersystem", ref risultatiole);
            while (risultatiole.Read())
            {
                FilterProduct.Items.Add(risultatiole["Sys"]);
                filterproductColor.Items.Add(risultatiole["Sys"]);
            }
            risultatiole.Close();

            dbc.disconnect();
            #endregion
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

            DataGridUt.Rows.Clear();
            inelaborazione.Visible = true;
            Application.DoEvents();

            dbc.connect(GVar.Database);
            dbc2.connect(GVar.Database);

            QuantitaTot_filter = 0;
            quantitaTot = 0;
            risultatiole.Close();

            #region  QUANTITA TOTALE SENZA FILTRO
            dbc.sqlview("SELECT SUM(q1) AS P1QS, SUM(q2) AS P2QS, SUM(q3) AS P3QS, SUM(q4) AS P4QS, SUM(q5) AS P5QS FROM  (SELECT * FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "') AS derivedTable", ref risultatiole);
            while (risultatiole.Read())
            {
                if (risultatiole["p1qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(risultatiole["p1qs"].ToString());
                }
                if (risultatiole["p2qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(risultatiole["p2qs"].ToString());
                }
                if (risultatiole["p3qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(risultatiole["p3qs"].ToString());
                }
                if (risultatiole["p4qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(risultatiole["p4qs"].ToString());
                }
                if (risultatiole["p5qs"].ToString() != "")
                {
                    quantitaTot = quantitaTot + Convert.ToDouble(risultatiole["p5qs"].ToString());
                }
            }
            risultatiole.Close();
            #endregion


            #region  QUANTITA FILTRO
            if (FilterBase.Text != GV.TUTTELEBASE || FilterUse.Text != GV.TUTTIGLIUSI || FilterColorCharts.Text != GV.TUTTECARTELLECOLORI)
            {
                dbc.sqlview("SELECT SUM(q1) as P1QS, SUM(q2) as P2QS, SUM(q3) as P3QS, SUM(q4) as P4QS, SUM(q5) as P5QS  FROM history WHERE " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risultatiole);
                while (risultatiole.Read())
                {
                    if (risultatiole["p1qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(risultatiole["p1qs"].ToString());
                    }
                    if (risultatiole["p2qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(risultatiole["p2qs"].ToString());
                    }
                    if (risultatiole["p3qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(risultatiole["p3qs"].ToString());
                    }
                    if (risultatiole["p4qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(risultatiole["p4qs"].ToString());
                    }
                    if (risultatiole["p5qs"].ToString() != "")
                    {
                        QuantitaTot_filter = QuantitaTot_filter + Convert.ToDouble(risultatiole["p5qs"].ToString());
                    }
                }
                risultatiole.Close();
            }
            #endregion

            dbc.sqlview("SELECT DISTINCT nome FROM (SELECT p1 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p2 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p3 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p4 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' UNION SELECT p5 as nome, dateformula FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "') as derived WHERE char_length(nome) > 0", ref risultatiole);

            while (risultatiole.Read())
            {
                quantita = 0;

                #region QUANTITA' PIGMENTO 1

                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {

                    dbc2.sqlview("SELECT SUM(q1) as P1QS FROM history WHERE p1 = '" + risultatiole["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                else
                {
                    dbc2.sqlview("SELECT SUM(q1) as P1QS FROM history WHERE p1 = '" + risultatiole["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and  dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }

                while (risqpig.Read())
                {
                    if (risqpig["P1QS"].ToString().Length > 0)
                    {
                        quantita = quantita + Convert.ToDouble(risqpig["P1QS"].ToString());
                    }
                }
                risqpig.Close();
                #endregion
                #region QUANTITA' PIGMENTO 2
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    dbc2.sqlview("SELECT SUM(q2) as P2QS FROM history WHERE p2 = '" + risultatiole["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                else
                {
                    dbc2.sqlview("SELECT SUM(q2) as P2QS FROM history WHERE p2 = '" + risultatiole["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                while (risqpig.Read())
                {
                    if (risqpig["p2qs"].ToString().Length > 0)
                    {
                        quantita = quantita + Convert.ToDouble(risqpig["p2qs"].ToString());
                    }
                }
                risqpig.Close();
                #endregion
                #region QUANTITA' PIGMENTO 3
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    dbc2.sqlview("SELECT SUM(q3) as P3QS FROM history WHERE p3 = '" + risultatiole["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                else
                {
                    dbc2.sqlview("SELECT SUM(q3) as P3QS FROM history WHERE p3 = '" + risultatiole["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                while (risqpig.Read())
                {
                    if (risqpig["p3qs"].ToString().Length > 0)
                    {
                        quantita = quantita + Convert.ToDouble(risqpig["p3qs"].ToString());
                    }
                }
                risqpig.Close();
                #endregion
                #region QUANTITA' PIGMENTO 4
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    dbc2.sqlview("SELECT SUM(q4) as P4QS FROM history WHERE p4 = '" + risultatiole["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                else
                {
                    dbc2.sqlview("SELECT SUM(q4) as P4QS FROM history WHERE p4 = '" + risultatiole["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                while (risqpig.Read())
                {
                    if (risqpig["p4qs"].ToString().Length > 0)
                    {
                        quantita = quantita + Convert.ToDouble(risqpig["p4qs"].ToString());
                    }
                }
                risqpig.Close();
                #endregion
                #region QUANTITA' PIGMENTO 5
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    dbc2.sqlview("SELECT SUM(q5) as P5QS FROM history WHERE p5 = '" + risultatiole["nome"].ToString() + "' and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                else
                {
                    dbc2.sqlview("SELECT SUM(q5) as P5QS FROM history WHERE p5 = '" + risultatiole["nome"].ToString() + "' AND " + DB_TUTTELEBASE + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risqpig);
                }
                while (risqpig.Read())
                {
                    if (risqpig["p5qs"].ToString().Length > 0)
                    {
                        quantita = quantita + Convert.ToDouble(risqpig["p5qs"].ToString());
                    }
                }
                risqpig.Close();
                #endregion

                dbc2.sqlview("SELECT * FROM pigmenti WHERE code = '" + risultatiole["nome"].ToString() + "'", ref risqpig);
                while (risqpig.Read())
                {
                    NomeEsteso = risqpig["fullname"].ToString();
                }

                #region POPOLAZIONE DATAGRID
                if (FilterBase.Text == GV.TUTTELEBASE && FilterUse.Text == GV.TUTTIGLIUSI && FilterColorCharts.Text == GV.TUTTECARTELLECOLORI)
                {
                    if (Math.Round(Convert.ToDouble(quantita), 3) > 0)
                    {
                        quantitaAssoluta = quantita.ToString();
                        quantita = (100 * quantita) / quantitaTot;
                        if (Convert.ToDouble(quantitaAssoluta) > 1000)
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble((Convert.ToDouble(quantitaAssoluta) / 1000)), 2) + " Lt";
                            DataGridUt.Rows.Add("Not", NomeEsteso, Math.Round(Convert.ToDouble(quantita), 2), quantitaAssoluta);
                            DataGridUt.Rows[DataGridUt.Rows.Count - 1].Cells[3].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble(quantitaAssoluta), 2) + " ml";
                            DataGridUt.Rows.Add("Not", NomeEsteso, Math.Round(Convert.ToDouble(quantita), 2), quantitaAssoluta);
                        }
                    }
                }
                else
                {
                    if (Math.Round(Convert.ToDouble(quantita), 3) > 0)
                    {
                        quantitaAssoluta = quantita.ToString();
                        quantita = (100 * quantita) / (QuantitaTot_filter);
                        if (Convert.ToDouble(quantitaAssoluta) > 1000)
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble((Convert.ToDouble(quantitaAssoluta) / 1000)), 2) + " Lt";
                            DataGridUt.Rows.Add("Not", NomeEsteso, Math.Round(Convert.ToDouble(quantita), 2), quantitaAssoluta);
                            DataGridUt.Rows[DataGridUt.Rows.Count - 1].Cells[3].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            quantitaAssoluta = Math.Round(Convert.ToDouble(quantitaAssoluta), 2) + " ml";
                            DataGridUt.Rows.Add("Not", NomeEsteso, Math.Round(Convert.ToDouble(quantita), 2), quantitaAssoluta);
                        }
                    }
                }
                #endregion
            }
            dbc.disconnect();
            dbc2.disconnect();

            GraficoStat.Enabled = true;
            PrintTablePigment.Enabled = true;
            inelaborazione.Visible = false;
        }

        private void GraficoStat_Click(object sender, EventArgs e)
        {
            Library.GVar.DataGridValori = null;
            Library.GVar.DataGridValori = new string[DataGridUt.Rows.Count, 2];

            for (int y = 0; y < DataGridUt.Rows.Count; y++)
            {
                Library.GVar.DataGridValori[y, 0] = DataGridUt.Rows[y].Cells[1].Value.ToString();
                Library.GVar.DataGridValori[y, 1] = DataGridUt.Rows[y].Cells[2].Value.ToString();
            }

            Library.GVar.TabAperta = 1;
            Library.GVar.TitoloGrafico = FilterBase.Text;
            frmGrafico grafico = new frmGrafico();
            grafico.ShowDialog();
        }

        private void PrintTablePigment_Click(object sender, EventArgs e)
        {
            if (PrintDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Library.GVar.TabAperta = 1;
                PrintPreviewDialog1.Document = PrintTablep;
                PrintPreviewDialog1.ShowDialog();
            }
        }

        private void PrintTablep_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font FontB = new Font("Verdana", 14, FontStyle.Bold);
            Font FontN = new Font("Verdana", 12);

            switch (Library.GVar.TabAperta)
            {
                case 1:
                    e.Graphics.DrawString("PIGMENST :", FontB, Brushes.Black, 30, 18);
                    e.Graphics.DrawString("% :", FontB, Brushes.Black, 300, 18);
                    e.Graphics.DrawString("Quantity :", FontB, Brushes.Black, 450, 18);
                    for (int y = 0; y < DataGridUt.Rows.Count; y++)
                    {
                        e.Graphics.DrawString(DataGridUt.Rows[y].Cells[1].Value.ToString(), FontN, Brushes.Black, 30, 50 + (y * 25));
                        e.Graphics.DrawString(DataGridUt.Rows[y].Cells[2].Value.ToString() + " %", FontN, Brushes.Black, 300, 50 + (y * 25));
                        e.Graphics.DrawString(DataGridUt.Rows[y].Cells[3].Value.ToString(), FontN, Brushes.Black, 450, 50 + (y * 25));
                    }
                    e.Graphics.DrawString("Filter: " + FilterBase.Text + "/" + FilterColorCharts.Text + "/" + FilterUse.Text, FontN, Brushes.Black, 30, 1050);
                    e.Graphics.DrawString("Date: From " + DalDate.Text.ToString() + " to " + AlDate.Text.ToString(), FontN, Brushes.Black, 30, 1075);
                    break;
                case 2:
                    e.Graphics.DrawString("BASE :", FontB, Brushes.Black, 30, 18);
                    e.Graphics.DrawString("% :", FontB, Brushes.Black, 300, 18);
                    e.Graphics.DrawString("Quantity :", FontB, Brushes.Black, 450, 18);
                    for (int y = 0; y < BDataGridUt.Rows.Count; y++)
                    {
                        e.Graphics.DrawString(BDataGridUt.Rows[y].Cells[1].Value.ToString(), FontN, Brushes.Black, 30, 50 + (y * 25));
                        e.Graphics.DrawString(BDataGridUt.Rows[y].Cells[2].Value.ToString() + " %", FontN, Brushes.Black, 300, 50 + (y * 25));
                        e.Graphics.DrawString(BDataGridUt.Rows[y].Cells[3].Value.ToString(), FontN, Brushes.Black, 450, 50 + (y * 25));
                    }
                    e.Graphics.DrawString("Filter: " + FilterProduct.Text + "/" + filterChartsBase.Text + "/" + filterUseBase.Text, FontN, Brushes.Black, 30, 1050);
                    e.Graphics.DrawString("Date: From " + BaseDal.Text.ToString() + " to " + BaseAl.Text.ToString(), FontN, Brushes.Black, 30, 1075);
                    break;
            }
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

        private void exeFilterBase_Click(object sender, EventArgs e)
        {
            double quantita = 0;
            string quantitaAssoluta = null;
            double QuantitaTot_filter = 0;
            double quantitaTot = 0;
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

            BDataGridUt.Rows.Clear();
            belaborazione.Visible = true;
            Application.DoEvents();

            //Controllare le 3 connessioni al DB.
            dbc.connect(GVar.Database);
            dbc2.connect(GVar.Database);
            dbc3.connect(GVar.Database);

            //Azzero Valori quantità
            QuantitaTot_filter = 0;
            quantitaTot = 0;

            #region QUANTITA' TOTALE SENZA FILTRO
            dbc.sqlview("SELECT base, formulasize FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' ORDER BY id ASC", ref risultatiole);
            //Variabili temporari
            string size = null;
            double Value = 0;
            string[] sv = null;
            while (risultatiole.Read())
            {
                //Azzero variabile temporali        
                sv = risultatiole["formulasize"].ToString().Split('-');
                size = sv[1].ToString();
                //DENSITA
                if (size == "KG")
                {
                    dbc2.sqlview("SELECT density, base FROM base WHERE base= '" + risultatiole["base"] + "'", ref risqpig);
                    while (risqpig.Read())
                    {
                        Value = Convert.ToDouble(sv[0].ToString().Replace(".", ",")) * Convert.ToDouble(risqpig["density"].ToString());
                    }
                }
                else
                {
                    Value = Convert.ToDouble(sv[0].ToString().Replace(".", ","));
                }
                quantitaTot = quantitaTot + Value;
            }
            risultatiole.Close();
            risqpig.Close();
            #endregion

            #region QUANTITA' TOTALE CON FILTRO
            if (FilterProduct.Text != GV.TUTTIIPRODOTTI || filterChartsBase.Text != GV.TUTTECARTELLECOLORI || filterUseBase.Text != GV.TUTTIGLIUSI)
            {
                dbc.sqlview("SELECT base, formulasize, system, colorcharts, use FROM history WHERE " + DB_TUTTIIPRODOTTI +  " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risultatiole);
                while (risultatiole.Read())
                {
                    sv = risultatiole["formulasize"].ToString().Split('-');
                    size = sv[1].ToString();
                    //DENSITA
                    if (size == "KG")
                    {
                        dbc2.sqlview("SELECT density, base FROM base WHERE base= '" + risultatiole["base"] + "'", ref risqpig);
                        while (risqpig.Read())
                        {
                            Value = Convert.ToDouble(sv[0].ToString().Replace(".", ",")) * Convert.ToDouble(risqpig["density"].ToString());
                        }
                    }
                    else
                    {
                        Value = Convert.ToDouble(sv[0].ToString().Replace(".", ","));
                    }
                    QuantitaTot_filter = QuantitaTot_filter + Value;
                }
                risultatiole.Close();
                risqpig.Close();
            }
            #endregion

            #region QUANTITA' PARZIALE CON I FILTRI
            if (FilterProduct.Text != GV.TUTTIIPRODOTTI || filterChartsBase.Text != GV.TUTTECARTELLECOLORI || filterUseBase.Text != GV.TUTTIGLIUSI)
            {
                dbc.sqlview("SELECT DISTINCT(base) as TmpBase, system FROM history WHERE " + DB_TUTTIIPRODOTTI + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risultatiole);
                while (risultatiole.Read())
                {
                    quantitaAssoluta = "0";
                    //Azzero variabile temporali        
                    dbc2.sqlview("SELECT formulasize, base, dateformula, system FROM history WHERE " + DB_TUTTIIPRODOTTI + " and " + DB_TUTTECARTELLECOLORI + " and " + DB_TUTTIGLIUSI + " and dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' and base ='" + risultatiole["TmpBase"] + "'", ref risqpig);
                    while (risqpig.Read())
                    {
                        sv = risqpig["formulasize"].ToString().Split('-');
                        size = sv[1].ToString();
                        //DENSITA
                        if (size == "KG")
                        {
                            dbc3.sqlview("SELECT density, base FROM base WHERE base= '" + risqpig["base"] + "'", ref risqd);
                            while (risqd.Read())
                            {
                                Value = Convert.ToDouble(sv[0].ToString().Replace(".", ",")) * Convert.ToDouble(risqd["density"].ToString());
                            }
                            risqd.Close();
                        }
                        else
                        {
                            Value = Convert.ToDouble(sv[0].ToString().Replace(".", ","));
                        }
                        quantitaAssoluta = quantitaAssoluta + Value;
                    }
                    risqpig.Close();
                    quantita = (100 * Convert.ToDouble(quantitaAssoluta)) / QuantitaTot_filter;
                    BDataGridUt.Rows.Add("Not", risultatiole["TmpBase"], Math.Round(Convert.ToDouble(quantita), 2), Math.Round(Convert.ToDouble(quantitaAssoluta.ToString()), 2) + " Lt");
                }
                risultatiole.Close();
            }
            #endregion
            #region QUANTITA' PARZIALE SENZA FILTRI
            else
            {
                dbc.sqlview("SELECT DISTINCT(base) as TmpBase, system FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'", ref risultatiole);
                while (risultatiole.Read())
                {
                    quantitaAssoluta = "0";
                    //Azzero variabile temporali        
                    dbc2.sqlview("SELECT formulasize, base, dateformula, system FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' and base = '" + risultatiole["TmpBase"] + "'", ref risqpig);
                    while (risqpig.Read())
                    {
                        sv = risqpig["formulasize"].ToString().Split('-');
                        size = sv[1].ToString();
                        //DENSITA
                        if (size == "KG")
                        {
                            dbc3.sqlview("SELECT density, base FROM base WHERE base= '" + risqpig["base"] + "'", ref risqd);
                            while (risqd.Read())
                            {
                                Value = Convert.ToDouble(sv[0].ToString().Replace(".", ",")) * Convert.ToDouble(risqd["density"].ToString());
                            }
                            risqd.Close();
                        }
                        else
                        {
                            Value = Convert.ToDouble(sv[0].ToString().Replace(".", ","));
                        }
                        QuantitaTot_filter = QuantitaTot_filter + Value;
                        quantitaAssoluta = quantitaAssoluta + Value;
                    }
                    risqpig.Close();
                    quantita = (100 * Convert.ToDouble(quantitaAssoluta)) / quantitaTot;
                    BDataGridUt.Rows.Add("Not", risultatiole["TmpBase"], Math.Round(Convert.ToDouble(quantita), 2), Math.Round(Convert.ToDouble(quantitaAssoluta.ToString()), 2) + " Lt");
                }
                risultatiole.Close();
            }
            #endregion

            dbc.disconnect();
            dbc2.disconnect();
            dbc3.disconnect();

            //Abilito il grafico e stampa
            GraficoStatb.Enabled = true;
            bPrintTableBase.Enabled = true;
            belaborazione.Visible = false;
        }

        private void GraficoStatb_Click(object sender, EventArgs e)
        {
            Library.GVar.DataGridValori = new string[BDataGridUt.Rows.Count, 2];

            for (int y = 0; y < BDataGridUt.Rows.Count; y++)
            {
                Library.GVar.DataGridValori[y, 0] = BDataGridUt.Rows[y].Cells[1].Value.ToString();
                Library.GVar.DataGridValori[y, 1] = BDataGridUt.Rows[y].Cells[2].Value.ToString();
            }

            Library.GVar.TabAperta = 2;
            Library.GVar.TitoloGrafico = FilterProduct.Text;
            frmGrafico grafico = new frmGrafico();
            grafico.ShowDialog();
        }

        private void bPrintTableBase_Click(object sender, EventArgs e)
        {
            if (PrintDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Library.GVar.TabAperta = 2;
                PrintPreviewDialog1.Document = PrintTablep;
                PrintPreviewDialog1.ShowDialog();
            }
        }

    }
}
