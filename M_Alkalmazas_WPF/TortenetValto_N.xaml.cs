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

namespace Sajat.Alkalmazas.WPF
{
    public partial class TortenetValto_N : UserControl
    {
        public TortenetValto_N()
        {
            InitializeComponent();
        }

        private void ItemMouseUp(object sender, MouseButtonEventArgs e)
        {
            Tortenet tortenet = BindingOperations.GetBindingExpression(sender as DependencyObject, TextBlock.TextProperty).DataItem as Tortenet;
            if (tortenet != null) (DataContext as Tortenetek_NM).Aktiv = tortenet.Azonosito;
        }
    }
}
