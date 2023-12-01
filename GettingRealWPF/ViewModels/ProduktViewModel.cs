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

namespace GettingRealWPF.ViewModels
{
    public class ProduktViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Merchandise> _merchandises;
        public ObservableCollection<Merchandise> Merchandises
        {
            get { return _merchandises; }
            set
            {
                _merchandises = value;
                OnPropertyChanged(nameof(Merchandises));
            }
        }

        //  public ObservableCollection<Samling> Merchandises { get; set; } = new ObservableCollection<Samling>();
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
        private ObservableCollection<string> _textFileContentLines;

        public ObservableCollection<string> TextFileContentLines
        {
            get { return _textFileContentLines; }
            set
            {
                _textFileContentLines = value;
                OnPropertyChanged(nameof(TextFileContentLines));
            }
        }
        public ProduktViewModel()
        {
            // Initialize Merchandises
            _merchandises = new ObservableCollection<Merchandise>();
        }

        public void GemProdukt()
        {
            Kategorier valgtKategoriObjekt = ValgtKategori;
            
            if (valgtKategoriObjekt != null)
            {
                
               
                switch (valgtKategoriObjekt.NavnType)
                {
                    case "Merchandise":
                        Merchandise nytProdukt = new Merchandise()
                        {
                            Navn = SelectedNavn,
                            Varenummer = SelectedVarenummer,
                            Pris = SelectedPris,
                            Kategori = ValgtKategori.NavnType
                        };
                        SaveToTextFile(nytProdukt);
                        MessageBox.Show($"Tilføjede ny Merchandise {SelectedNavn}, {SelectedVarenummer}, {SelectedPris}");
                        OnPropertyChanged(nameof(Merchandises));
                        break;

                    // Tilføj flere cases for andre kategorier efter behov

                    default:
                        MessageBox.Show("Ukendt kategori");
                        break;
                }
            }
        }
        private void SaveToTextFile(Merchandise merchandise)
        {
            // Specify the file path (you can customize this path)
            string filePath = "MerchandiseData.txt";

            // Check if the file exists, if not, create a new one
            if (!File.Exists(filePath))
            {
                using (StreamWriter createFile = File.CreateText(filePath))
                {
                    // Write a header or any initial content if needed
                    createFile.WriteLine("Navn, Varenummer, Pris, Kategori");
                }
            }

            // Use StreamWriter to append the information to the text file
            using (StreamWriter writer = File.AppendText(filePath))
            {
                // Format the information and write it to the file
                string dataLine = $"{merchandise.Navn}, {merchandise.Varenummer}, {merchandise.Pris}, {merchandise.Kategori}";
                writer.WriteLine(dataLine);
            }

            // Read the content of the file and update the TextFileContentLines property
            TextFileContentLines = new ObservableCollection<string>(File.ReadAllLines(filePath));
        }

    }

}



