﻿using System;
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

    
    public partial class UmowionewizytyLekarza : Window
    {
        Klinika? klinika;
        public UmowionewizytyLekarza(Klinika? klinika)
        {
            InitializeComponent();
            this.klinika = klinika;
            if (klinika != null)
            {
                LstLekarze.ItemsSource = klinika.Lekarze;
                LstLekarze.SelectionChanged += LstLekarze_SelectionChanged;

            }
            else
            {
                MessageBox.Show("Plik xml jest pusty");
            }
           
        }

        private void LstLekarze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstLekarze.SelectedItem is Lekarz selectedLekarz)
            {
                var filteredWizyty = selectedLekarz.WypiszZaplanowaneWizytyLekarza();
                LstWizytyLekarzy.Items.Clear();

                foreach (var termin in filteredWizyty.Split(Environment.NewLine))
                {
                    string trimmedTermin = termin.Trim();
                    if (!string.IsNullOrEmpty(trimmedTermin))
                    {
                        LstWizytyLekarzy.Items.Add(trimmedTermin);
                    }
                }
            }
        }
    }
}
