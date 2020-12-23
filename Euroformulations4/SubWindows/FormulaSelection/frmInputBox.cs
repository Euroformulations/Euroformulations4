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
    public partial class frmInputBox : Form
    {
        private bool bOKPressed = false;
        private string sInputText = "";
        private string title;
        private string labelMessage;
        private Library.Language lang = Library.Language.GetInstance();

        public frmInputBox(string title, string labelMessage)
        {
            InitializeComponent();
            this.title = title;
            this.labelMessage = labelMessage;
        }

        public bool OKPressed { get { return bOKPressed; } }
        public string InputText { get { return sInputText; } }

        private void btnDispense_Click(object sender, EventArgs e)
        {
            sInputText = txtInput.Text;
            bOKPressed = true;
            this.Close();
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = title;
                this.lblMessage.Text = labelMessage;
                btnDispense.Text = lang.GetWord("ok");
            }
            catch (Exception){}
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) { return; }
            btnDispense_Click(null, null);
        }
    }
}
