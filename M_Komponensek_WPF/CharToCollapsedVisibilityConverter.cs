using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Sajat.WPF
{
    public class CharToCollapsedVisibilityConverter : IValueConverter
    {

        public string VisibleChar { get; set; } = "I";

        public string CollapsedChar { get; set; } = "N";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString().ToUpper() == VisibleChar) return Visibility.Visible;
            else return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility)
            {
                if ((Visibility)value == Visibility.Visible)
                    return VisibleChar;
                else
                    return CollapsedChar;
            }
            return CollapsedChar;
        }
    }
}
