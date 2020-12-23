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

namespace Euroformulations4.SubWindows.Qualita
{
    public partial class frmQualitaColori : Form
    {
        private Library.Data.Database.DBConnector db;
        private static Language lang = Language.GetInstance();
        private Colore _ColoreSelezionato = null;
        private int _IDColoreSelezionato = -1;
        private Colore _ColoreReturned = null;
        public int _IDColoreReturned = -1;
        private Dictionary<string, TreeNode> dicNodi = new Dictionary<string, TreeNode>();
        private bool READ_MODE = false; //else: write
        private bool bColorSaved = false;

        //constructor for READ MODE
        public frmQualitaColori()
        {
            InitializeComponent();

            db = new Library.Data.Database.DBConnector();
            LoadTWColori();
            READ_MODE = true;
            this.lblTitolo.Text = lang.GetWord("quality37");
            ColorChanged(null, "");
            btnEsegui.Text = lang.GetWord("confirm");
            this.menuTW.Items.Clear();
        }

        //constructor for WRITE MODE
        public frmQualitaColori(Colore c)
        {
            InitializeComponent();

            db = new Library.Data.Database.DBConnector();
            LoadTWColori("");
            this.lblTitolo.Text = lang.GetWord("quality38");
            btnSearch.Enabled = false;
            ColorChanged(c, lang.GetWord("quality39"));
            btnEsegui.Text = lang.GetWord("save");
            this.menuTW.Items.Clear();
        }

        #region PROPERTIES
        public Colore ColoreReturned
        {
            get { return _ColoreReturned; }
        }
        public int IDColoreReturned
        {
            get { return _IDColoreReturned; }
        }
        public bool ColorSaved
        {
            get { return bColorSaved; }
        }
        #endregion

        #region BUTTON LAYOUT
        private void ButtonMouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = null;
            btn.BackColor = System.Drawing.Color.LightGray;
        }
        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Euroformulations4.Properties.Resources.button_content_lightblu;
            btn.BackColor = System.Drawing.Color.Transparent;
        }
        private void SubButtonMouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = Euroformulations4.Properties.Resources.button_orange;
            btn.BackColor = System.Drawing.Color.Transparent;
        }
        #endregion

        #region BUTTON CLICK
        private void btnExpand_Click(object sender, EventArgs e)
        {
            twColori.ExpandAll();
            twColori.TopNode = dicNodi["F_-1"];
        }
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            twColori.CollapseAll();
        }
        private void btnEsegui_Click(object sender, EventArgs e)
        {
            try
            {
                if (READ_MODE)
                {
                    if (_ColoreSelezionato == null) throw new Exception(lang.GetWord("quality46"));
                    this._ColoreReturned = this._ColoreSelezionato;
                    this._IDColoreReturned = this._IDColoreSelezionato;
                    this.Close();
                }
                else
                {
                    //scrittura
                    if (_ColoreSelezionato == null) throw new Exception(lang.GetWord("quality47"));
                    TreeNode nodoSelected = twColori.SelectedNode;
                    if (nodoSelected == null) throw new Exception(lang.GetWord("quality48"));
                    if (!nodoSelected.Name.StartsWith("F")) throw new Exception(lang.GetWord("quality48"));
                    string name = Microsoft.VisualBasic.Interaction.InputBox(lang.GetWord("quality50"), lang.GetWord("quality49"), "", -1, -1);
                    if (name == "") throw new Exception(lang.GetWord("quality51"));
                    string sIDFolder = nodoSelected.Name.Substring(2);

                    //insert data
                    Dictionary<string, string> data = new Dictionary<string, string>()
                    {
                        {"nome_colore", "'" + name + "'"},
                        {"x", _ColoreSelezionato.X.ToString().Replace(",", ".")},
                        {"y", _ColoreSelezionato.Y.ToString().Replace(",", ".")},
                        {"z", _ColoreSelezionato.Z.ToString().Replace(",", ".")},
                        {"l", _ColoreSelezionato.CIEL.ToString().Replace(",", ".")},
                        {"a", _ColoreSelezionato.CIEa.ToString().Replace(",", ".")},
                        {"b", _ColoreSelezionato.CIEb.ToString().Replace(",", ".")},
                        {"cod_dir", sIDFolder}
                    };
                    
                    object res = db.QueryInsert("sqc_color", data, "idcolore");
                    bColorSaved = true;

                    if (res != null)
                    {
                        if (!dicNodi.ContainsKey("C_" + res.ToString()))
                        {
                            TreeNode node = new TreeNode(name, 0, 0) { Name = "C_" + res.ToString() };
                            nodoSelected.Nodes.Add(node);
                            dicNodi.Add("C_" + res.ToString(), node);
                            twColori.Update();
                            twColori.SelectedNode = node;
                            twColori.Focus();
                        }
                        this._IDColoreReturned = Convert.ToInt32(res.ToString());
                    }

                    //disable this button
                    btnEsegui.Enabled = false;
                    btnSearch.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtCercaColore.Text.Trim();
            if (text == "") return;
            foreach (KeyValuePair<string, TreeNode> pair in dicNodi)
            {
                if (pair.Value.Text.Contains(text))
                {
                    twColori.CollapseAll();
                    pair.Value.Expand();
                    twColori.SelectedNode = pair.Value;
                    twColori.Focus();
                    return;
                }
            }
        }
        #endregion

        #region KEY PRESS
        private void txtCercaColore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            btnSearch_Click(null, null);
        }
        private void twColori_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            TreeNode node = twColori.SelectedNode;
            if (node == null) return;
            if (node.Name.StartsWith("F_"))
            {
                //folder
                if (node.IsExpanded)
                    node.Collapse();
                else
                    node.Expand();
            }
            else
            {
                //color
                if (!btnEsegui.Enabled) return;
                btnEsegui_Click(null, null);
            }
        }
        #endregion

        #region TOOLSTRIP MENU
        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                TreeNode nodo = twColori.SelectedNode;
                if (nodo == null) return;

                TreeNode parent = nodo.Parent;
                if (parent != null)
                {
                    if (parent.Parent != null)
                    {
                        throw new Exception(lang.GetWord("quality52"));
                    }
                }


                //if (parent == null) parent = dicNodi["F_-1"];
                if (!nodo.Name.StartsWith("F_")) throw new Exception(lang.GetWord("quality53"));
                string sIDParentFolder = nodo.Name.Substring(2);

                string name = Microsoft.VisualBasic.Interaction.InputBox(lang.GetWord("quality55"), lang.GetWord("quality54"), "", -1, -1);
                if (name.Trim() == "") throw new Exception(lang.GetWord("quality56"));
                name = name.Trim();

                Dictionary<string, string> data = new Dictionary<string, string>() 
                { 
                    {"idparent", sIDParentFolder},
                    {"nomedir", "'" + name + "'"}
                };

                object res = db.QueryInsert("sqc_dir", data, "iddir");

                if (res != null)
                {
                    if (!dicNodi.ContainsKey("F_" + res.ToString()))
                    {
                        TreeNode node = new TreeNode(name, 1, 1) { Name = "F_" + res.ToString() };
                        nodo.Nodes.Add(node);
                        dicNodi.Add("F_" + res.ToString(), node);
                        twColori.Update();
                        twColori.SelectedNode = node;
                        twColori.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ": " + query);
            }
        }
        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode nodo = twColori.SelectedNode;
                if (nodo == null) throw new Exception(lang.GetWord("quality57"));
                DeleteItem("F", nodo.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode nodo = twColori.SelectedNode;
                if (nodo == null) throw new Exception(lang.GetWord("quality58"));
                DeleteItem("C", nodo.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteItem(string requestType, string nodeName)
        {
            try
            {
                if (requestType == "F" && nodeName.StartsWith("C_")) throw new Exception(lang.GetWord("quality57"));
                if (requestType == "C" && nodeName.StartsWith("F_")) throw new Exception(lang.GetWord("quality58"));

                string message = lang.GetWord("quality59");
                if (requestType == "C") message = lang.GetWord("quality60");
                DialogResult dialogResult = MessageBox.Show(message, lang.GetWord("quality61"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                //yes
                string IDRecord = nodeName.Substring(2);
                if (requestType == "C")
                {
                    db.QueryDelete("sqc_color", "idcolore = " + IDRecord);
                }
                else
                {
                    bool result = DeleteFolderAndSubs(IDRecord);
                    if (!result) MessageBox.Show(lang.GetWord("quality62"));
                }

                twColori.Nodes.Remove(dicNodi[nodeName]);
                dicNodi.Remove(nodeName);
                twColori.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool DeleteFolderAndSubs(string sIDFolder, bool rimozione_ricorsiva = false)
        {
            try
            {
                //base
                if (sIDFolder == "-1" || sIDFolder == "-2") return true;

                bool bResult = true;

                //delete Sub-Folder
                List<string> directory = new List<string>();
                string sql = "SELECT iddir FROM sqc_dir WHERE idparent = " + sIDFolder;
                DataTable dt = db.SQLQuerySelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    directory.Add(dr["iddir"].ToString());
                }
                
                foreach (string dir in directory)
                {
                    bResult = bResult && DeleteFolderAndSubs(dir, true);
                }

                //delete colors of that folder
                sql = "SELECT idcolore FROM sqc_color WHERE cod_dir = " + sIDFolder;
                dt = db.SQLQuerySelect(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    dicNodi.Remove("C_" + dr["idcolore"].ToString());
                }

                db.QueryDelete("sqc_color", "cod_dir = " + sIDFolder);

                //delete current folder
                db.QueryDelete("sqc_dir", "iddir = " + sIDFolder);

                if(rimozione_ricorsiva) dicNodi.Remove("F_" + sIDFolder);

                return bResult;
            }catch(Exception)
            {
                return false;
            }
        }
        #endregion

        #region TREEVIEW MANAGEMENT
        private void LoadTWColori(string preSelectedColor = "", bool showColors = true)
        {
            try
            {
                twColori.Nodes.Clear();
                dicNodi = new Dictionary<string, TreeNode>();

                //lettura nodo root
                string sql = "SELECT * FROM sqc_dir WHERE iddir = -1";
                DataTable dt = db.SQLQuerySelect(sql);


                if (dt.Rows.Count == 0)
                {
                    Dictionary<string, string> data = new Dictionary<string,string>();
                    data.Add("iddir", "-1");
                    data.Add("idparent", "-2");
                    data.Add("nomedir", "'ROOT'");
                    db.QueryInsert("sqc_dir", data);
                }

                TreeNode preSelectedNode = null;
                TreeNode nodeRoot = new TreeNode(lang.GetWord("quality40"), 2, 2) { Name = "F_-1" };
                dicNodi.Add("F_-1", nodeRoot);
                nodeRoot.ImageIndex = 2;

                sql = "SELECT * FROM sqc_dir LEFT OUTER JOIN sqc_color ON cod_dir = iddir ORDER BY idparent, nomedir, nome_colore";
                dt = db.SQLQuerySelect(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        //process folder
                        int IDCartella = Convert.ToInt32(dr["iddir"].ToString());
                        string nomeCartella = dr["nomedir"].ToString();
                        string sParent = dr["idparent"].ToString().Trim();
                        if (!dicNodi.ContainsKey(("F_" + IDCartella.ToString())))
                        {
                            TreeNode node = new TreeNode(nomeCartella, 1, 1) { Name = "F_" + IDCartella.ToString() };
                            //node.ImageIndex = 1;
                            dicNodi.Add("F_" + IDCartella.ToString(), node);
                            if (sParent == "-1")
                            {
                                nodeRoot.Nodes.Add(node);
                            }
                            else
                            {
                                if (dicNodi.ContainsKey("F_" + sParent))
                                {
                                    dicNodi["F_" + sParent].Nodes.Add(node);
                                }
                            }
                        }

                        if (showColors)
                        {
                            TreeNode nodoFolder = dicNodi["F_" + IDCartella.ToString()];

                            //process colore
                            string sIDColore = dr["idcolore"].ToString().Trim();
                            if (sIDColore != "")
                            {
                                TreeNode node = new TreeNode(dr["nome_colore"].ToString(), 0, 0) { Name = "C_" + sIDColore };
                                if (preSelectedColor != "" && node.Text == preSelectedColor)
                                {
                                    preSelectedNode = node;
                                }
                                //node.ImageIndex = 0;
                                dicNodi.Add("C_" + sIDColore, node);
                                nodoFolder.Nodes.Add(node);
                            }
                        }


                    }
                    catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
                }

                twColori.Nodes.Add(nodeRoot);

                twColori.ExpandAll();

                foreach (TreeNode tn in nodeRoot.Nodes)
                {
                    tn.Collapse();
                }

                if (preSelectedNode != null)
                {
                    twColori.CollapseAll();
                    preSelectedNode.Expand();
                    twColori.SelectedNode = preSelectedNode;
                    twColori.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NodeSelected(object sender, TreeViewEventArgs e)
        {
            if (READ_MODE || (!READ_MODE && !btnEsegui.Enabled))
            {
                try
                {
                    TreeNode node = e.Node;
                    if (!e.Node.Name.StartsWith("C"))
                    {
                        ColorChanged(null, lang.GetWord("quality47"));
                        return;
                    }
                    string sIDColore = node.Name.Substring(2);

                    string sql = "SELECT * FROM sqc_color WHERE idcolore = " + sIDColore;
                    DataTable dt = db.SQLQuerySelect(sql);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        double x = Convert.ToDouble(dr["x"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        double y = Convert.ToDouble(dr["y"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        double z = Convert.ToDouble(dr["z"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                        double l = Convert.ToDouble(dr["l"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        double a = Convert.ToDouble(dr["a"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                        double b = Convert.ToDouble(dr["b"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                        this._IDColoreSelezionato = Convert.ToInt32(sIDColore);
                        ColorChanged(new Colore(Convert.ToInt32(sIDColore), node.Text, l, a, b, x, y, z), node.Text);
                    }
                    else
                    {
                        _ColoreSelezionato = null;
                    }
                }
                catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }

            }
        }
        private void nodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            twColori.SelectedNode = node;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            this.menuTW.Items.Clear();
            if (node.Name.StartsWith("F_"))
            {
                //folder
                if (node.Name != "F_-1")
                {
                    this.menuTW.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.newFolderToolStripMenuItem,
                    this.deleteFolderToolStripMenuItem});
                }
                else
                {
                    this.menuTW.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.newFolderToolStripMenuItem});
                }
            }
            else
            { 
                if (node.Name.StartsWith("C_"))
                {
                    //color
                    this.menuTW.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.deleteColorToolStripMenuItem});
                }
            }
        }
        private void nodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!READ_MODE) return;
            try
            {
                TreeNode node = e.Node;
                if (!e.Node.Name.StartsWith("C"))
                {
                    ColorChanged(null, lang.GetWord("quality47"));
                    return;
                }

                string sIDColore = node.Name.Substring(2);

                string sql = "SELECT * FROM sqc_color WHERE idcolore = " + sIDColore;
                DataTable dt = db.SQLQuerySelect(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    double x = Convert.ToDouble(dr["x"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    double y = Convert.ToDouble(dr["y"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    double z = Convert.ToDouble(dr["z"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                    double l = Convert.ToDouble(dr["l"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    double a = Convert.ToDouble(dr["a"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    double b = Convert.ToDouble(dr["b"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                    _ColoreSelezionato = new Colore(Convert.ToInt32(sIDColore), node.Text, l, a, b, x, y, z);
                    this._IDColoreSelezionato = Convert.ToInt32(sIDColore);
                }
                else
                {
                    _ColoreSelezionato = null;
                }
                btnEsegui_Click(null, null);
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }
        private void menuTW_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.menuTW.Items.Clear();
        }
        #endregion

        private void ColorChanged(Colore c, string labelSelectedColor_Value)
        {
            try
            {
                lblSelectedColor.Text = labelSelectedColor_Value;
                this._ColoreSelezionato = c;

                if (c == null)
                {
                    panColor.BackColor = Color.Transparent;
                    lblR.Text = "R : ";
                    lblG.Text = "G : ";
                    lblB.Text = "B : ";
                    lblCIEL.Text = "L* : ";
                    lblCIEa.Text = "a* : ";
                    lblCIEb.Text = "b* : ";
                    lblX.Text = "X* : ";
                    lblY.Text = "Y* : ";
                    lblZ.Text = "Z* : ";
                    lblC.Text = "C* : ";
                    lblh.Text = "h : ";
                    lblCIEL2.Text = lblCIEL.Text;
                }
                else
                {
                    double[] rgb = Library.Colore.XYZ_RGB(c.X, c.Y, c.Z);
                    lblR.Text = "R : " + Convert.ToInt32(rgb[0]);
                    lblG.Text = "G : " + Convert.ToInt32(rgb[1]);
                    lblB.Text = "B : " + Convert.ToInt32(rgb[2]);
                    lblCIEL.Text = "L* : " + c.CIEL.ToString("0.00");
                    lblCIEa.Text = "a* : " + c.CIEa.ToString("0.00");
                    lblCIEb.Text = "b* : " + c.CIEb.ToString("0.00");
                    lblX.Text = "X* : " + c.X.ToString("0.00");
                    lblY.Text = "Y* : " + c.Y.ToString("0.00");
                    lblZ.Text = "Z* : " + c.Z.ToString("0.00");
                    lblC.Text = "C* : " + c.C.ToString("0.00");
                    lblh.Text = "h : " + c.H.ToString("0.00");
                    lblCIEL2.Text = lblCIEL.Text;

                    panColor.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQualitaColori_Load(object sender, EventArgs e)
        {
            groupBox3.Text = lang.GetWord("quality40");
            label1.Text = lang.GetWord("quality41");
            btnSearch.Text = lang.GetWord("quality42");
            btnExpand.Text = lang.GetWord("quality43");
            btnCollapse.Text = lang.GetWord("quality44");
            groupBox1.Text = lang.GetWord("quality45");
            btnEsegui.Text = lang.GetWord("confirm");
            btnBackup.Text = lang.GetWord("quality73");
            btnRestore.Text = lang.GetWord("quality74");
            groupBox4.Text = lang.GetWord("quality73") + " / " + lang.GetWord("quality74");
        }

        private void frmQualitaColori_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception)
            {
                //LOG HERE
            }
        }
        
    }
}
