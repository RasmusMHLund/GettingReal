using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class Kategorier
    {
        public string NavnType { get; set; }

        public Kategorier(string navnType)
        {
            NavnType = navnType;
        }
    }
}
