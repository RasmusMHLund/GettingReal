using GettingRealWPF.Models.Produkter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealWPF.Models;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

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

        // De 4 lister 
        public ObservableCollection<Samling> Merchandise { get; set; }
        public ObservableCollection<Samling> BærMerchandise { get; set; }
        public ObservableCollection<Samling> Firmagaver { get; set; }
        public ObservableCollection<Samling> Profilbekledning { get; set; }

        // Comboboxen
        public ObservableCollection<Kategorier> Kategorier { get; set; } = new ObservableCollection<Kategorier> 
        {
            new Kategorier("Merchandise"),
            new Kategorier("BærMerchandise"),
            new Kategorier("Firmagaver"),
            new Kategorier("Profilbeklædning")
        };
       
        // Indsamler data til listerne (virker ikke?)
        public ProduktViewModel()
        {
           
            Merchandise = new ObservableCollection<Samling>(samlingRepository.GetMerchandise());
            BærMerchandise = new ObservableCollection<Samling>(samlingRepository.GetBærMerchandise());
            Firmagaver = new ObservableCollection<Samling>(samlingRepository.GetFirmagaver());
            Profilbekledning = new ObservableCollection<Samling>(samlingRepository.GetProfilbekledning());

        }

        private Kategorier valgtKategori;
        public Kategorier ValgtKategori
        {
            get { return valgtKategori; }
            set
            {
                valgtKategori = value;
                OnPropertyChanged(nameof(ValgtKategori));
            }
        }


        private string navn;
        public string Navn
        {
            get { return navn; }
            set
            {
                navn = value;
                OnPropertyChanged(nameof(Navn));
            }
        }

        private string varenummer;
        public string Varenummer
        {
            get { return varenummer; }
            set
            {
                varenummer = value;
                OnPropertyChanged(nameof(Varenummer));
            }
        }

        private double pris;
        public double Pris
        {
            get { return pris; }
            set
            {
                pris = value;
                OnPropertyChanged(nameof(Pris));
            }
        }
        public void GemProdukt() // Tilføjelse af produkter (gem)
        {
            // Hent det valgte Kategorier-objekt fra ComboBox'en
            Kategorier valgtKategoriObjekt = ValgtKategori;


            if (valgtKategoriObjekt != null)
            {
                Samling nytProdukt = new Samling
                {
                    Navn = Navn,
                    Varenummer = Varenummer,
                    Pris = Pris,
                    Kategori = valgtKategoriObjekt.NavnType
                };

                // Tilføj det nye produkt til den relevante liste baseret på valgt kategori
                switch (valgtKategoriObjekt.NavnType)
                {
                    case "Merchandise":
                        Merchandise.Add(nytProdukt);
                        MessageBox.Show("Tilføjede ny Merchandise");
                        OnPropertyChanged(nameof(Merchandise));
                        break;
                    case "BærMerchandise":
                        BærMerchandise.Add(nytProdukt);
                        MessageBox.Show("Tilføjede ny BærMerchandise");
                        OnPropertyChanged(nameof(BærMerchandise));
                        break;
                    case "Firmagaver":
                        Firmagaver.Add(nytProdukt);
                        MessageBox.Show("Tilføjede ny Firmagaver");
                        OnPropertyChanged(nameof(Firmagaver));
                        break;
                    case "Profilbeklædning":
                        Profilbekledning.Add(nytProdukt);
                        MessageBox.Show("Tilføjede ny Profilbeklædning");
                        OnPropertyChanged(nameof(Profilbekledning));
                        break;
                    default:
                        MessageBox.Show("Ukendt kategori");
                        break;
                }
            }
        }
    }
}


