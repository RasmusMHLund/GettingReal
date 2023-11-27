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

namespace GettingRealWPF.Views
{
    /// <summary>
    /// Interaction logic for WindowAbonnementer.xaml
    /// </summary>
    public partial class WindowAbonnementer : Window
    {
        public WindowAbonnementer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TilmeldKunde tilmeldKunde = new TilmeldKunde();
            tilmeldKunde.Show();
        }
    }
}
