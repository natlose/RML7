using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Sajat.WPF
{
    public class ReferenceToVisibilityConverter : IValueConverter
    {
        public Visibility NemLathatoVisibility { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null) return Visibility.Visible;
            else return NemLathatoVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
