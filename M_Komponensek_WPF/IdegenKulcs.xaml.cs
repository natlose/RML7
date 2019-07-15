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
    public partial class IdegenKulcs : UserControl
    {
        public IdegenKulcs()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CimkeProperty =
            DependencyProperty.Register(
                "Cimke",
                typeof(string),
                typeof(IdegenKulcs),
                new PropertyMetadata("")
            );

        public string Cimke
        {
            get { return (string)GetValue(CimkeProperty); }
            set { SetValue(CimkeProperty, value); }
        }

        public static readonly DependencyProperty SzovegProperty =
            DependencyProperty.Register(
                "Szoveg",
                typeof(string),
                typeof(IdegenKulcs),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        public string Szoveg
        {
            get { return (string)GetValue(SzovegProperty); }
            set { SetValue(SzovegProperty, value); }
        }

        public static readonly DependencyProperty KulcsProperty =
            DependencyProperty.Register(
                "Kulcs",
                typeof(string),
                typeof(IdegenKulcs),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        public string Kulcs
        {
            get { return (string)GetValue(KulcsProperty); }
            set { SetValue(KulcsProperty, value); }
        }

        public static readonly DependencyProperty KeresProperty =
            DependencyProperty.Register(
                "Keres",
                typeof(RoutedEventHandler),
                typeof(IdegenKulcs)
            );

        public RoutedEventHandler Keres
        {
            get { return (RoutedEventHandler)GetValue(KeresProperty); }
            set { SetValue(KeresProperty, value); }
        }

        public bool VanKeres { get => Keres != null; }

        private void KeresClick(object sender, RoutedEventArgs e)
        {
            Keres?.Invoke(this, null);
        }

    }
}
