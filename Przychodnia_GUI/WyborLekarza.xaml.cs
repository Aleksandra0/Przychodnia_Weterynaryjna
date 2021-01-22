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
    /// Interaction logic for WyborLekarza.xaml
    /// </summary>
    public partial class WyborLekarza : Window
    {
        Klient klient = new Klient();
        Lekarz l1 = new Lekarz();
        Lekarz l2 = new Lekarz();
        Lekarz l3 = new Lekarz();
        Lekarz l4 = new Lekarz();
        /// <summary>Initializes a new instance of the <see cref="WyborLekarza" /> class.</summary>
        /// <param name="klient2">The klient2.</param>
        public WyborLekarza(Klient klient2)
        {
            klient = klient2;
            //Stworzenie zespołu lekarzy
            Lekarz lekarz1 = new Lekarz("Dawid", "Nowak", "09.12.1986", "00178956435", Osoba.Plcie.M, "509678999", "dn@interia.eu", "Koty", "dr. weterynarz", 8);
            Lekarz lekarz2 = new Lekarz("Krzysztof", "Ambasada", "07.10.1983", "00178956732", Osoba.Plcie.M, "506925173", "ka@interia.eu", "Psy", "dr. weterynarz", 10);
            Lekarz lekarz3 = new Lekarz("Krystyna", "Brzyska", "09.10.1990", "00178446797", Osoba.Plcie.K, "5089258173", "kb@interia.eu", "Króliki", "dr. weterynarz", 6);
            Lekarz lekarz4 = new Lekarz("Aneta", "Gryfińska", "21.12.1988", "00178454427", Osoba.Plcie.K, "5089562173", "ag@interia.eu", "Koty", "dr. weterynarz", 8);
            Zespol_lekarzy zespol = new Zespol_lekarzy();
            zespol.Dodaj_lekarza(lekarz1);
            zespol.Dodaj_lekarza(lekarz2);
            zespol.Dodaj_lekarza(lekarz3);
            zespol.Dodaj_lekarza(lekarz4);
            Console.WriteLine(zespol.ToString());
            InitializeComponent();
            bt1.Content = lekarz1.ToString();
            bt2.Content = lekarz2.ToString();
            bt3.Content = lekarz3.ToString();
            bt4.Content = lekarz4.ToString();
            l1 = lekarz1;
            l2 = lekarz2;
            l3 = lekarz3;
            l4 = lekarz4;
        }

        /// <summary>Handles the click event of the bt1 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void bt1_click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbDataw.Text) || string.IsNullOrEmpty(tbGodzinaw.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola");
            }
            else
            {
                OknoKoncowe okno = new OknoKoncowe(l1, tbDataw.Text, tbGodzinaw.Text, klient);
                okno.Show();
                Close();
            }
        }

        /// <summary>Handles the click event of the bt2 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void bt2_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDataw.Text) || string.IsNullOrEmpty(tbGodzinaw.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola");
            }
            else
            {
                OknoKoncowe okno = new OknoKoncowe(l2, tbDataw.Text, tbGodzinaw.Text, klient);
                okno.Show();
                Close();
            }
        }

        /// <summary>Handles the click event of the bt3 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void bt3_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDataw.Text) || string.IsNullOrEmpty(tbGodzinaw.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola");
            }
            else
            {
                OknoKoncowe okno = new OknoKoncowe(l3, tbDataw.Text, tbGodzinaw.Text, klient);
                okno.Show();
                Close();
            }
        }
        /// <summary>Handles the click event of the bt4 control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void bt4_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDataw.Text) || string.IsNullOrEmpty(tbGodzinaw.Text))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola");
            }
            else
            {
                OknoKoncowe okno = new OknoKoncowe(l4, tbDataw.Text, tbGodzinaw.Text, klient);
                okno.Show();
                Close();
            }
        }
    }
}
