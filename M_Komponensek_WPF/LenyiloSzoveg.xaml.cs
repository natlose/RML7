using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class LenyiloSzoveg : UserControl
    {
        public LenyiloSzoveg()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CimkeProperty =
            DependencyProperty.Register(
                "Cimke",
                typeof(string),
                typeof(LenyiloSzoveg),
                new PropertyMetadata("")
            );

        public string Cimke
        {
            get { return (string)GetValue(CimkeProperty); }
            set { SetValue(CimkeProperty, value); }
        }

        public static readonly DependencyProperty KodProperty =
            DependencyProperty.Register(
                "Kod",
                typeof(string),
                typeof(LenyiloSzoveg),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        public string Kod
        {
            get { return (string)GetValue(KodProperty); }
            set { SetValue(KodProperty, value); }
        }

        public static readonly DependencyProperty SzotarProperty =
            DependencyProperty.Register(
                "Szotar",
                typeof(Dictionary<string, string>),
                typeof(LenyiloSzoveg)
            );

        public Dictionary<string, string> Szotar
        {
            get { return (Dictionary<string, string>)GetValue(SzotarProperty); }
            set { SetValue(SzotarProperty, value); }
        }

    }
}
