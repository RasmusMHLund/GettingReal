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
            
            // Validate username and password (replace with your authentication logic)
            if (username == "1" && password == "1")
            {
                MessageBox.Show("Login successful!");
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
                DialogResult = false;
                
            }
        }

    }
}
