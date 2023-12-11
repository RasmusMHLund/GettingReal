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
using GettingRealWPF.Views;

namespace GettingRealWPF.Views
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            
            // Validate username and password
            if (username == "Admin" && password == "AdminLogin123")
            {
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Forkerte login oplysninger, prøv igen.");
                DialogResult = false;
                
            }
        }

    }
}
