using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Logika interakcji dla klasy NoweZwierze.xaml
    /// </summary>
    
    public partial class NoweZwierze : Window
    {
        Zwierze zwierze;
        public NoweZwierze()
        {
            InitializeComponent();
        }


        public NoweZwierze(Zwierze z) :this()
        {
            zwierze = z;
            TxtImie.Text = zwierze.Imie;
            TxtGatunek.Text = zwierze.Gatunek;
            TxtWiek.Text = zwierze.Wiek.ToString();
            TxtImieWlasciciela.Text = zwierze.ImieWlasciciela;
            TxtNazwiskoWlasciciela.Text = zwierze.NazwiskoWlasciciela;
            TxtTelefonKontaktowy.Text = zwierze.TelefonKontaktowy;

    

        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            
            bool res = false;
            if (!string.IsNullOrEmpty(TxtGatunek.Text)
                && !string.IsNullOrEmpty(TxtImieWlasciciela.Text)
                && !string.IsNullOrEmpty(TxtNazwiskoWlasciciela.Text)
                && !string.IsNullOrEmpty(TxtTelefonKontaktowy.Text))
            {
                zwierze.Imie = TxtImie.Text;
                zwierze.Gatunek = TxtGatunek.Text;
                zwierze.Wiek = int.Parse(TxtWiek.Text);
                zwierze.ImieWlasciciela = TxtImieWlasciciela.Text;
                zwierze.NazwiskoWlasciciela = TxtNazwiskoWlasciciela.Text;
                zwierze.TelefonKontaktowy = TxtTelefonKontaktowy.Text;
                res = true;
            }
            else 
            {
               
                MessageBox.Show("Nie wszystkie kluczowe informacje zostały podane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DialogResult = res;
        }

        private void BtnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
