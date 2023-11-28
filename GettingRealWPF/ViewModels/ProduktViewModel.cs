using GettingRealWPF.Models.Produkter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealWPF.Models;

namespace GettingRealWPF.ViewModels
{
    class ProduktViewModel
    {
        private SamlingRepo samlingRepository;

        public ObservableCollection<Samling> Merchandise { get; set; }
        public ObservableCollection<Samling> BærMerchandise { get; set; }
        public ObservableCollection<Samling> Firmagaver { get; set; }
        public ObservableCollection<Samling> Profilbekledning { get; set; }

        public ProduktViewModel()
        {
            samlingRepository = new SamlingRepo();

            Merchandise = new ObservableCollection<Samling>(samlingRepository.GetMerchandise());
            BærMerchandise = new ObservableCollection<Samling>(samlingRepository.GetBærMerchandise());
            Firmagaver = new ObservableCollection<Samling>(samlingRepository.GetFirmagaver());
            Profilbekledning = new ObservableCollection<Samling>(samlingRepository.GetProfilbekledning());

        }
        
    }
}
