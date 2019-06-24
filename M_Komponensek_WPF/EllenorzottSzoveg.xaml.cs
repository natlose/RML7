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
    public partial class EllenorzottSzoveg : UserControl
    {
        public EllenorzottSzoveg()
        {
            InitializeComponent();
        }

        //Regisztráljuk a WPF nyilvántartásába, hogy az EllenorzottSzoveg osztály objektumpéldányaival kapcsolatban szeretnénk
        //egy Cimke nevű, string típusú, "" értékkel inicializált tulajdonságot kezelni.
        //Ez egy DependencyProperty.
        //Ezek értéke kezelhető XAML-ban, Binding célok lehetnek, értékük öröklődik lefele a vizuális objektumfán, stílusok, animációk alanya lehet.
        //Hagyomány szerint a neve Property-re végződik
        //A VS-nek van rá snippetje: propdp 2xTAB
        public static readonly DependencyProperty CimkeProperty =
            DependencyProperty.Register("Cimke", typeof(string), typeof(EllenorzottSzoveg), new PropertyMetadata(""));

        //Ez csak a DependencyProperty könnyebb kezelhetősége miatt hozzuk létre, hogy ne kelljen vessződni a GetValue(), SetValue() metódusokkal
        //Soha ne rakj ide ennél több logikát, mert a framework elemei közvetlenül is használhatják a Get/SetValue metódusokat, és akkor kimarad amit ide írsz
        public string Cimke
        {
            get { return (string)GetValue(CimkeProperty); }
            set { SetValue(CimkeProperty, value); }
        }

        //Kell nekünk egy Szoveg nevű függő tulajdonság is, méghozzá kétirányú Binding-al
        //Ezt a láncot készülünk felépíteni:
        //
        // MainWindowVM.Partner.FirstName <-Binding-> EllenorzottSzoveg.Szoveg <-Binding-> TextBox.Text
        //
        //Akármelyik vége változik a láncnak, akarjuk hogy a változás közvetítésre kerüljön
        public static readonly DependencyProperty SzovegProperty =
            DependencyProperty.Register(
                "Szoveg", 
                typeof(string), 
                typeof(EllenorzottSzoveg), 
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault) //így a XAML-ban nem kell mindig kiírni, hogy Mode=TwoWay
            );
        
        public string Szoveg
        {
            get { return (string)GetValue(SzovegProperty); }
            set { SetValue(SzovegProperty, value); }
        }
    }
}
