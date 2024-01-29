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
using KlinikaWeterynaryjna;

namespace KlinikaGui_2
{
    /// <summary>
    /// Logika interakcji dla klasy NowyLekarz.xaml
    /// </summary>
    public partial class NowyLekarz : Window
    {
        Lekarz lekarz;
        public NowyLekarz()
        {
            InitializeComponent();
        }

        public NowyLekarz(Lekarz l) : this()
        {
            lekarz = l;
            TxtImieLekarza.Text = lekarz.ImieLekarza;
            TxtNazwiskoLekarza.Text = lekarz.NazwiskoLekarza;
            CmbSpecjalizacja.ItemsSource = Enum.GetValues(typeof(EnumSpecjalizacja));
            CmbSpecjalizacja.SelectedItem = lekarz.Specjalizacja;

        }


        private void BtnZatwierdzL_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;
            if (!string.IsNullOrEmpty(TxtImieLekarza.Text)
                && !string.IsNullOrEmpty(TxtNazwiskoLekarza.Text)
                && !string.IsNullOrEmpty(CmbSpecjalizacja.Text))

            {
                lekarz.ImieLekarza = TxtImieLekarza.Text;
                lekarz.NazwiskoLekarza = TxtNazwiskoLekarza.Text;
                if (Enum.TryParse(typeof(EnumSpecjalizacja), CmbSpecjalizacja.Text, out object specjalizacja))
                {
                    lekarz.Specjalizacja = (EnumSpecjalizacja)specjalizacja;
                    res = true;
                }
                else
                {
                    MessageBox.Show("Nieprawidłowa specjalizacja.");
                }

                res = true;
            }
            else
            {
                MessageBox.Show("Nie wszystkie kluczowe informacje zostały podane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DialogResult = res;
        }

        private void BtnAnulujL_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

       
    }
}
