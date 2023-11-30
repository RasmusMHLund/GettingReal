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
        

        public ObservableCollection<Samling> merchandises { get; set; } = new ObservableCollection<Samling>();
        Samling samling = new Samling();
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Kategorier> Kategorier { get; set; } = new ObservableCollection<Kategorier>
        {
            new Kategorier("Merchandise"),
            new Kategorier("BærMerchandise"),
            new Kategorier("Firmagaver"),
            new Kategorier("Profilbeklædning")
        };
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GemProdukt()
        {
            Kategorier valgtKategoriObjekt = ValgtKategori;
            // Tjek om valgtKategoriObjekt er tildelt
            if (valgtKategoriObjekt != null)
            {
                
                Samling nytProdukt = new Samling    
                {
                    Navn = samling.Navn,
                    Varenummer = samling.Varenummer,
                    Pris = samling.Pris,
                    Kategori = valgtKategoriObjekt.NavnType
                };

                switch (valgtKategoriObjekt.NavnType)
                {
                    case "Merchandise":
                        merchandises.Add(nytProdukt);
                        MessageBox.Show($"Tilføjede ny Merchandise {samling.Navn}, {samling.Varenummer}, {samling.Pris}");
                        OnPropertyChanged(nameof(merchandises));
                        break;

                    // Tilføj flere cases for andre kategorier efter behov

                    default:
                        MessageBox.Show("Ukendt kategori");
                        break;
                }
            }
        }
    }

}



