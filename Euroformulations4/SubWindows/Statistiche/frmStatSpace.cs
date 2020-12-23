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
    public partial class frmStatSpace : Form
    {
        private Language lang = Language.GetInstance();
        private Library.Data.Database.DBConnector db = new Library.Data.Database.DBConnector();
        private string sAllProducts = "";

        public frmStatSpace()
        {
            InitializeComponent();
        }

        private void frmStatistiche_Load(object sender, EventArgs e)
        {
            try
            {
                #region Traduzioni
                gbFrom.Text = lang.GetWord("stat09");
                gbTo.Text = lang.GetWord("stat10");
                gbProduct.Text = lang.GetWord("stat15");
                btnSearch.Text = lang.GetWord("search");
                #endregion

                Scolor.ChartAreas[0].BackImage = Application.StartupPath + "\\include\\spettrocolore.png";
                Scolor.ChartAreas[0].BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;

                System.DateTime dateAnno = System.DateTime.Now;
                ColorDal.Value = new DateTime(dateAnno.Year, 1, 1);
                ColorAl.Value = new DateTime(dateAnno.Year, 12, 31);

                sAllProducts = lang.GetWord("stat18");

                filterproductColor.Items.Add(sAllProducts);
                DataTable dt = db.SQLQuerySelect("SELECT DISTINCT(system) as Sys, ordersystem FROM history ORDER BY ordersystem");
                foreach (DataRow dr in dt.Rows)
                {
                    filterproductColor.Items.Add(dr["Sys"]);
                }
                filterproductColor.Text = sAllProducts;
                this.ActiveControl = Scolor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string DataDalTmp = null;
                string DataAlTmp = null;
                double QuantitaTot = 0;

                DataDalTmp = ColorDal.Value.Year + "/" + ColorDal.Value.Month + "/" + ColorDal.Value.Day;
                DataAlTmp = ColorAl.Value.Year + "/" + ColorAl.Value.Month + "/" + ColorAl.Value.Day;

                Scolor.Series[0].Points.Clear();
                System.Drawing.Color c = default(System.Drawing.Color);
                c = System.Drawing.Color.FromArgb(0, 0, 10);

                string sql = "SELECT * FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' and system = '" + filterproductColor.Text + "'";
                if (filterproductColor.Text == sAllProducts)
                {
                    sql = "SELECT * FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "'";
                }

                DataTable dt = db.SQLQuerySelect(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    QuantitaTot = 0;
                    string sql2 = "SELECT SUM(q1) as P1QS, SUM(q2) as P2QS, SUM(q3) as P3QS, SUM(q4) as P4QS, SUM(q5) as P5QS  FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' and system = '" + filterproductColor.Text + "' and colorname= '" + dr["colorname"].ToString() + "'";

                    if (filterproductColor.Text == sAllProducts)
                    {
                        sql2 = "SELECT SUM(q1) as P1QS, SUM(q2) as P2QS, SUM(q3) as P3QS, SUM(q4) as P4QS, SUM(q5) as P5QS  FROM history WHERE dateformula >=  '" + DataDalTmp + "' And dateformula <= '" + DataAlTmp + "' and colorname= '" + dr["colorname"].ToString() + "'";
                    }

                    DataTable dt2 = db.SQLQuerySelect(sql2);


                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        if (dr2["p1qs"].ToString() != "")
                        {
                            QuantitaTot = QuantitaTot + Convert.ToDouble(dr2["p1qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        }
                        if (dr2["p2qs"].ToString() != "")
                        {
                            QuantitaTot = QuantitaTot + Convert.ToDouble(dr2["p2qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        }
                        if (dr2["p3qs"].ToString() != "")
                        {
                            QuantitaTot = QuantitaTot + Convert.ToDouble(dr2["p3qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        }
                        if (dr2["p4qs"].ToString() != "")
                        {
                            QuantitaTot = QuantitaTot + Convert.ToDouble(dr2["p4qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        }
                        if (dr2["p5qs"].ToString() != "")
                        {
                            QuantitaTot = QuantitaTot + Convert.ToDouble(dr2["p5qs"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        }
                    }
                    c = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["R"].ToString()), Convert.ToInt32(dr["G"].ToString()), Convert.ToInt32(dr["B"].ToString()));
                    Scolor.Series[0].Points.AddXY(c.GetHue(), c.GetBrightness(), Convert.ToInt32(QuantitaTot));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmStatSpace_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception){}
        }
    }
}
