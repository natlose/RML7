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
    /// <summary>
    /// Interaction logic for IrszamValasztas.xaml
    /// </summary>
    public partial class IrszamValasztas_N : UserControl, ICsatolhatoNezet
    {
        public IrszamValasztas_N()
        {
            InitializeComponent();
        }

        public object NezetModell => DataContext;

        private void Visszakor(object sender, RoutedEventArgs e)
        {
            (DataContext as IrszamValasztas_NM).Visszakor();
        }
        private void Lekerdezeskor(object sender, RoutedEventArgs e)
        {
            (DataContext as IrszamValasztas_NM).Lekerdezeskor();
        }
    }
}
