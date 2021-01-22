using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Text.RegularExpressions;

namespace Przychodnia_GUI
{
    /// <summary>
    /// Interaction logic for Rejestracja.xaml
    /// </summary>
    /// 

    public partial class Rejestracja : Window
    {
        /// <summary>Initializes a new instance of the <see cref="Rejestracja" /> class.</summary>
        public Rejestracja()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the btZatwierdz control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbImie.Text) || string.IsNullOrEmpty(tbNazwisko.Text) || string.IsNullOrEmpty(tbData_urodzenia.Text) || string.IsNullOrEmpty(tbPesel.Text) || string.IsNullOrEmpty(cbPlec.Text) || string.IsNullOrEmpty(tbNumer.Text) || string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbAdres.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola");
            }
            else
            {
                Osoba.Plcie plec;
                if (cbPlec.Text == "kobieta")
                {
                    plec = Osoba.Plcie.K;
                }
                else if (cbPlec.Text == "mężczyzna")
                {
                    plec = Osoba.Plcie.M;
                }
                else
                {
                    plec = Osoba.Plcie.I;
                }
                Regex wzorzec = new Regex("^\\d{11}$");
                if (wzorzec.IsMatch(tbPesel.Text))
                {
                    Klient klient = new Klient(tbImie.Text, tbNazwisko.Text, tbData_urodzenia.Text, tbPesel.Text, plec, tbNumer.Text, tbEmail.Text, tbAdres.Text, "pusty");
                    int id = 0;
                    Rejestracja_pacjent rejestracja = new Rejestracja_pacjent(klient, id);
                    rejestracja.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Podano zły format peselu");
                }
                
            }

        }
    }
}
