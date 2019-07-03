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

namespace Sajat.WPF
{
    public partial class SzuromezoRacs : UserControl
    {
        public SzuromezoRacs()
        {
            InitializeComponent();
        }

        private SzuromezoGyujtemeny szuromezok;
        public SzuromezoGyujtemeny Szuromezok
        {
            get => szuromezok;
            set
            {
                szuromezok = value;
                UjRacsSorHozzaadasa();
            }
        }

        public void Torleskor(object s, RoutedEventArgs e)
        {
            SzuromezoLenyilo lenyilo = s as SzuromezoLenyilo;
            BindingOperations.ClearAllBindings(lenyilo);
            SzuromezoSzoveg szoveg = lenyilo.Combo.Tag as SzuromezoSzoveg;
            Szuromezo mezo = szoveg.Text.GetBindingExpression(TextBox.TextProperty).ResolvedSource as Szuromezo;
            mezo.Ertek = String.Empty;
            int row = Grid.GetRow(lenyilo);
            Grid.Children.Remove(lenyilo);
            Grid.Children.Remove(szoveg);
            foreach (var elem in Grid.Children.OfType<UIElement>())
            {
                if (Grid.GetRow(elem) > row) Grid.SetRow(elem, Grid.GetRow(elem) - 1);
            }
            Grid.RowDefinitions.Remove(Grid.RowDefinitions.Last());
            foreach (SzuromezoLenyilo regiLenyilo in Grid.Children.OfType<SzuromezoLenyilo>()) regiLenyilo.LathatosagFrissitese();
        }

        public void UjRacsSorHozzaadasa()
        {
            SzuromezoLenyilo lenyilo = new SzuromezoLenyilo();
            lenyilo.Button.Tag = this;
            lenyilo.Combo.SetBinding(
                ComboBox.ItemsSourceProperty, 
                new Binding(nameof(Szuromezok)) { Source = this }
            );
            Grid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Auto)
                });
            foreach (SzuromezoLenyilo regiLenyilo in Grid.Children.OfType<SzuromezoLenyilo>()) regiLenyilo.LathatosagFrissitese();
            int sorLetszam = Grid.RowDefinitions.Count;
            Grid.SetRowSpan(Splitter, sorLetszam);
            Grid.SetRow(lenyilo, sorLetszam - 1);
            lenyilo.Combo.SelectionChanged += (s, e) =>
            {
                ComboBox cb = s as ComboBox;
                SzuromezoSzoveg szvg = cb.Tag as SzuromezoSzoveg;
                if (e.RemovedItems.Count == 1)
                {
                    Szuromezo mezo = ((KeyValuePair<string, Szuromezo>)e.RemovedItems[0]).Value as Szuromezo;
                    mezo.Ertek = String.Empty;
                    BindingOperations.ClearBinding(szvg.Text, TextBox.TextProperty);
                }
                if (e.AddedItems.Count == 1)
                {
                    Szuromezo mezo = ((KeyValuePair<string, Szuromezo>)e.AddedItems[0]).Value as Szuromezo;
                    szvg.Text.SetBinding(
                        TextBox.TextProperty,
                        new Binding(nameof(mezo.Ertek)) { Source = mezo }
                        );
                }
                if (e.RemovedItems.Count == 0 && e.AddedItems.Count == 1) UjRacsSorHozzaadasa();
            };
            Grid.Children.Add(lenyilo);
            SzuromezoSzoveg szoveg = new SzuromezoSzoveg();
            Grid.SetColumn(szoveg, 2);
            Grid.SetRow(szoveg, sorLetszam - 1);
            Grid.Children.Add(szoveg);
            lenyilo.Combo.Tag = szoveg;
        }

    }
}
