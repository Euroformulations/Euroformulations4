using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Euroformulations4.SubWindows.ColorSearch
{
    public partial class frmGetColor : Form
    {
        private Library.Language lang = Library.Language.GetInstance();
        Library.Data.Dispositivi.DispositivoBase dispositivo;
        private double _CIEL = 0;
        private double _CIEa = 0;
        private double _CIEb = 0;
        private List<double> lstL = new List<double>();
        private List<double> lstA = new List<double>();
        private List<double> lstB = new List<double>();
        private bool bLetturaEseguita = false;
        private Dispatcher dispa = Dispatcher.CurrentDispatcher;
        private Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
        public frmGetColor()
        {
            InitializeComponent();
        }

        #region PROPERTIES
        public double CIEL
        {
            get { return _CIEL; }
        }
        public double CIEa
        {
            get { return _CIEa; }
        }
        public double CIEb
        {
            get { return _CIEb; }
        }
        public bool LetturaEseguita
        {
            get { return bLetturaEseguita; }
        }
        #endregion

        private void frmGetColor_Load(object sender, EventArgs e)
        {
            try
            {
                //traduzioni
                this.Text = lang.GetWord("device05");
                btnRead.Text = lang.GetWord("device06");
                

                Library.Data.Dispositivi.eLetturaTipo tipoLettura = Library.Data.Dispositivi.eLetturaTipo.Singola;
                if (Library.GVar.attivazioni.Act_ColorSearch || Library.GVar.attivazioni.Act_QualityControl)
                {
                    tipoLettura = (Library.Data.Dispositivi.eLetturaTipo)Convert.ToInt32(sharedSettings.GetValue("DeviceReadType"));
                }

                if (tipoLettura == Library.Data.Dispositivi.eLetturaTipo.Singola)
                {
                    gbCurrent.Visible = false;
                    gbAverage.Visible = false;
                    lblCounter.Visible = false;
                    btnEnd.Visible = false;
                }
                else
                {
                    gbCurrent.Text = lang.GetWord("device13");
                    gbAverage.Text = lang.GetWord("device14");
                    btnEnd.Text = lang.GetWord("device15");
                    lblCounter.Text = "# 0";
                }

                this.dispositivo = Library.Data.Dispositivi.DispositiviManager.GetDispositivo();
                dispositivo.DatiRicevuti += new Library.Data.Dispositivi.DispositivoBase.DatiRicevutiEventHandler(ColorReceived);
                dispositivo.ErroreDispositivo += new Library.Data.Dispositivi.DispositivoBase.ErroreDispositivoEventHandler(DeviceError); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, lang.GetWord("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dispositivo.ReadRequest();
        }

        private void ColorReceived(string data)
        {
            try
            {
                this.bLetturaEseguita = true;
                string[] items = data.Split('\t');

                double l, a, b;

                if (dispositivo.ReflectanceReader)
                {
                    List<double> spettro = new List<double>();
                    for (int count = 0; count < items.Length; count++)
                    {
                        try
                        {
                            double d = Convert.ToDouble(items[count].Replace(",", "."), CultureInfo.InvariantCulture);
                            spettro.Add(d);
                        }
                        catch (Exception) { MessageBox.Show(items[count]); }
                    }
                    double[] XYZ = Library.Colore.Spectrum_XYZ(spettro);
                    XYZ[0] = XYZ[0] / 100;
                    XYZ[1] = XYZ[1] / 100;
                    XYZ[2] = XYZ[2] / 100;
                    double[] Lab = Library.Colore.XYZ_LAB(XYZ[0], XYZ[1], XYZ[2]);

                    l = Lab[0];
                    a = Lab[1];
                    b = Lab[2];

                    lstL.Add(l);
                    lstA.Add(a);
                    lstB.Add(b);
                }
                else
                {
                    l = Convert.ToDouble(items[0].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    a = Convert.ToDouble(items[1].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    b = Convert.ToDouble(items[2].ToString().Replace(",", "."), CultureInfo.InvariantCulture);

                    lstL.Add(l);
                    lstA.Add(a);
                    lstB.Add(b);
                }

                //calcolo valore medio
                double totL = 0, totA = 0, totB = 0;
                int i = 0;
                while (i < lstL.Count)
                {
                    totL += lstL.ElementAt(i);
                    totA += lstA.ElementAt(i);
                    totB += lstB.ElementAt(i);

                    i++;
                }
                this._CIEL = totL / (int)i;
                this._CIEa = totA / (int)i;
                this._CIEb = totB / (int)i;
                
                Library.Data.Dispositivi.eLetturaTipo tipoLettura = (Library.Data.Dispositivi.eLetturaTipo)Convert.ToInt32(sharedSettings.GetValue("DeviceReadType"));
                if (tipoLettura == Library.Data.Dispositivi.eLetturaTipo.Singola)
                {
                    dispa.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                    {
                        this.Close();
                    }));
                }
                else
                {
                    dispa.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                    {
                        lblCounter.Text = "# " + lstL.Count.ToString();
                        
                        lblL.Text = "CIEL*: " + this._CIEL.ToString("0.00");
                        lblA.Text = "CIEa*: " + this._CIEa.ToString("0.00");
                        lblB.Text = "CIEb*: " + this._CIEb.ToString("0.00");
                        lblLCurrent.Text = "CIEL*: " + l.ToString("0.00");
                        lblACurrent.Text = "CIEa*: " + a.ToString("0.00");
                        lblBCurrent.Text = "CIEb*: " + b.ToString("0.00");

                        double[] xyz = Library.Colore.LAB_XYZ(this._CIEL, this.CIEa, this.CIEb);
                        double[] rgb = Library.Colore.XYZ_RGB(xyz[0], xyz[1], xyz[2]);
                        panPreview.BackColor = System.Drawing.Color.FromArgb((int)rgb[0], (int)rgb[1], (int)rgb[2]);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeviceError(string error)
        {
            MessageBox.Show(error, lang.GetWord("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmGetColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                dispositivo.DatiRicevuti -= new Library.Data.Dispositivi.DispositivoBase.DatiRicevutiEventHandler(ColorReceived);
                dispositivo.ErroreDispositivo -= new Library.Data.Dispositivi.DispositivoBase.ErroreDispositivoEventHandler(DeviceError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, lang.GetWord("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
