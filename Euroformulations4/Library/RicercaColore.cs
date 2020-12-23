using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Euroformulations4.Library
{
    class RicercaColore
    {
        private double l = -1, a = -1, b = -1;
        private bool bSearchFromCubecc = false;
        private int nRis = 1;
        private bool bDEStandard = true;
        private object oFilterInterior = null; //null= not set; true: filtered interior; false: filtered exterior
        private List<int> lstFilterProdotti = null;  //null= not set; not null = list of valid products
        private List<int> lstFilterCartella = null;  //null= not set; not null = list of valid products 
        private Match[] r;

        public RicercaColore()
        {
            l = 0;
            a = 0;
            b = 0;
        }

        public void Preset_LAB(double l, double a, double b)
        {
            this.l = l;
            this.a = a;
            this.b = b;
        }
        public void Preset_RGB(double r, double g, double b)
        {
            double[] xyz = Library.Colore.RGB_XYZ(r, g, b);
            double[] lab = Library.Colore.XYZ_LAB(xyz[0], xyz[1], xyz[2]);
            this.l = lab[0];
            this.a = lab[1];
            this.b = lab[2];
        }
        public void Preset_XYZ(double r, double g, double b)
        {
            double[] xyz = Library.Colore.RGB_XYZ(r, g, b);
            this.l = xyz[0];
            this.a = xyz[1];
            this.b = xyz[2];
        }
        public void Preset_SearchFromCubeCC(bool bSearchFromCubecc) { this.bSearchFromCubecc = bSearchFromCubecc; }

        public bool Filter_Interior
        {
            set { oFilterInterior = value; }
        }
        public List<int> Filter_Products
        {
            set { if (value != null) { this.lstFilterProdotti = value; } }
        }
        public List<int> Filter_CartellaColori
        {
            set { if (value != null) { this.lstFilterCartella = value; } }
        }
        public bool Filter_DEStandard
        {
            set { this.bDEStandard = value; }
        }

        public int ResultNumbers
        {
            set { if (value > 0 && value <= 100) { this.nRis = value; } }
            get { return nRis; }
        }

        public SortedDictionary<double, int> ColorSearchExecute()
        {
            SortedDictionary<double, int> resultMatch = new SortedDictionary<double, int>();

            int nPoints = Library.GVar.lstColoriFull.Count;
            int nThread = (nPoints / 100000);
            if ((nPoints - (nThread * 100000)) > 0) nThread++;
            Thread[] t = new Thread[nThread];
            r = new Match[nThread * nRis];

            int indexTemp = 0;
            for (int i = 0; i < nThread; i++)
            {
                int val = indexTemp;
                int val2 = i;
                if (val2 != (nThread - 1))
                    t[i] = new Thread(() => ThreadFunction(val, val + 100000 - 1, val2));
                else
                    t[i] = new Thread(() => ThreadFunction(val, nPoints - 1, val2));
                t[i].Start();
                indexTemp += 100000;
            }

            //main thread synchronize
            for (int i = 0; i < t.Length; i++)
            {
                t[i].Join();
            }

            //result order
            resultMatch.Clear();
            foreach (Match rl in r)
            {
                if (rl != null)
                {
                    if (!resultMatch.ContainsKey(rl.delta))
                        resultMatch.Add(rl.delta, rl.index);
                }
            }


            return resultMatch;
        }

        private void ThreadFunction(int start, int end, int indexDest)
        {
            SortedDictionary<double, int> sDic = new SortedDictionary<double, int>();
            /*
             * TODO filtri
            bool bDEStandard = chkDEStandard.Checked;
            bool bControlloProdotti = filtro_IDProdotti.Count > 0;
            bool bControlloCartella = filtro_IDCartella.Count > 0;*/

            for (; start <= end; start++)
            {
                Colore c = Library.GVar.lstColoriFull[start];
                
                //condizioni per considerare colore
                bool bInternoEsterno = true;
                if (oFilterInterior != null)
                {
                    bInternoEsterno = (c.Interior && (bool)oFilterInterior) || (!c.Interior && !(bool)oFilterInterior);
                }
                
                bool bValido = true;
                if (bSearchFromCubecc && !c.HasLABCube) { bValido = false; }
                if (bValido && this.lstFilterProdotti != null)
                {
                    if (!this.lstFilterProdotti.Contains(c.CodProdotto)) { bValido = false; }
                }
                if (bValido && this.lstFilterCartella != null)
                {
                    if (!this.lstFilterCartella.Contains(c.CodCartellaColori))
                    {
                        bValido = false;
                    }
                }

                if (bInternoEsterno && bValido)
                {
                    //value algorithm
                    double valore;
                    if (bDEStandard)
                        valore = c.CIELabDistanceSquare(l, a, b, bSearchFromCubecc);
                    else
                        valore = c.DeltaECie2000DistanceSquare(l, a, b, bSearchFromCubecc);

                    //insert
                    if (!sDic.ContainsKey(valore))
                    {
                        sDic.Add(valore, start);
                    }
                        

                    //clean
                    if (sDic.Keys.Count == 1000)
                    {
                        SortedDictionary<double, int> sDic2 = new SortedDictionary<double, int>();
                        int matchCountClear = sDic.Keys.Count;
                        for (int z = 0; z < nRis && z < matchCountClear; z++)
                        {
                            sDic2.Add(sDic.ElementAt(z).Key, sDic.ElementAt(z).Value);
                        }
                        sDic = sDic2;
                    }
                }
            }

            int matchCount = sDic.Keys.Count;

            for (int j = 0; (j < nRis && j < matchCount); j++)
            {
                r[(indexDest * nRis) + j] = new Match(sDic.ElementAt(j).Value, sDic.ElementAt(j).Key);
            }
        }


        private class Match
        {
            public double delta;
            public int index;
            public Match(int index, double delta)
            {
                this.index = index;
                this.delta = delta;
            }
        }
    }
}
