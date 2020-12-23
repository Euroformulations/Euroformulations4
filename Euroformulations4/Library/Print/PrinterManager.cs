using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace Euroformulations4.Library.Print
{
    class PrinterManager
    {
        private static System.Drawing.Printing.PrintDocument printDoc;
        private static PrintPreviewDialog anteprimaDialog;
        private PrintDialog stampaDialog;
        private List<string> lstImagesPath = new List<string>();
        private string sDocX = "";
        private Dispatcher disp = Dispatcher.CurrentDispatcher;
        #region Drawing_attributes
        private int imgIndex = 0;
        #endregion

        public PrinterManager()
        {
            printDoc = new System.Drawing.Printing.PrintDocument();
            anteprimaDialog = new System.Windows.Forms.PrintPreviewDialog();
            stampaDialog = new PrintDialog();
            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(AnteprimaRendering);
        }

        public PrinterManager(List<string> lstImagesPath, string sDocX)
            : this()
        {
            this.lstImagesPath = lstImagesPath;
            this.sDocX = sDocX;
        }

        public void AnteprimaStampa()
        {
            anteprimaDialog.Document = printDoc;
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

        public void Stampa()
        {
            PrintExecute(null, null);
        }

        private void PrintExecute(object sender, EventArgs e)
        {
            if(stampaDialog.ShowDialog() != DialogResult.OK) {return;}

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Application.StartupPath + "/Printer.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    Arguments = "-print " + sDocX.Replace(" ", "%20") + " " + stampaDialog.PrinterSettings.PrinterName.Replace(" ", "%20"),
                }
            };
            
            proc.OutputDataReceived += new DataReceivedEventHandler(ProcessDataReceived);
            
            proc.Start();
            proc.BeginOutputReadLine();
        }

        public void ProcessDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) 
            {
                disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                    anteprimaDialog.Close();
                }));
                return; 
            }
            if (e.Data == "0") 
            {
                disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                    anteprimaDialog.Close();
                }));
                 return; 
            }
            else if(e.Data.StartsWith("err"))
            {
                MessageBox.Show(e.Data.Substring(3));
            }
            //else unmanaged
        }

        private void AnteprimaRendering(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (lstImagesPath.Count == 0)
            {
                e.HasMorePages = false;
            }
            else
            {
                Image img;
                using (var bmpTemp = new Bitmap(lstImagesPath[imgIndex]))
                {
                    img = new Bitmap(bmpTemp);
                }

                Point loc = new Point(0, 0);
                e.Graphics.DrawImage(img, 0, 0, (float)e.PageSettings.PaperSize.Width, (float)e.PageSettings.PaperSize.Height);

                if (imgIndex < lstImagesPath.Count - 1)
                {
                    e.HasMorePages = true;
                    imgIndex++;
                }
                else
                {
                    e.HasMorePages = false;
                    imgIndex = 0;
                }
            }
        }

    }
}
