using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    internal class SamlingRepo
    {
       private List<Samling> samlingList = new List<Samling>();

        public void AddSamling(Samling samling)
        {
            samlingList.Add(samling);
        }
        public void RemoveSamling(Samling samling)
        {
            samlingList.Remove(samling);
        }
        public List<Samling > GetSamlingList()
        {
            return samlingList;
        }
    }
}

