using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
    /// Logika interakcji dla klasy ZwierzeWindow.xaml
    /// </summary>
    public partial class ZwierzeWindow : Window
    {
        private Klinika? klinika;

        public ZwierzeWindow(Klinika? klinika)
        {
            this.klinika = klinika;
            InitializeComponent();
            Title = $"Zwierze";

            if (klinika != null)
            {
                LstZwierzat.ItemsSource = new ObservableCollection<Zwierze>(klinika.Zwierzeta);
            }
            else
            {
                MessageBox.Show("Plik xml jest pusty");
            }
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {

            if (klinika != null)
            {
                Zwierze z = new();
                NoweZwierze osw = new(z);
                bool? res = osw.ShowDialog();
                if (res == true && klinika is not null)
                {
                    klinika.DodawanieZwierzecia(z);
                    LstZwierzat.ItemsSource = new ObservableCollection<Zwierze>(klinika.Zwierzeta);
                }
            }
            else
            {
                MessageBox.Show("Brak dostępu do danych Klinika");
            }
        }
        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                klinika.ZapiszXML(filename);
            }
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = Environment.CurrentDirectory;
            dlg.Filter = "xml files (*.zml)|*.xml"; ;
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                klinika = Klinika.OdczytXml(filename);
                if (klinika is not null)
                {

                    LstZwierzat.ItemsSource = new ObservableCollection<Zwierze>(klinika.Zwierzeta);
                }
            }
        }

        private void BtnUsunZwierze_Click(object sender, RoutedEventArgs e)
        {
            if (LstZwierzat.SelectedIndex > -1 && klinika is not null)
            {
                klinika.UsuwanieZwierzecia(LstZwierzat.SelectedItem as Zwierze);
                LstZwierzat.ItemsSource = new ObservableCollection<Zwierze>(klinika.Zwierzeta);
            }
        }

        private void BtnSortuj_Click(object sender, RoutedEventArgs e)
        {
            if (klinika is not null)
            {
                klinika.SortujZwierzeta();
                LstZwierzat.ItemsSource = new ObservableCollection<Zwierze>(klinika.Zwierzeta);
            }
        }

    }
}
