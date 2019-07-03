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

namespace Sajat.WPF
{
    public partial class SzuromezoSzoveg : UserControl
    {
        public SzuromezoSzoveg()
        {
            InitializeComponent();
        }

        public Visibility KeresLathato
        {
            get
            {
                Visibility visibility = Visibility.Collapsed;
                BindingExpression binding = Text.GetBindingExpression(TextBox.TextProperty);
                if (binding != null)
                {
                    Szuromezo mezo = binding.ResolvedSource as Szuromezo;
                    if (mezo != null && mezo.Kereseskor != null) visibility = Visibility.Visible;
                }
                return visibility;
            }
        }

        public bool CsakOlvashato
        {
            get
            {
                BindingExpression binding = Text.GetBindingExpression(TextBox.TextProperty);
                return binding == null;
            }
        }

        private void KeresClick(object sender, RoutedEventArgs e)
        {
            Szuromezo mezo = Text.GetBindingExpression(TextBox.TextProperty).ResolvedSource as Szuromezo;
            mezo?.Kereseskor?.Invoke(mezo);
        }

        internal void BindingfuggokErtesitese()
        {
            KeresButton.GetBindingExpression(Button.VisibilityProperty)?.UpdateTarget();
            Text.GetBindingExpression(TextBox.IsReadOnlyProperty)?.UpdateTarget();
        }
    }
}
