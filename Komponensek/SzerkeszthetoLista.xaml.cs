using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    public partial class SzerkeszthetoLista : UserControl
    {
        public SzerkeszthetoLista()
        {
            InitializeComponent();
        }

        public GridViewColumnCollection Oszlopok { get; set; } = new GridViewColumnCollection();

        public void TetelForrasValtozaskor(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            AutoResizeGridViewColumns(MyGridView);
        }

        static void AutoResizeGridViewColumns(GridView view)
        {
            if (view == null || view.Columns.Count < 1) return;
            foreach (var column in view.Columns)
            {
                // Ez kierőszakolja a méretezést (leveszem, majd visszarakom rá az Auto szélességet)
                column.Width = column.ActualWidth;
                column.Width = double.NaN;
            }
        }

        #region Cimke
        public static readonly DependencyProperty CimkeProperty =
            DependencyProperty.Register(
                "Cimke",
                typeof(string),
                typeof(SzerkeszthetoLista),
                new PropertyMetadata("")
            );

        public string Cimke
        {
            get { return (string)GetValue(CimkeProperty); }
            set { SetValue(CimkeProperty, value); }
        }
        #endregion

        #region TetelForras
        public static readonly DependencyProperty TetelForrasProperty =
            DependencyProperty.Register(
                "TetelForras",
                typeof(INotifyCollectionChanged),
                typeof(SzerkeszthetoLista),
                new PropertyMetadata((dpo, e) => {
                    if (e.OldValue != null) (e.OldValue as INotifyCollectionChanged).CollectionChanged -= (dpo as SzerkeszthetoLista).TetelForrasValtozaskor;
                    if (e.NewValue != null) (e.NewValue as INotifyCollectionChanged).CollectionChanged += (dpo as SzerkeszthetoLista).TetelForrasValtozaskor;
                })
            );

        public INotifyCollectionChanged TetelForras
        {
            get { return (INotifyCollectionChanged)GetValue(TetelForrasProperty); }
            set { SetValue(TetelForrasProperty, value); }
        }
        #endregion

        #region SzerkesztoTemplate
        public DataTemplate SzerkesztoTemplate
        {
            get { return (DataTemplate)GetValue(SzerkesztoTemplateProperty); }
            set { SetValue(SzerkesztoTemplateProperty, value); }
        }

        public static readonly DependencyProperty SzerkesztoTemplateProperty =
            DependencyProperty.Register("SzerkesztoTemplate", typeof(DataTemplate), typeof(SzerkeszthetoLista));
        #endregion

        private void Betoltve(object sender, RoutedEventArgs e)
        {
            if (Oszlopok.Count > 0)
            {
                List<GridViewColumn> buffer = Oszlopok.ToList();
                Oszlopok.Clear();
                foreach (var oszlop in buffer) MyGridView.Columns.Add(oszlop);
            }
        }
    }
}
