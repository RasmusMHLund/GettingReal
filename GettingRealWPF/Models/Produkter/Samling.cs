using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models.Produkter
{
    public class Samling : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private string kategori;
        public string Kategori
        {
            get { return kategori; }
            set
            {
                kategori = value;
                OnPropertyChanged(nameof(Kategori));
            }
        }

        public override string ToString()
        {
            return $"{Navn}, {Pris}, {Varenummer}, {Kategori}";
        }
    }
}
