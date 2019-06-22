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

namespace AppFrame
{
    public partial class FoAblak_N : Window
    {
        public FoAblak_N()
        {
            InitializeComponent();
        }

        private void FeluletBetoltesenekBefejezesekor(object sender, RoutedEventArgs e)
        {
            (BalMenu_N.DataContext as BalMenu_NM).UjTortenetKerelem += (Tortenetek_N.DataContext as Tortenetek_NM).UjTortenetKerelemkor;
            (Tortenetek_N.DataContext as Tortenetek_NM).TortenetValtozott += (s, ea) => {
                Tortenetek_ScrollViewer.ScrollToRightEnd();
            };

        }
    }
}
