using Sajat.Alkalmazas.API;
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

namespace Sajat.Partner
{
    public partial class OrszagValasztas_N : UserControl
    {
        public OrszagValasztas_N()
        {
            InitializeComponent();
        }

        private void Lekerdezeskor(object sender, RoutedEventArgs e)
        {
            (DataContext as OrszagValasztas_NM).Lekerdezeskor();
        }

        private void Felveszkor(object sender, RoutedEventArgs e)
        {
            (DataContext as OrszagValasztas_NM).Felveszkor();
        }

        private void Visszakor(object sender, RoutedEventArgs e)
        {
            (DataContext as OrszagValasztas_NM).Visszakor();
        }

        private void Kivalasztaskor(object sender, object e)
        {
            (DataContext as OrszagValasztas_NM).Kivalasztaskor(e as Orszag);
        }

        private void Modositaskor(object sender, object e)
        {
            (DataContext as OrszagValasztas_NM).Modositaskor(e as Orszag);
        }
    }
}
