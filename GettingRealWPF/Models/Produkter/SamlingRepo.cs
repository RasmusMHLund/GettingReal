using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    internal class SamlingRepo
    {
        private ObservableCollection<Samling> samlingList = new ObservableCollection<Samling>();

        public void AddSamling(Samling samling)
        {
            samlingList.Add(samling);
        }
        public void RemoveSamling(Samling samling)
        {
            samlingList.Remove(samling);
        }
        public ObservableCollection<Samling> SamlingList
        {
            get { return samlingList; }
            set { samlingList = value; }
        }
    }
}

