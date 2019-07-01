using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sajat.WPF
{

    [ContentProperty(nameof(Oszlopok))]
    public partial class KetgombosLista : UserControl
    {
        public KetgombosLista()
        {
            InitializeComponent();
        }

        private void Betoltve(object sender, RoutedEventArgs e)
        {
            // A WPF nem engedi másik elemhez rendelni egy GridViewColumn objektumot,
            // amíg az hozzá van rendelve valamihez. Úgyhogy ki kell vegyem az Oszlopok gyűjteményből (de csak egyszer):
            if (Oszlopok.Count > 0)
            {
                List<GridViewColumn> buffer = Oszlopok.ToList();
                Oszlopok.Clear();
                // A kiválasztógombok oszlopát csak akkor adom hozzá, ha van végrehajtójuk:
                if (Kivalaszt != null)
                {
                    GridViewColumn oszlop = new GridViewColumn();
                    oszlop.CellTemplate = FindResource("KivalasztOszlopTemplate") as DataTemplate;
                    MyGridView.Columns.Add(oszlop);
                }
                foreach (var oszlop in buffer) MyGridView.Columns.Add(oszlop);
                bool felveszKellhet = false; //Csak az utolsó oszlopra kell Felvesz gomb, de itt még nem tudom, mi lesz az utolsó oszlop
                // A megnyitógombok oszlopát csak akkor adom hozzá, ha van végrehajtójuk:
                if (Megnyit != null)
                {
                    GridViewColumn oszlop = new GridViewColumn();
                    oszlop.CellTemplate = FindResource("MegnyitOszlopTemplate") as DataTemplate;
                    MyGridView.Columns.Add(oszlop);
                    felveszKellhet = true;
                }
                if (Modosit != null)
                // A módosítógombok oszlopát csak akkor adom hozzá, ha van végrehajtójuk:
                {
                    GridViewColumn oszlop = new GridViewColumn();
                    oszlop.CellTemplate = FindResource("ModositOszlopTemplate") as DataTemplate;
                    MyGridView.Columns.Add(oszlop);
                    felveszKellhet = true;
                }
                if (felveszKellhet)
                {
                    // A Felvesz gombot csak akkor adom hozzá, ha van végrehajtója
                    if (Felvesz != null) MyGridView.Columns.Last().Header = FindResource("FelveszHeader") as GridViewColumnHeader;
                }
            }
        }

        public GridViewColumnCollection Oszlopok { get; set; } = new GridViewColumnCollection();

        public IEnumerable TetelForras
        {
            get { return (IEnumerable)GetValue(TetelForrasProperty); }
            set { SetValue(TetelForrasProperty, value); }
        }

        public static readonly DependencyProperty TetelForrasProperty =
            DependencyProperty.Register(
                "TetelForras",
                typeof(IEnumerable),
                typeof(KetgombosLista)
            );

        public EventHandler<object> Kivalaszt
        {
            get { return (EventHandler<object>)GetValue(KivalasztProperty); }
            set { SetValue(KivalasztProperty, value); }
        }

        public static readonly DependencyProperty KivalasztProperty =
            DependencyProperty.Register(
                "Kivalaszt",
                typeof(EventHandler<object>),
                typeof(KetgombosLista)
            );

        private void KivalasztClick(object sender, RoutedEventArgs e)
        {
            Kivalaszt?.Invoke(this, (e.Source as Button).DataContext);
        }


        public EventHandler<object> Modosit
        {
            get { return (EventHandler<object>)GetValue(ModositProperty); }
            set { SetValue(ModositProperty, value); }
        }

        public static readonly DependencyProperty ModositProperty =
            DependencyProperty.Register(
                "Modosit",
                typeof(EventHandler<object>),
                typeof(KetgombosLista)
            );

        private void ModositClick(object sender, RoutedEventArgs e)
        {
            Modosit?.Invoke(this, (e.Source as Button).DataContext);
        }

        public EventHandler<object> Megnyit
        {
            get { return (EventHandler<object>)GetValue(MegnyitProperty); }
            set { SetValue(MegnyitProperty, value); }
        }

        public static readonly DependencyProperty MegnyitProperty =
            DependencyProperty.Register(
                "Megnyit",
                typeof(EventHandler<object>),
                typeof(KetgombosLista)
            );

        private void MegnyitClick(object sender, RoutedEventArgs e)
        {
            Megnyit?.Invoke(this, (e.Source as Button).DataContext);
        }

        public RoutedEventHandler Felvesz
        {
            get { return (RoutedEventHandler)GetValue(FelveszProperty); }
            set { SetValue(FelveszProperty, value); }
        }

        public static readonly DependencyProperty FelveszProperty =
            DependencyProperty.Register(
                "Felvesz",
                typeof(RoutedEventHandler),
                typeof(KetgombosLista)
            );

        private void FelveszClick(object sender, RoutedEventArgs e)
        {
            Felvesz?.Invoke(this, new RoutedEventArgs());
        }
    }
}
