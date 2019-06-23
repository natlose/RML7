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
using AlkalmazasKeret.API;

namespace Partner
{
    public partial class SzemelyValasztasFE : UserControl, ICsatolhatoNezet
    {
        public SzemelyValasztasFE()
        {
            InitializeComponent();
        }

        public object NezetModell => DataContext;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((SzemelyValasztasNM)DataContext).Megsem();
        }

        private void Uj_Click(object sender, RoutedEventArgs e)
        {
            ((SzemelyValasztasNM)DataContext).Uj();
        }

        private void Kivalaszt_Click(object sender, RoutedEventArgs e)
        {
            ((SzemelyValasztasNM)DataContext).Kivalaszt();
        }
    }
}
