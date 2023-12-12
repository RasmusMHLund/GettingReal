using GettingRealWPF.ViewModels;
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
using GettingRealWPF.ViewModels;
using System.Runtime.CompilerServices;

namespace GettingRealWPF.Views
{
    public partial class WindowAbonnementer : Window
    {
        private KundeViewModel viewModel;
        public WindowAbonnementer()
        {
            InitializeComponent();
            viewModel = new KundeViewModel();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TilføjKunde(object sender, RoutedEventArgs e)
        {
            TilmeldKunde tilmeldKunde = new TilmeldKunde();
            tilmeldKunde.Show();
            Close();
        }

        private void FjernKunde_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveSelectedKunde(viewModel.KundeInfo, Kundeliste);
            viewModel.UpdateTextFile(viewModel.KundeInfo);
        }

        private void SendNyhedsbrev_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nyhedsbrev sendt til valgte kunder");
        }
    }
}
