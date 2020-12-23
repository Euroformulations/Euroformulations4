using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace Euroformulations4.Library.Formulation
{
    class CostCalculator
    {
        private int IDListino;
        private Library.Data.Database.DBConnector dbconnector;

        public CostCalculator(Library.Data.Database.DBConnector dbconnector, int IDListino)
        {
            this.IDListino = IDListino;
            this.dbconnector = dbconnector;
        }

        public double GetCostoBase(string sNome, double dQta, double dDensita, Library.Formulation.eUnita unita)
        {
            string sql = "SELECT costo_base, unita_base FROM base_costi WHERE id_listino = " + IDListino + " AND nome_base = '"+ sNome +"'";
            DataTable dt = dbconnector.SQLQuerySelect(sql);
            if (dt.Rows.Count == 0) { return 0.01d; }

            double costo = Convert.ToDouble(dt.Rows[0]["costo_base"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            Library.Formulation.eUnita dbunita = eUnita.LT;
            string sUnita = dt.Rows[0]["unita_base"].ToString().ToUpper();
            if (sUnita == "KG") { dbunita = eUnita.KG; }

            if (unita == dbunita)
            {
                costo *= dQta;
            }
            else
            {
                double qta = Library.Formulation.Formula.ConvertValue(dQta, unita, dbunita, dDensita);
                costo *= qta;
            }

            if (costo < 0.01d) costo = 0.01d;

            return costo;
        }

        public double GetCostoLatta(string sNomeBase, double dQtaLatta, Library.Formulation.eUnita unita)
        {
            if (unita != eUnita.KG && unita != eUnita.LT) { throw new Exception("unit for cost calc is not valid"); }

            string sql = "SELECT costo_lattaggio FROM lattaggi WHERE id_listino = " + IDListino + " AND nome_base_latt = '"+ sNomeBase +"' AND lattaggio = '"+ dQtaLatta.ToString().Replace(',', '.') +"'";
            if (unita == eUnita.LT)
            {
                sql += " AND unita_lattaggio = 'L'";
            }
            else
            {
                sql += " AND unita_lattaggio = 'KG'";
            }

            DataTable dt = dbconnector.SQLQuerySelect(sql);
            if (dt.Rows.Count == 0) { return 0.01d; }

            double costo = Convert.ToDouble(dt.Rows[0]["costo_lattaggio"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            if (costo < 0.01d) costo = 0.01d;

            return costo;
        }

        public double GetCostoColorante(string sNome, double dQta, double dDensita, Library.Formulation.eUnita unita)
        {
            string sql = "SELECT costo, unita FROM pig_costi WHERE id_listino = " + IDListino + " AND nome_pigmento = '"+ sNome +"'";
            DataTable dt = dbconnector.SQLQuerySelect(sql);
            if (dt.Rows.Count == 0) { return 0.01d; }

            double costo = Convert.ToDouble(dt.Rows[0]["costo"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            Library.Formulation.eUnita dbunita = eUnita.LT;
            string sUnita = dt.Rows[0]["unita"].ToString().ToUpper();
            if (sUnita == "KG") { dbunita = eUnita.KG; }

            if (unita == dbunita)
            {
                costo *= dQta;
            }
            else
            {
                double qta = Library.Formulation.Formula.ConvertValue(dQta, unita, dbunita, dDensita);
                costo *= qta;
            }
            
            if (costo < 0.01d) costo = 0.01d;
            return costo;
        }
    }
}
