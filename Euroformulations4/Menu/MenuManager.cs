using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Euroformulations4.Library;
using System.Windows.Threading;

namespace Euroformulations4.Menu
{
    public class MenuManager
    {
        private static Library.Language lang = Library.Language.GetInstance();

        #region CONFIG attributes
        private System.Drawing.Color colorMenuMouseEnter = System.Drawing.Color.White;
        private System.Drawing.Color colorMenuSelected = System.Drawing.Color.FromArgb(160, 215, 243);
        private int XLocation = 5;
        private int YLocation = 2;
        #endregion

        #region DATA attributes
        private Dictionary<string, ButtonInfo> dicKeySuperButton = new Dictionary<string, ButtonInfo>();

        private ButtonInfo currentButton = null;
        private ButtonInfo currentBigButton = null;

        private Dictionary<Panel, string> dicPanIndex = new Dictionary<Panel, string>();
        private Dictionary<Label, string> dicLabelIndex = new Dictionary<Label, string>();
        private Dictionary<PictureBox, string> dicPicIndex = new Dictionary<PictureBox, string>();
        private Dictionary<string, ButtonInfo> dicKeyFunctionButton = new Dictionary<string, ButtonInfo>();
        private List<ButtonInfo> lstAnimatedButton = new List<ButtonInfo>();
        private Euroformulations4.Library.AnimationMenuManager AnimationManager = new Library.AnimationMenuManager();
        private ButtonInfo bFormulation;
        private ButtonInfo subColorSearch = null;
        
        private Euroformulations4.SubWindows.WindowMain.frmEuroFormulationsNew frmGUI = null;
        private ToolTip tp = new ToolTip();
        private Dispatcher disp = Dispatcher.CurrentDispatcher;
        #endregion

        public MenuManager(Euroformulations4.SubWindows.WindowMain.frmEuroFormulationsNew frmGUI, bool bAdminMode) 
        {
            this.frmGUI = frmGUI;

            bFormulation = new ButtonInfo(lang.GetWord("menu27"), Properties.Resources.paint88, GVar.attivazioni.Act_Basics, "0", lang.GetWord("Formulation_menu"), lang.GetWord("menu_deactivated"));
            bFormulation.Add(new ButtonInfo(lang.GetWord("menu22"), Properties.Resources.list_1, GVar.attivazioni.Act_Basics, "formulaclassic", lang.GetWord("Insert New Formula_menu"), lang.GetWord("menu_deactivated")));
            bFormulation.Add(new ButtonInfo(lang.GetWord("menu23"), Properties.Resources.magnifier52, GVar.attivazioni.Act_Basics, "formulasearch", lang.GetWord("Insert New Formula_menu"), lang.GetWord("menu_deactivated")));
            bFormulation.Add(new ButtonInfo(lang.GetWord("menu24"), Properties.Resources.wall_clock, GVar.attivazioni.Act_Basics && GVar.attivazioni.Act_History, "formulahistory", lang.GetWord("Insert New Formula_menu"), lang.GetWord("menu_deactivated")));
            
            ButtonInfo b2 = new ButtonInfo(lang.GetWord("menu02"), Properties.Resources.documents7, GVar.attivazioni.Act_PersonalFormula, "2", lang.GetWord("Personal Formula_menu"), lang.GetWord("menu_deactivated"));
                b2.Add(new ButtonInfo(lang.GetWord("menu25"), Properties.Resources.archive44, GVar.attivazioni.Act_PersonalFormula, "nuovaformula", lang.GetWord("Insert New Formula_menu"), lang.GetWord("menu_deactivated")));
                b2.Add(new ButtonInfo(lang.GetWord("menu04"), Properties.Resources.rectangular4, GVar.attivazioni.Act_PersonalFormula, "viewformula", lang.GetWord("View Personal Formulas_menu"), lang.GetWord("menu_deactivated")));
                b2.Add(new ButtonInfo("Erogazione Libera", Properties.Resources.CMYK, true, "eroga", lang.GetWord("View Personal Formulas_menu"), lang.GetWord("menu_deactivated")));
            ButtonInfo b3 = new ButtonInfo("MyQuality", Properties.Resources.choosing, GVar.attivazioni.Act_QualityControl, "4", lang.GetWord("MyQuality_menu"), lang.GetWord("menu_deactivated"));
                b3.Add(new ButtonInfo(lang.GetWord("menu06"), Properties.Resources.color8, GVar.attivazioni.Act_QualityControl, "qualita", lang.GetWord("Quality Control_menu"), lang.GetWord("menu_deactivated")));
            ButtonInfo b4 = new ButtonInfo("MySearch", Properties.Resources.magnifying_glass11, GVar.attivazioni.Act_ColorSearch || GVar.attivazioni.Act_ComplementaryColors, "6", lang.GetWord("MySearch_menu"), lang.GetWord("menu_deactivated"));
            if (GVar.attivazioni.Act_ColorSearch)
            {
                this.subColorSearch = new ButtonInfo(lang.GetWord("menu08"), Properties.Resources.wait, true, "ricercacolore", lang.GetWord("Color Search_menu"), lang.GetWord("menu_deactivated"));
                b4.Add(this.subColorSearch);
            }
            else
            {
                b4.Add(new ButtonInfo(lang.GetWord("menu08"), Properties.Resources.magnifier52, false, "ricercacolore", lang.GetWord("Color Search_menu"), lang.GetWord("menu_deactivated")));
            }
            ButtonInfo b5 = new ButtonInfo(lang.GetWord("menu09"), Properties.Resources.business12, GVar.attivazioni.Act_ClientManagement, "8", lang.GetWord("Customer_menu"), lang.GetWord("menu_deactivated"));
                b5.Add(new ButtonInfo(lang.GetWord("menu26"), Properties.Resources.archive44, GVar.attivazioni.Act_ClientManagement, "nuovocliente", lang.GetWord("New Customer_menu"), lang.GetWord("menu_deactivated")));
                b5.Add(new ButtonInfo(lang.GetWord("menu11"), Properties.Resources.rectangular4, GVar.attivazioni.Act_ClientManagement, "viewclient", lang.GetWord("View Customers_menu"), lang.GetWord("menu_deactivated")));
            ButtonInfo b6 = new ButtonInfo(lang.GetWord("menu12"), Properties.Resources.bars_graphic, GVar.attivazioni.Act_Statistics, "10", lang.GetWord("Statistics_menu"), lang.GetWord("menu_deactivated"));
            b6.Add(new ButtonInfo(lang.GetWord("stat02"), Properties.Resources.paint111, GVar.attivazioni.Act_Statistics, "statCol", lang.GetWord("Statistics_menu"), lang.GetWord("menu_deactivated")));
            b6.Add(new ButtonInfo(lang.GetWord("stat03"), Properties.Resources.paint3, GVar.attivazioni.Act_Statistics, "statBasi", lang.GetWord("Statistics_menu"), lang.GetWord("menu_deactivated")));
                b6.Add(new ButtonInfo(lang.GetWord("stat04"), Properties.Resources.color7, GVar.attivazioni.Act_Statistics, "statSpace", lang.GetWord("Statistics_menu"), lang.GetWord("menu_deactivated")));
            ButtonInfo b7 = new ButtonInfo(lang.GetWord("menu13"), Properties.Resources.coins15, GVar.attivazioni.Act_Basics, "12", lang.GetWord("Prices_menu"), lang.GetWord("menu_deactivated"));
                b7.Add(new ButtonInfo(lang.GetWord("menu14"), Properties.Resources.document238, GVar.attivazioni.Act_Basics, "listini", lang.GetWord("New Price List_menu"), lang.GetWord("menu_deactivated")));
                b7.Add(new ButtonInfo(lang.GetWord("menu15"), Properties.Resources.paint111, GVar.attivazioni.Act_Basics, "colorantcost", lang.GetWord("Colorants/Paints_menu"), lang.GetWord("menu_deactivated")));
                b7.Add(new ButtonInfo(lang.GetWord("menu16"), Properties.Resources.paint3, GVar.attivazioni.Act_Basics, "lattaggi", lang.GetWord("Packaging Size_menu"), lang.GetWord("menu_deactivated")));
            ButtonInfo b8 = new ButtonInfo(lang.GetWord("menu17"), Properties.Resources.gear39, GVar.attivazioni.Act_Basics, "14", lang.GetWord("Settings_menu"), lang.GetWord("menu_deactivated"));
                b8.Add(new ButtonInfo(lang.GetWord("menu18"), Properties.Resources.tools6, GVar.attivazioni.Act_Basics, "impostazioni", lang.GetWord("General_menu"), lang.GetWord("menu_deactivated")));
                b8.Add(new ButtonInfo(lang.GetWord("settings57"), Properties.Resources.edit5, GVar.attivazioni.Act_ColorSearch || GVar.attivazioni.Act_QualityControl, "dispositivi", lang.GetWord("devices_menu"), lang.GetWord("menu_deactivated")));
                b8.Add(new ButtonInfo(lang.GetWord("settings61"), Properties.Resources.drop18, GVar.attivazioni.Act_Basics, "macchine", lang.GetWord("machines_menu"), lang.GetWord("menu_deactivated")));
                b8.Add(new ButtonInfo(lang.GetWord("menu28"), Properties.Resources.database38_16, GVar.attivazioni.Act_Basics, "database", lang.GetWord("database_menu"), lang.GetWord("menu_deactivated")));
            //ButtonInfo b10 = new ButtonInfo("FreeDispense", Properties.Resources.magnifying_glass11,/* GVar.attivazioni.Act_FreeDispense*/true,  "18", lang.GetWord("FreeDispense_menu"), lang.GetWord("menu_deactivated"));
            //b10.Add(new ButtonInfo("Dispense", Properties.Resources.tools6,/*GVar.attivazioni.Act_FreeDispense,*/ true,"itest", lang.GetWord("FreeDispense_menu"), lang.GetWord("menu_deactivated")));

            //register main (animated) button (except formulation button)

            lstAnimatedButton.Add(bFormulation);
            lstAnimatedButton.Add(b2);
            lstAnimatedButton.Add(b3);
            lstAnimatedButton.Add(b4);
            lstAnimatedButton.Add(b5);
            lstAnimatedButton.Add(b6);
            lstAnimatedButton.Add(b7);
            //lstAnimatedButton.Add(b10);
            lstAnimatedButton.Add(b8);


            //admin
            if (bAdminMode || System.Diagnostics.Debugger.IsAttached)
            {
                ButtonInfo b9 = new ButtonInfo("Administrative Tools", Properties.Resources.users53, true, "16", "administrative tools", "");
                b9.Add(new ButtonInfo("Tools", Properties.Resources.listini, true, "ecadmin", "Tools", ""));
                lstAnimatedButton.Add(b9);
            }
        }

        public bool FormulationActivated
        {
            get { return bFormulation.Activated; }
        }

        public void LoadForSearchCompleted()
        {
            disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                if (subColorSearch != null)
                {
                    subColorSearch.Image = Properties.Resources.magnifier52;
                }
            }));
        }

        #region DRAW/SELECTION
        public void Draw(Panel p)
        {
            p.SuspendLayout();
            int index = 0;

            //draw btn Formulation
            /*SetPropertyBigButtonPanel(bFormulation, "btn;" );
            p.Controls.Add(bFormulation.Panel);
            dicKeyFunctionButton.Add(bFormulation.Key, bFormulation);
            YLocation += 10;*/

            //draw other button (all contains subPanels)
            foreach (ButtonInfo button in lstAnimatedButton)
            {
                SetPropertyBigButtonPanel(button, "srv;");
                p.Controls.Add(button.Panel);

                if (button.SubButton.Count > 0)
                {
                    Panel pContainer = new Panel();
                    SetPropertyPanelContainer(pContainer, 25 * button.SubButton.Count);
                    YLocation += 25 * button.SubButton.Count;

                    int i = 0;
                    foreach (ButtonInfo subBtn in button.SubButton)
                    {
                        Panel pbSub = new Panel();
                        SetPropertySubButtonPanel(subBtn, i);
                        pContainer.Controls.Add(subBtn.Panel);
                        dicKeyFunctionButton.Add(subBtn.Key, subBtn);
                        i++;
                    }

                    p.Controls.Add(pContainer);
                    AnimationManager.AddItem(button.Panel, pContainer);
                    index += 2;
                }
                YLocation += 10;
            }

            AnimationManager.CollapseAll();
            p.ResumeLayout();
        }
        private void SetPropertyBigButtonPanel(ButtonInfo button, string keyType)
        {
            button.BigButton = true;
            Panel pan = button.Panel;
            string key = keyType + button.Key;

            Label l = button.Label;
            l.AutoSize = true;
            l.BackColor = System.Drawing.Color.Transparent;
            if (button.Activated) 
            { 
                l.Cursor = System.Windows.Forms.Cursors.Hand; 
                l.Click += new System.EventHandler(this.ButtonLabelClick); 
            }
            l.Font = new System.Drawing.Font("Comfortaa", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.ForeColor = System.Drawing.Color.White;
            l.Location = new System.Drawing.Point(39, 9);
            l.Size = new System.Drawing.Size(104, 20);
            l.TabIndex = 1;
            l.Text = button.Name;
            dicLabelIndex.Add(l, key);
            l.MouseEnter += new EventHandler(BigButtonMouseEnter_Label);
            l.MouseLeave += new EventHandler(BigButtonMouseLeave_Label);
            if (button.Description != "") tp.SetToolTip(l, button.Description);

            PictureBox pBox = button.PictureBox;
            pBox.Image = ((System.Drawing.Image)(button.Image));
            pBox.Location = new System.Drawing.Point(6, 3);
            pBox.Size = new System.Drawing.Size(32, 32);
            pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pBox.TabIndex = 2;
            pBox.TabStop = false;
            dicPicIndex.Add(pBox, key);
            pBox.MouseEnter += new EventHandler(BigButtonMouseEnter_Picture);
            pBox.MouseLeave += new EventHandler(BigButtonMouseLeave_Picture);
            pBox.BackColor = System.Drawing.Color.Transparent;
            if (button.Description != "") tp.SetToolTip(pBox, button.Description);

            if (button.Activated)
            {
                //pan.BackColor = System.Drawing.Color.White;
                pan.BackColor = System.Drawing.Color.FromArgb(0, 171, 184);
                pBox.Click += new System.EventHandler(this.ButtonPictureClick);
            }
            else
            {
                pan.BackColor = System.Drawing.Color.FromArgb(148, 148, 148);
            }

            pan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pan.Controls.Add(pBox);
            pan.Controls.Add(l);
            if (button.Activated) 
            { 
                pan.Cursor = System.Windows.Forms.Cursors.Hand; 
                pan.Click += new System.EventHandler(this.ButtonPanelClick); 
            }
            pan.Location = new System.Drawing.Point(XLocation, YLocation);
            pan.Margin = new System.Windows.Forms.Padding(0);
            pan.Size = new System.Drawing.Size(229, 38);
            pan.TabIndex = 3;
            pan.MouseEnter += new EventHandler(BigButtonMouseEnter_Pan);
            pan.MouseLeave += new EventHandler(BigButtonMouseLeave_Pan);
            dicPanIndex.Add(pan, key);
            if (button.Description != "") tp.SetToolTip(pan, button.Description);


            dicKeySuperButton.Add(key, button);
            YLocation += 38;
        }

        private void SetPropertyPanelContainer(Panel p, int height)
        {
            p.Location = new System.Drawing.Point(XLocation + 6, YLocation);
            p.Margin = new System.Windows.Forms.Padding(0);
            p.Size = new System.Drawing.Size(209, height);
        }
        private void SetPropertySubButtonPanel(ButtonInfo button, int indexPan)
        {
            Panel panel = button.Panel;

            string key = "btn;" + button.Key;
            Label l = button.Label;
            l.AutoSize = true;
            l.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.Location = new System.Drawing.Point(44, 6);
            l.Size = new System.Drawing.Size(71, 16);
            l.Text = button.Name;
            if (button.Activated)
                l.Click += new System.EventHandler(this.ButtonLabelClick);
            else
                l.ForeColor = System.Drawing.Color.White;
            if (button.Description != "") tp.SetToolTip(l, button.Description);
            dicLabelIndex.Add(l, key);

            PictureBox pBox = button.PictureBox;
            pBox.Image = ((System.Drawing.Image)(button.Image));
            pBox.Location = new System.Drawing.Point(6, 3);
            pBox.Size = new System.Drawing.Size(16, 16);
            pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            if (button.Activated) pBox.Click += new System.EventHandler(this.ButtonPictureClick);
            if (button.Description != "") tp.SetToolTip(pBox, button.Description);
            dicPicIndex.Add(pBox, key);

            if (button.Activated)
                panel.BackColor = System.Drawing.Color.Transparent;
            else
                panel.BackColor = System.Drawing.Color.Gray;
            panel.Controls.Add(pBox);
            panel.Controls.Add(l);
            if (button.Activated) panel.Cursor = System.Windows.Forms.Cursors.Hand;
            panel.Location = new System.Drawing.Point(0, 25 * indexPan);
            panel.Margin = new System.Windows.Forms.Padding(0);
            panel.Size = new System.Drawing.Size(209, 25);
            if (button.Activated) panel.MouseEnter += new System.EventHandler(this.SubButton_MouseEnter);
            if (button.Activated) panel.MouseLeave += new System.EventHandler(this.SubButton_MouseLeave);
            if (button.Activated) panel.Click += new System.EventHandler(this.ButtonPanelClick);
            if (button.Description != "") tp.SetToolTip(panel, button.Description);
            dicPanIndex.Add(panel, key);
        }
        private void UpdateCurrentSelectedButton(string selectedKey)
        {
            ButtonInfo button = dicKeyFunctionButton[selectedKey];

            if (currentButton != null)
            {
                if (currentButton.Activated)
                {
                    //currentButton.Panel.Click += new System.EventHandler(this.ButtonPanelClick);
                    currentButton.Panel.Cursor = System.Windows.Forms.Cursors.Hand;
                    currentButton.Label.Cursor = System.Windows.Forms.Cursors.Hand;
                    //currentButton.Label.Click += new System.EventHandler(this.ButtonLabelClick);
                    //currentButton.PictureBox.Click += new System.EventHandler(this.ButtonPictureClick);
                }
                currentButton.Panel.BackColor = System.Drawing.Color.Transparent;
                /*if (currentButton.Panel == bFormulation.Panel)
                {
                    if (bFormulation.Activated)
                    {
                        currentButton.Panel.BackgroundImage = null;
                        currentButton.Panel.BackColor = System.Drawing.Color.FromArgb(0, 171, 184);
                        currentButton.Label.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        currentButton.Panel.BackColor = System.Drawing.Color.Gray;
                    }
                }
                else
                {*/
                    if (button.Activated) currentButton.Panel.MouseEnter += new System.EventHandler(this.SubButton_MouseEnter);
                    if (button.Activated) currentButton.Panel.MouseLeave += new System.EventHandler(this.SubButton_MouseLeave);
                //}
                currentButton.Selected = false;
            }

            currentButton = button;
            currentButton.Selected = true;
            /*if (currentButton.Panel == bFormulation.Panel)
            {
                if (bFormulation.Activated)
                {
                    if (this.currentBigButton != null)
                    {
                        this.currentBigButton.Selected = false;
                        this.currentBigButton = null;
                        AnimationManager.CollapseAll();
                    }
                    currentButton.Panel.BackgroundImage = null;
                    currentButton.Panel.BackColor = System.Drawing.Color.FromArgb(0, 149, 66);
                    
                }
                else
                {
                    
                }
                
            }
            else
            {*/
            currentButton.Panel.BackgroundImage = null;
            currentButton.Panel.BackColor = colorMenuSelected;
            if (button.Activated) currentButton.Panel.MouseEnter -= this.SubButton_MouseEnter;
            if (button.Activated) currentButton.Panel.MouseLeave -= this.SubButton_MouseLeave;
            //}
            //button.Panel.Click -= this.ButtonPanelClick;
            //button.Panel.Cursor = System.Windows.Forms.Cursors.Default;
            //button.Label.Cursor = System.Windows.Forms.Cursors.Default;
            //button.Label.Click -= this.ButtonLabelClick;
            //button.PictureBox.Click -= this.ButtonPictureClick;

            ButtonInfo btnParent = currentButton.Parent;
            if (btnParent != null)
            {
                if (currentBigButton != btnParent)
                {
                    ButtonClick("srv;" + btnParent.Key.ToString());
                }
            }

        }
        public void SelectedButton(string key, bool enableWindowChanged = true)
        {
            ButtonClick("btn;" + key, enableWindowChanged);
        }
        #endregion

        #region BIG BUTTON MOUSE ENTER/LEAVE
        private void BigButtonMouseEnter_Pan(object sender, EventArgs e)
        {
            Panel pan = (Panel)sender;
            string nome = dicPanIndex[pan];
            ButtonInfo btn = dicKeySuperButton[nome];
            frmGUI.Menu_suspendLayout();
            btn.SetMouseEnter();
            frmGUI.Menu_ResumeLayout();
        }
        private void BigButtonMouseLeave_Pan(object sender, EventArgs e)
        {
            Panel pan = (Panel)sender;
            string nome = dicPanIndex[pan];
            ButtonInfo btn = dicKeySuperButton[nome];
            frmGUI.Menu_suspendLayout();
            btn.SetMouseLeave();
            frmGUI.Menu_ResumeLayout();
        }
        private void BigButtonMouseEnter_Label(object sender, EventArgs e)
        {
            Label pan = (Label)sender;
            string nome = dicLabelIndex[pan];
            ButtonInfo btn = dicKeySuperButton[nome];
            frmGUI.Menu_suspendLayout();
            btn.SetMouseEnter();
            frmGUI.Menu_ResumeLayout();
        }
        private void BigButtonMouseLeave_Label(object sender, EventArgs e)
        {
            Label pan = (Label)sender;
            string nome = dicLabelIndex[pan];
            ButtonInfo btn = dicKeySuperButton[nome];
            frmGUI.Menu_suspendLayout();
            btn.SetMouseLeave();
            frmGUI.Menu_ResumeLayout();
        }
        private void BigButtonMouseEnter_Picture(object sender, EventArgs e)
        {
            PictureBox pan = (PictureBox)sender;
            string nome = dicPicIndex[pan];
            ButtonInfo btn = dicKeySuperButton[nome];
            frmGUI.Menu_suspendLayout();
            btn.SetMouseEnter();
            frmGUI.Menu_ResumeLayout();
        }
        private void BigButtonMouseLeave_Picture(object sender, EventArgs e)
        {
            PictureBox pan = (PictureBox)sender;
            string nome = dicPicIndex[pan];
            ButtonInfo btn = dicKeySuperButton[nome];
            frmGUI.Menu_suspendLayout();
            btn.SetMouseLeave();
            frmGUI.Menu_ResumeLayout();
        }
        #endregion

        #region SUB BUTTON ENTER/LEAVE
        private void SubButton_MouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            ClearPanelMenuSelected(p);
            if (p.ClientRectangle.Contains(p.PointToClient(Control.MousePosition)))
            {
                p.BackColor = colorMenuMouseEnter;
                p.BackgroundImage = null;
            }
        }
        private void SubButton_MouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            if (!p.ClientRectangle.Contains(p.PointToClient(Control.MousePosition)))
                p.BackColor = System.Drawing.Color.Transparent;
        }
        public void ClearPanelMenuSelected(Panel pCurrent)
        {
            foreach (KeyValuePair<string, ButtonInfo> pair in dicKeyFunctionButton)
            {
                ButtonInfo button = pair.Value;
                if (button != bFormulation && button.Panel != pCurrent && button.Activated && button != currentButton)
                {
                    button.Panel.BackColor = System.Drawing.Color.Transparent;
                }
            }
        }
        #endregion

        #region BUTTON CLICK
        private bool eventEnabled = true;
        private void ButtonPanelClick(object sender, EventArgs e)
        {
            if (!eventEnabled) return;
            eventEnabled = false;
            Panel p = (Panel)sender;
            ButtonClick(dicPanIndex[p]);
            eventEnabled = true;
        }
        private void ButtonLabelClick(object sender, EventArgs e)
        {
            if (!eventEnabled) return;
            eventEnabled = false;
            Label l = (Label)sender;
            ButtonClick(dicLabelIndex[l]);
            eventEnabled = true;
        }
        private void ButtonPictureClick(object sender, EventArgs e)
        {
            if (!eventEnabled) return;
            eventEnabled = false;
            PictureBox pic = (PictureBox)sender;
            ButtonClick(dicPicIndex[pic]);
            eventEnabled = true;
        }
        private void ButtonClick(string key, bool enableWindowChanged = true)
        {
            try
            {
                if (key.StartsWith("srv;"))
                {
                    //service
                    string iKey = key.Substring(4);
                    if (currentBigButton != null)
                    {
                        currentBigButton.Selected = false;
                    }
                    currentBigButton = dicKeySuperButton[key];
                    currentBigButton.Selected = true;
                    AnimationManager.RefreshMenu(Convert.ToInt32(iKey));
                }
                else
                {
                    if (key.StartsWith("btn;"))
                    {
                        key = key.Substring(4);
                        if (key == "ricercacolore" && !Euroformulations4.Library.GVar.bLoadFormuleEnded)
                        {
                            throw new Exception(lang.GetWord("data_loading"));
                        }
                        UpdateCurrentSelectedButton(key);
                        if (enableWindowChanged && frmGUI != null) frmGUI.KeyChanged(key);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
 
    }
}
