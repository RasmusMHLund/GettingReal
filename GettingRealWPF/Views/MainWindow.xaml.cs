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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GettingRealWPF.Views;

namespace GettingRealWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Brev_Click(object sender, RoutedEventArgs e)
        {
            BrevWindow brevWindow = new BrevWindow();
            brevWindow.Show();
        }

        private void produkt_Click(object sender, RoutedEventArgs e)
        {
            WindowProdukter windowProdukter = new WindowProdukter();
            windowProdukter.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowAbonnementer windowAbonnementer = new WindowAbonnementer();
            windowAbonnementer.Show();
        }
    }
}
