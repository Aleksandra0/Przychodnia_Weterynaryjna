using System;
using System.Collections.Generic;
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

namespace Przychodnia_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>Initializes a new instance of the <see cref="MainWindow" /> class.</summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the btStart control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            Rejestracja rejestracja = new Rejestracja();
            rejestracja.Show();
            Close();
        }
    }
}
