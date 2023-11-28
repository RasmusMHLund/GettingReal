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
        public TilføjProdukt()
        {
            InitializeComponent();

            viewModel = new ProduktViewModel();
            DataContext = viewModel;
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void GemProdukt_Click(object sender, RoutedEventArgs e)
        {
            // Få oplysningerne fra tekstboksene
            string navn = ProduktType.Text;
            string varenummer = Varenummer.Text;

            // Tjek om prisen er en gyldig double
            if (!double.TryParse(Pris.Text, out double pris))
            {
                MessageBox.Show("Ugyldig prisformat.");
                return;
            }

            // Få den valgte kategori fra ComboBoxen
            string valgtKategori = ProduktType.SelectedItem as string;

            // Tjek om en kategori er valgt
            if (string.IsNullOrEmpty(valgtKategori))
            {
                MessageBox.Show("Vælg venligst en kategori.");
                return;
            }

            // Opret et nyt produkt baseret på oplysningerne
            Samling nytProdukt = new Samling
            {
                Navn = navn,
                Varenummer = varenummer,
                Pris = pris,
                Kategori = valgtKategori
            };

            // Tilføj det nye produkt til den passende ObservableCollection baseret på kategori
            switch (valgtKategori)
            {
                case "Merchandise":
                    viewModel.Merchandise.Add(nytProdukt);
                    break;

                case "BærMerchandise":
                    viewModel.BærMerchandise.Add(nytProdukt);
                    break;

                case "Firmagaver":
                    viewModel.Firmagaver.Add(nytProdukt);
                    break;

                case "Profilbekledning":
                   viewModel.Profilbekledning.Add(nytProdukt);
                    break;

                default:
                    MessageBox.Show("Ukendt kategori.");
                    break;
            }

            // Meddelelse om, at produktet blev gemt
            MessageBox.Show("Produktet blev gemt!");
        }

    }
}
