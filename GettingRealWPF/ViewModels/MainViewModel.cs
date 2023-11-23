using GettingRealWPF.Models.Produkter;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealWPF.ViewModels
{
    public class ProdukterViewModel
    {
        private SamlingRepo samlingRepo;
        public ObservableCollection<Samling> Samlinger { get; set; }
        /*public ProdukterViewModel(SamlingRepo repo)
        {
            samlingRepo = repo;
            Samlinger= new ObservableCollection<Samling>(samlingRepo.GetSamlingList());
        }*/
    }
}
