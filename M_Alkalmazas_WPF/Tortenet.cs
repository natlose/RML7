using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;

namespace Sajat.Alkalmazas.WPF
{
    public class Tortenet : Megfigyelheto
    {
        //Ide teszem annak delegáltnak a címét, ami fel tudja oldani a felhasználói eset azonosítókat szerelvényre és osztályra
        private Func<string, RegiszterBejegyzes> fesetIdFelismeres;

        public DateTime Azonosito { get; private set; }

        public ObservableCollection<FEset_N> Nezetek { get; private set; }

        // Ezt kívülről a Tortenetek_NM fogja állítgatni.
        // Csak az a célja, hogy a TortenetValto_N legyen képes eltérően
        // megjeleníteni az aktív történetet.
        private bool aktivVagyok;
        public bool AktivVagyok
        {
            get => aktivVagyok;
            set => ErtekadasErtesites(ref aktivVagyok, value);
        }

        public Tortenet(FEKerelem kerelem, Action<Tortenet> valtozaskor, Func<string, RegiszterBejegyzes> fesetIdFelismeres)
        {
            this.fesetIdFelismeres = fesetIdFelismeres;
            Azonosito = DateTime.Now;
            Nezetek = new ObservableCollection<FEset_N>();
            Nezetek.CollectionChanged += (s, e) => {
                valtozaskor?.Invoke(this);
            };
            FEKerelemkor(kerelem);
        }

        public void FEKerelemkor(FEKerelem kerelem)
        {
            try
            {
                RegiszterBejegyzes regiszter = fesetIdFelismeres(kerelem.Id);
                if (regiszter == null)
                    throw new ArgumentException($"A {kerelem.Id} felhasználói esetre nincs regisztrált osztály!");
                FEset_N nezet = new FEset_N();
                Type type = Type.GetType(regiszter.Osztaly + ", " + regiszter.Szerelveny, true);
                object ismeretlenN = Activator.CreateInstance(type);
                if (!((ismeretlenN is UserControl) && (ismeretlenN is ICsatolhatoNezet)))
                    throw new ArgumentException($"A {ismeretlenN.GetType().AssemblyQualifiedName} UserControl és ICsatolhatoNezet kell legyen!");
                nezet.NezetHelye.Child = ismeretlenN as UserControl;
                object ismeretlenNM = (ismeretlenN as ICsatolhatoNezet).NezetModell;
                if (!(ismeretlenNM is ICsatolhatoNezetModell))
                    throw new ArgumentException($"A {ismeretlenNM.GetType().AssemblyQualifiedName} ICsatolhatoNezetModell kell legyen!");
                ICsatolhatoNezetModell csatolhatoNM = ismeretlenNM as ICsatolhatoNezetModell;
                csatolhatoNM.SajatFEKerelem += this.FEKerelemkor;
                // Lecserélem a kérelemben az eredményfeldolgozót a sajátomra,
                // amiben azért meghívom az eredetit is, de közben el tudom intézni
                // a saját dolgaimat:
                Action<FEEredmenyek> eredmenyfeldolgozo = kerelem.Eredmeny;
                kerelem.Eredmeny = (eredmenyek) =>
                {
                    eredmenyfeldolgozo?.Invoke(eredmenyek);
                    // Majd a GC szépen mindent felszabadít, ha sehogy nem hivatkozom tovább semmire:
                    csatolhatoNM.SajatFEKerelem -= this.FEKerelemkor;
                    Nezetek.Remove(Nezetek.Last());
                    // Ha még maradt korábbi eset, az lesz az aktív:
                    if (Nezetek.Count > 0) Nezetek.Last().IsEnabled = true;
                };
                csatolhatoNM.KapottFEKerelem = kerelem;
                if (Nezetek.Count > 0) Nezetek.Last().IsEnabled = false;
                Nezetek.Add(nezet);
            }
            catch (Exception e)
            {
                FEset_N nezet = new FEset_N();
                KivetelesHelyzet kivetel = new KivetelesHelyzet();
                kivetel.Uzenet = e.Message;
                kivetel.Vissza += (s, n) =>
                {
                    Nezetek.Remove(Nezetek.Last());
                };
                nezet.NezetHelye.Child = kivetel;
                Nezetek.Add(nezet);
            }
        }

    }
}
