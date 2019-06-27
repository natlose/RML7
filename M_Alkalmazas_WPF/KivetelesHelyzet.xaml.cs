using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class KivetelesHelyzet : UserControl, INotifyPropertyChanged
    {
        public KivetelesHelyzet()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string uzenet;

        public string Uzenet
        {
            get { return uzenet; }
            set
            {
                uzenet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Uzenet)));
            }
        }

        public event EventHandler Vissza;

        private void VisszaClick(object sender, RoutedEventArgs e)
        {
            Vissza?.Invoke(this, null);
        }
    }
}
