using GettingRealWPF.Models.Produkter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.Models
{
    public class Kunde : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Kunde(string mail)
        {
            
        }

        public Kunde()
        {
            
        }

        private ObservableCollection<Kategorier> _kategorier;
        public ObservableCollection<Kategorier> Kategorier
        {
            get { return _kategorier; }
            set
            {
                _kategorier = value;
                OnPropertyChanged(nameof(Kategorier));
            }
        }

        private string _mail;
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }

        public override string ToString()
        {
            return $"{Mail}";
        }
    }

}
