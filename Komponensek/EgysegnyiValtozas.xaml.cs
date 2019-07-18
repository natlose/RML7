using Sajat.ObjektumModel;
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
    public partial class EgysegnyiValtozas : UserControl
    {
        public EgysegnyiValtozas()
        {
            InitializeComponent();
        }

        public FrameworkElement Tartalom { get; set; }

        public RoutedEventHandler Rogzit
        {
            get { return (RoutedEventHandler)GetValue(RogzitProperty); }
            set { SetValue(RogzitProperty, value); }
        }

        public static readonly DependencyProperty RogzitProperty =
            DependencyProperty.Register(
                "Rogzit",
                typeof(RoutedEventHandler),
                typeof(EgysegnyiValtozas)
            );

        private void RogzitClick(object sender, RoutedEventArgs e)
        {
            Rogzit?.Invoke(this, new RoutedEventArgs());
            GetBindingExpression(RogzitesEredmenyProperty).UpdateTarget();
        }

        public RoutedEventHandler Elvet
        {
            get { return (RoutedEventHandler)GetValue(ElvetProperty); }
            set { SetValue(ElvetProperty, value); }
        }

        public static readonly DependencyProperty ElvetProperty =
            DependencyProperty.Register(
                "Elvet",
                typeof(RoutedEventHandler),
                typeof(EgysegnyiValtozas)
            );

        public RoutedEventHandler Torol
        {
            get { return (RoutedEventHandler)GetValue(TorolProperty); }
            set { SetValue(TorolProperty, value); }
        }

        public static readonly DependencyProperty TorolProperty =
            DependencyProperty.Register(
                "Torol",
                typeof(RoutedEventHandler),
                typeof(EgysegnyiValtozas)
            );

        public bool VanTorolVegrehajto => Torol != null;

        public bool VanValtozas
        {
            get { return (bool)GetValue(VanValtozasProperty); }
            set { SetValue(VanValtozasProperty, value); }
        }

        public static readonly DependencyProperty VanValtozasProperty =
            DependencyProperty.Register("VanValtozas", typeof(bool), typeof(EgysegnyiValtozas), new PropertyMetadata(false));

        public RogzitesEredmeny RogzitesEredmeny
        {
            get { return (RogzitesEredmeny)GetValue(RogzitesEredmenyProperty); }
            set { SetValue(RogzitesEredmenyProperty, value); }
        }

        public static readonly DependencyProperty RogzitesEredmenyProperty =
            DependencyProperty.Register("RogzitesEredmeny", typeof(RogzitesEredmeny), typeof(EgysegnyiValtozas));

        private void ElvetClick(object sender, RoutedEventArgs e)
        {
            GetBindingExpression(VanValtozasProperty).UpdateTarget();
            if (VanValtozas)
            {
                ElvetTorolGombPanel.Visibility = Visibility.Collapsed;
                ElvetesMegerositesePanel.Visibility = Visibility.Visible;
            }
            else Elvet?.Invoke(this, new RoutedEventArgs());
        }

        private void ElvetesMegerositveClick(object sender, RoutedEventArgs e)
        {
            Elvet?.Invoke(this, new RoutedEventArgs());
        }

        private void ElvetesMegszakitvaClick(object sender, RoutedEventArgs e)
        {
            ElvetTorolGombPanel.Visibility = Visibility.Visible;
            ElvetesMegerositesePanel.Visibility = Visibility.Collapsed;
        }

        private void TorolClick(object sender, RoutedEventArgs e)
        {
            ElvetTorolGombPanel.Visibility = Visibility.Collapsed;
            TorlesMegerositesePanel.Visibility = Visibility.Visible;
        }

        private void TorlesMegerositveClick(object sender, RoutedEventArgs e)
        {
            Torol?.Invoke(this, new RoutedEventArgs());
        }

        private void TorlesMegszakitvaClick(object sender, RoutedEventArgs e)
        {
            ElvetTorolGombPanel.Visibility = Visibility.Visible;
            TorlesMegerositesePanel.Visibility = Visibility.Collapsed;
        }
    }
}
