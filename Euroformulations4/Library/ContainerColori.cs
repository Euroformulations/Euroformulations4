using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library
{
    public class ContainerColori
    {
        private string _nome;
        private List<Colore> list = new List<Colore>();

        public ContainerColori(string Nome)
        {
            _nome = Nome;
        }

        public string Nome
        {
            get { return _nome; }
        }

        public object AddColor(Colore shade)
        {
            list.Add(shade);
            return null;
        }

        public List<Colore> ColoriReference()
        {
            return list;
        }

    }
}
