using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Euroformulations4.SubWindows
{
    public partial class frmGrafico : Form
    {
        public frmGrafico()
        {
            InitializeComponent();
        }

        private void frmGrafico_Load(object sender, EventArgs e)
        {
            switch (Library.GVar.TabAperta)
            {
                case 1:
                    #region GRAFICO COLORANT USAGE
                    chartPB.Titles[0].Text = "Colorant Usage. Base: " + Library.GVar.TitoloGrafico;
                    chartPB.ChartAreas[0].AxisX.Interval = 1;

                    for (int y = 0; y < Library.GVar.DataGridValori.GetLength(0); y++)
                    {
                        chartPB.Series[0].Points.AddXY(Library.GVar.DataGridValori[y, 0], Convert.ToDouble(Library.GVar.DataGridValori[y, 1].ToString()));
                        chartPB.Series[0].Points[y].Label = Library.GVar.DataGridValori[y, 1] + "%";
                        chartPB.Series[0].Points[y].AxisLabel = Library.GVar.DataGridValori[y, 0];
                    }
                    break;
                    #endregion
                case 2:
                    #region GRAFICO BASE USAGE
                    chartPB.Titles[0].Text = "Base Usage. Product: " + Library.GVar.TitoloGrafico;
                    chartPB.ChartAreas[0].AxisX.Interval = 1;

                    for (int y = 0; y < Library.GVar.DataGridValori.GetLength(0); y++)
                    {
                        chartPB.Series[0].Points.AddXY(Library.GVar.DataGridValori[y, 0], Convert.ToDouble(Library.GVar.DataGridValori[y, 1].ToString()));
                        chartPB.Series[0].Points[y].Label = Library.GVar.DataGridValori[y, 1] + "%";
                        chartPB.Series[0].Points[y].AxisLabel = Library.GVar.DataGridValori[y, 0];
                    }
                    break;
                    #endregion
            }
        }

        #region FUNZIONALITA' DI PRINT
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font printFont = new System.Drawing.Font("Verdana", 10);
            System.Drawing.Rectangle myRec = new System.Drawing.Rectangle(0, 30, Convert.ToInt32(PrintDocument1.DefaultPageSettings.PrintableArea.Height), Convert.ToInt32(PrintDocument1.DefaultPageSettings.PrintableArea.Width));
            e.Graphics.DrawString("Euro formulations 4", printFont, Brushes.Black, 5, 10);
            chartPB.Printing.PrintPaint(e.Graphics, myRec);
        }

        private void PrintGrafico_Click(object sender, EventArgs e)
        {
            PrintDocument1.DefaultPageSettings.Landscape = true;
            PrintPreviewDialog1.Document = PrintDocument1;
            PrintPreviewDialog1.ShowDialog();
        }
        #endregion;

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

    }
}