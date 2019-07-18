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
    public partial class PartnerModositas_N : UserControl
    {
        public PartnerModositas_N()
        {
            InitializeComponent();
        }

        private void Rogziteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).Rogziteskor();
        }

        private void Elveteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).Elveteskor();
        }

        private void Torleskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PartnerModositas_NM).Torleskor();
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
