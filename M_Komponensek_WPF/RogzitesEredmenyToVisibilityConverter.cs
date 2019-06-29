using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using Sajat.ObjektumModel;

namespace Sajat.WPF
{
    public class RogzitesEredmenyToVisibilityConverter : IValueConverter
    {

        public RogzitesEredmeny VisibleEredmeny { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is RogzitesEredmeny && (RogzitesEredmeny) value == VisibleEredmeny) return Visibility.Visible;
            else return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
