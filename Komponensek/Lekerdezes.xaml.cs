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
    public partial class Lekerdezes : UserControl
    {
        public Lekerdezes()
        {
            InitializeComponent();
        }

        public FrameworkElement Tartalom { get; set; }

        public SzuromezoGyujtemeny Szuromezok
        {
            get { return (SzuromezoGyujtemeny)GetValue(SzuromezokProperty); }
            set { SetValue(SzuromezokProperty, value); }
        }

        public static readonly DependencyProperty SzuromezokProperty =
            DependencyProperty.Register(
                "Szuromezok",
                typeof(SzuromezoGyujtemeny),
                typeof(Lekerdezes),
                new PropertyMetadata((s, e) =>
                {
                    (s as Lekerdezes).SzuromezoRacs.Szuromezok = e.NewValue as SzuromezoGyujtemeny;
                })
            );

        public RoutedEventHandler Lekerdez
        {
            get { return (RoutedEventHandler)GetValue(LekerdezProperty); }
            set { SetValue(LekerdezProperty, value); }
        }

        public static readonly DependencyProperty LekerdezProperty =
            DependencyProperty.Register(
                "Lekerdez",
                typeof(RoutedEventHandler),
                typeof(Lekerdezes)
            );

        public RoutedEventHandler Vissza
        {
            get { return (RoutedEventHandler)GetValue(VisszaProperty); }
            set { SetValue(VisszaProperty, value); }
        }

        public static readonly DependencyProperty VisszaProperty =
            DependencyProperty.Register(
                "Vissza",
                typeof(RoutedEventHandler),
                typeof(Lekerdezes)
            );

        private void LekerdezClick(object sender, RoutedEventArgs e)
        {
            Lekerdez?.Invoke(this, new RoutedEventArgs());
        }

        private void VisszaClick(object sender, RoutedEventArgs e)
        {
            Vissza?.Invoke(this, new RoutedEventArgs());
        }

    }
}
