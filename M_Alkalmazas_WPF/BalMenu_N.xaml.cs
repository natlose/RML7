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
    public partial class BalMenu_N : UserControl
    {
        public BalMenu_N()
        {
            InitializeComponent();
        }

        private void FeluletBetoltesenekBefejezesekor(object sender, RoutedEventArgs e)
        {
            ((BalMenu_NM)DataContext).FeluletBetoltesenekBefejezesekor();
        }

        private void sorKivalasztasakor(object esemenyforras)
        {
            BalMenuSor sor = (((ListBox)esemenyforras).SelectedItem as BalMenuSor);
            if (sor != null) ((BalMenu_NM)DataContext).SorKivalasztasakor(sor);
        }

        private void ListBox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            sorKivalasztasakor(e.Source);
        }

        private void ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) sorKivalasztasakor(e.Source);
        }

    }
}
