using Sajat.Alkalmazas.API;
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
    public partial class IrszamValasztas_N : UserControl
    {
        public IrszamValasztas_N()
        {
            InitializeComponent();
        }

        private void Visszakor(object sender, RoutedEventArgs e)
        {
            (DataContext as IrszamValasztas_NM).Visszakor();
        }
        private void Lekerdezeskor(object sender, RoutedEventArgs e)
        {
            (DataContext as IrszamValasztas_NM).Lekerdezeskor();
        }
        private void Modositaskor(object sender, object e)
        {
            (DataContext as IrszamValasztas_NM).Modositaskor(e as Irszam);
        }
        private void Felveszkor(object sender, RoutedEventArgs e)
        {
            (DataContext as IrszamValasztas_NM).Felveszkor();
        }

        private void Kivalasztaskor(object sender, object e)
        {
            (DataContext as IrszamValasztas_NM).Kivalasztaskor(e as Irszam);
        }
    }
}
