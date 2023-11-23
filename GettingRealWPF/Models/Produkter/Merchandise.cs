using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    internal class Merchandise : Samling
    {
        public Merchandise(string navn, double pris, string varenummer) : base()
        {
            Navn = navn;
            Pris = pris;
            Varenummer = varenummer;
        }
        public Merchandise(string navn, double pris) : this(navn, pris, "")
        {
        }
        public Merchandise(string navn) : this(navn, 0, "")
        {
        }
    }
}
