using GettingRealWPF.Models.Produkter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealWPF.Models;
using System.ComponentModel;

namespace GettingRealWPF.ViewModels
{
    class ProduktViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SamlingRepo samlingRepository = new SamlingRepo();

        public ObservableCollection<Samling> Merchandise { get; set; }
        public ObservableCollection<Samling> BærMerchandise { get; set; }
        public ObservableCollection<Samling> Firmagaver { get; set; }
        public ObservableCollection<Samling> Profilbekledning { get; set; }


        public ObservableCollection<Kategorier> Kategorier { get; set; } = new ObservableCollection<Kategorier> // Comboxoen
        {
            new Kategorier("Merchandise"), 
            new Kategorier("BærMerchandise"),
            new Kategorier("Firmagaver"),
            new Kategorier("Profilbeklædning")
        };

        public ProduktViewModel()
        {
            Merchandise = new ObservableCollection<Samling>(samlingRepository.GetMerchandise());
            BærMerchandise = new ObservableCollection<Samling>(samlingRepository.GetBærMerchandise());
            Firmagaver = new ObservableCollection<Samling>(samlingRepository.GetFirmagaver());
            Profilbekledning = new ObservableCollection<Samling>(samlingRepository.GetProfilbekledning());

        }
    }
}
