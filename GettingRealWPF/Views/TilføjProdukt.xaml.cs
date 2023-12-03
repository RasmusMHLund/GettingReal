using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
namespace GettingRealWPF.Views
{
    /// <summary>
    /// Interaction logic for TilføjProdukt.xaml
    /// </summary>
    public partial class TilføjProdukt : Window
    {

        private ProduktViewModel viewModel;
        public TilføjProdukt(ProduktViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void GemProdukt_Click(object sender, RoutedEventArgs e)
        {
            
            ProduktViewModel viewModel = DataContext as ProduktViewModel;
            viewModel.GemProdukt();

               
            
        }

    }
}
