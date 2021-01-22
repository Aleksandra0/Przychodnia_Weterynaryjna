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
    /// Interaction logic for OknoKoncowe.xaml
    /// </summary>
    public partial class OknoKoncowe : Window
    {
        /// <summary>Initializes a new instance of the <see cref="OknoKoncowe" /> class.</summary>
        /// <param name="lekarz">The lekarz.</param>
        /// <param name="data">The data.</param>
        /// <param name="godzina">The godzina.</param>
        /// <param name="klient">The klient.</param>
        public OknoKoncowe(Lekarz lekarz, string data, string godzina, Klient klient)
        {
            InitializeComponent();
            tboxData.Text = "Data wizyty: " + data + ", godzina wizyty: " + godzina;
            tboxLekarz.Text = "Do: " + lekarz.Tytuly + " " + lekarz.Imie + " " + lekarz.Nazwisko;
            tboxZwierzeta.Text = klient.ToString2();
        }

        /// <summary>Handles the Click event of the btZakoncz control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btZakoncz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
      }
}
