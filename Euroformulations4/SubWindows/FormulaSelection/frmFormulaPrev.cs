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
    public partial class frmFormulaPrev : Form
    {
        private string sProdottoStart;
        private string sColorName;
        private string sUsoStart;
        private Library.Data.Database.DBConnector db;
        private Dictionary<int, Library.Formulation.Formula> dicData;
        private bool bEndLoad = false;
        private Library.Data.SharedSettings sharedSettings;
        private string sNumFormat = "N0";
        private Library.Language lang = Library.Language.GetInstance();
        private Library.Formulation.Formula selectedFormula = null;
        private bool bExitWithSelection = false;

        public frmFormulaPrev(string sProdotto, string sColorName, string sUso)
        {
            InitializeComponent();

            try
            {
                this.sProdottoStart = sProdotto;
                this.sColorName = sColorName;
                this.sUsoStart = sUso;
                this.db = new Library.Data.Database.DBConnector();
                this.dicData = new Dictionary<int, Library.Formulation.Formula>();
                this.sharedSettings = new Library.Data.SharedSettings();
                int iDecimals = Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"));
                if (iDecimals > 0)
                {
                    sNumFormat = "N" + iDecimals.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Library.Formulation.Formula SelectedFormula
        {
            get 
            {
                if (bExitWithSelection) { return selectedFormula; }
                else { return null; }
            }
        }

        private void frmFormulaPrev_Load(object sender, EventArgs e)
        {
            try
            {
                #region TRADUZIONI
                this.Text = lang.GetWord("formulaprev01");
                lblInfo.Text = lang.GetWord("formulaprev02");
                btnConfirm.Text = lang.GetWord("formulaprev03");
                #endregion


                string sql = "SELECT id, dateformula FROM formule_prev WHERE system = '" + this.sProdottoStart + "' AND  colorname = '" + this.sColorName + "' and use = '" + this.sUsoStart + "' ORDER BY dateformula DESC";
                DataTable dt = db.SQLQuerySelect(sql);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["id"].ToString());
                    DateTime dateformula = DateTime.Parse(dr["dateformula"].ToString());
                    Library.Formulation.Formula formula = Library.Formulation.Formula.InitFormula_From_formulePrev(id);

                    dicData.Add(id, formula);

                    dgTinte.Rows.Add();
                    dgTinte.Rows[i].Cells[0].Value = id;
                    dgTinte.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(formula.RGB_R), Convert.ToInt32(formula.RGB_G), Convert.ToInt32(formula.RGB_B));
                    dgTinte.Rows[i].Cells[2].Value = dateformula.ToString("yyyy-MM-dd");

                    i++;
                }
                dgTinte.ClearSelection();
                SetButtonColor(btnConfirm);
                btxt.Text = "";

                bEndLoad = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgTinte_SelectionChanged(object sender, EventArgs e)
        {
            if (!bEndLoad) { return; }
            try
            {
                int idformula = Convert.ToInt32(dgTinte.SelectedRows[0].Cells[0].Value.ToString());
                selectedFormula = dicData[idformula];

                dgFormula.Rows.Clear();
                for (int i = 0; i < selectedFormula.ColorantsCount; i++)
                {
                    double qml = Library.Formulation.Formula.ConvertValue(selectedFormula.ColorantQta(i), selectedFormula.ColorantsUnit, Library.Formulation.eUnita.ml, selectedFormula.ColorantDensita(i));
                    double qgr = Library.Formulation.Formula.ConvertValue(selectedFormula.ColorantQta(i), selectedFormula.ColorantsUnit, Library.Formulation.eUnita.gr, selectedFormula.ColorantDensita(i));

                    string sGr = Math.Round(qgr, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);
                    string sMl = Math.Round(qml, Convert.ToInt32(sharedSettings.GetValue("DecimalNumber"))).ToString(sNumFormat);

                    dgFormula.Rows.Add("", selectedFormula.ColorantName(i), sGr, sMl);
                    dgFormula.Rows[i].Cells[0].Style.BackColor = selectedFormula.ColorantPreview(i);
                }

                btxt.Text = selectedFormula.BaseName + " " + lang.GetWord("for") + " " + selectedFormula.BaseQta.ToString().Replace(".", ",") + " " + selectedFormula.BaseUnita.ToString().ToUpper();

                //qta base

                /*
                 PackagePreProcessor packageprocessor = new PackagePreProcessor(listLatte.SelectedItems[0].SubItems[0].Text.ToString());
                    string[] sTagData = listLatte.SelectedItems[0].Tag.ToString().Split(';');
                    if (packageprocessor.bError) { throw new Exception(lang.GetWord("formula34")); }
                    Library.Formulation.eUnita unitaBase = packageprocessor.unitaBase;
                    string subLabel = packageprocessor.subLabel;
                    double qtaBase = packageprocessor.qtaBase;

                    formula = formula_originale.ChangeBase(qtaBase, unitaBase, true, sTagData[1]);

                    double refill = (Convert.ToDouble(sTagData[0])) * 100;
                    formula = formula.GetFormulaRefilled((int) refill);
                    
                 */

                dgFormula.ClearSelection();
                dgFormula.Enabled = true;
                btnConfirm.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                bExitWithSelection = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgTinte_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idformula = Convert.ToInt32(dgTinte.SelectedRows[0].Cells[0].Value.ToString());
                selectedFormula = dicData[idformula];
                btnConfirm_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_EnabledChanged(object sender, EventArgs e)
        {
            SetButtonColor((Button)sender);
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
    }
}
