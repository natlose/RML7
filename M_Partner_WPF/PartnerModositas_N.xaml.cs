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
    public partial class PartnerModositas_N : UserControl, ICsatolhatoNezet
    {
        public PartnerModositas_N()
        {
            InitializeComponent();
        }

        public object NezetModell => DataContext;

        private void BetoltesBefejezesekor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).BetoltesBefejezesekor();
        }

        private void Rogziteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).Rogziteskor();
        }

        private void Elveteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).Elveteskor();
        }

        public void OrszagKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).OrszagKereseskor();
        }

        public void PostaCimFelveszkor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).PostaCimFelveszkor();
        }

        private void PostaCimMegnyitaskor(object sender, object e)
        {
            (DataContext as PartnerModositas_NM).PostaCimMegnyitaskor(e as PostaCim);
        }
    }
}
