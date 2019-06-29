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

namespace Sajat.Alkalmazas.WPF
{
    public partial class FEset_N : UserControl
    {
        public FEset_N()
        {
            InitializeComponent();
        }

        private void Thumb_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            MeretezoThumb.Background = Brushes.Orange;
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (NezetHelye.ActualWidth + e.HorizontalChange > MeretezoThumb.ActualWidth + NezetHelye.Padding.Right + NezetHelye.Padding.Left + 10)
            {
                NezetHelye.SetValue(WidthProperty, NezetHelye.ActualWidth + e.HorizontalChange);

            }
        }

        private void Thumb_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            MeretezoThumb.Background = Brushes.DarkGray;
        }

        private void MeretezoThumb_MouseEnter(object sender, MouseEventArgs e)
        {
            MeretezoThumb.Opacity = 1;
        }

        private void MeretezoThumb_MouseLeave(object sender, MouseEventArgs e)
        {
            MeretezoThumb.Opacity = 0.5;
        }
    }
}
