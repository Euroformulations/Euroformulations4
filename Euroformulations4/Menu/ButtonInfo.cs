using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Euroformulations4.Menu
{
    class ButtonInfo
    {
        private bool _selected = false;
        private bool _bigbutton = false;
        private string _name = "";
        private bool _activated = false;
        private Bitmap _image = null;
        private List<ButtonInfo> _subButton = new List<ButtonInfo>();
        private string _key = "";
        private string _activatedDesc = "";
        private string _deactivatedDesc = "";
        private Panel panel = new Panel();
        private PictureBox pBox = new PictureBox();
        private Label l = new Label();
        private ButtonInfo parent = null;

        public ButtonInfo(string name, Bitmap image, bool activated)
        {
            this._name = name;
            this._image = image;
            this._activated = activated;
        }

        public ButtonInfo(string name, Bitmap image, bool activated, string key)
            : this(name, image, activated)
        {
            this._key = key;
        }

        public ButtonInfo(string name, Bitmap image, bool activated, string key, string activatedDescription, string deactivatedDescription)
            : this(name, image, activated, key)
        {
            this._activatedDesc = activatedDescription;
            this._deactivatedDesc = deactivatedDescription;
        }

        public void Add(ButtonInfo btn)
        {
            btn.parent = this;
            this._subButton.Add(btn);
        }

        public ButtonInfo Parent
        {
            get { return parent; }
        }

        #region PROPERTIES
        public List<ButtonInfo> SubButton
        {
            get { return _subButton; }
        }

        public string Name { get { return _name; } }
        public bool Activated { get { return _activated; } }
        public Bitmap Image 
        { 
            get 
            { 
                if(_image != null)  return _image;
                return new Bitmap(10, 10);//default mining null
            }
            set
            {
                this._image = value;
                pBox.Image = this._image;
            }
        }

        public string Key { get { return _key; } }

        public string Description
        {
            get
            {
                if (_activated)
                    return _activatedDesc;
                return _deactivatedDesc;
            }
        }

        public Panel Panel 
        {
            get
            {
                return panel;
            }
        }
        public Label Label
        {
            get 
            {
                return l;
            }
        }
        public PictureBox PictureBox
        {
            get 
            {
                return pBox;
            }
        }
        #endregion


        #region funzioni
        public void SetMouseEnter()
        {
            if (!_selected)
            {
                InitEnter();
            }
        }
        private void InitEnter()
        {
            if (!this._activated) return;
            if (this._bigbutton)
            {
                //l.BackgroundImage = Euroformulations4.Properties.Resources.SfondoMenu;
                pBox.BackgroundImage = null;

                //pBox.BackgroundImage = Euroformulations4.Properties.Resources.SfondoMenu;
                panel.BackColor = Color.FromArgb(0, 149, 66);
            }
        }
        public void SetMouseLeave()
        {
            if (!_selected)
            {
                InitLeave();
            }
        }
        private void InitLeave()
        {
            if (!this._activated) return;
            if (this._bigbutton)
            {
                pBox.BackgroundImage = null;
                panel.BackColor = Color.FromArgb(0, 171, 184);
            }
        }
        public bool Selected
        {
            set 
            { 
                this._selected = value;
                if (this._selected)
                {
                    InitEnter();
                }
                else
                {
                    InitLeave();
                }
            }
            get { return this._selected; }
        }
        public bool BigButton
        {
            set { this._bigbutton = value; }
            get { return this._bigbutton; }
        }

        #endregion
    }

    
}
