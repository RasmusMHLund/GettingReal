using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class BærMerchandise : Samling
    {
        public BærMerchandise(string navn, string varenummer, double pris) : base()
        {
            Navn = navn;
            Pris = pris;
            Varenummer = varenummer;
        }
        public BærMerchandise(string navn, double pris) : this(navn, "", pris)
        {
        }
        public BærMerchandise(string navn) : this(navn, "", 0)
        {
        }
        public BærMerchandise()
        {
            // Initialize default values or leave properties uninitialized
        }
    }
}
