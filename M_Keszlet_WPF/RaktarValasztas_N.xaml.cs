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

namespace Sajat.Keszlet
{
    public partial class RaktarValasztas_N : UserControl
    {
        public RaktarValasztas_N()
        {
            InitializeComponent();
        }

        private void Lekerdezeskor(object sender, RoutedEventArgs e)
        {
            (DataContext as RaktarValasztas_NM).Lekerdezeskor();
        }

        private void Visszakor(object sender, RoutedEventArgs e)
        {
            (DataContext as RaktarValasztas_NM).Visszakor();
        }

        private void Felveszkor(object sender, RoutedEventArgs e)
        {
            (DataContext as RaktarValasztas_NM).Felveszkor();
        }

        private void Kivalasztaskor(object sender, object e)
        {
            (DataContext as RaktarValasztas_NM).Kivalasztaskor(e as Raktar);
        }

        private void Modositaskor(object sender, object e)
        {
            (DataContext as RaktarValasztas_NM).Modositaskor(e as Raktar);
        }

        private void Megnyitaskor(object sender, object e)
        {
            (DataContext as RaktarValasztas_NM).Megnyitaskor(e as Raktar);
        }
    }
}
