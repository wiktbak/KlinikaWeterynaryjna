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
using KlinikaWeterynaryjna;

namespace KlinikaGui_2
{
    
    public partial class WizytaWindow : Window
    {
        private Klinika? klinika;
        public WizytaWindow(Klinika? klinika)
        {
            InitializeComponent();
            this.klinika = klinika;

          
        }

        private void BtnWyswietlHistorieZwierzecia_Click(object sender, RoutedEventArgs e)
        {
            WizytyZwierzeciaWindowxaml w = new WizytyZwierzeciaWindowxaml(klinika);
            w.Show();
        }

        private void ZaplanowaneWizyty_Click(object sender, RoutedEventArgs e)
        {
            ZaplanowaneWizytyZwierzecia w = new ZaplanowaneWizytyZwierzecia(klinika);
            w.Show();
        }

        private void BtnUmowienieWizytyLekarza_Click(object sender, RoutedEventArgs e)
        {
            UmowionewizytyLekarza w = new UmowionewizytyLekarza(klinika);
            w.Show();

        }

        private void BtnUmowWizyte_Click(object sender, RoutedEventArgs e)
        {
            if (klinika != null)
            {
                Wizyta w = new();
                UmowWizyteWindow osw = new(w, klinika);
                bool? res = osw.ShowDialog();
                if (res == true && klinika is not null)
                {
                    klinika.DodawanieWizyty(w);
                    MessageBox.Show("Pomyślnie dodano wizyte");
                }
            }
        }


    }

}
