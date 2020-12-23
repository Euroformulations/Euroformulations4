using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.Amministrazione
{
    public partial class frmPassword : Form
    {
        public enum eRequestType
        { 
            settings = 0,
            eurocolori_admin = 1
        }
        private static Library.Language lang = Library.Language.GetInstance();
        private eRequestType requestType;
        private bool bAdminEnabled = false;
        public frmPassword(eRequestType requestType)
        {
            InitializeComponent();
            this.requestType = requestType;
        }

        public bool AdminEnabled
        {
            get { return bAdminEnabled; }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnEnter_Click(null, null);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                switch (requestType)
                {
                    case eRequestType.eurocolori_admin:
                        {
                            if (txtPassword.Text == Library.Licenze.Internal_Administration_Password())
                            {
                                bAdminEnabled = true;
                                this.Close();
                            }
                            else
                            {
                                bAdminEnabled = false;
                                MessageBox.Show(lang.GetWord("settings91"));
                            }
                            break;
                        }
                    case eRequestType.settings:
                        {
                            Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
                            string sPassword = settings.GetValue("SettingsPassword");
                            if (txtPassword.Text == sPassword)
                            {
                                bAdminEnabled = true;
                                this.Close();
                            }
                            else
                            {
                                bAdminEnabled = false;
                                MessageBox.Show(lang.GetWord("settings91"));
                            }
                            break;
                        }
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            this.Text = lang.GetWord("settings90");
            gbPassword.Text = lang.GetWord("Password");
            btnEnter.Text = lang.GetWord("Enter");
        }
    }
}
