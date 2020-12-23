using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Euroformulations4.Library
{
    class AnimationMenuManager
    {
        private List<Panel> lstPan;
        private List<int> panState;
        private List<int> originalPanHeight;
        private static int iThreadSleep = 10; //ms
        private static int iScaleUnit = 10; //px
        private int iPanelOpen = -1;

        public AnimationMenuManager()
        {
            lstPan = new List<Panel>();
            panState = new List<int>();
            originalPanHeight = new List<int>();
        }

        public void AddItem(Panel menuButton, Panel menuContent)
        {
            lstPan.Add(menuButton);
            lstPan.Add(menuContent);
            panState.Add(1);
            originalPanHeight.Add(menuContent.Size.Height);
        }

        public void RefreshMenu(int indexMenuButton)
        {
            RefreshExecute(indexMenuButton, true);
        }

        private void RefreshExecute(int indexMenuButton, bool considerPrev = true)
        {
            if (indexMenuButton % 2 != 0 || indexMenuButton >= (lstPan.Count - 1)) return;

            if (iPanelOpen != -1 && considerPrev && indexMenuButton != iPanelOpen)
            {
                RefreshExecute(iPanelOpen, false);
            }

            int indexInfoPanel = indexMenuButton / 2;
            int stato = panState[indexInfoPanel];
            Panel p = lstPan[indexMenuButton + 1];
            int offset = originalPanHeight[indexInfoPanel];

            for (int i = 0; i <= offset; i = i + iScaleUnit)
            {
                //scale control
                int iScale = iScaleUnit;
                if ((i + iScaleUnit) > offset)
                {
                    iScale = offset - i;
                }

                //update current panels
                Application.DoEvents();
                if (stato == 1)
                {
                    p.Height = p.Height - iScale;
                }
                else
                {
                    p.Height = p.Height + iScale;
                }

                //update all panel behind
                for (int j = indexMenuButton + 2; j < lstPan.Count; j++)
                {
                    Panel pBrother = lstPan[j];
                    Point pt = lstPan[j].Location;
                    if (stato == 1)
                    {
                        pt.Y -= iScale;
                    }
                    else
                    {
                        pt.Y += iScale;
                    }
                    lstPan[j].Location = new Point(pt.X, pt.Y);
                }

                System.Threading.Thread.Sleep(iThreadSleep);

            }

            //update stato
            if (stato == 1)
            {
                panState[indexInfoPanel] = 0;
            }
            else
            {
                panState[indexInfoPanel] = 1;
            }

            if (considerPrev)
            {
                if (indexMenuButton != iPanelOpen)
                    iPanelOpen = indexMenuButton;
                else
                    iPanelOpen = -1;
            }

        }

        public void CollapseAll()
        {
            for (int i = 0; i < panState.Count; i++)
            {
                if (panState[i] == 1)
                {
                    RefreshExecute(i * 2, false);
                }
            }
            iPanelOpen = -1;
        }
    }
}
