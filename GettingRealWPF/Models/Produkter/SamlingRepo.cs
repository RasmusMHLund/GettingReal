using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class SamlingRepo
    {
       

        public ObservableCollection<Samling> Merchandise { get; set; } = new ObservableCollection<Samling>();
        public ObservableCollection<Samling> BærMerchandise { get; set; } = new ObservableCollection<Samling>();
        public ObservableCollection<Samling> Firmagaver { get; set; } = new ObservableCollection<Samling>();
        public ObservableCollection<Samling> Profilbeklædning { get; set; } = new ObservableCollection<Samling>();

        
        public SamlingRepo()
        {
            // Du kan initialisere eller udføre anden opsætning her
            // For eksempel, tilføj nogle standardværdier til listerne
           /*  Merchandise.Add(new Samling { Navn = "Standard Merchandise", Varenummer = "123", Pris = 19.99, Kategori = "Merchandise" });
            BærMerchandise.Add(new Samling { Navn = "Standard BærMerchandise", Varenummer = "456", Pris = 29.99, Kategori = "BærMerchandise" });
            Firmagaver.Add(new Samling { Navn = "Standard Firmagaver", Varenummer = "789", Pris = 39.99, Kategori = "Firmagaver" });
            Profilbeklædning.Add(new Samling { Navn = "Standard Profilbeklædning", Varenummer = "012", Pris = 49.99, Kategori = "Profilbeklædning" }); */
        }
        public ObservableCollection<Samling> GetMerchandise()
        {
            return new ObservableCollection<Samling>(Merchandise);
        }

        public ObservableCollection<Samling> GetBærMerchandise()
        {
            return new ObservableCollection<Samling>(BærMerchandise);
        }

        public ObservableCollection<Samling> GetFirmagaver()
        {
            return new ObservableCollection<Samling>(Firmagaver);
        }

        public ObservableCollection<Samling> GetProfilbeklædning()
        {
            return new ObservableCollection<Samling>(Profilbeklædning);
        }
    }

}


