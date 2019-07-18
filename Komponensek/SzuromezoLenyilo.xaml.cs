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

namespace Sajat.WPF
{
    public partial class SzuromezoLenyilo : UserControl
    {
        public SzuromezoLenyilo()
        {
            InitializeComponent();
        }

        public Visibility Lathato
        {
            get
            {
                SzuromezoRacs racs = Button.Tag as SzuromezoRacs;
                int sorLetszam = racs.Grid.RowDefinitions.Count;
                int sor = Grid.GetRow(this);
                if (sorLetszam == 2 && sor == 0 || sor == sorLetszam - 1) return Visibility.Hidden;
                else return Visibility.Visible;
            }
        }

        public void LathatosagFrissitese()
        {
            Button.GetBindingExpression(Button.VisibilityProperty)?.UpdateTarget();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((sender as Button).Tag as SzuromezoRacs).Torleskor(this, new RoutedEventArgs());
        }
    }
}
