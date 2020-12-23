using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.ColorSearch
{
    public partial class frmGetManualColor : Form
    {
        private enum eTipoLettura
        { 
            Cube = 0,
            D50 = 1,
            D65 = 2,
        }
        
        private static Library.Language lang = Library.Language.GetInstance();
        Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
        private double l = 0d, a = 0d, b = 0d;
        private bool bReaded = false;
        private bool bReadedWithCube = false;
        private int iMetodoLettura = 0;

        public frmGetManualColor()
        {
            InitializeComponent();
        }

        private void frmGetManualColor_Load(object sender, EventArgs e)
        {
            btnConfirm.Text = lang.GetWord("confirm");
            gbDefaultDevice.Text = lang.GetWord("search34");

            Dictionary<int, string> dicTipoLettura = new Dictionary<int, string>();
            dicTipoLettura.Add((int)eTipoLettura.Cube, lang.GetWord("device10"));
            dicTipoLettura.Add((int)eTipoLettura.D50, lang.GetWord("d50"));
            dicTipoLettura.Add((int)eTipoLettura.D65, lang.GetWord("d65"));

            cmbDispositivi.DataSource = new BindingSource(dicTipoLettura, null);
            cmbDispositivi.DisplayMember = "Value";
            cmbDispositivi.ValueMember = "Key";

            iMetodoLettura = Convert.ToInt32(settings.GetValue("MetodoLetturaLAB"));
            cmbDispositivi.SelectedValue = iMetodoLettura;
        }

        public double CIEL { get { return l; } }
        public double CIEa { get { return a; } }
        public double CIEb { get { return b; } }
        public bool Readed { get { return bReaded; } }

        public bool ReadedWithCube { get { return bReadedWithCube; } }

        private void txtL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == '-') 
                e.Handled = false;
            else
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDispositivi.SelectedValue == null) { throw new Exception(lang.GetWord("search35")); }
                iMetodoLettura = Convert.ToInt32(cmbDispositivi.SelectedValue.ToString());
                eTipoLettura gestioneLAB = (eTipoLettura) iMetodoLettura;

                if (txtL.Text.Trim() == "" || txtA.Text.Trim() == "" || txtB.Text.Trim() == "") { bReaded = false; }
                this.l = Convert.ToDouble(txtL.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                this.a = Convert.ToDouble(txtA.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                this.b = Convert.ToDouble(txtB.Text.Replace(",", "."), CultureInfo.InvariantCulture);

                if (gestioneLAB == eTipoLettura.Cube || gestioneLAB == eTipoLettura.D50)
                {
                    double[] xyz_d65 = Library.Colore.LAB_XYZ(l, a, b);
                    double[] lab = Library.Colore.XYZ_LAB(xyz_d65[0], xyz_d65[1], xyz_d65[2]);
                    this.l = lab[0];
                    this.a = lab[1];
                    this.b = lab[2];
                    bReadedWithCube = true;
                }

                bReaded = true;
                this.Close();
            }
            catch (Exception ex)
            {
                if (txtL.Text.Trim() == "" || txtA.Text.Trim() == "" || txtB.Text.Trim() == "")
                {
                    if (txtL.Text.Trim() == "") txtL.BackColor = Color.Red; else txtL.BackColor = Color.White;
                    if (txtA.Text.Trim() == "") txtA.BackColor = Color.Red; else txtA.BackColor = Color.White;
                    if (txtB.Text.Trim() == "") txtB.BackColor = Color.Red; else txtB.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmGetManualColor_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                settings.SetValue("MetodoLetturaLAB", iMetodoLettura.ToString());
            }
            catch (Exception){ }
        }
    }
}
