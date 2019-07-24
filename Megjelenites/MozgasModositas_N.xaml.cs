using Sajat.Uzlet;
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

namespace Sajat.Megjelenites
{
    public partial class MozgasModositas_N : UserControl
    {
        public MozgasModositas_N()
        {
            InitializeComponent();
        }

        private void PartnerKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as MozgasModositas_NM).PartnerKereseskor();
        }

        private MozgasTetel tetel(object sender)
        {
            DependencyObject target = sender as DependencyObject;
            do
                target = VisualTreeHelper.GetParent(target);
            while (target != null && !(target is SzerkeszthetoLista));
            return (target as SzerkeszthetoLista)?.KijeloltTetel as MozgasTetel;
        }

        private void CikkszamKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as MozgasModositas_NM).CikkszamKereseskor(tetel(sender));
        }

        private void CikkszamUtan(object sender, RoutedEventArgs e)
        {
            (DataContext as MozgasModositas_NM).CikkszamUtan(tetel(sender));
        }

        private void NevKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as MozgasModositas_NM).NevKereseskor(tetel(sender));
        }

        private void KoltseghelyKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as MozgasModositas_NM).KoltseghelyKereseskor();
        }

        private void Rogziteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as MozgasModositas_NM).Rogziteskor();
        }

        private void Elveteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as MozgasModositas_NM).Elveteskor();
        }
    }
}
