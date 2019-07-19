using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Sajat.WPF
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public Visibility NemLathatoVisibility { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is int && (int)value != 0) return Visibility.Visible;
            else return NemLathatoVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
