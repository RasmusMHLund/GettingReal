using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class Merchandise : Samling 
    {
        public Merchandise(string navn, string varenummer, double pris) : base()
        {
            Navn = navn;
            Pris = pris;
            Varenummer = varenummer;
        }
        public Merchandise(string navn, double pris) : this(navn, "", pris)
        {
        }
        public Merchandise(string navn) : this(navn, "", 0)
        {
        }
        public Merchandise()
        {
            // Initialize default values or leave properties uninitialized
        }



    }
}
