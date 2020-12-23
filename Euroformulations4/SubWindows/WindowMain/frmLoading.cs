using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmLoading : Form
    {
        private Image imgSfondo;
        public frmLoading()
        {
            InitializeComponent();
        }

        public Image ImageSfondo
        {
            set { imgSfondo = value; }
        }

        private void pbSfondo_Paint(object sender, PaintEventArgs e)
        {
            Image img;
            if (imgSfondo != null)
            {
                img = ResizeImage(imgSfondo, pbLogo.Width, pbLogo.Height);
            }
            else
            {
                img = ResizeImage(Properties.Resources.logo_euroformulations4, pbLogo.Width, pbLogo.Height);
            }
            var g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            int x = 0, y = 0;
            if (img.Width < pbLogo.Width)
            {
                x = (pbLogo.Width - img.Width) / 2;
            }
            if (img.Height < pbLogo.Height)
            {
                y = (pbLogo.Height - img.Height) / 2;
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
