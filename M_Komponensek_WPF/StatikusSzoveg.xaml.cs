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
    public partial class StatikusSzoveg : UserControl
    {
        public StatikusSzoveg()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CimkeProperty =
            DependencyProperty.Register(
                "Cimke", 
                typeof(string), 
                typeof(StatikusSzoveg), 
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
                typeof(StatikusSzoveg),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        public string Szoveg
        {
            get { return (string)GetValue(SzovegProperty); }
            set { SetValue(SzovegProperty, value); }
        }
    }
}
