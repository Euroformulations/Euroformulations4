using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Euroformulations4.Library;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Euroformulations4.SubWindows.FormulaSelection
{

    public partial class frmComplementari : Form
    {
        private Language lang = Library.Language.GetInstance();
        private Library.Data.Database.DBConnector db;
        private int idFormula;
        private bool bUseSelected = false;
        private ToolTip tp = new ToolTip();
        public int iIDSelectedColor = -1;

        public frmComplementari(int ID)
        {
            InitializeComponent();
            this.idFormula = ID;
        }

        public int IDSelectedColor
        {
            get { return iIDSelectedColor; }
        }

        private void frmComplementari_Load(object sender, EventArgs e)
        {

            db = new Library.Data.Database.DBConnector();

            this.Text = lang.GetWord("formula62");
            lblSelectProduct.Text = lang.GetWord("complementary02");
            lblSelectUse.Text = lang.GetWord("complementary03");
            lblSelectComplementary.Text = lang.GetWord("complementary04");

            string sql = "SELECT * FROM formule WHERE id = " + this.idFormula;
            DataTable dt = db.SQLQuerySelect(sql);
            DataRow dr = dt.Rows[0];
            int rl = Convert.ToInt32(dr["r"]);
            int gl = Convert.ToInt32(dr["g"]);
            int bl = Convert.ToInt32(dr["b"]);

            pl.BackColor = Color.FromArgb(rl, gl, bl);
            pRiferimento.BackColor = pl.BackColor;

            #region Init prodotti
            foreach (KeyValuePair<int, string> pair in Library.GVar.dicProducts)
            {
                ListProduct.Items.Add(new Item(pair.Key, pair.Value));
            }
            #endregion

            lblRiferimento.Text = dr["colorname"].ToString();
            lblSelezionato.Text = "";
        }

        private void ListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListProduct.Text.Length == 0) { return; }
            ListUse.Items.Clear();

            string sql = "SELECT distinct(use) as USO FROM formule WHERE system = '" + ListProduct.Text + "'";
            DataTable dt = db.SQLQuerySelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                ListUse.Items.Add(dr["USO"].ToString());
            }

            if (bUseSelected)
            {
                ListProduct.Enabled = false;
                ListUse.Enabled = false;
                SetColoriComplementari(pl1, null, 50);
                SetColoriComplementari(pl2, null, 50);
                SetColoriComplementari(pl3, null, 50);
                SetColoriComplementari(pl4, null, 50);
                SetColoriComplementari(pl5, null, 50);
                SetColoriComplementari(pl6, null, 50);
                SetColoriComplementari(pl7, null, 50);
                SetColoriComplementari(pl8, null, 50);
                SetColoriComplementari(pl9, null, 50);
                SetColoriComplementari(pl10, null, 50);
                SetColoriComplementari(pl11, null, 50);
                SetColoriComplementari(pl12, null, 50);
                ListProduct.Enabled = true;
                ListUse.Enabled = true;
            }
        }

        private void ListUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListProduct.Enabled = false;
            ListUse.Enabled = false;


            if (ListUse.Text.Length > 0)
            {
                if (bUseSelected)
                {
                    SetColoriComplementari(pl1, null, 50);
                    SetColoriComplementari(pl2, null, 50);
                    SetColoriComplementari(pl3, null, 50);
                    SetColoriComplementari(pl4, null, 50);
                    SetColoriComplementari(pl5, null, 50);
                    SetColoriComplementari(pl6, null, 50);
                    SetColoriComplementari(pl7, null, 50);
                    SetColoriComplementari(pl8, null, 50);
                    SetColoriComplementari(pl9, null, 50);
                    SetColoriComplementari(pl10, null, 50);
                    SetColoriComplementari(pl11, null, 50);
                    SetColoriComplementari(pl12, null, 50);    
                }
                this.SuspendLayout();
                bUseSelected = false;
                Harmony.HSVData hsv = Harmony.RGBtoHSV(pl.BackColor);
                SetColoriComplementari(pl1, new Harmony.HSVData() { h = hsv.h + 30, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl2, new Harmony.HSVData() { h = hsv.h + 60, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl3, new Harmony.HSVData() { h = hsv.h + 90, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl4, new Harmony.HSVData() { h = hsv.h + 120, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl5, new Harmony.HSVData() { h = hsv.h + 150, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl6, new Harmony.HSVData() { h = hsv.h + 180, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl7, new Harmony.HSVData() { h = hsv.h + 210, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl8, new Harmony.HSVData() { h = hsv.h + 240, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl9, new Harmony.HSVData() { h = hsv.h + 270, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl10, new Harmony.HSVData() { h = hsv.h + 300, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl11, new Harmony.HSVData() { h = hsv.h + 330, s = hsv.s, v = hsv.v }, 50);
                SetColoriComplementari(pl12, new Harmony.HSVData() { h = hsv.h + 350, s = hsv.s, v = hsv.v }, 50);
                this.ResumeLayout();
                bUseSelected = true;
            }

            ListProduct.Enabled = true;
            ListUse.Enabled = true;
        }

        private void panelMouseEnter(object sender, EventArgs e)
        {
            if (!bUseSelected) { return; }
            Panel p = (Panel)sender;
            pSelezionato.BackColor = p.BackColor;
            if (p.Tag != null)
            {
                lblSelezionato.Text = ((Item)p.Tag).value;
            }
        }

        private void panelMouseLeave(object sender, EventArgs e)
        {
            pSelezionato.BackColor = Color.White;
            lblSelezionato.Text = "";
        }

        private void PanelClick(object sender, EventArgs e)
        {
            if (!this.bUseSelected) { return; }

            Panel p = (Panel)sender;
            if (p.Tag != null)
            {
                iIDSelectedColor = ((Item)p.Tag).key;
                this.Close();
            }
        }

        private void SetColoriComplementari(Panel p, object oHSV, int lSleep)
        {
            if (oHSV != null)
            {
                p.MouseClick += new MouseEventHandler(PanelClick);
                p.MouseEnter += new EventHandler(panelMouseEnter);
                p.MouseLeave += new EventHandler(panelMouseLeave);

                Harmony.HSVData HSV = (Harmony.HSVData)oHSV;

                Item selProduct = (Item)ListProduct.SelectedItem;
                List<int> filtroProdotto = new List<int> { selProduct.key };

                RicercaColore ricerca = new RicercaColore();
                ricerca.Preset_RGB(Harmony.ConvertHsvToRgb(HSV.h, HSV.s, HSV.v).R, Harmony.ConvertHsvToRgb(HSV.h, HSV.s, HSV.v).G, Harmony.ConvertHsvToRgb(HSV.h, HSV.s, HSV.v).B);
                ricerca.Filter_Products = filtroProdotto;
                if (ListUse.Text.Trim() == "INTERIOR")
                {
                    ricerca.Filter_Interior = true;
                }
                else
                {
                    if (ListUse.Text.Trim() == "EXTERIOR")
                    {
                        ricerca.Filter_Interior = false;
                    }
                }
                SortedDictionary<double, int> output = ricerca.ColorSearchExecute();

                int indexColor = output[output.ElementAt(0).Key];
                Colore c = Library.GVar.lstColoriFull[indexColor];
                tp.SetToolTip(p, GVar.dicColorcharts[c.CodCartellaColori] + " " + c.Nome);


                p.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(c.R), Convert.ToInt32(c.G), Convert.ToInt32(c.B));
                p.Tag = new Item(c.ID, c.Nome);
            }
            else
            {
                p.MouseClick -= new MouseEventHandler(PanelClick);
                p.MouseEnter -= new EventHandler(panelMouseEnter);
                p.MouseLeave -= new EventHandler(panelMouseLeave);
                tp.SetToolTip(p, "");
                p.BackColor = Color.White;
                p.Tag = null;
            }

            Application.DoEvents();
            System.Threading.Thread.Sleep(lSleep);
        }

        private void frmComplementari_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.CloseConnection();
        }

        class Item
        {
            public int key;
            public string value;

            public Item(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
            public override string ToString()
            {
                return value;
            }

        }
    }
}
