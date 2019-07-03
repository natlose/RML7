using Sajat.Alkalmazas.API;
using Sajat.WPF;
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
    public partial class PartnerValasztas_N : UserControl, ICsatolhatoNezet
    {
        public PartnerValasztas_N()
        {
            InitializeComponent();
        }

        public object NezetModell => DataContext;

        private void Lapozaskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerValasztas_NM).Lapozaskor();
        }

        private void Lekerdezeskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerValasztas_NM).Lekerdezeskor();
        }

        private void Felveszkor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerValasztas_NM).Felveszkor();
        }

        private void Visszakor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerValasztas_NM).Visszakor();
        }

        private void Kivalasztaskor(object sender, object e)
        {
            (DataContext as PartnerValasztas_NM).Kivalasztaskor(e as Partner);
        }

        private void Modositaskor(object sender, object e)
        {
            (DataContext as PartnerValasztas_NM).Modositaskor(e as Partner);
        }

    }
}
