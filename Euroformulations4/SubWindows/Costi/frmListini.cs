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

namespace Euroformulations4.SubWindows.Costi
{
    public enum eListinoStato
    {
        inserimento = 0,
        aggiornamento = 1
    }
    public partial class frmListini : Form
    {
        private Library.Data.Database.DBConnector db;
        private Language lang = Language.GetInstance();
        public int id_listino_modifica;
        private eListinoStato stato = eListinoStato.inserimento;

        public frmListini()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        private void frmListini_Load(object sender, EventArgs e)
        {
            groupBox1.Text = lang.GetWord("cost20");
            label1.Text = lang.GetWord("cost21");
            label2.Text = lang.GetWord("cost22");
            btnSave.Text = lang.GetWord("cost23");
            groupBox2.Text = lang.GetWord("cost24");
            exportToExcelToolStripMenuItem.Text = lang.GetWord("cost35");
            importToExcelToolStripMenuItem.Text = lang.GetWord("cost36");
            updatePriceListToolStripMenuItem.Text = lang.GetWord("cost34");
            deletePriceListToolStripMenuItem.Text = lang.GetWord("cost25");
            btnCopy.Text = lang.GetWord("copy01");
            groupBox3.Text = lang.GetWord("copy01");

            ToolTip toolTipSelected = new ToolTip();
            toolTipSelected.SetToolTip(this.lstPriceList, lang.GetWord("cost33"));
            toolTipSelected.SetToolTip(this.pbHelp, lang.GetWord("cost38"));
            exportToExcelToolStripMenuItem.Enabled = false;
            importToExcelToolStripMenuItem.Enabled = false;
            updatePriceListToolStripMenuItem.Enabled = false;
            deletePriceListToolStripMenuItem.Enabled = false;

            string sQuery = "SELECT id_list, nome_listino FROM listino ORDER BY id_list LIMIT 1";
            if (GVar.attivazioni.Act_ListiniUnlimited)
            {
                sQuery = "SELECT id_list, nome_listino FROM listino ORDER BY nome_listino";
            }

            DataTable dt = db.SQLQuerySelect(sQuery);
            foreach (DataRow dr in dt.Rows)
            {
                lstPriceList.Items.Add(new CustomItem(Convert.ToInt32(dr["id_list"]), dr["nome_listino"].ToString()));
            }

        }

        private void frmListini_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.CloseConnection();
        }

        private void SalvaPriceList_Click(object sender, EventArgs e)
        {
            try
            {
                if (stato == eListinoStato.inserimento)
                {
                    DataTable dt = db.SQLQuerySelect("SELECT COUNT(id_list) as nlistini FROM listino");
                    int nlistini = Convert.ToInt32(dt.Rows[0]["nlistini"]);

                    if (txtPriceList.Text.Trim() == "") { return; }

                    if (!GVar.attivazioni.Act_ListiniUnlimited && nlistini >= 1) { throw new Exception("Price list Full"); }

                    Dictionary<string, string> dicData = new Dictionary<string, string>();
                    dicData.Add("nome_listino", "'" + txtPriceList.Text + "'");
                    dicData.Add("valuta", "'" + txtValuta.Text + "'");
                    object oIDListino = db.QueryInsert("listino", dicData, "id_list");

                    if (db.LastQueryError != "") { throw new Exception(lang.GetWord("cost29")); }

                    int ID_New_Listino = Convert.ToInt32(oIDListino);

                    foreach (var pair in GVar.ListaPigmenti)
                    {
                        string[] ListaPig = pair.Key.ToString().Split('/');
                        dicData = new Dictionary<string, string>();
                        dicData.Add("nome_pigmento", "'" + ListaPig[0] + "'");
                        dicData.Add("id_listino", ID_New_Listino.ToString());
                        dicData.Add("unita", "'L'");
                        dicData.Add("costo", "0");
                        db.QueryInsert("pig_costi", dicData);
                    }

                    for (int i = 0; i < GVar.ListaBasi.Count; i++)
                    {
                        dicData = new Dictionary<string, string>();
                        dicData.Add("nome_base", "'" + GVar.ListaBasi[i].ToString() + "'");
                        dicData.Add("id_listino", ID_New_Listino.ToString());
                        dicData.Add("unita_base", "L");
                        dicData.Add("costo_base", "0");
                        db.QueryInsert("base_costi", dicData);
                    }


                    MessageBox.Show(lang.GetWord("cost26") + " " + txtPriceList.Text + " " + lang.GetWord("cost27"), lang.GetWord("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstPriceList.Items.Add(new CustomItem(ID_New_Listino, txtPriceList.Text));
                    txtPriceList.Text = "";

                }
                else
                {
                    Dictionary<string, object> dicData = new Dictionary<string, object>();
                    dicData.Add("nome_listino", txtPriceList.Text);
                    db.QueryUpdate("listino", dicData, "id_list = " + id_listino_modifica);
                    btnSave.Text = lang.GetWord("cost23");
                    stato = eListinoStato.inserimento;
                    lstPriceList.Items.Add(new CustomItem(id_listino_modifica, txtPriceList.Text));
                    btnSave.Text = lang.GetWord("cost23");
                    txtPriceList.Text = "";
                    MessageBox.Show(lang.GetWord("cost32"), lang.GetWord("cost32"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void ListPriceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPriceList.SelectedItems.Count == 0) return;

            exportToExcelToolStripMenuItem.Enabled = true;
            importToExcelToolStripMenuItem.Enabled = true;
            updatePriceListToolStripMenuItem.Enabled = true;
            deletePriceListToolStripMenuItem.Enabled = true;
        }
        

        private void deletePriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CustomItem ci = (CustomItem)lstPriceList.SelectedItem;
                int IDListino = ci.id;

                DialogResult dialogResult = MessageBox.Show(lang.GetWord("cost18") + " " + ci.name + "?", lang.GetWord("cost30"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) { return; }

                //rimozione da db
                db.QueryDelete("listino", "id_list = " + IDListino);
                db.QueryDelete("base_costi", "id_listino = " + IDListino);
                db.QueryDelete("lattaggi", "id_listino = " + IDListino);
                db.QueryDelete("pig_costi", "id_listino = " + IDListino);
                Dictionary<string, object> dicData = new Dictionary<string, object>();
                dicData.Add("idlistino", Library.Data.Database.DBConnector.eSpecialValue.NULL);
                db.QueryUpdate("clienti", dicData, "idlistino = " + IDListino);

                //rimozione grafica
                lstPriceList.Items.Remove(ci);

                //rimozione da settings
                Library.Data.DBSettings settings = new Library.Data.DBSettings();
                string sIDListinoDefault = settings.GetValue("ListinoDefault");
                if (sIDListinoDefault != "")
                {
                    int IDListinoDefault = Convert.ToInt32(sIDListinoDefault);
                    if (IDListino == IDListinoDefault)
                    {
                        settings.SetValue("ListinoDefault", "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updatePriceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CustomItem ci = (CustomItem)lstPriceList.SelectedItem;
                this.id_listino_modifica = ci.id;
                txtPriceList.Text = ci.name;
                lstPriceList.Items.Remove(ci);
                btnSave.Text = lang.GetWord("cost31");
                stato = eListinoStato.aggiornamento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyPriceList_Click(object sender, EventArgs e)
        {
            Costi.frmCopy form = new Costi.frmCopy();
            form.ShowDialog();
        }

        private class CustomItem
        {
            public int id;
            public string name;
            public CustomItem(int id, string name) { this.id = id; this.name = name; }
            public override string ToString()
            {
                return name;
            }
        }

    }
}
