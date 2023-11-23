using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    internal class Profilbeklædning : Samling
    {
        public Profilbeklædning(string navn, double pris, string varenummer) : base()
        {
            Navn = navn;
            Pris = pris;
            Varenummer = varenummer;
        }
        public Profilbeklædning(string navn, double pris) : this(navn, pris, "")
        {
        }
        public Profilbeklædning(string navn) : this(navn, 0, "")
        {
        }
    }
}
