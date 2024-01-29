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
    /// Logika interakcji dla klasy UmowWizyteWindow.xaml
    /// </summary>
    public partial class UmowWizyteWindow : Window
    {
        Wizyta wizyta;
        Klinika? klinika;

        public UmowWizyteWindow()
        {
            InitializeComponent();

        }

            public UmowWizyteWindow(Wizyta w, Klinika? klinika) :this()
        {
            wizyta = w;
            if (klinika != null)
            {
                CmbLekarz.ItemsSource = klinika.Lekarze;
                CmbZwierze.ItemsSource = klinika.Zwierzeta;
            }

            CmbLekarz.SelectionChanged += CmbLekarz_SelectionChanged;
            CmbZwierze.SelectionChanged += CmbZwierze_SelectionChanged;
            CmbTerminy.SelectionChanged += CmbTerminy_SelectionChanged;
        }

        private void CmbLekarz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbLekarz.SelectedItem is Lekarz selectedLekarz)
            {
                CmbTerminy.ItemsSource = selectedLekarz.Harmonogram.Select(termin => termin.data);
                wizyta.Lekarz = selectedLekarz;
            }
        }

        private void CmbTerminy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbTerminy.SelectedItem != null)
            {
                wizyta.Data_wizyty = Convert.ToDateTime(CmbTerminy.SelectedItem);
            }
        }

        private void CmbZwierze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbZwierze.SelectedItem is Zwierze selectedZwierze)
            {
                wizyta.Zwierze = selectedZwierze;
            }
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            if (CmbLekarz.SelectedItem is Lekarz selectedLekarz)
            {
                wizyta.Lekarz = selectedLekarz;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Proszę wybrać lekarza.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (CmbTerminy.SelectedItem != null)
            {
                wizyta.Data_wizyty = Convert.ToDateTime(CmbTerminy.SelectedItem);
            }
            else
            {
                isValid = false;
                MessageBox.Show("Proszę wybrać termin.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (CmbZwierze.SelectedItem is Zwierze selectedZwierze)
            {
                wizyta.Zwierze = selectedZwierze;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Proszę wybrać zwierzę.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (string.IsNullOrEmpty(TxtPowod.Text))
            {
                isValid = false;
                MessageBox.Show("Pole 'Powód' nie może być puste.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                wizyta.Powod = TxtPowod.Text;
            }

            if (isValid)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                // Pozostaw okno otwarte w przypadku błędu.
            }
        }

        private void BtnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
