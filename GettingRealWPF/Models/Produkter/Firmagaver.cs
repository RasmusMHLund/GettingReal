using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class Firmagaver : Samling
    {
        public Firmagaver(string navn, string varenummer, double pris) : base()
        {
            Navn = navn;
            Pris = pris;
            Varenummer = varenummer;
        }
        public Firmagaver(string navn, double pris) : this(navn, "", pris)
        {
        }
        public Firmagaver(string navn) : this(navn, "", 0)
        {
        }
        public Firmagaver()
        {
        }
    }
}