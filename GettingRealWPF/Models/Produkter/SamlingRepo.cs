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
        public ObservableCollection<Samling> GetMerchandise()
        {
            // Returner en separat liste for Merchandise
            return new ObservableCollection<Samling>(samlingList);
        }

        public ObservableCollection<Samling> GetBærMerchandise()
        {
            // Returner en separat liste for BearMerchandise
            return new ObservableCollection<Samling>(samlingList);
        }

        public ObservableCollection<Samling> GetFirmagaver()
        {
            // Returner en separat liste for Firmagaver
            return new ObservableCollection<Samling>(samlingList);
        }

        public ObservableCollection<Samling> GetProfilbekledning()
        {
            // Returner en separat liste for Profilbekledning
            return new ObservableCollection<Samling>(samlingList);
        }
    }
}

