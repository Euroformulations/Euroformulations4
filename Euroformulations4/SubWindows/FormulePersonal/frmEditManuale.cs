using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.SubWindows.FormulePersonal
{
    public partial class frmEditManuale : Form
    {
        private Library.Data.Database.DBConnector db;
        private Library.Data.DBSettings settings = new Library.Data.DBSettings();
        private Library.Language lang = Library.Language.GetInstance();
        private double ml;
        private int IDMachine;
        private double ouncetype;
        private int iMaxValue2 = -1;
        private int iMaxValue3 = -1;
        private double mlOut = -1d;

        public frmEditManuale(double ml)
        {
            InitializeComponent();
            this.ml = ml;
            this.IDMachine = Convert.ToInt32(settings.GetValue("IDMachineOunceEdit"));
            db = new Library.Data.Database.DBConnector();
        }

        public double MilliliterValue { get { return mlOut; } }

        private void frmEditManuale_Load(object sender, EventArgs e)
        {
            try
            {
                btnDispense.Text = lang.GetWord("confirm");

                DataTable dt = db.SQLQuerySelect("SELECT * FROM machine WHERE id_machine = " + IDMachine.ToString());
                DataRow dr = dt.Rows[0];
                int iMachine_type = Convert.ToInt32(dr["machine_type"].ToString());
                ouncetype = Convert.ToDouble(dr["oncetype"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                this.Text = dr["name"].ToString();

                switch ((Library.Data.Machine.eMacchina)iMachine_type)
                {
                    case Library.Data.Machine.eMacchina.Manual_Y_48_192:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "48";
                            gb3.Text = "192";
                            iMaxValue2 = 48;
                            iMaxValue3 = 192;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_384:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "48";
                            gb3.Text = "384";
                            iMaxValue2 = 48;
                            iMaxValue3 = 384;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96_192:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "96";
                            gb3.Text = "192";
                            iMaxValue2 = 96;
                            iMaxValue3 = 192;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96_384:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "96";
                            gb3.Text = "384";
                            iMaxValue2 = 96;
                            iMaxValue3 = 384;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "48";
                            iMaxValue2 = 48;
                            iMaxValue3 = -1;
                            gb3.Visible = false;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "96";
                            iMaxValue2 = 96;
                            iMaxValue3 = -1;
                            gb3.Visible = false;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_192:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "192";
                            iMaxValue2 = 192;
                            iMaxValue3 = -1;
                            gb3.Visible = false;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_384:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "384";
                            iMaxValue2 = 384;
                            iMaxValue3 = -1;
                            gb3.Visible = false;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_drops8:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "48";
                            gb4.Text = "drops8";
                            iMaxValue2 = 48;
                            iMaxValue3 = -1;
                            gb3.Visible = false;
                            gb4.Location = gb3.Location;
                            cmb4.Items.Add("0");
                            cmb4.Items.Add("1/8");
                            cmb4.Items.Add("1/4");
                            cmb4.Items.Add("3/8");
                            cmb4.Items.Add("1/2");
                            cmb4.Items.Add("5/8");
                            cmb4.Items.Add("3/4");
                            cmb4.Items.Add("7/8");
                            cmb4.Items.Add("7/8*");
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_drops4:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "48";
                            gb4.Text = "drops4";
                            iMaxValue2 = 48;
                            iMaxValue3 = -1;
                            gb3.Visible = false;
                            gb4.Location = gb3.Location;
                            cmb4.Items.Add("0");
                            cmb4.Items.Add("1/4");
                            cmb4.Items.Add("1/2");
                            cmb4.Items.Add("3/4");
                            cmb4.Items.Add("3/4*");
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_96_drops4:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "96";
                            gb4.Text = "drops4";
                            iMaxValue2 = 96;
                            iMaxValue3 = -1;
                            gb3.Visible = false;
                            gb4.Location = gb3.Location;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_48_96:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "48";
                            gb3.Text = "96";
                            iMaxValue2 = 48;
                            iMaxValue3 = 96;
                            gb4.Visible = false;
                            break;
                        }
                    case Library.Data.Machine.eMacchina.Manual_Y_32_128:
                        {
                            gb1.Text = "Y";
                            gb2.Text = "32";
                            gb3.Text = "128";
                            iMaxValue2 = 32;
                            iMaxValue3 = 128;
                            gb4.Visible = false;
                            break;
                        }
                }

                //calcolo valori
                int value1 = (int)((double)ml / ouncetype);
                double mlResto1 = ml - ((double)value1 * ouncetype);
                double secondaAsta = 0;
                switch (gb2.Text)
                {
                    case "32":
                        {
                            secondaAsta = 32d;
                            break;
                        }
                    case "48":
                        {
                            secondaAsta = 48d;
                            break;
                        }
                    case "96":
                        {
                            secondaAsta = 96d;
                            break;
                        }
                    case "192":
                        {
                            secondaAsta = 192d;
                            break;
                        }
                    case "384":
                        {
                            secondaAsta = 384d;
                            break;
                        }
                }

                int value2 = (int)((mlResto1 * secondaAsta) / ouncetype);
                double mlResto2 = mlResto1 - ((ouncetype * (double)value2) / secondaAsta);

                //popolo primi 2 valori
                txt1.Text = value1.ToString();
                txt2.Text = value2.ToString();

                if (gb3.Visible)
                {
                    switch (gb3.Text)
                    {
                        case "384":
                            {
                                txt3.Text = ((int)((mlResto2 * 384d) / ouncetype)).ToString();
                                break;
                            }
                        case "192":
                            {
                                txt3.Text = ((int)((mlResto2 * 192d) / ouncetype)).ToString();
                                break;
                            }
                        case "96":
                            {
                                txt3.Text = ((int)((mlResto2 * 96d) / ouncetype)).ToString();
                                break;
                            }
                        case "128":
                            {
                                txt3.Text = ((int)((mlResto2 * 128d) / ouncetype)).ToString();
                                break;
                            }
                    }
                }

                if (gb4.Visible)
                {
                    int drops = (int)Math.Round((mlResto2 * 384) / ouncetype, 0);
                    switch (gb4.Text)
                    {
                        case "drops4":
                            {
                                switch (drops)
                                {

                                    case 0:
                                        cmb4.Text = "0";
                                        break;
                                    case 1:
                                    case 2:
                                        cmb4.Text = "1/4";
                                        break;
                                    case 3:
                                    case 4:
                                        cmb4.Text = "1/2";
                                        break;
                                    case 5:
                                    case 6:
                                        cmb4.Text = "3/4";
                                        break;
                                    default:
                                        cmb4.Text = "3/4*";
                                        break;
                                }
                                break;
                            }
                        case "drops8":
                            {
                                switch (drops)
                                {
                                    case 0:
                                        cmb4.Text = "0";
                                        break;
                                    case 1:
                                        cmb4.Text = "1/8";
                                        break;
                                    case 2:
                                        cmb4.Text = "1/4";
                                        break;
                                    case 3:
                                        cmb4.Text = "3/8";
                                        break;
                                    case 4:
                                        cmb4.Text = "1/2";
                                        break;
                                    case 5:
                                        cmb4.Text = "5/8";
                                        break;
                                    case 6:
                                        cmb4.Text = "3/4";
                                        break;
                                    case 7:
                                        cmb4.Text = "7/8";
                                        break;
                                    default:
                                        cmb4.Text = "7/8*";
                                        break;
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void frmEditManuale_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnDispense_Click(object sender, EventArgs e)
        {
            try
            {
                double mlValue = 0;

                #region TERZA ASTA

                if (gb3.Visible)
                {
                    int valTerzaAsta = Convert.ToInt32(txt3.Text);
                    if (iMaxValue3 != -1)
                    {
                        if (valTerzaAsta < 0 || valTerzaAsta > iMaxValue3)
                        {
                            txt3.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            txt3.BackColor = Color.White;
                        }
                    }
                    switch (gb3.Text)
                    {
                        case "384":
                            {
                                mlValue += (ouncetype * (double)valTerzaAsta) / 384;
                                break;
                            }
                        case "192":
                            {
                                mlValue += (ouncetype * (double)valTerzaAsta) / 192;
                                break;
                            }
                        case "128":
                            {
                                mlValue += (ouncetype * (double)valTerzaAsta) / 128;
                                break;
                            }
                    }
                }
                if (gb4.Visible)
                {
                    int valoreQuartaAsta = 0;
                    switch (cmb4.Text)
                    {
                        case "0":
                            {
                                valoreQuartaAsta = 0;
                                break;
                            }
                        case "1/8":
                            {
                                valoreQuartaAsta = 1;
                                break;
                            }
                        case "1/4":
                            {
                                valoreQuartaAsta = 2;
                                break;
                            }
                        case "3/8":
                            {
                                valoreQuartaAsta = 3;
                                break;
                            }
                        case "1/2":
                            {
                                valoreQuartaAsta = 4;
                                break;
                            }
                        case "5/8":
                            {
                                valoreQuartaAsta = 5;
                                break;
                            }
                        case "3/4":
                            {
                                valoreQuartaAsta = 6;
                                break;
                            }
                        case "7/8":
                            {
                                valoreQuartaAsta = 7;
                                break;
                            }
                        case "7/8*":
                        case "3/4*":
                            {
                                valoreQuartaAsta = 8;
                                break;
                            }
                    }
                    mlValue += ((double)valoreQuartaAsta * ouncetype) / 384d;
                }
                #endregion

                #region SECONDA ASTA
                int valSecondaAsta = Convert.ToInt32(txt2.Text);
                if (iMaxValue2 != -1)
                {
                    if (valSecondaAsta < 0 || valSecondaAsta > iMaxValue2)
                    {
                        txt2.BackColor = Color.Red;
                        return;
                    }
                    else
                    {
                        txt2.BackColor = Color.White;
                    }
                }
                double secondaAsta = 0;
                switch (gb2.Text)
                {
                    case "32":
                        {
                            secondaAsta = 32d;
                            break;
                        }
                    case "48":
                        {
                            secondaAsta = 48d;
                            break;
                        }
                    case "96":
                        {
                            secondaAsta = 96d;
                            break;
                        }
                    case "192":
                        {
                            secondaAsta = 192d;
                            break;
                        }
                    case "384":
                        {
                            secondaAsta = 384d;
                            break;
                        }
                }
                mlValue += (ouncetype * (double)valSecondaAsta) / secondaAsta;
                #endregion

                #region PRIMA ASTA
                int valPrimaAsta = Convert.ToInt32(txt1.Text);
                mlValue += ((double)valPrimaAsta) * ouncetype;
                #endregion

                mlOut = mlValue;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
