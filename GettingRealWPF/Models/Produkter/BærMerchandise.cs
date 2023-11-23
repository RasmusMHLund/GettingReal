using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    internal class BærMerchandise : Samling
    {
        public BærMerchandise(string navn, double pris, string varenummer) : base()
        {
            Navn = navn;
            Pris = pris;
            Varenummer = varenummer;
        }
        public BærMerchandise(string navn, double pris) : this(navn, pris, "")
        {
        }
        public BærMerchandise(string navn) : this(navn, 0, "")
        {
        }
    }
}
