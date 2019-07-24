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
    public partial class EllenorzottDatum : UserControl
    {
        public EllenorzottDatum()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CimkeProperty =
            DependencyProperty.Register("Cimke", typeof(string), typeof(EllenorzottDatum), new PropertyMetadata(""));

        public string Cimke
        {
            get { return (string)GetValue(CimkeProperty); }
            set { SetValue(CimkeProperty, value); }
        }

        public static readonly DependencyProperty DatumProperty =
            DependencyProperty.Register(
                "Datum",
                typeof(DateTime),
                typeof(EllenorzottDatum),
                new FrameworkPropertyMetadata(
                    DateTime.Now,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        public DateTime Datum
        {
            get { return (DateTime)GetValue(DatumProperty); }
            set { SetValue(DatumProperty, value); }
        }

    }
}
