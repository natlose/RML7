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
    public partial class PolcMegtekintes_N : UserControl
    {
        public PolcMegtekintes_N()
        {
            InitializeComponent();
        }

        private void Bezaraskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PolcMegtekintes_NM).Bezaraskor();
        }

        private void KeszletMegnyitaskor(object sender, object e)
        {
            (DataContext as PolcMegtekintes_NM).KeszletMegnyitaskor(e);
        }
    }
}
