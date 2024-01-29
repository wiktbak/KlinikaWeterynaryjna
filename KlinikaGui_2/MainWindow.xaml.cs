using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandlebarsDotNet.Collections;
using KlinikaWeterynaryjna;

namespace KlinikaGui_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Klinika? klinika;


        public MainWindow()
        {
            InitializeComponent();
            string xmlFilePath = @"C:\Users\laura_a1y0snp\Desktop\Semestry\NowaWersjavol4-2\GitGrafika\KlinikaWeterynaryjna\KlinikaWeterynaryjna\Klinika.xml";

            klinika = Klinika.OdczytXml(xmlFilePath);
            if (klinika == null)
            {
                MessageBox.Show("Plik xml jest pusty");
            }


            
        }

        private void BtnZwierzeta_Click(object sender, RoutedEventArgs e)
        {
            ZwierzeWindow zwierzeWindow = new ZwierzeWindow(klinika);
            zwierzeWindow.Show();
        }

        private void BtnLekarze_Click(object sender, RoutedEventArgs e)
        {
            LekarzWindow lekarzWindow = new LekarzWindow(klinika);
            lekarzWindow.Show();
        }

        private void BtnWizyty_Click(object sender, RoutedEventArgs e)
        {
            WizytaWindow wizytaWindow = new WizytaWindow(klinika);
            wizytaWindow.Show();
        }
    }
}
