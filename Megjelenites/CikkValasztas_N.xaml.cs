using Sajat.Uzlet;
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

namespace Sajat.Megjelenites
{
    public partial class CikkValasztas_N : UserControl
    {
        public CikkValasztas_N()
        {
            InitializeComponent();
        }

        private void Lapozaskor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkValasztas_NM).Lapozaskor();
        }

        private void Lekerdezeskor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkValasztas_NM).Lekerdezeskor();
        }

        private void Visszakor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkValasztas_NM).Visszakor();
        }

        private void Felveszkor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkValasztas_NM).Felveszkor();
        }

        private void Kivalasztaskor(object sender, object e)
        {
            (DataContext as CikkValasztas_NM).Kivalasztaskor(e as Cikk);
        }

        private void Modositaskor(object sender, object e)
        {
            (DataContext as CikkValasztas_NM).Modositaskor(e as Cikk);
        }

        private void Megnyitaskor(object sender, object e)
        {
            (DataContext as CikkValasztas_NM).Megnyitaskor(e as Cikk);
        }
    }
}
