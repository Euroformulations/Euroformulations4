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

namespace Euroformulations4.SubWindows
{
    public partial class frmQualita : Form
    {
        private double L1, a1, b1, L2, a2, b2;
        public frmQualita()
        {
            InitializeComponent();
            SMSave.Enabled = false;
        }

        private void DeltaE_Click(object sender, EventArgs e)
        {
            Library.Color Delta = new Library.Color();
            Delta.DeltaE(L1, a1, b1, L2, a2, b2);
            Delta.DeltaECie2000(L1, a1, b1, L2, a2, b2);
            detxt.Text = "Il DeltaE è: " + Delta.DEValue;
            decmctxt.Text = "Il DeltaE cie 2000 è: " + Delta.Deltacie2000;
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            try
            {
                //Test ultima lettura da spettrofotometro
                DateTime dtLastCalibration = Library.Spettrofotometro.GetLastCalibration();
                DateTime dtCompare = DateTime.Now.AddHours(-12);
                if (dtLastCalibration < dtCompare)
                    throw new Exception("You need to (re)calibrate your device first");

                btnSample.Enabled = false;
                double[] xyzLab = Library.Spettrofotometro.ReadXYZLab();
                L2 = xyzLab[3];
                a2 = xyzLab[4];
                b2 = xyzLab[5];

                //Popolazione Testi
                Library.Color Colorf4 = new Library.Color();
                Colorf4.XYZ_RGB(xyzLab[0], xyzLab[1], xyzLab[2]);
                System.Drawing.Color c = System.Drawing.Color.FromArgb((int)Colorf4.R, (int)Colorf4.G, (int)Colorf4.B);


                RSTD2.Text = "R : " + Math.Round(Colorf4.R, 0);
                GSTD2.Text = "G : " + Math.Round(Colorf4.G, 0);
                BSTD2.Text = "B : " + Math.Round(Colorf4.B, 0);
                CIELSTD2.Text = "L* : " + Math.Round(L2, 2);
                CIEASTD2.Text = "a* : " + Math.Round(a2, 2);
                CIEBSTD2.Text = "b* : " + Math.Round(b2, 2);
                XSTD2.Text = "X* : " + Math.Round(xyzLab[0], 2);
                YSTD2.Text = "Y* : " + Math.Round(xyzLab[1], 2);
                ZSTD2.Text = "Z* : " + Math.Round(xyzLab[2], 2);
                CSTD2.Text = "C* : " + Math.Round(Math.Sqrt(Math.Pow(a2, 2) + Math.Pow(b2, 2)), 2);
                HSTD2.Text = "h : " + Math.Round(Colorf4.Arcotan(b2, a2), 2);

                txtColorSample.BackColor = System.Drawing.Color.FromArgb((int) Colorf4.R, (int) Colorf4.G, (int) Colorf4.B);
                btnSample.Enabled = true;
                SMSave.Enabled = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            try
            {
                //Test ultima lettura da spettrofotometro
                DateTime dtLastCalibration = Library.Spettrofotometro.GetLastCalibration();
                DateTime dtCompare = DateTime.Now.AddHours(-12);
                if (dtLastCalibration < dtCompare)
                    throw new Exception("You need to (re)calibrate your device first");

                btnStandard.Enabled = false;
                double[] xyzLab = Library.Spettrofotometro.ReadXYZLab();

                //Popolazione LAB per delta
                L1 = xyzLab[3];
                a1 = xyzLab[4];
                b1 = xyzLab[5];

                //Popolazione Testi
                Library.Color Colorf4 = new Library.Color();
                Colorf4.XYZ_RGB(xyzLab[0], xyzLab[1], xyzLab[2]);
                System.Drawing.Color c = System.Drawing.Color.FromArgb((int)Colorf4.R, (int)Colorf4.G, (int)Colorf4.B);

                RSTD1.Text = "R : " + Math.Round(Colorf4.R, 0);
                GSTD1.Text = "G : " + Math.Round(Colorf4.G, 0);
                BSTD1.Text = "B : " + Math.Round(Colorf4.B, 0);
                CIELSTD1.Text = "L* : " + Math.Round(L1, 2);
                CIEASTD1.Text = "a* : " + Math.Round(a1, 2);
                CIEBSTD1.Text = "b* : " + Math.Round(b1, 2);
                XSTD1.Text = "X* : " + Math.Round(xyzLab[0], 2);
                YSTD1.Text = "Y* : " + Math.Round(xyzLab[1], 2);
                ZSTD1.Text = "Z* : " + Math.Round(xyzLab[2], 2);
                CSTD1.Text = "C* : " + Math.Round(Math.Sqrt(Math.Pow(a1, 2) + Math.Pow(b1, 2)), 2);
                HSTD1.Text = "h : " + Math.Round(Colorf4.Arcotan(b1, a1), 2);

                txtColorStandard.BackColor = System.Drawing.Color.FromArgb((int)Colorf4.R, (int)Colorf4.G, (int)Colorf4.B);
                btnStandard.Enabled = true;
                STDSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void frmQualita_Load(object sender, EventArgs e)
        {

        }
    }
}
