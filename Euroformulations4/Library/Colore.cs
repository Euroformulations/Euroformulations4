using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library
{
    public class Colore
    {
        private int _id;
        private string _nome;

        private bool bLabLoaded = false;
        private double _CIEL;
        private double _CIEa;
        private double _CIEb;
        private double[] _CIELab_Cubecc = null; //CIELab di cartella colori letta da Cube
        private double _deformula;

        private bool bRgbLoaded = false;
        private double _R;
        private double _G;
        private double _B;

        private bool bXyzLoaded = false;
        private double _X;
        private double _Y;
        private double _Z;

        private int _interior = -1; //-1: not set; 0: interior; else exterior
        
        private int _prodotto = -1;
        private int _cartellaColori = -1;

        public Colore(int ID, string Nome, bool interior, double CIE_L, double CIE_a, double CIE_b, double R, double G, double B, int prodotto, int cartellaColori, double[] CIELab_Cubecc, double deformula)
        {
            _id = ID;
            _nome = Nome;
            if (interior)
                this._interior = 0;
            else
                this._interior = 1;
            _CIEL = CIE_L;
            _CIEa = CIE_a;
            _CIEb = CIE_b;
            _CIELab_Cubecc = CIELab_Cubecc;
            _deformula = deformula;
            bLabLoaded = true;
            _R = R;
            _G = G;
            _B = B;
            bRgbLoaded = true;
            _prodotto = prodotto;
            _cartellaColori = cartellaColori;
        }

        public Colore(int ID, string Nome, double CIE_L, double CIE_a, double CIE_b, double X, double Y, double Z) {
            _id = ID;
            _nome = Nome;
            _CIEL = CIE_L;
            _CIEa = CIE_a;
            _CIEb = CIE_b;
            bLabLoaded = true;
            _X = X;
            _Y = Y;
            _Z = Z;
            bXyzLoaded = true;
        }

        public Colore(double CIE_L, double CIE_a, double CIE_b, double X, double Y, double Z)
        {
            _id = -1;
            _nome ="";
            _CIEL = CIE_L;
            _CIEa = CIE_a;
            _CIEb = CIE_b;
            bLabLoaded = true;
            _X = X;
            _Y = Y;
            _Z = Z;
            bXyzLoaded = true;
        }

        public Colore(double CIE_L, double CIE_a, double CIE_b)
        {
            _id = -1;
            _nome = "";
            _CIEL = CIE_L;
            _CIEa = CIE_a;
            _CIEb = CIE_b;
            bLabLoaded = true;
        }

        public int ID
        {
            get { return _id; }
        }
        public string Nome
        {
            get { return _nome; }
        }
        public bool Interior 
        {
            get 
            {
                if (_interior == -1) throw new Exception("Colore._interior must be 0 or 1 to use Interior property");
                if (_interior == 0) return true;
                return false;
            }
        }
        public double CIEL
        {
            get 
            {
                if (!bLabLoaded) throw new Exception("CIEL value not set");
                return _CIEL; 
            }
        }
        public double CIEa
        {
            get { if (!bLabLoaded) throw new Exception("CIEa value not set"); 
                return _CIEa; }
        }
        public double CIEb
        {
            get {
                if (!bLabLoaded) throw new Exception("CIEb value not set");
                return _CIEb; 
            }
        }

        public double[] CIELab_CubeCC { get { return _CIELab_Cubecc; } }
        public bool HasLABCube { get { return _CIELab_Cubecc != null; } }
        public double DEFormula { get { return _deformula; } }
        public double R
        {
            get 
            {
                if (!bRgbLoaded) throw new Exception("R value not set");
                return _R; 
            }
        }
        public double G
        {
            get {
                if (!bRgbLoaded) throw new Exception("G value not set");
                return _G; 
            }
        }
        public double B
        {
            get {
                if (!bRgbLoaded) throw new Exception("B value not set");
                return _B; 
            }
        }

        public double X
        {
            get
            {
                if (!bXyzLoaded) throw new Exception("X value not set");
                return _X;
            }
        }
        public double Y
        {
            get
            {
                if (!bXyzLoaded) throw new Exception("Y value not set");
                return _Y;
            }
        }
        public double Z
        {
            get
            {
                if (!bXyzLoaded) throw new Exception("Z value not set");
                return _Z;
            }
        }

        public double C 
        {
            get 
            {
                if (!bLabLoaded) throw new Exception("CIEL value not set");
                return Math.Sqrt(Math.Pow(_CIEa, 2) + Math.Pow(_CIEb, 2));
            }    
        }
        public double H
        {
            get
            {
                if (!bLabLoaded) throw new Exception("CIEL value not set");
                return Arcotan(_CIEb, _CIEa);
            }
        }

        public int CodProdotto
        {
            get { return _prodotto; }
        }
        public int CodCartellaColori
        {
            get { return _cartellaColori; }
        }

        public double CIELabDistanceSquare(double L, double a, double b, bool SearchFromCubeCC)
        {
            if (!bLabLoaded) throw new Exception("Lab value not set");
            double deltaL, deltaA, deltaB;
            if (SearchFromCubeCC)
            {
                if (_CIELab_Cubecc != null)
                {
                    deltaL = _CIELab_Cubecc[0] - L;
                    deltaA = _CIELab_Cubecc[1] - a;
                    deltaB = _CIELab_Cubecc[2] - b;
                }
                else
                {
                    deltaL = _CIEL - L;
                    deltaA = _CIEa - a;
                    deltaB = _CIEb - b;
                }
            }
            else
            {
                deltaL = _CIEL - L;
                deltaA = _CIEa - a;
                deltaB = _CIEb - b;
            }

            return (deltaL * deltaL) + (deltaA * deltaA) + (deltaB * deltaB);
        }
        public double CIELabDistance(double L, double a, double b, bool SearchFromCubeCC) {
            return Math.Sqrt(CIELabDistanceSquare(L, a, b, SearchFromCubeCC));
        }
        public double CIELabDistance(Colore c, bool SearchFromCubeCC)
        {
            return CIELabDistance(c.CIEL, c.CIEa, c.CIEb, SearchFromCubeCC);
        }
        public double DeltaECie2000DistanceSquare(double L2, double a2, double b2, bool SearchFromCubeCC)
        {
            if (!bLabLoaded) throw new Exception("Lab value not set");

            double L = 0;
            double C1 = 0;
            double C2 = 0;
            double CT1 = 0;
            double CT2 = 0;
            double CT = 0;
            double C = 0;
            double G = 0;
            double at1 = 0;
            double at2 = 0;
            double h1 = 0;
            double h2 = 0;
            double h = 0;
            double T = 0;
            double Dh = 0;
            double Dl = 0;
            double Dc = 0;
            double dh1 = 0;
            double Sl = 0;
            double Sc = 0;
            double Sh = 0;
            double DeltaO = 0;
            double rc = 0;
            double rt = 0;
            double kl = 0;
            double kc = 0;
            double kh = 0;

            double CIEL_process = _CIEL;
            double CIEa_process = _CIEa;
            double CIEb_process = _CIEb;
            if (SearchFromCubeCC && _CIELab_Cubecc != null)
            {
                CIEL_process = _CIELab_Cubecc[0];
                CIEa_process = _CIELab_Cubecc[1];
                CIEb_process = _CIELab_Cubecc[2];
            }

            L = (CIEL_process + L2) / 2;
            C1 = Math.Sqrt(Math.Pow(CIEa_process, 2) + Math.Pow(CIEb_process, 2));
            C2 = Math.Sqrt(Math.Pow(a2, 2) + Math.Pow(b2, 2));
            C = (C1 + C2) / 2;
            G = (1 - Math.Sqrt(Math.Pow(C, 7) / (Math.Pow(C, 7) + Math.Pow(25, 7)))) / 2;
            at1 = CIEa_process * (1 + G);
            at2 = a2 * (1 + G);

            //Riscrivo C Primo
            CT1 = Math.Sqrt(Math.Pow(at1, 2) + Math.Pow(CIEb_process, 2));
            CT2 = Math.Sqrt(Math.Pow(at2, 2) + Math.Pow(b2, 2));
            CT = (CT1 + CT2) / 2;

            //Trovo H1 primo
            if (Arcotan(CIEb_process, at1) >= 0)
            {
                h1 = Arcotan(CIEb_process, at1);
            }
            else
            {
                h1 = Arcotan(CIEb_process, at1) + 360;
            }

            //Trovo H2 primo
            if (Arcotan(b2, at2) >= 0)
            {
                h2 = Arcotan(b2, at2);
            }
            else
            {
                h2 = Arcotan(b2, at2) + 360;
            }

            //Trovo H medio
            if (Math.Abs(h1 - h2) > 180)
            {
                h = (h1 + h2 + 360) / 2;
            }
            else
            {
                h = (h1 + h2) / 2;
            }

            //Trovo T
            T = 1 - 0.17 * Math.Cos(h - 30) + 0.24 * Math.Cos(2 * h) + 0.32 * Math.Cos(3 * h + 6) - 0.2 * Math.Cos(4 * h - 63);

            //Trovo Dh
            if (Math.Abs(h2 - h1) <= 180)
            {
                Dh = h2 - h1;
            }
            if (Math.Abs(h2 - h1) > 180 & h2 <= h1)
            {
                Dh = h2 - h1 + 360;
            }
            if (Math.Abs(h2 - h1) > 180 & h2 > h1)
            {
                Dh = h2 - h1 - 360;
            }

            //Trovo Dl
            Dl = L2 - CIEL_process;

            //trovo dc
            Dc = CT2 - CT1;

            //trovo dh
            dh1 = 2 * Math.Sqrt(CT1 * CT2) * Math.Sin(Dh / 2);

            //Trovo gli S
            Sl = 1 + ((0.015 * Math.Pow((L - 50), 2)) / Math.Sqrt(20 + Math.Pow((L - 50), 2)));

            Sc = 1 + 0.045 * CT;

            Sh = 1 + 0.015 * CT * T;

            //Trovo Delta0
            DeltaO = 30 * Math.Exp(-(Math.Pow(((h - 275) / 25), 2)));

            rc = 2 * Math.Sqrt(Math.Pow(CT1, 7) / (Math.Pow(CT1, 7) + Math.Pow(25, 7)));
            rt = -rc * Math.Sin(2 * DeltaO);

            kl = 1;
            kc = 1;
            kh = 1;

            return (Math.Pow((Dl / (kl * Sl)), 2)) + (Math.Pow((Dc / (kc * Sc)), 2)) + (Math.Pow((Dh / (kh * Sh)), 2)) + rt * (Dc / (kc * Sc)) * (Dh / (kh * Sh));
        }
        public double DeltaECie2000Distance(double L2, double a2, double b2, bool SearchFromCubeCC)
        {
            return Math.Sqrt(DeltaECie2000DistanceSquare(L2, a2, b2, SearchFromCubeCC));
        }
        public double DeltaECie2000Distance(Colore c, bool SearchFromCubeCC)
        {
            return DeltaECie2000Distance(c.CIEL, c.CIEa, c.CIEb, SearchFromCubeCC);
        }

        public static double DeltaH(Colore coloreSTD, Colore coloreSample)
        {
            double XDE = Math.Sqrt((coloreSample.CIEa * coloreSample.CIEa) + (coloreSample.CIEb * coloreSample.CIEb)) -
                    Math.Sqrt((coloreSTD.CIEa * coloreSTD.CIEa) + (coloreSTD.CIEb * coloreSTD.CIEb));

            return Math.Sqrt(
                    ((coloreSample.CIEa - coloreSTD.CIEa) * (coloreSample.CIEa - coloreSTD.CIEa)) +
                    ((coloreSample.CIEb - coloreSTD.CIEb) * (coloreSample.CIEb - coloreSTD.CIEb)) -
                    (XDE * XDE));
        }

        public static double Arcotan(double b, double a)
        {
            double h = Math.Atan2(b, a);

            // convert from radians to degrees
            if (h > 0)
            {
                h = (h / Math.PI) * 180.0;
            }
            else
            {
                h = 360 - (Math.Abs(h) / Math.PI) * 180.0;
            }

            if (h < 0)
            {
                h += 360.0;
            }
            else if (h >= 360)
            {
                h -= 360.0;
            }

           // double L = lab.L;
            //item.C = Math.Sqrt(lab.A * lab.A + lab.B * lab.B);
            //item.H = h;
            return Math.Round(h,0);
        }

        public static double[] RGB_XYZ(double R, double G, double B)
        {
            double var_R = (R / 255);
            //R from 0 to 255
            double var_G = (G / 255);
            //G from 0 to 255
            double var_B = (B / 255);
            //B from 0 to 255
            if (var_R > 0.04045)
            {
                var_R = Math.Pow(((var_R + 0.055) / 1.055), 2.4);
            }
            else
            {
                var_R = var_R / 12.92;
            }
            if (var_G > 0.04045)
            {
                var_G = Math.Pow(((var_G + 0.055) / 1.055), 2.4);
            }
            else
            {
                var_G = var_G / 12.92;
            }
            if (var_B > 0.04045)
            {
                var_B = Math.Pow(((var_B + 0.055) / 1.055), 2.4);
            }
            else
            {
                var_B = var_B / 12.92;
            }

            var_R = var_R * 100;
            var_G = var_G * 100;
            var_B = var_B * 100;

            //Observer. = 2°, Illuminant = D65
            double X = var_R * 0.4124 + var_G * 0.3576 + var_B * 0.1805;
            double Y = var_R * 0.2126 + var_G * 0.7152 + var_B * 0.0722;
            double Z = var_R * 0.0193 + var_G * 0.1192 + var_B * 0.9505;
            return new double[] {X, Y,Z};
        }
        public static double[] XYZ_LAB(double X, double Y, double Z)
        {
            //D65 XYZ white reference
            double Xr = 95.047d;
            double Yr = 100.0d;
            double Zr = 108.883d;

            double xr = X / Xr;
            double yr = Y / Yr;
            double zr = Z / Zr;

            double Epsilon = 216d / 24389d;
            double Kappa = 24389d / 27d;

            double fx = xr > Epsilon ? Math.Pow(xr, 1d / 3d) : ((Kappa * xr) + 16) / 116;
            double fy = yr > Epsilon ? Math.Pow(yr, 1d / 3d) : ((Kappa * yr) + 16) / 116;
            double fz = zr > Epsilon ? Math.Pow(zr, 1d / 3d) : ((Kappa * zr) + 16) / 116;

            double CIEL = (116d * fy) - 16;
            double CIEa = 500d * (fx - fy);
            double CIEb = 200d * (fy - fz);

            return new double[] {CIEL, CIEa, CIEb};
        }
        public static double[] LAB_XYZ(double L, double a, double b)
        {

            // conversion algorithm described here: http://www.brucelindbloom.com/index.html?Eqn_Lab_to_XYZ.html
            double fy = (L + 16) / 116d;
            double fx = a / 500d + fy;
            double fz = fy - b / 200d;

            double fx3 = Math.Pow(fx, 3);
            double fz3 = Math.Pow(fz, 3);

            double Epsilon = 216d / 24389d;
            double Kappa = 24389d / 27d;

            double xr = fx3 > Epsilon ? fx3 : (116 * fx - 16) / Kappa;
            double yr = L > Kappa * Epsilon ? Math.Pow((L + 16) / 116d, 3) : L / Kappa;
            double zr = fz3 > Epsilon ? fz3 : (116 * fz - 16) / Kappa;

            //D65 WHITEPOINT
            //0.95047, 1, 1.08883

            double Xr = 0.95047d;
            double Yr = 1d;
            double Zr = 1.08883d;

            xr = CropRange(xr, 0, 1);
            yr = CropRange(yr, 0, 1);
            zr = CropRange(zr, 0, 1);

            double X = (xr * Xr) * 100;
            double Y = (yr * Yr) * 100;
            double Z = (zr * Zr) * 100;

            return new double[]{X, Y, Z};
        }
        public static double CropRange(double value, double min, double max)
        {
            if (value < min)
                return min;

            if (value > max)
                return max;

            return value;
        }
        public static double[] XYZ_RGB(double X, double Y, double Z)
        {
            //Observer = 10°, Illuminant = D65
            double[] rgb = new double[3];

            double Var_X = X / 100;
            double Var_Y = Y / 100;
            double Var_Z = Z / 100;

            double Var_R = Var_X * 3.2406 + Var_Y * -1.5372 + Var_Z * -0.4986;
            double Var_G = Var_X * -0.9689 + Var_Y * 1.8758 + Var_Z * 0.0415;
            double Var_B = Var_X * 0.0557 + Var_Y * -0.204 + Var_Z * 1.057;

            if (Var_R > 0.0031308)
            {
                Var_R = 1.055 * Math.Pow(Var_R, 1 / 2.4) - 0.055;
            }
            else
            {
                Var_R = 12.92 * Var_R;
            }

            if (Var_G > 0.0031308)
            {
                Var_G = 1.055 * Math.Pow(Var_G, 1 / 2.4) - 0.055;
            }
            else
            {
                Var_G = 12.92 * Var_G;
            }

            if (Var_B > 0.0031308)
            {
                Var_B = 1.055 * Math.Pow(Var_B, 1 / 2.4) - 0.055;
            }
            else
            {
                Var_B = 12.92 * Var_B;
            }

            if (Var_R * 255 <= 0)
            {
                rgb[0] = 0;
            }
            else
            {
                if (Var_R * 255 > 255)
                {
                    rgb[0] = 255;
                }
                else
                {
                    rgb[0] = Math.Round(Var_R * 255,0);
                }
            }

            if (Var_G * 255 <= 0)
            {
                rgb[1] = 0;
            }
            else
            {
                if (Var_G * 255 > 255)
                {
                    rgb[1] = 255;
                }
                else
                {
                    rgb[1] = Math.Round(Var_G * 255,0);
                }
            }

            if (Var_B * 255 <= 0)
            {
                rgb[2] = 0;
            }
            else
            {
                if (Var_B * 255 > 255)
                {
                    rgb[2] = 255;
                }
                else
                {
                    rgb[2] = Math.Round(Var_B * 255,0);
                }
            }

            return rgb;
        }

        public static double[] Spectrum_XYZ(List<double> Reflectance)
        {
            //Observer = 10°, Illuminant = D65
            double TmpX = 0;
            double TmpY = 0;
            double TmpZ = 0;
            double[] XYZ = new double[3];
            List<double> XTri = new List<double>();
            List<double> YTri = new List<double>();
            List<double> ZTri = new List<double>();

            #region Coefficenti di distribuzione D65 - 10°
            XTri.Add(0.097);
            XTri.Add(0.616);
            XTri.Add(1.66);
            XTri.Add(2.377);
            XTri.Add(3.512);
            XTri.Add(3.789);
            XTri.Add(3.103);
            XTri.Add(1.937);
            XTri.Add(0.747);
            XTri.Add(0.11);
            XTri.Add(0.007);
            XTri.Add(0.314);
            XTri.Add(1.027);
            XTri.Add(2.174);
            XTri.Add(3.38);
            XTri.Add(4.735);
            XTri.Add(6.081);
            XTri.Add(7.31);
            XTri.Add(8.393);
            XTri.Add(8.603);
            XTri.Add(8.771);
            XTri.Add(7.996);
            XTri.Add(6.476);
            XTri.Add(4.635);
            XTri.Add(3.074);
            XTri.Add(1.814);
            XTri.Add(1.031);
            XTri.Add(0.557);
            XTri.Add(0.261);
            XTri.Add(0.114);
            XTri.Add(0.057);

            YTri.Add(0.01);
            YTri.Add(0.064);
            YTri.Add(0.171);
            YTri.Add(0.283);
            YTri.Add(0.549);
            YTri.Add(0.888);
            YTri.Add(1.277);
            YTri.Add(1.817);
            YTri.Add(2.545);
            YTri.Add(3.164);
            YTri.Add(4.309);
            YTri.Add(5.631);
            YTri.Add(6.896);
            YTri.Add(8.136);
            YTri.Add(8.684);
            YTri.Add(8.903);
            YTri.Add(8.614);
            YTri.Add(7.95);
            YTri.Add(7.164);
            YTri.Add(5.945);
            YTri.Add(5.11);
            YTri.Add(4.067);
            YTri.Add(2.99);
            YTri.Add(2.02);
            YTri.Add(1.275);
            YTri.Add(0.724);
            YTri.Add(0.407);
            YTri.Add(0.218);
            YTri.Add(0.102);
            YTri.Add(0.044);
            YTri.Add(0.022);

            ZTri.Add(0.436);
            ZTri.Add(2.808);
            ZTri.Add(7.868);
            ZTri.Add(11.703);
            ZTri.Add(17.958);
            ZTri.Add(20.358);
            ZTri.Add(17.861);
            ZTri.Add(13.085);
            ZTri.Add(7.51);
            ZTri.Add(3.743);
            ZTri.Add(2.003);
            ZTri.Add(1.004);
            ZTri.Add(0.529);
            ZTri.Add(0.271);
            ZTri.Add(0.116);
            ZTri.Add(0.03);
            ZTri.Add(-0.003);
            ZTri.Add(0.001);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);
            ZTri.Add(0);


            #endregion

            for (int i = 0; i < Reflectance.Count; i++)
            {
                TmpX += XTri[i] * Reflectance[i];
                TmpY += YTri[i] * Reflectance[i];
                TmpZ += ZTri[i] * Reflectance[i];
            }

            XYZ[0] = TmpX;
            XYZ[1] = TmpY;
            XYZ[2] = TmpZ;

            return XYZ;
        }

    }

}
