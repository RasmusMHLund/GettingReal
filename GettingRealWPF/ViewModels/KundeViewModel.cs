using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GettingRealWPF.Models;
using GettingRealWPF.Models.Produkter;

namespace GettingRealWPF.ViewModels
{
    public class KundeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       

        private ObservableCollection<Kunde> _kundeInfo;
        public ObservableCollection<Kunde> KundeInfo
        {
            get { return _kundeInfo; }
            set
            {
                _kundeInfo = value;
                OnPropertyChanged(nameof(KundeInfo));
            }
        }

        private Kunde _selectedKunde;
        public Kunde SelectedKunde
        {
            get { return _selectedKunde; } 
            set
            {
                _selectedKunde = value;
                OnPropertyChanged(nameof(SelectedKunde));
            }
        }

        private string _selectedMail;
        public string SelectedMail
        {
            get { return _selectedMail; }
            set
            {
                _selectedMail = value;
                OnPropertyChanged(nameof(SelectedMail));
            }
        }

        public KundeViewModel()
        {
            _kundeInfo = new ObservableCollection<Kunde>();
            SelectedKategorier = new ObservableCollection<Kategorier>();
            LoadDataFromTxt("KundeData.txt", KundeInfo);
        }
        public ObservableCollection<Kategorier> Kategorier { get; set; } = new ObservableCollection<Kategorier>
        {
            new Kategorier("Merchandise"),
            new Kategorier("BærMerchandise"),
            new Kategorier("Firmagaver"),
            new Kategorier("Profilbeklædning")
        };
        private ObservableCollection<Kategorier> _selectedKategorier;
        public ObservableCollection<Kategorier> SelectedKategorier
        {
            get { return _selectedKategorier; }
            set
            {
                _selectedKategorier = value;
                OnPropertyChanged(nameof(SelectedKategorier));
            }
        }


        public void AddKunde()
        {
            string newMail = SelectedMail.Trim();

            if (!string.IsNullOrEmpty(newMail) && SelectedKategorier.Any())
            {
                Kunde kunde = new Kunde()
                {
                    Mail = newMail,
                    Kategorier = new ObservableCollection<Kategorier>(SelectedKategorier)
                };

                KundeInfo.Add(kunde);
                SaveToTextFile(newMail, SelectedKategorier);

                
                string selectedKategorierString = "";
                foreach (var kategori in SelectedKategorier)
                {
                    selectedKategorierString += kategori.NavnType + ", ";
                }

                // Fjern det sidste komma og mellemrum
                if (!string.IsNullOrEmpty(selectedKategorierString))
                {
                    selectedKategorierString = selectedKategorierString.Substring(0, selectedKategorierString.Length - 2);
                }

                MessageBox.Show($"Tilføjede ny mail: {newMail} Valgte interesser: {selectedKategorierString}");
                OnPropertyChanged(nameof(KundeInfo));
            }
            else
            {
                MessageBox.Show("Mail, og mindst en kategori skal være valgt.");
            }
        }



        private void SaveToTextFile(string mail, ObservableCollection<Kategorier> selectedKategorier)
        {
            string filePath = "KundeData.txt";

            if (!File.Exists(filePath))
            {
                using (StreamWriter createFile = File.CreateText(filePath))
                {
                }
            }

            using (StreamWriter writer = File.AppendText(filePath))
            {
                string line = $"{mail} - ";

                bool isFirstCategory = true;  

                foreach (var kategori in selectedKategorier)
                {
                    if (!isFirstCategory)
                    {
                        line += ", ";
                    }

                    line += kategori.NavnType;
                    isFirstCategory = false;  // Bruges til at se om den skal skrive komma efter en kategori. 
                }

                writer.WriteLine(line);
            }
        }

        private void LoadDataFromTxt(string fileName, ObservableCollection<Kunde> collection)
        {
            string filePath = $"{fileName}";

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Kunde kunde = new Kunde() { Mail = line };
                        collection.Add(kunde);
                    }
                }

                OnPropertyChanged(nameof(collection));
            }
        }

        public void RemoveSelectedKunde(ObservableCollection<Kunde> itemList, ListBox listBox)
        {
            // Konverter objekterne i SelectedItems til Kunde type
            var selectedItems = listBox.SelectedItems.Cast<Kunde>().ToList();

            foreach (var selectedItem in selectedItems)
            {
                itemList.Remove(selectedItem);
            }

            UpdateTextFile(itemList);
        }

        public void UpdateTextFile(ObservableCollection<Kunde> itemList)
        {
            string filePath = "KundeData.txt";

            // Konverter ObservableCollection til en liste og skriv listen til tekstfilen
            List<string> lines = new List<string>();

            foreach (var item in itemList)
            {
                lines.Add(item.ToString());
            }

            // Overskriv eksisterende fil med den opdaterede liste
            File.WriteAllLines(filePath, lines);
        }
    }
}
