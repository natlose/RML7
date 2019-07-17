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
    public partial class CikkMegtekintes_N : UserControl
    {
        public CikkMegtekintes_N()
        {
            InitializeComponent();
        }

        private void Bezaraskor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkMegtekintes_NM).Bezaraskor();
        }

    }
}
