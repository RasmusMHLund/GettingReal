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
using GettingRealWPF.ViewModels;
using GettingRealWPF.Views;


namespace GettingRealWPF
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
           
        }

        private void KundeLogin(object sender, RoutedEventArgs e)
        {

            TilmeldKunde tilmeldKunde = new TilmeldKunde();
            tilmeldKunde.Show();
            Close();
        }

        private void AdminLogin(object sender, RoutedEventArgs e)
        {
            // Open the LoginWindow
            var adminLogin = new AdminLogin();
            if (adminLogin.ShowDialog() == true)
            {
                // Login successful, open the MainWindow
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Handle login failure or cancellation
            }
        }
    }
}
