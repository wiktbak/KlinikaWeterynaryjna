using KlinikaWeterynaryjna;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KlinikaGui_2
{
    /// <summary>
    /// Logika interakcji dla klasy LekarzWindow.xaml
    /// </summary>
    public partial class LekarzWindow : Window
    {
        private Klinika? klinika;
        public LekarzWindow(Klinika? klinika)
        {
            InitializeComponent();
            this.klinika = klinika;

            if (klinika != null)
            {
                LstLekarze.ItemsSource = new ObservableCollection<Lekarz>(klinika.Lekarze);
            }
            else
            {
                MessageBox.Show("Plik xml jest pusty");
            }
        }

        private void BtnDodajLekarza_Click(object sender, RoutedEventArgs e)
        {
            Lekarz l = new();
            NowyLekarz osw = new(l);
            bool? res = osw.ShowDialog();
            if (res == true && klinika is not null)
            {
                klinika.DodawanieLekarza(l);
                LstLekarze.ItemsSource =
                    new ObservableCollection<Lekarz>(klinika.Lekarze);
            }
        }

        private void BtnUsunLekarza_Click(object sender, RoutedEventArgs e)
        {
            if (LstLekarze.SelectedIndex > -1 && klinika is not null)
            {
                klinika.UsuwanieLekarza(LstLekarze.SelectedItem as Lekarz);
                LstLekarze.ItemsSource = new ObservableCollection<Lekarz>(klinika.Lekarze);
            }
        }

        private void BtnSortujNazwisko_Click(object sender, RoutedEventArgs e)
        {
            if (klinika is not null)
            {
                klinika.SortujLekarzy();
                LstLekarze.ItemsSource = new ObservableCollection<Lekarz>(klinika.Lekarze);
            }
        }
    }
}
