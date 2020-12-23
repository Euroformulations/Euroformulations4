using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euroformulations4.Library.Data.Dispositivi
{
    interface IDispositivo
    {
        double[] Read_XYZLab();
        bool CanRead();
        System.Windows.Forms.Form GetWindowManager(bool bTopLevel);
    }
}
