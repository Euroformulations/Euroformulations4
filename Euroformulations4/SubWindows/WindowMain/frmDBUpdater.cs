using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmDBUpdater : Form
    {
        public frmDBUpdater()
        {
            InitializeComponent();
        }

        public void SetPoint(int counter)
        {
            switch (counter % 5)
            {
                case 0:
                    {
                        lblPoint.Text = "";
                        break;
                    }
                case 1:
                    {
                        lblPoint.Text = ".";
                        break;
                    }
                case 2:
                    {
                        lblPoint.Text = ". .";
                        break;
                    }
                case 3:
                    {
                        lblPoint.Text = ". . .";
                        break;
                    }
                default:{ break; }
            }
        }

        


        
    }
}
