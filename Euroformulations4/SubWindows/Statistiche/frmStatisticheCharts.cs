using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.Statistiche
{
    public partial class frmStatisticheCharts : Form
    {
        private Library.Data.Database.DBConnector db;
        private string colorcharts;

        public frmStatisticheCharts(string chart)
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
            colorcharts = chart;
        }

        private void frmStatisticheCharts_Load(object sender, EventArgs e)
        {
            #region immagine iniziale
            Scolor.ChartAreas[0].BackImage = Application.StartupPath + "\\include\\spettrocolore.png";
            Scolor.ChartAreas[0].BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            #endregion immagine iniziale

            #region POPOLAZIONE GRAFICO ColorSpace
            Scolor.Series[0].Points.Clear();
            System.Drawing.Color c = default(System.Drawing.Color);
            c = System.Drawing.Color.FromArgb(0, 0, 10);

            string sql3 = "SELECT DISTINCT(colorname), R, G , B FROM formule WHERE colorcharts ='" + colorcharts + "'";
            DataTable dtColorSpace = db.SQLQuerySelect(sql3);
            if (dtColorSpace != null)
            {
                foreach (DataRow DataRow in dtColorSpace.Rows)
                {
                    c = System.Drawing.Color.FromArgb(Convert.ToInt32(DataRow["R"].ToString()), Convert.ToInt32(DataRow["G"].ToString()), Convert.ToInt32(DataRow["B"].ToString()));
                    Scolor.Series[0].Points.AddXY(c.GetHue(), c.GetBrightness(), Convert.ToInt32(1));
                }
            }
            #endregion
        }


        private void frmStatisticheCharts_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.CloseConnection();
        }

    }
}

