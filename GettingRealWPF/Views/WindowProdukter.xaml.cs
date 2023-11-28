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
        private ProduktViewModel viewModel; // viewModel.Merchandise.Add() for at tilføje til de enkelte elementer
        public WindowProdukter()
        {
            InitializeComponent();

            viewModel = new ProduktViewModel(); // Hvis `viewModel` er en klassevariabel
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TilføjProdukt tilføjProdukt = new TilføjProdukt();
            tilføjProdukt.Show();
        }
    }
}
