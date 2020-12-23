using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmWelcome : Form
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private Image imgSfondo = null;
        private bool bDemo = false;
        //private int xFigPerc = 30;
        //private int yFigPerc = 30;

        public frmWelcome()
        {
            InitializeComponent();
        }

        public bool Demo
        {
            set { this.bDemo = value; }
        }

        public Image ImageSfondo
        {
            set { this.imgSfondo = value; }
        }

        private void frmLicense_Load(object sender, EventArgs e)
        {
            lblSelect2.Text = lang.GetWord("welcome02");
            Library.Data.DBSettings settings = new Library.Data.DBSettings();
            bool bShowLabelEmail = settings.GetValue("showlabelemail") == "1";
            if (bDemo && bShowLabelEmail)
            {
                lblInfo.Text = lang.GetWord("welcome03");
            }
            else
            {
                lblInfo.Visible = false;
            }
        }

        private void frmWelcome_Resize(object sender, EventArgs e)
        {
            /*int hLogo = (this.Size.Height * this.yFigPerc) / 100;
            int wLogo = (this.Size.Width * this.xFigPerc) / 100;

            int hCentro = (this.Size.Height / 2) - 30;
            int xCentro = this.Size.Width / 2;

            int xFig = xCentro - (wLogo / 2);
            int yFig = hCentro - (hLogo / 2);

            pbLogo.Size = new Size(wLogo, hLogo);
            pbLogo.Location = new Point(xFig, yFig);*/

        }

        private void frmWelcome_ResizeBegin(object sender, EventArgs e)
        {
            //pbLogo.SuspendLayout();
        }

        private void frmWelcome_ResizeEnd(object sender, EventArgs e)
        {
            //  pbLogo.ResumeLayout();
        }

        private void pbSfondo_Paint(object sender, PaintEventArgs e)
        {
            Image img = null;
            if (imgSfondo == null)
            {
                img = ResizeImage(Properties.Resources.eclogo, 250, 250);
                lblSelect2.Visible = true;
            }
            else
            {
                img = ResizeImage(imgSfondo, pbSfondo.Width, pbSfondo.Height);
                lblSelect2.Visible = false;
            }

            var g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            int x = 0, y = 0;
            if (img.Width < pbSfondo.Width)
            {
                x = (pbSfondo.Width - img.Width) / 2;
            }
            if (img.Height < pbSfondo.Height)
            {
                y = (pbSfondo.Height - img.Height) / 2;
            }

            g.DrawImage(img, x, y, img.Width, img.Height);
        }
        private Image ResizeImage(Image img, double maxWidth, double maxHeight)
        {
            double resizeWidth = img.Width;
            double resizeHeight = img.Height;

            double aspect = resizeWidth / resizeHeight;

            if (resizeWidth > maxWidth)
            {
                resizeWidth = maxWidth;
                resizeHeight = resizeWidth / aspect;
            }
            if (resizeHeight > maxHeight)
            {
                aspect = resizeWidth / resizeHeight;
                resizeHeight = maxHeight;
                resizeWidth = resizeHeight * aspect;
            }
            return (Image)(new Bitmap(img, new Size((int)resizeWidth, (int)resizeHeight)));
        }
    }
}
