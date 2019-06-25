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
    public partial class Szerkesztes_N : UserControl, ICsatolhatoNezet
    {
        public Szerkesztes_N()
        {
            InitializeComponent();
        }

        public object NezetModell => DataContext;

        private void BetoltesBefejezesekor(object sender, RoutedEventArgs e)
        {
            (DataContext as Szerkesztes_NM).BetoltesBefejezesekor();
        }

        private void Rogziteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as Szerkesztes_NM).Rogziteskor();
        }

        private void Elveteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as Szerkesztes_NM).Elveteskor();
        }
    }
}
