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
using GettingRealWPF.Models.Produkter;
using System.Collections.ObjectModel;

namespace GettingRealWPF.Views
{
    /// <summary>
    /// Interaction logic for TilmeldKunde.xaml
    /// </summary>
    public partial class TilmeldKunde : Window
    {
        private KundeViewModel viewModel;


        public TilmeldKunde()
        {
            InitializeComponent();
            this.viewModel = new KundeViewModel(); // Initialize the viewModel
            DataContext = viewModel;
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            viewModel.AddKunde();
            
            
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                
                if (DataContext is KundeViewModel viewModel)
                {
                    viewModel.SelectedKategorier.Clear();

                    foreach (var selectedItem in listBox.SelectedItems)
                    {
                        if (selectedItem is Kategorier kategorie)
                        {
                            viewModel.SelectedKategorier.Add(kategorie);
                        }
                    }
                }
            }
        }

    }
}
