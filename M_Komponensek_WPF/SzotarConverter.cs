using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Sajat.WPF
{
    public class SzotarConverter : IValueConverter
    {
        public Szotar Szotar { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string && Szotar.ContainsKey((string)value)) return Szotar[(string)value];
            else return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
