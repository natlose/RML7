using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Sajat.WPF
{
    public class GrafikasGomb : Button
    {
        public static DependencyProperty GrafikaProperty = DependencyProperty.Register(
            "Grafika", 
            typeof(Geometry), 
            typeof(GrafikasGomb), 
            new FrameworkPropertyMetadata(new PropertyChangedCallback(Data_Changed))
        );

        public Geometry Grafika
        {
            get { return (Geometry)GetValue(GrafikaProperty); }
            set { SetValue(GrafikaProperty, value); }
        }

        private static void Data_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            GrafikasGomb thisClass = (GrafikasGomb)o;
            thisClass.SetData();
        }

        private void SetData()
        {
            Path path = new Path();
            path.Data = Grafika;
            path.Fill = Brushes.Black;
            path.Stroke = this.Foreground;
            path.StrokeThickness = 1;
            this.Content = path;
        }
    }
}
