using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sajat.Alkalmazas.WPF
{
    public partial class FoAblak_N : Window, INotifyPropertyChanged
    {
        public FoAblak_N()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Ertesites([CallerMemberName] string tulajdonsagNeve = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNeve));
        }

        private bool kilepesMegerositesZajlik = false;
        public bool KilepesMegerositesZajlik
        {
            get => kilepesMegerositesZajlik;
            set
            {
                kilepesMegerositesZajlik = value;
                Ertesites(nameof(KilepesMegerositesZajlik));
            }
        }

        private bool kilepesMegerositve = false;

        private void FeluletBetoltesenekBefejezesekor(object sender, RoutedEventArgs e)
        {
            (BalMenu_N.DataContext as BalMenu_NM).UjTortenetKerelem += (Tortenetek_N.DataContext as Tortenetek_NM).UjTortenetKerelemkor;
            (Tortenetek_N.DataContext as Tortenetek_NM).TortenetValtozott += (s, ea) => {
                Tortenetek_ScrollViewer.ScrollToRightEnd();
            };
            TortenetValto_N.DataContext = Tortenetek_N.DataContext;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(Tortenetek_N.DataContext as Tortenetek_NM).FoAblakBezarhato)
            {
                if (!KilepesMegerositesZajlik)
                {
                    e.Cancel = true;
                    KilepesMegerositesZajlik = true;
                }
                else
                {
                    if (!kilepesMegerositve) e.Cancel = true;
                }
            }
        }

        private void KilepesMegerositveClick(object sender, RoutedEventArgs e)
        {
            kilepesMegerositve = true;
            Close();
        }

        private void KilepesElvetveClick(object sender, RoutedEventArgs e)
        {
            KilepesMegerositesZajlik = false;
        }
    }
}
