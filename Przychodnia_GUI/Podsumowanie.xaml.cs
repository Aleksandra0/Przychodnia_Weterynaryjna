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
    /// Interaction logic for Podsumowanie.xaml
    /// </summary>
    public partial class Podsumowanie : Window
    {
        Klient klient = new Klient();
        /// <summary>Initializes a new instance of the <see cref="Podsumowanie" /> class.</summary>
        /// <param name="klient2">The klient2.</param>
        public Podsumowanie(Klient klient2)
        {
            InitializeComponent();
            klient = klient2;
            tboxDane.Text = klient.ToString();
            klient.Sortuj();
            tboxPupile.Text = klient.ToString2();
        }

        /// <summary>Handles the Click event of the btWizyta control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btWizyta_Click(object sender, RoutedEventArgs e)
        {
            WyborLekarza wybor = new WyborLekarza(klient);
            wybor.Show();
            Close();
        }

        /// <summary>Handles the Click event of the btPowrot control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
