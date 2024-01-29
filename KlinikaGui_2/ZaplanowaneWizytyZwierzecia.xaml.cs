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
  
    public partial class ZaplanowaneWizytyZwierzecia : Window
    {
        Klinika? klinika;
        public ZaplanowaneWizytyZwierzecia(Klinika? klinika)
        {
            InitializeComponent();
            this.klinika = klinika;
            if (klinika != null)
            {
                LstWybierzZwierzeZ.ItemsSource = new ObservableCollection<Zwierze>(klinika.Zwierzeta);
                LstWybierzZwierzeZ.SelectionChanged += LstWybierzZwierzeZ_SelectionChanged;

            }
            else
            {
                MessageBox.Show("Plik xml jest pusty");
            }
        }

        private void LstWybierzZwierzeZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LstWybierzZwierzeZ.SelectedItem is Zwierze selectedZwierze)
            {
                var filteredWizyty = klinika.Wizyty.FindAll(w => w.Zwierze.Equals(selectedZwierze) && w.Data_wizyty >= DateTime.Now).ToList();
                if (filteredWizyty.Count > 0)
                {
                    LstZaplWizyty.ItemsSource = filteredWizyty;
                    LstZaplWizyty.Items.Refresh();
                }

                else { MessageBox.Show("Zwierze nie ma zaplanowanych wizyt"); }
            }

        }
    }
}
