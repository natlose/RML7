﻿using System;
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

namespace Sajat.Megjelenites
{
    public partial class CikkModositas_N : UserControl
    {
        public CikkModositas_N()
        {
            InitializeComponent();
        }

        private void Rogziteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkModositas_NM).Rogziteskor();
        }

        private void Elveteskor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkModositas_NM).Elveteskor();
        }

        private void AlCsoportKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as CikkModositas_NM).AlCsoportKereseskor();
        }
    }
}
