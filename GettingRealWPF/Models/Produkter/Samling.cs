using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class Samling
    {
        public string Navn { get; set; }
        public double Pris {  get; set; }
        public string Varenummer { get; set; }
        
        public override string ToString()
        {
            return $"Navn: {Navn}, Pris: {Pris}, Varenummer: {Varenummer}";
        }
    }
}
