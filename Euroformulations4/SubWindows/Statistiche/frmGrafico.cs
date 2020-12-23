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

namespace Euroformulations4.SubWindows.Statistiche
{
    public partial class frmGrafico : Form
    {
        private Library.Language lang = Library.Language.GetInstance();
        private eTipoGrafico eTipo;
        private string sTitolo;
        private string[,] sData;
        public enum eTipoGrafico
        { 
            Coloranti = 1,
            Basi = 2
        }

        public frmGrafico(eTipoGrafico eTipo, string sTitolo)
        {
            InitializeComponent();
            this.eTipo = eTipo;
            this.sTitolo = sTitolo;
        }

        public string[,] Data
        {
            set 
            {
                this.sData = value;
            }
        }

        private void frmGrafico_Load(object sender, EventArgs e)
        {
            PrintGrafico.Text = lang.GetWord("stat01");

            switch (eTipo)
            {
                case eTipoGrafico.Coloranti:
                    chartPB.Titles[0].Text = "Colorant Usage. Base: " + this.sTitolo;
                    chartPB.ChartAreas[0].AxisX.Interval = 1;

                    for (int y = 0; y < sData.GetLength(0); y++)
                    {
                        chartPB.Series[0].Points.AddXY(sData[y, 0], Convert.ToDouble(sData[y, 1].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture));
                        chartPB.Series[0].Points[y].Label = sData[y, 1] + "%";
                        chartPB.Series[0].Points[y].AxisLabel = sData[y, 0];
                    }

                    break;
                case eTipoGrafico.Basi:
                    chartPB.Titles[0].Text = "Base Usage. Product: " + this.sTitolo;
                    chartPB.ChartAreas[0].AxisX.Interval = 1;

                    for (int y = 0; y < sData.GetLength(0); y++)
                    {
                        chartPB.Series[0].Points.AddXY(sData[y, 0], Convert.ToDouble(sData[y, 1].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture));
                        chartPB.Series[0].Points[y].Label = sData[y, 1] + "%";
                        chartPB.Series[0].Points[y].AxisLabel = sData[y, 0];
                    }

                    break;
            }
        }

        #region FUNZIONI DI STAMPA
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font printFont = new System.Drawing.Font("Verdana", 10);
            System.Drawing.Rectangle myRec = new System.Drawing.Rectangle(0, 30, Convert.ToInt32(printDocument.DefaultPageSettings.PrintableArea.Height), Convert.ToInt32(printDocument.DefaultPageSettings.PrintableArea.Width));
            e.Graphics.DrawString("Euro formulations 4", printFont, Brushes.Black, 5, 10);
            chartPB.Printing.PrintPaint(e.Graphics, myRec);
        }

        private void PrintGrafico_Click(object sender, EventArgs e)
        {
            printDocument.DefaultPageSettings.Landscape = true;
            anteprimaDialog.Document = printDocument;
            Image img = ((ToolStripButton)((ToolStrip)anteprimaDialog.Controls[1]).Items[0]).Image;
            ToolStrip ts = ((ToolStrip)anteprimaDialog.Controls[1]);
            ToolStripButton tsb = (ToolStripButton)((ToolStrip)anteprimaDialog.Controls[1]).Items[0];
            ts.Items.Remove(tsb);
            ToolStripButton b = new ToolStripButton();
            b.Image = img;
            b.Size = tsb.Size;
            b.Visible = true;
            ts.Items.Insert(0, b);
            b.Click += new EventHandler(PrintExecute);
            anteprimaDialog.Width = 800;
            anteprimaDialog.Height = 600;
            anteprimaDialog.ShowIcon = false;
            anteprimaDialog.ShowDialog();
        }

        private void PrintExecute(object sender, EventArgs e)
        {
            if (stampaDialog.ShowDialog() != DialogResult.OK) { return; }
            printDocument.PrinterSettings.PrinterName = stampaDialog.PrinterSettings.PrinterName;
            printDocument.Print();
        }
        #endregion;

    }
}