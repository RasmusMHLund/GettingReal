using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GettingRealWPF.Models.Produkter;
using GettingRealWPF.ViewModels;
using GettingRealWPF.Views;

namespace GettingRealWPF
{
    /// <summary>
    /// Interaction logic for WindowProdukter.xaml
    /// </summary>
    public partial class WindowProdukter : Window
    {
        private ProduktViewModel viewModel;

        public WindowProdukter()
        {
            InitializeComponent();
            viewModel = new ProduktViewModel();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TilføjProdukt tilføjProdukt = new TilføjProdukt(viewModel);
            tilføjProdukt.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Tjekker hvilken listbox der er markeret ved hjælp af count
            if (listBoxMerchandise.SelectedItems.Count > 0)
            {
                viewModel.RemoveSelectedItems(viewModel.MerchandiseItems, listBoxMerchandise);
                viewModel.UpdateTextFile("Merchandise", viewModel.MerchandiseItems);
            }
            else if (listBoxBærMerchandise.SelectedItems.Count > 0)
            {
                viewModel.RemoveSelectedItems(viewModel.BærMerchandiseItems, listBoxBærMerchandise);
                viewModel.UpdateTextFile("BærMerchandise", viewModel.BærMerchandiseItems);
            }
            else if (listBoxFirmagaver.SelectedItems.Count > 0)
            {
                viewModel.RemoveSelectedItems(viewModel.FirmagaverItems, listBoxFirmagaver);
                viewModel.UpdateTextFile("Firmagaver", viewModel.FirmagaverItems);
            }
            else if (listBoxProfilbeklædning.SelectedItems.Count > 0)
            {
                viewModel.RemoveSelectedItems(viewModel.ProfilbeklædningItems, listBoxProfilbeklædning);
                viewModel.UpdateTextFile("Profilbeklædning", viewModel.ProfilbeklædningItems);
            }
        }


    }
}
