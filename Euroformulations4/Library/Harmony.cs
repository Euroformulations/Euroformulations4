using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library
{
    class Harmony
    {
        internal struct HSVData 
        {
            internal double h;
            internal double s;
            internal double v;
        }

        public static HSVData RGBtoHSV(System.Drawing.Color RGB)
        {
            double r = (double)RGB.R / 255;
            double g = (double)RGB.G / 255;
            double b = (double)RGB.B / 255;

            double h;
            double s;
            double v;

            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);
            v = max;
            double delta = max - min;
            if (max == 0 || delta == 0)
            {
                s = 0;
                h = 0;
            }
            else
            {
                s = delta / max;
                if (r == max)
                {
                    // Between Yellow and Magenta
                    h = (g - b) / delta;
                }
                else if (g == max)
                {
                    // Between Cyan and Yellow
                    h = 2 + (b - r) / delta;
                }
                else
                {
                    // Between Magenta and Cyan
                    h = 4 + (r - g) / delta;
                }

            }

            h *= 60;
            if (h < 0)
            {
                h += 360;
            }

            return new HSVData()
            {
                h = h,
                s = s,
                v = v
            };
        }

        public static System.Drawing.Color ConvertHsvToRgb(double h, double s, double v)
        {
            System.Diagnostics.Debug.Assert(0.0 <= s && s <= 1.0);
            System.Diagnostics.Debug.Assert(0.0 <= v && v <= 1.0);

            // normalize the hue:
            while (h < 0)
                h += 360;
            while (h > 360)
                h -= 360;

            h = h / 360;

            byte MAX = 255;

            if (s > 0)
            {
                if (h >= 1)
                    h = 0;
                h = 6 * h;
                int hueFloor = (int)Math.Floor(h);
                byte a = (byte)Math.Round(MAX * v * (1.0 - s));
                byte b = (byte)Math.Round(MAX * v * (1.0 - (s * (h - hueFloor))));
                byte c = (byte)Math.Round(MAX * v * (1.0 - (s * (1.0 - (h - hueFloor)))));
                byte d = (byte)Math.Round(MAX * v);

                switch (hueFloor)
                {
                    case 0: return System.Drawing.Color.FromArgb(MAX, d, c, a);
                    case 1: return System.Drawing.Color.FromArgb(MAX, b, d, a);
                    case 2: return System.Drawing.Color.FromArgb(MAX, a, d, c);
                    case 3: return System.Drawing.Color.FromArgb(MAX, a, b, d);
                    case 4: return System.Drawing.Color.FromArgb(MAX, c, a, d);
                    case 5: return System.Drawing.Color.FromArgb(MAX, d, a, b);
                    default: return System.Drawing.Color.FromArgb(0, 0, 0, 0);
                }
            }
            else
            {
                byte d = (byte)(v * MAX);
                return System.Drawing.Color.FromArgb(255, d, d, d);
            }
        }



    }
}
