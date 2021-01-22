using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekt_Przychodnia_weterynaryjna;

namespace Przychodnia_GUI
{
    /// <summary>
    /// Interaction logic for Rejestracja_pacjent.xaml
    /// </summary>
    public partial class Rejestracja_pacjent : Window
    {
        Klient klient = new Klient();
        int id = 0;
        /// <summary>Initializes a new instance of the <see cref="Rejestracja_pacjent" /> class.</summary>
        /// <param name="klient2">The klient2.</param>
        /// <param name="id2">The id2.</param>
        public Rejestracja_pacjent(Klient klient2, int id2)
        {
            InitializeComponent();
            klient = klient2;
            id = id2;
        }

        /// <summary>Handles the Click event of the btUmow control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btUmow_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbImiez.Text) || string.IsNullOrEmpty(tbData_urodzeniaz.Text) || string.IsNullOrEmpty(cbPlecz.Text) || string.IsNullOrEmpty(tbZnaki_szczegolne.Text) || string.IsNullOrEmpty(tbGatunek.Text) || string.IsNullOrEmpty(tbRasa.Text) || string.IsNullOrEmpty(tbBarwa.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola");
            }
            else
            {
                Zwierze.Plcie_zwierzat plec;
                if (cbPlecz.Text == "samiec")
                {
                    plec = Zwierze.Plcie_zwierzat.samiec;
                }
                else
                {
                    plec = Zwierze.Plcie_zwierzat.samica;
                }
                Pacjent pacjent = new Pacjent(tbImiez.Text, tbData_urodzeniaz.Text, plec, tbGatunek.Text, tbRasa.Text, tbBarwa.Text, tbZnaki_szczegolne.Text, id, klient);
                klient.Dodaj_pacjenta(pacjent);
                Podsumowanie podsumowanie = new Podsumowanie(klient);
                podsumowanie.Show();
                Close();
            }
        }

        /// <summary>Handles the Click event of the btDodajKolejne control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btDodajKolejne_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbImiez.Text) || string.IsNullOrEmpty(tbData_urodzeniaz.Text) || string.IsNullOrEmpty(cbPlecz.Text) || string.IsNullOrEmpty(tbZnaki_szczegolne.Text) || string.IsNullOrEmpty(tbGatunek.Text) || string.IsNullOrEmpty(tbRasa.Text) || string.IsNullOrEmpty(tbBarwa.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola");
            }
            else
            {
                Zwierze.Plcie_zwierzat plec;
                if (cbPlecz.Text == "samiec")
                {
                    plec = Zwierze.Plcie_zwierzat.samiec;
                }
                else
                {
                    plec = Zwierze.Plcie_zwierzat.samica;
                }
                Pacjent pacjent = new Pacjent(tbImiez.Text, tbData_urodzeniaz.Text, plec, tbGatunek.Text, tbRasa.Text, tbBarwa.Text, tbZnaki_szczegolne.Text, id, klient);
                klient.Dodaj_pacjenta(pacjent);
                tbImiez.Clear();
                tbData_urodzeniaz.Clear();
                tbGatunek.Clear();
                tbRasa.Clear();
                tbBarwa.Clear();
                tbZnaki_szczegolne.Clear();
                id++;
            }
        }
    }
}
