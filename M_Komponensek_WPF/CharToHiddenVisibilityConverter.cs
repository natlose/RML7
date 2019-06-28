using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Sajat.WPF
{
    public class CharToHiddenVisibilityConverter : IValueConverter
    {

        public string VisibleChar { get; set; } = "I";

        public string HiddenChar { get; set; } = "N";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().ToUpper() == VisibleChar) return Visibility.Visible;
            else return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility)
            {
                if ((Visibility)value == Visibility.Visible)
                    return VisibleChar;
                else
                    return HiddenChar;
            }
            return HiddenChar;
        }
    }
}
