using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Euroformulations4.Library;
using Npgsql;
using System.Globalization;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;


namespace Euroformulations4.SubWindows.FormulaSelection
{
    public partial class frmOunceDispensing : Form
    {
        private Language lang = Language.GetInstance();
        private Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
        private Library.Data.DBSettings settings = new Library.Data.DBSettings();

        #region Data
        private Library.Data.Machine.eMacchina machineType;
        private double ouncetype;
        private List<string> lstColorantiNomi;
        private List<double> lstColorantiCosto, lstColorantiQtaML;
        private List<System.Drawing.Color> lstColorantiPreview;
        private string sNomeCliente, sTelCliente, sColorName, sColorchart, sUse, sBaseName, sBaseQta, sUnitaCosto;
        private double baseCosto;
        #endregion

        public frmOunceDispensing(Library.Data.Machine.eMacchina machineType, double ouncetype, List<string> lstColorantiNomi, List<double> lstColorantiQtaML, List<double> lstColorantiCosto, List<System.Drawing.Color> lstColorantiPreview, string sNomeCliente, string sTelCliente, string sColorName, string sColorchart, string sUse, string sBaseName, string sBaseQta, double baseCosto, string sUnitaCosto)
        {
            InitializeComponent();

            this.machineType = machineType;
            this.ouncetype = ouncetype;
            this.lstColorantiNomi = lstColorantiNomi;
            this.lstColorantiQtaML = lstColorantiQtaML;
            this.lstColorantiCosto = lstColorantiCosto;
            this.sNomeCliente = sNomeCliente;
            this.sTelCliente = sTelCliente;
            this.lstColorantiPreview = lstColorantiPreview;
            this.sColorName = sColorName;
            this.sColorchart = sColorchart;
            this.sUse = sUse;
            this.sBaseName = sBaseName;
            this.sBaseQta = sBaseQta;
            this.baseCosto = baseCosto;
            this.sUnitaCosto = sUnitaCosto;
        }

        private void frmOunceDispensing_Load(object sender, EventArgs e)
        {
            try
            {
                dgDati.Columns[0].HeaderText = lang.GetWord("formula11");
                dgDati.Columns[1].HeaderText = lang.GetWord("formula26");

                if (sharedSettings.HasKey("stampaOnce")) { cmbPrinter.Text = sharedSettings.GetValue("stampaOnce"); }
                string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\template\\ManualTemplate");
                for (int i = 0; i < filePaths.Length; i++)
                {
                    cmbPrinter.Items.Add(filePaths[i].Replace(Application.StartupPath + "\\template\\ManualTemplate\\", ""));
                }

                switch (machineType)
                {
                    case Library.Data.Machine.eMacchina.Manual_Y_48_192:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "48";
                            dgDati.Columns[4].HeaderText = "192";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_384:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "48";
                            dgDati.Columns[4].HeaderText = "384";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96_192:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "96";
                            dgDati.Columns[4].HeaderText = "192";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96_384:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "96";
                            dgDati.Columns[4].HeaderText = "384";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "48";
                            dgDati.Columns[4].HeaderText = "";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "96";
                            dgDati.Columns[4].HeaderText = "";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_192:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "192";
                            dgDati.Columns[4].HeaderText = "";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_384:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "384";
                            dgDati.Columns[4].HeaderText = "";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_drops8:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "48";
                            dgDati.Columns[4].HeaderText = "drops8";

                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_drops4:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "48";
                            dgDati.Columns[4].HeaderText = "drops4";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96_drops4:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "96";
                            dgDati.Columns[4].HeaderText = "drops4";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_96:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "48";
                            dgDati.Columns[4].HeaderText = "96";
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_32_128:
                        {
                            dgDati.Columns[2].HeaderText = "Y";
                            dgDati.Columns[3].HeaderText = "32";
                            dgDati.Columns[4].HeaderText = "128";
                            break;
                        }
                }

                for (int i = 0; i < lstColorantiNomi.Count; i++)
                {
                    dgDati.Rows.Add();
                    dgDati.Rows[i].Cells[0].Style.BackColor = lstColorantiPreview[i];
                    dgDati.Rows[i].Cells[1].Value = lstColorantiNomi[i];

                    //calcolo valori
                    double ml = lstColorantiQtaML[i];
                    int value1 = (int)((double)ml / ouncetype);
                    double mlResto1 = ml - ((double)value1 * ouncetype);
                    double secondaAsta = 0;
                    switch (dgDati.Columns[3].HeaderText)
                    {
                        case "32":
                            {
                                secondaAsta = 32d;
                                break;
                            }
                        case "48":
                            {
                                secondaAsta = 48d;
                                break;
                            }
                        case "96":
                            {
                                secondaAsta = 96d;
                                break;
                            }
                        case "192":
                            {
                                secondaAsta = 192d;
                                break;
                            }
                        case "384":
                            {
                                secondaAsta = 384d;
                                break;
                            }
                    }

                    int value2 = (int)((mlResto1 * secondaAsta) / ouncetype);
                    double mlResto2 = mlResto1 - ((ouncetype * (double)value2) / secondaAsta);
                    
                    dgDati.Rows[i].Cells[2].Value = value1.ToString();
                    dgDati.Rows[i].Cells[3].Value = value2.ToString();
                    


                    if (dgDati.Columns[4].HeaderText.Trim() != "")
                    {
                        dgDati.Rows[i].Cells[4].Value = "*";
                    }

                }
                dgDati.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        #region IMAGE FUNCTION
        private static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }

        private MemoryStream Image2Stream(Image image, System.Drawing.Imaging.ImageFormat formaw)
        {
            MemoryStream stream = new System.IO.MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }
        #endregion

        private void TypePrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            sharedSettings.SetValue("stampaOnce", cmbPrinter.Text);
        }
    }
}
