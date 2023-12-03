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
using System.IO;
using System.Diagnostics;
using System.Printing;

namespace GettingRealWPF.ViewModels
{
    public class ProduktViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        private ObservableCollection<Merchandise> _merchandiseItems;
        public ObservableCollection<Merchandise> MerchandiseItems
        {
            get { return _merchandiseItems; }
            set
            {
                _merchandiseItems = value;
                OnPropertyChanged(nameof(MerchandiseItems));
            }
        }

        private ObservableCollection<BærMerchandise> _bærMerchandiseItems;
        public ObservableCollection<BærMerchandise> BærMerchandiseItems
        {
            get { return _bærMerchandiseItems; }
            set
            {
                _bærMerchandiseItems = value;
                OnPropertyChanged(nameof(BærMerchandiseItems));
            }
        }
        public ProduktViewModel()
        {
            // Initialize collections for different categories
            _merchandiseItems = new ObservableCollection<Merchandise>();
            _bærMerchandiseItems = new ObservableCollection<BærMerchandise>();
        }
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

        
        private string _selectedNavn;
        public string SelectedNavn
        {
            get { return _selectedNavn; }
            set
            {
                if (_selectedNavn != value)
                {
                    _selectedNavn = value;
                    OnPropertyChanged(nameof(SelectedNavn));
                }
            }
        }
        private string _selectedVarenummer;
        public string SelectedVarenummer
        {
            get { return _selectedVarenummer; }
            set
            {
                if (_selectedVarenummer != value)
                {
                    _selectedVarenummer = value;
                    OnPropertyChanged(nameof(SelectedVarenummer));
                }
            }
        }

        private double _selectedPris;
        public double SelectedPris
        {
            get { return _selectedPris; }
            set
            {
                if (_selectedPris != value)
                {
                    _selectedPris = value;
                    OnPropertyChanged(nameof(SelectedPris));
                }
            }
        }
        private void LoadData() // Skal laves 
        {
            
        }
        
        public void GemProdukt()
        {
            Kategorier valgtKategoriObjekt = ValgtKategori;

            if (valgtKategoriObjekt != null)
            {
                switch (valgtKategoriObjekt.NavnType)
                {
                    case "Merchandise":
                        Merchandise nytMerch = new Merchandise()
                        {
                            Navn = SelectedNavn,
                            Varenummer = SelectedVarenummer,
                            Pris = SelectedPris,
                            Kategori = valgtKategoriObjekt.NavnType
                        };
                        SaveToTextFile(nytMerch);
                        MerchandiseItems.Add(nytMerch);
                        MessageBox.Show($"Tilføjede ny Merchandise {SelectedNavn}, {SelectedVarenummer}, {SelectedPris}");
                        OnPropertyChanged(nameof(MerchandiseItems));
                        break;

                    case "BærMerchandise":
                        BærMerchandise nytBærMerch = new BærMerchandise()
                        {
                            Navn = SelectedNavn,
                            Varenummer = SelectedVarenummer,
                            Pris = SelectedPris,
                            Kategori = valgtKategoriObjekt.NavnType
                        };
                        SaveToTextFile(nytBærMerch);
                        BærMerchandiseItems.Add(nytBærMerch);
                        MessageBox.Show($"Tilføjede ny BærMechandise {SelectedNavn}, {SelectedVarenummer}, {SelectedPris}");
                        OnPropertyChanged(nameof(BærMerchandiseItems));
                        
                        break;

                        // Tilføj flere cases her
                    

                    default:
                        MessageBox.Show("Ukendt kategori");
                        break;
                }
            }
        }
        
        
        private void SaveToTextFile(Samling samling)
        {
            
            string filePath = $"{samling.Kategori}Data.txt";

            try
            {
                // Check if the file exists, if not, create a new one
                if (!File.Exists(filePath))
                {
                    using (StreamWriter createFile = File.CreateText(filePath))
                    {
                        // Write a header or any initial content if needed
                        createFile.WriteLine("Navn, Varenummer, Pris");
                    }
                }

                // Use StreamWriter to append the information to the text file
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    
                    // Format the information and write it to the file
                    string dataLine = $"{samling.Navn}, {samling.Varenummer}, {samling.Pris}";
                    writer.WriteLine(dataLine);
                }

                // Update the corresponding ObservableCollection
                if (samling is Merchandise merchandise)
                {
                    MerchandiseItems.Add(merchandise);
                    OnPropertyChanged(nameof(MerchandiseItems));

                }
                else if (samling is BærMerchandise bærMerchandise)
                {
                    BærMerchandiseItems.Add(bærMerchandise);
                    OnPropertyChanged(nameof(BærMerchandiseItems));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der skete en fejl");
               
            }
        }
    }

}



