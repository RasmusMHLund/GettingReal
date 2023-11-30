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
        public SamlingRepo Samling { get; set; }

        public SamlingRepo samling = new SamlingRepo();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Comboboxen
        public ObservableCollection<Kategorier> Kategorier { get; set; } = new ObservableCollection<Kategorier>
        {
            new Kategorier("Merchandise"),
            new Kategorier("BærMerchandise"),
            new Kategorier("Firmagaver"),
            new Kategorier("Profilbeklædning")
        };

        // Constructor
        public ProduktViewModel()
        {
            // Initialisér listerne fra SamlingRepo
            Samling = new SamlingRepo
            {
                Merchandise = samling.GetMerchandise(),
                BærMerchandise = samling.GetBærMerchandise(),
                Firmagaver = samling.GetFirmagaver(),
                Profilbeklædning = samling.GetProfilbeklædning()
            };
        }

        // De 4 lister

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

        public void GemProdukt()
        {
            SamlingRepo samlingRepo = new SamlingRepo();
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

                switch (valgtKategoriObjekt.NavnType)
                {
                    case "Merchandise":
                        Samling.Merchandise.Add(nytProdukt);
                        MessageBox.Show($"Tilføjede ny Merchandise {Navn}, {Varenummer}, {Pris}");
                        OnPropertyChanged(nameof(Samling.Merchandise));
                        break;
                    case "BærMerchandise":
                        Samling.BærMerchandise.Add(nytProdukt);
                        MessageBox.Show($"Tilføjede ny BærMerchandise {Navn}, {Varenummer}, {Pris}");
                        OnPropertyChanged(nameof(Samling.BærMerchandise));
                        break;
                    case "Firmagaver":
                        Samling.Firmagaver.Add(nytProdukt);
                        MessageBox.Show($"Tilføjede ny Firmagaver {Navn}, {Varenummer}, {Pris}");
                        OnPropertyChanged(nameof(Samling.Firmagaver));
                        break;
                    case "Profilbeklædning":
                        Samling.Profilbeklædning.Add(nytProdukt);
                        MessageBox.Show($"Tilføjede ny Profilbeklædning {Navn}, {Varenummer}, {Pris}");
                        OnPropertyChanged(nameof(Samling.Profilbeklædning));
                        break;
                    default:
                        MessageBox.Show("Ukendt kategori");
                        break;
                }
            }
        }
    }
}



