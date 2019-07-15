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

namespace Sajat.Keszlet
{
    public partial class RaktarMegtekintes_N : UserControl
    {
        public RaktarMegtekintes_N()
        {
            InitializeComponent();
        }

        private void Bezaraskor(object sender, RoutedEventArgs e)
        {
            (DataContext as RaktarMegtekintes_NM).Bezaraskor();
        }

        private void PolcModositaskor(object sender, object e)
        {
            (DataContext as RaktarMegtekintes_NM).PolcModositaskor(e as Polc);
        }

        private void PolcMegnyitaskor(object sender, object e)
        {
            (DataContext as RaktarMegtekintes_NM).PolcMegnyitaskor(e as Polc);
        }

        private void PolcFelveszkor(object sender, RoutedEventArgs e)
        {
            (DataContext as RaktarMegtekintes_NM).PolcFelveszkor();
        }

    }
}
