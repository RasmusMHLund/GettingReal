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
            return new ObservableCollection<Samling>(samlingList.Where(s => s.Kategori == "Merchandise"));
        }

        public ObservableCollection<Samling> GetBærMerchandise()
        {
            return new ObservableCollection<Samling>(samlingList.Where(s => s.Kategori == "BærMerchandise"));
        }

        public ObservableCollection<Samling> GetFirmagaver()
        {
            return new ObservableCollection<Samling>(samlingList.Where(s => s.Kategori == "Firmagaver"));
        }

        public ObservableCollection<Samling> GetProfilbekledning()
        {
            return new ObservableCollection<Samling>(samlingList.Where(s => s.Kategori == "Profilbekledning"));
        }



    }
}

