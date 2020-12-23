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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;

namespace Euroformulations4.SubWindows.Qualita
{
    public partial class frmQualita : Form
    {
        private Library.Data.Database.DBConnector db;
        private static Language lang = Language.GetInstance();
        private Colore coloreSTD = null, coloreSample = null;
        private int IDSQC_standard = -1, IDSQC_sample = -1;
        private Euroformulations4.Menu.MenuManager menu = null;
        private Bitmap _grafico = null;
        private Bitmap _graficoL = null;

        public frmQualita()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
            btnSalvaStandard.Enabled = false;
            btnSalvaSample.Enabled = false;
            SetButtonColor(btnSalvaStandard);
            SetButtonColor(btnSalvaSample);
            SetButtonColor(btnPrint);
        }

        public Euroformulations4.Menu.MenuManager SetMenu
        {
            set { this.menu = value; }
        }

        #region BUTTON CLICK
        private void btnApriStandard_Click(object sender, EventArgs e)
        {
            try
            {
                frmQualitaColori form = new frmQualitaColori();
                form.ShowDialog();
                Colore coloreTemp = form.ColoreReturned;
                this.IDSQC_standard = form.IDColoreReturned;
                if (coloreTemp == null) return;

                this.coloreSTD = coloreTemp;
                SetData_ColoreSTD();

                btnSalvaStandard.Enabled = false;
                RunColorCompare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnApriSample_Click(object sender, EventArgs e)
        {
            try
            {
                frmQualitaColori form = new frmQualitaColori();
                form.ShowDialog();
                Colore coloreTemp = form.ColoreReturned;
                this.IDSQC_sample = form.IDColoreReturned;
                if (coloreTemp == null) return;
                this.coloreSample = coloreTemp;

                SetData_ColoreSample();
                btnSample.Enabled = true;
                RunColorCompare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSalvaStandard_Click(object sender, EventArgs e)
        {
            try 
            {
                frmQualitaColori form = new frmQualitaColori(this.coloreSTD);
                form.ShowDialog();
                if (form.ColorSaved)
                {
                    this.IDSQC_standard = form.IDColoreReturned;
                    btnSalvaStandard.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSalvaSample_Click(object sender, EventArgs e)
        {
            try
            {
                frmQualitaColori form = new frmQualitaColori(this.coloreSample);
                form.ShowDialog();
                if (form.ColorSaved)
                {
                    this.IDSQC_sample = form.IDColoreReturned;
                    btnSalvaSample.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSample_Click(object sender, EventArgs e)
        {
            try
            {
                Library.Data.Dispositivi.DispositivoBase disp = Library.Data.Dispositivi.DispositiviManager.GetDispositivo();

                if (!disp.Calibrato())
                {
                    DialogResult dialogResult = MessageBox.Show(lang.GetWord("calibration_message"), lang.GetWord("infoMessage"), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    System.Windows.Forms.Form frmDevideDetail = disp.GetWindowManager(true, false);
                    if (frmDevideDetail != null)
                    {
                        frmDevideDetail.ShowDialog();
                    }

                    return;
                }

                ColorSearch.frmGetColor frmColor = new ColorSearch.frmGetColor();
                frmColor.ShowDialog();
                if (!frmColor.LetturaEseguita) { return; }

                btnSample.Enabled = false;

                double l = frmColor.CIEL;
                double a = frmColor.CIEa;
                double b = frmColor.CIEb;
                double[] xyz = Library.Colore.LAB_XYZ(l, a, b);
                this.IDSQC_sample = -1;
                this.coloreSample = new Colore(l, a, b, xyz[0], xyz[1], xyz[2]);
                SetData_ColoreSample();

                btnSample.Enabled = true;
                btnSalvaSample.Enabled = true;
                RunColorCompare();
            }
            catch (Exception ex)
            {
                btnSample.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }
        private void btnStandard_Click(object sender, EventArgs e)
        {
            try
            {
                Library.Data.Dispositivi.DispositivoBase disp = Library.Data.Dispositivi.DispositiviManager.GetDispositivo();

                if (!disp.Calibrato())
                {
                    DialogResult dialogResult = MessageBox.Show(lang.GetWord("calibration_message"), lang.GetWord("infoMessage"), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                    System.Windows.Forms.Form frmDevideDetail = disp.GetWindowManager(true, false);
                    if (frmDevideDetail != null)
                    {
                        frmDevideDetail.ShowDialog();
                    }

                    return;
                }

                ColorSearch.frmGetColor frmColor = new ColorSearch.frmGetColor();
                frmColor.ShowDialog();
                if (!frmColor.LetturaEseguita) { return; }

                btnStandard.Enabled = false;

                double l = frmColor.CIEL;
                double a = frmColor.CIEa;
                double b = frmColor.CIEb;
                double[] xyz = Library.Colore.LAB_XYZ(l, a, b);
                this.IDSQC_standard = -1;
                this.coloreSTD = new Colore(l, a, b, xyz[0], xyz[1], xyz[2]);
                SetData_ColoreSTD();
                btnSalvaStandard.Enabled = true;
                btnStandard.Enabled = true;
                RunColorCompare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnStandard.Enabled = true;
            }
        }
        #endregion

        #region FUNCTION
        private void RunColorCompare() 
        {
            if (this.coloreSTD == null || this.coloreSample == null) return;
            try
            {
                if (dgDifference.Rows.Count == 0)
                {
                    dgDifference.Rows.Add();
                    dgDifference.Rows.Add();
                    dgDifference.Rows[0].Height = ((dgDifference.Height - dgDifference.ColumnHeadersHeight) / 2) - 1;
                    dgDifference.Rows[1].Height = ((dgDifference.Height - dgDifference.ColumnHeadersHeight) / 2) - 1;
                }

                foreach (DataGridViewCell cella in dgDifference.Rows[0].Cells)
                { 
                    cella.ReadOnly = true;
                    cella.Style.ForeColor = System.Drawing.Color.Black;
                    cella.Style.BackColor = SystemColors.Control;
                }
                foreach (DataGridViewCell cella in dgDifference.Rows[1].Cells)
                {
                    cella.ReadOnly = true;
                    cella.Style.ForeColor = System.Drawing.Color.Black;
                    cella.Style.BackColor = SystemColors.Control;
                }

                double deltaL = coloreSample.CIEL - coloreSTD.CIEL;
                double deltaA = coloreSample.CIEa - coloreSTD.CIEa;
                double deltaB = coloreSample.CIEb - coloreSTD.CIEb;
                double deltaC = coloreSample.C - coloreSTD.C;

                dgDifference.Rows[0].Cells["ΔL"].Value = deltaL.ToString("0.00");
                dgDifference.Rows[0].Cells["Δa"].Value = deltaA.ToString("0.00");
                dgDifference.Rows[0].Cells["ΔB"].Value = deltaB.ToString("0.00");
                dgDifference.Rows[0].Cells["ΔC"].Value = deltaC.ToString("0.00");
                dgDifference.Rows[0].Cells["Δh"].Value = Library.Colore.DeltaH(coloreSTD, coloreSample).ToString("0.00");
                dgDifference.Rows[0].Cells["DE"].Value = coloreSTD.CIELabDistance(coloreSample, false).ToString("0.00");
                dgDifference.Rows[0].Cells["CIEDE2000"].Value = coloreSTD.DeltaECie2000Distance(coloreSample, false).ToString("0.00");

                //riga 1
                if (deltaL > 0) dgDifference.Rows[1].Cells["ΔL"].Value = lang.GetWord("quality31");
                else if (deltaL < 0) dgDifference.Rows[1].Cells["ΔL"].Value = lang.GetWord("quality32");
                if (deltaA > 0) dgDifference.Rows[1].Cells["Δa"].Value = lang.GetWord("quality33");
                else if (deltaA < 0) dgDifference.Rows[1].Cells["Δa"].Value = lang.GetWord("quality34");
                if (deltaB > 0) dgDifference.Rows[1].Cells["ΔB"].Value = lang.GetWord("quality35");
                else if (deltaB < 0) dgDifference.Rows[1].Cells["ΔB"].Value = lang.GetWord("quality36");
                //if (deltaC > 0) dgDifference.Rows[1].Cells["ΔC"].Value = "Brighter";
                //else if (deltaC < 0) dgDifference.Rows[1].Cells["ΔC"].Value = "Duller";


                dgDifference.ClearSelection();

                //draw grafico
                double[] rgb = Library.Colore.XYZ_RGB(coloreSTD.X, coloreSTD.Y, coloreSTD.Z);
                System.Drawing.Color  cStd = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));

                double[] rgb2 = Library.Colore.XYZ_RGB(coloreSample.X, coloreSample.Y, coloreSample.Z);
                System.Drawing.Color cSample = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb2[0]), Convert.ToInt32(rgb2[1]), Convert.ToInt32(rgb2[2]));

                _grafico = DrawGrafico(cStd, cSample, deltaA, deltaB, true);
                ResizeImage(this._grafico, pGrafico);
                _graficoL = DrawGraficoL(cStd, cSample, deltaL);
                ResizeImage(this._graficoL, pGraficoL);
                btnPrint.Enabled = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private Bitmap DrawGrafico(System.Drawing.Color cStandard, System.Drawing.Color cSample, double deltaA, double deltaB, bool videoLayout = true)
        {
            pGrafico.Visible = true;
            Font f = new Font("Arial", 12);
            int X_GRAFICO = 568;
            int Y_GRAFICO = 556;
            Bitmap bmp = new Bitmap(X_GRAFICO, Y_GRAFICO);

            System.Drawing.Color cLinee = System.Drawing.Color.Gray;
            if (videoLayout) 
            { 
                cLinee = System.Drawing.Color.White; 
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                //parameters
                int xMargin = 70;
                int yMargin = 60;
                

                //draw structure
                int Qp_width = (X_GRAFICO - (xMargin * 2)) / 10;
                int Qp_height = (Y_GRAFICO - (yMargin * 2)) / 10;
                SolidBrush blueBrush = new SolidBrush(System.Drawing.Color.FromArgb(174, 174, 174));  //background
                if (!videoLayout) { blueBrush = new SolidBrush(System.Drawing.Color.White); }

                Rectangle rect = new Rectangle(0, 0, X_GRAFICO, Y_GRAFICO);
                g.FillRectangle(blueBrush, rect);

                int xYellow1 = 0, xYellow2 = 0, yYellow1 = 0, yYellow2 = 0;
                int xBlu1 = 0, xBlu2 = 0, yBlu1 = 0, yBlu2 = 0;

                for (int i = 0; i <= 10; i++)  //vertical
                {
                    if (i != 5)
                    {
                        g.DrawLine(new Pen(cLinee), (i * Qp_width) + xMargin, yMargin, (i * Qp_width) + xMargin, yMargin + (Qp_height * 10) + 10);
                    }
                    else
                    {
                        xYellow1 = (i * Qp_width) + xMargin;
                        yYellow1 = yMargin;
                        xYellow2 = (i * Qp_width) + xMargin;
                        yYellow2 = yMargin + (Qp_height * 10) / 2;

                        xBlu1 = (i * Qp_width) + xMargin;
                        yBlu1 = yMargin + (Qp_height * 10) / 2;
                        xBlu2 = (i * Qp_width) + xMargin;
                        yBlu2 = yMargin + (Qp_height * 10) + 10;

                        //g.DrawLine(new Pen(darkYellow, 2), (i * Qp_width) + xMargin, yMargin, (i * Qp_width) + xMargin, yMargin + (Qp_height * 10) / 2);
                        //g.DrawLine(new Pen(System.Drawing.Color.Blue, 2), (i * Qp_width) + xMargin, yMargin + (Qp_height * 10) / 2, (i * Qp_width) + xMargin, yMargin + (Qp_height * 10) + 10);

                        //draw text for +-Db
                        string text = "+Δb*";
                        SizeF stringSize = g.MeasureString(text, f);
                        g.DrawString(text, f, Brushes.Black, (i * Qp_width) + xMargin - (stringSize.Width / 2), 5);
                        g.DrawString("-Δb*", f, Brushes.Black, (i * Qp_width) + xMargin - (stringSize.Width / 2), Y_GRAFICO - 22);
                    }
                     
                }
                for (int i = 0; i <= 10; i++) //horizontal
                {
                    if (i != 5)
                    {
                        g.DrawLine(new Pen(cLinee), xMargin - 10, (i * Qp_height) + yMargin, xMargin + (Qp_width * 10), (i * Qp_height) + yMargin);
                    }
                    else
                    {
                        g.DrawLine(new Pen(System.Drawing.Color.Green, 3), xMargin - 10, (i * Qp_height) + yMargin, xMargin + (Qp_width * 10) / 2, (i * Qp_height) + yMargin);
                        g.DrawLine(new Pen(System.Drawing.Color.Red, 3), xMargin + (Qp_width * 10 / 2), (i * Qp_height) + yMargin, xMargin + (Qp_width * 10), (i * Qp_height) + yMargin);

                        //draw text for +-Da
                        string text = "-Δa*";
                        SizeF stringSize = g.MeasureString(text, f);
                        g.DrawString(text, f, Brushes.Black, 3, (i * Qp_height) + yMargin - (stringSize.Height / 2));
                        g.DrawString("+Δa*", f, Brushes.Black, Y_GRAFICO - stringSize.Width - 2, (i * Qp_height) + yMargin - (stringSize.Height / 2));
                    }
                }

                //draw center vertical lines (qui per visibilità)
                System.Drawing.Color darkYellow = System.Drawing.Color.FromArgb(232, 183, 13);
                g.DrawLine(new Pen(darkYellow, 3), xYellow1, yYellow1, xYellow2, yYellow2);
                g.DrawLine(new Pen(System.Drawing.Color.Blue, 3), xBlu1, yBlu1, xBlu2, yBlu2);


                //calcolo centro del grafico
                int diametro = 10;
                int xCentro = xMargin + (Qp_width * 10) / 2 - diametro / 2;
                int yCentro = yMargin + (Qp_height * 10) / 2 - diametro / 2;
                
                //calcolo location campione
                double x = Math.Abs(deltaA) * 2;
                double y = Math.Abs(deltaB) * 2;

                int Lx = 10;
                int Ly = 10;
                while(Lx < (x + 20))
                {
                    Lx += 10;
                }
                while (Ly < (y + 20))
                {
                    Ly += 10;
                }

                int UMx = Lx / 10;
                int UMy = Ly / 10;

                double NQx = Math.Abs(deltaA) / UMx;
                double NQy = Math.Abs(deltaB) / UMy;

                int XPx = (int)((double)Qp_width * NQx);
                int XPy = (int)((double) Qp_height * NQy);

                if (deltaA < 0) { XPx = XPx * -1; }
                if (deltaB > 0) { XPy = XPy * -1; }

                XPx = xCentro + XPx;
                XPy = yCentro + XPy;

                //draw circle
                g.DrawEllipse(new Pen(Brushes.Black), XPx, XPy, diametro, diametro);
                g.FillEllipse(new System.Drawing.SolidBrush(cSample), XPx, XPy, diametro, diametro);
                g.DrawEllipse(new Pen(Brushes.Black), xCentro, yCentro, diametro, diametro);
                g.FillEllipse(new System.Drawing.SolidBrush(cStandard), xCentro, yCentro, diametro, diametro);

                //draw u.m.
                for (int i = 0; i <= 10; i++) //horizontal
                {
                    string text = ((UMy * (i - 5)) * -1).ToString();
                    SizeF stringSize = g.MeasureString(text, f);
                    g.DrawString(text, f, Brushes.Black, xMargin - 10 - stringSize.Width, (i * Qp_height) + yMargin - (stringSize.Height/ 2));
                }
                for (int i = 0; i <= 10; i++)  //vertical
                {
                    string text = (UMx * (i - 5)).ToString();
                    SizeF stringSize = g.MeasureString(text, f);
                    g.DrawString(text, f, Brushes.Black, (i * Qp_width) + xMargin - (stringSize.Width / 2), yMargin + (Qp_height * 10) + 15);
                }
            }
            return bmp;
        }
        private Bitmap DrawGraficoL(System.Drawing.Color cStandard, System.Drawing.Color cSample, double deltaL, bool videoLayout = true)
        {
            int X_GRAFICO = 240, Y_GRAFICO = 556;
            pGraficoL.Visible = true;

            Font f = new Font("Arial", 12);
            Bitmap bmp = new Bitmap(X_GRAFICO, Y_GRAFICO);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //parameters
                int xMargin = 70;
                int yMargin = 60;
                System.Drawing.Color cLinee = System.Drawing.Color.Gray;
                if (videoLayout) { cLinee = System.Drawing.Color.White; }

                //draw structure
                int Qp_height = (Y_GRAFICO - (yMargin * 2)) / 10;
                SolidBrush blueBrush = new SolidBrush(System.Drawing.Color.FromArgb(174, 174, 174));  //background
                if (!videoLayout) { blueBrush = new SolidBrush(System.Drawing.Color.White); }
                Rectangle rect = new Rectangle(0, 0, X_GRAFICO, Y_GRAFICO);
                g.FillRectangle(blueBrush, rect);
                g.DrawLine(new Pen(cLinee), xMargin + /*metà orizz.*/ (X_GRAFICO - (2 * xMargin)) / 2, yMargin - 10, xMargin + /*metà orizz.*/ (X_GRAFICO - (2 * xMargin)) / 2, (Qp_height * 10) + yMargin + 10); //vertical
                for (int i = 0; i <= 10; i++) //horizontal
                {
                    g.DrawLine(new Pen(cLinee), xMargin, (i * Qp_height) + yMargin, X_GRAFICO - xMargin, (i * Qp_height) + yMargin);
                }

                //calcolo centro del grafico
                int diametro = 10;
                int xCentro = xMargin + ((X_GRAFICO - (xMargin * 2)) / 2) - (diametro / 2);
                int yCentro = yMargin + (Qp_height * 5) - (diametro / 2);

                //calcolo location campione
                double y = Math.Abs(deltaL) * 2;

                int Ly = 10;
                while (Ly < (y + 20))
                {
                    Ly += 10;
                }

                int UMy = Ly / 10;

                double NQy = Math.Abs(deltaL) / UMy;

                int XPy = (int)((double)Qp_height * NQy);

                if (deltaL > 0) { XPy = XPy * -1; }

                XPy = yCentro + XPy;

                //draw circle
                g.DrawEllipse(new Pen(Brushes.Black), xCentro, XPy, diametro, diametro);
                g.FillEllipse(new System.Drawing.SolidBrush(cSample), xCentro, XPy, diametro, diametro);
                g.DrawEllipse(new Pen(Brushes.Black), xCentro, yCentro, diametro, diametro);
                g.FillEllipse(new System.Drawing.SolidBrush(cStandard), xCentro, yCentro, diametro, diametro);

                //draw u.m.
                for (int i = 0; i <= 10; i++) //horizontal
                {
                    int val = (UMy * (i - 5)) * -1;
                    string text = val.ToString();
                    if (val > 0) text = "+" + text;
                    SizeF stringSize = g.MeasureString(text, f);
                    g.DrawString(text, f, Brushes.Black, X_GRAFICO - 20 - stringSize.Width, (i * Qp_height) + yMargin - (stringSize.Height / 2));
                }

                //draw text for +-DL
                string textL = "+ΔL*";
                SizeF stringSizeL = g.MeasureString(textL, f);
                g.DrawString(textL, f, Brushes.Black, xMargin + /*metà orizz.*/ (X_GRAFICO - (2 * xMargin)) / 2 - (stringSizeL.Width / 2), 10);
                g.DrawString("-ΔL*", f, Brushes.Black, xMargin + /*metà orizz.*/ (X_GRAFICO - (2 * xMargin)) / 2 - (stringSizeL.Width / 2), Y_GRAFICO - 22);
            }
            return bmp;
        }
        public void ResizeImage(Bitmap grafico, Panel panel)
        {
            if (grafico == null) return;

            Image image = grafico;
            int width = panel.Width;
            int height = panel.Height;

            panel.BackgroundImage = ScaleImage(image, width, height);
        }
        private static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            try
            {
                System.Drawing.Size newSize = GetScale(image.Width, image.Height, maxWidth, maxHeight);
                int newWidth = newSize.Width;
                int newHeight = newSize.Height;
                Bitmap newImage = new Bitmap(newWidth, (int)newHeight);
                Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
                Bitmap bmp = new Bitmap(newImage);
                return bmp;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static System.Drawing.Size GetScale(double imageWidth, double imageHeight, double maxWidth, double maxHeight)
        {
            double ratioX = maxWidth / imageWidth;
            double ratioY = maxHeight / imageHeight;
            double ratio = Math.Min(ratioX, ratioY);

            double newWidth =  (imageWidth * ratio);
            double newHeight = (imageHeight * ratio);

            System.Drawing.Size s = new System.Drawing.Size((int)newWidth, (int)newHeight);
            return s;
        }
        private void SetData_ColoreSTD()
        {
            double[] rgb = Library.Colore.XYZ_RGB(coloreSTD.X, coloreSTD.Y, coloreSTD.Z);

            RSTD1.Text = "R : " + Math.Round(rgb[0], 0);
            GSTD1.Text = "G : " + Math.Round(rgb[1], 0);
            BSTD1.Text = "B : " + Math.Round(rgb[2], 0);
            CIELSTD1.Text = "L* : " + Math.Round(coloreSTD.CIEL, 2);
            CIEASTD1.Text = "a* : " + Math.Round(coloreSTD.CIEa, 2);
            CIEBSTD1.Text = "b* : " + Math.Round(coloreSTD.CIEb, 2);
            XSTD1.Text = "X* : " + Math.Round(coloreSTD.X, 2);
            YSTD1.Text = "Y* : " + Math.Round(coloreSTD.Y, 2);
            ZSTD1.Text = "Z* : " + Math.Round(coloreSTD.Z, 2);
            CSTD1.Text = "C* : " + Math.Round(coloreSTD.C, 2);
            HSTD1.Text = "h : " + Math.Round(coloreSTD.H, 2);
            CIEL2STD1.Text = CIELSTD1.Text;

            txtColorStandard.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
        }
        private void SetData_ColoreSample()
        {
            double[] rgb = Library.Colore.XYZ_RGB(coloreSample.X, coloreSample.Y, coloreSample.Z);
            RSTD2.Text = "R : " + Math.Round(rgb[0], 0);
            GSTD2.Text = "G : " + Math.Round(rgb[1], 0);
            BSTD2.Text = "B : " + Math.Round(rgb[2], 0);
            CIELSTD2.Text = "L* : " + Math.Round(coloreSample.CIEL, 2);
            CIEASTD2.Text = "a* : " + Math.Round(coloreSample.CIEa, 2);
            CIEBSTD2.Text = "b* : " + Math.Round(coloreSample.CIEb, 2);
            XSTD2.Text = "X* : " + Math.Round(coloreSample.X, 2);
            YSTD2.Text = "Y* : " + Math.Round(coloreSample.Y, 2);
            ZSTD2.Text = "Z* : " + Math.Round(coloreSample.Z, 2);
            CSTD2.Text = "C* : " + Math.Round(coloreSample.C, 2);
            HSTD2.Text = "h : " + Math.Round(coloreSample.H, 2);
            CIEL2STD2.Text = CIELSTD2.Text;

            txtColorSample.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
        }
        private MemoryStream Image2Stream(Image image, ImageFormat formaw)
        {
            MemoryStream stream = new System.IO.MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
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
        #endregion

        #region EVENT
        private void pGrafico_SizeChanged(object sender, EventArgs e)
        {
            ResizeImage(this._grafico, pGrafico);
        }
        private void pGraficoL_SizeChanged(object sender, EventArgs e)
        {
            ResizeImage(this._graficoL, pGraficoL);
        }
        private void frmQualita_Load(object sender, EventArgs e)
        {
            groupBox3.Text = lang.GetWord("quality01");
            btnStandard.Text = lang.GetWord("quality02");
            groupBox2.Text = lang.GetWord("quality19");
            btnSample.Text = lang.GetWord("quality20");
            groupBox6.Text = lang.GetWord("quality21");
            lblStandard.Text = lang.GetWord("quality23");
            lblSample.Text = lang.GetWord("quality24");
            btnPrint.Text = lang.GetWord("quality63");
            this.ActiveControl = dgDifference;
        }
        private void lblPrint_Click(object sender, EventArgs e)
        {
            if (this.coloreSTD == null || this.coloreSample == null) return;
            string path = Application.StartupPath + "\\include\\A4SQC.docx";
            if (!System.IO.File.Exists(path)) { return; }

            try
            {
                btnPrint.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                string sNomeStd = "", nomeSample = "";
                #region GET COLORS NAME
                if (this.IDSQC_sample != -1 || this.IDSQC_standard != -1)
                {
                    try
                    {
                        string sql = "SELECT idcolore, nome_colore FROM sqc_color WHERE idcolore IN (" + this.IDSQC_sample + ", " + this.IDSQC_standard + ")";
                        DataTable dt = db.SQLQuerySelect(sql);
                        foreach (DataRow dr in dt.Rows)
                        {
                            int IDReaded = Convert.ToInt32(dr["idcolore"].ToString());
                            if (IDReaded == IDSQC_sample)
                            {
                                nomeSample = dr["nome_colore"].ToString();
                            }
                            else
                            {
                                if (IDReaded == IDSQC_standard) { sNomeStd = dr["nome_colore"].ToString(); }
                            }
                        }
                    }
                    catch (Exception) { }
                }
                #endregion


                //init data
                DateTime dtNow = DateTime.Now;
                double[] rgb_std = Library.Colore.XYZ_RGB(coloreSTD.X, coloreSTD.Y, coloreSTD.Z);
                double[] rgb_sample = Library.Colore.XYZ_RGB(coloreSample.X, coloreSample.Y, coloreSample.Z);
                double deltaL = coloreSample.CIEL - coloreSTD.CIEL;
                double deltaA = coloreSample.CIEa - coloreSTD.CIEa;
                double deltaB = coloreSample.CIEb - coloreSTD.CIEb;
                double[] rgb = Library.Colore.XYZ_RGB(coloreSTD.X, coloreSTD.Y, coloreSTD.Z);
                System.Drawing.Color cStd = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
                double[] rgb2 = Library.Colore.XYZ_RGB(coloreSample.X, coloreSample.Y, coloreSample.Z);
                System.Drawing.Color cSample = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb2[0]), Convert.ToInt32(rgb2[1]), Convert.ToInt32(rgb2[2]));
                Bitmap graficoStampa = DrawGrafico(cStd, cSample, deltaA, deltaB, false);
                System.Drawing.Size graficoStampaSize = GetScale(graficoStampa.Width, graficoStampa.Height, 530, 430);
                Bitmap graficoStampaL = DrawGraficoL(cStd, cSample, deltaL, false);
                System.Drawing.Size graficoStampaSizeL = GetScale(graficoStampaL.Width, graficoStampaL.Height, 187, 430);

            

                //NOTE: non possiamo stampare direttamente con le GEMBOX PERCHE':
                //    1- problema anteprima
                //    2- usando il loro comando avviene un ridimensionamento incontrollato della form (bug di gembox)


                //ensure folder ef4dataprint
                string tempPath = System.IO.Path.GetTempPath() + "ef4dataprint";
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                else
                {
                    foreach (string file in Directory.GetFiles(tempPath))
                    {
                        File.Delete(file);
                    }
                }
                


                //delete file temporanei
                foreach (string file in Directory.GetFiles(tempPath))
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnPrint.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }
        private void button_EnabledChanged(object sender, EventArgs e)
        {
            SetButtonColor((Button)sender);
        }
        #endregion  

        private void frmQualita_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception)
            {
                //LOG HERE
            }
        }
    
    }
}
