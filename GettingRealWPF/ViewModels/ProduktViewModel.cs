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
using System.Windows.Controls;

namespace GettingRealWPF.ViewModels
{
    public class ProduktViewModel : INotifyPropertyChanged 
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        private ObservableCollection<Samling> _merchandiseItems;
        public ObservableCollection<Samling> MerchandiseItems
        {
            get { return _merchandiseItems; }
            set
            {
                _merchandiseItems = value;
                OnPropertyChanged(nameof(MerchandiseItems));
            }
        }

        private ObservableCollection<Samling> _bærMerchandiseItems;
        public ObservableCollection<Samling> BærMerchandiseItems
        {
            get { return _bærMerchandiseItems; }
            set
            {
                _bærMerchandiseItems = value;
                OnPropertyChanged(nameof(BærMerchandiseItems));
            }
        }

        private ObservableCollection<Samling> _firmagaverItems;

        public ObservableCollection<Samling> FirmagaverItems
        {
            get { return _firmagaverItems; }

            set 
            {
                _firmagaverItems = value;
                OnPropertyChanged(nameof(FirmagaverItems));
            }
        }

        private ObservableCollection<Samling> _profilbeklædningItems;
        public ObservableCollection<Samling> ProfilbeklædningItems
        {
            get { return _profilbeklædningItems; }

            set
            {
                _profilbeklædningItems = value;
                OnPropertyChanged(nameof(ProfilbeklædningItems));
            }
        }
        public ProduktViewModel()
        {

            // Instasiere de forskellige collections og kalder med Load metoderne
           
            _merchandiseItems = new ObservableCollection<Samling>();
            _bærMerchandiseItems = new ObservableCollection<Samling>();
            _firmagaverItems = new ObservableCollection<Samling>();
            _profilbeklædningItems = new ObservableCollection<Samling>();

            LoadDataFromTxt("MerchandiseData.txt", MerchandiseItems);
            LoadDataFromTxt("BærMerchandiseData.txt", BærMerchandiseItems);
            LoadDataFromTxt("FirmagaverData.txt", FirmagaverItems);
            LoadDataFromTxt("ProfilbeklædningData.txt", ProfilbeklædningItems);
        }

        // Bindet til dropdown menuen
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

        private void LoadDataFromTxt(string fileName, ObservableCollection<Samling> collection)
        {
            // Opret filstien baseret på den relative sti
            string filePath = $"{fileName}";

            // Kontroller om filen eksisterer
            if (File.Exists(filePath))
            {
                // Åbn en StreamReader for at læse filen
                using (StreamReader reader = new StreamReader(filePath))
                {
                   
                    // Læs filen linje for linje
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        // Del linjen i dele ved komma
                        string[] parts = line.Split(',');

                        // Kontroller, om der er mindst 3 dele
                        if (parts.Length >= 3)
                        {
                            Samling samling = new Samling()
                            {
                                Navn = parts[0].Trim(),
                                Varenummer = parts[1].Trim(),
                                
                            };

                            // Kontroller og konverter prisen - konvertering fra string til double
                            if (double.TryParse(parts[2].Trim(), out double pris))
                            {
                                samling.Pris = pris;
                            }

                            // Tilføj samlingen til ObservableCollection
                            collection.Add(samling);
                        }
                    }
                }

                // Opdater visningen ved at udløse PropertyChanged-eventet
                OnPropertyChanged(nameof(collection));
            }
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
                        MessageBox.Show($"Tilføjede ny BærMechandise {SelectedNavn}, {SelectedVarenummer}, {SelectedPris}");
                        
                        OnPropertyChanged(nameof(BærMerchandiseItems));
                        break;

                    case "Firmagaver":
                        Firmagaver nytFirmagaver = new Firmagaver()
                        {
                            Navn = SelectedNavn,
                            Varenummer = SelectedVarenummer,
                            Pris = SelectedPris,
                            Kategori = valgtKategoriObjekt.NavnType
                        };
                        SaveToTextFile(nytFirmagaver);
                        MessageBox.Show($"Tilføjede ny Firmagaver {SelectedNavn}, {SelectedVarenummer}, {SelectedPris}");
                        OnPropertyChanged(nameof(FirmagaverItems));
                        break;

                    case "Profilbeklædning":
                        Profilbeklædning nytProfilbeklædning = new Profilbeklædning()
                        {
                            Navn = SelectedNavn,
                            Varenummer = SelectedVarenummer,
                            Pris = SelectedPris,
                            Kategori = valgtKategoriObjekt.NavnType
                        };
                        SaveToTextFile(nytProfilbeklædning);
                        MessageBox.Show($"Tilføjede ny Profilbeklædning {SelectedNavn}, {SelectedVarenummer}, {SelectedPris}");
                        OnPropertyChanged(nameof(ProfilbeklædningItems));
                        break;
          
                    default:
                        MessageBox.Show("Ukendt kategori");
                        break;
                }
            }
        }
        
        
        private void SaveToTextFile(Samling samling)
        {
            
            string filePath = $"{samling.Kategori}Data.txt";

            
                // Check if the file exists, if not, create a new one
                if (!File.Exists(filePath))
                {
                    using (StreamWriter createFile = File.CreateText(filePath))
                    {
                         // Laver en fil hvis filen ikke eksitere ved navn filpath  
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
                else if (samling is Firmagaver firmagaver) 
                {
                    FirmagaverItems.Add(firmagaver);
                    OnPropertyChanged(nameof(FirmagaverItems));
                }
                else if (samling is Profilbeklædning profilbeklædning) 
                {
                    ProfilbeklædningItems.Add(profilbeklædning);
                    OnPropertyChanged(nameof(profilbeklædning));
                }
        }
    }
}



