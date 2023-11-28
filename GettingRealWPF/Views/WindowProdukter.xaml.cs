﻿using System;
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

            ProduktViewModel viewModel = new ProduktViewModel();
            DataContext = viewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
