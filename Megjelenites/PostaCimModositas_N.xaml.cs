﻿using Sajat.Alkalmazas.API;
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

namespace Sajat.Megjelenites
{
    public partial class PostaCimModositas_N : UserControl
    {
        public PostaCimModositas_N()
        {
            InitializeComponent();
        }

        public void OrszagKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PostaCimModositas_NM).OrszagKereseskor();
        }

        private void Bezaraskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PostaCimModositas_NM).Bezaraskor();
        }

        public void IranyitoszamKereseskor(object sender, RoutedEventArgs e)
        {
            (DataContext as PostaCimModositas_NM).IrszamKereseskor();
        }
    }
}
