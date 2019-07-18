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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sajat.WPF
{
    [ContentProperty(nameof(Tartalom))]
    public partial class EgysegnyiMegnyitas : UserControl
    {
        public EgysegnyiMegnyitas()
        {
            InitializeComponent();
        }

        public FrameworkElement Tartalom { get; set; }

        public RoutedEventHandler Bezar
        {
            get { return (RoutedEventHandler)GetValue(BezarProperty); }
            set { SetValue(BezarProperty, value); }
        }

        public static readonly DependencyProperty BezarProperty =
            DependencyProperty.Register(
                "Bezar",
                typeof(RoutedEventHandler),
                typeof(EgysegnyiMegnyitas)
            );

        private void BezarClick(object sender, RoutedEventArgs e)
        {
            Bezar?.Invoke(this, new RoutedEventArgs());
        }

    }
}
