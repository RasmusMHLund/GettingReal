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

        private string _navn;
        public string Navn
        {
            get { return _navn; }
            set
            {
                _navn = value;
                OnPropertyChanged(nameof(Navn));
            }
        }

        private double _pris;
        public double Pris
        {
            get { return _pris; }
            set
            {
                _pris = value;
                OnPropertyChanged(nameof(Pris));
            }
        }

        private string _varenummer;
        public string Varenummer
        {
            get { return _varenummer; }
            set
            {
                _varenummer = value;
                OnPropertyChanged(nameof(Varenummer));
            }
        }

        private string _kategori;
        public string Kategori
        {
            get { return _kategori; }
            set
            {
                _kategori = value;
                OnPropertyChanged(nameof(Kategori));
            }
        }

        public override string ToString()
        {
            return $"{Navn}, {Pris}, {Varenummer}";
        } 
    }
}
