using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class Profilbeklædning : Samling
    {
        public Profilbeklædning(string navn, string varenummer, double pris) : base()
        {
            Navn = navn;
            Pris = pris;
            Varenummer = varenummer;
        }
        public Profilbeklædning(string navn, double pris) : this(navn, "", pris)
        {
        }
        public Profilbeklædning(string navn) : this(navn, "", 0)
        {
        }
        public Profilbeklædning()
        {

        }
    }
}
