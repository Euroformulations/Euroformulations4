using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.FormulaSelection
{
    public partial class frmNumErogazioni : Form
    {
        private Library.Language lang = Library.Language.GetInstance();
        private int nErogazioni = 1;
        
        public frmNumErogazioni()
        {
            InitializeComponent();
        }

        public int Erogazioni { get { return nErogazioni; } }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnDispense_Click(null, null);
                e.Handled = false;
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnDispense_Click(object sender, EventArgs e)
        {
            try
            {
                nErogazioni = Convert.ToInt32(txtNum.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmNumErogazioni_Load(object sender, EventArgs e)
        {
            try
            {
                gbNumbers.Text = lang.GetWord("formula67");
                btnConfirm.Text = lang.GetWord("confirm");
                txtNum.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
                
                
            
        }


    }
}
