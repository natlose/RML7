using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Ninject;
using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;

namespace Sajat.Alkalmazas.WPF
{
    public class Tortenet : Megfigyelheto
    {
        //Ide teszem annak delegáltnak a címét, ami fel tudja oldani a felhasználói eset azonosítókat szerelvényre és osztályra
        private Func<string, RegiszterBejegyzes> fesetIdFelismeres;

        private IKernel ninjectKernel;

        public Tortenet(
            FEKerelem kerelem,
            Action<Tortenet> valtozaskor,
            Func<string, RegiszterBejegyzes> fesetIdFelismeres,
            IKernel ninjectKernel)
        {
            this.fesetIdFelismeres = fesetIdFelismeres;
            this.ninjectKernel = ninjectKernel;
            Azonosito = DateTime.Now;
            FEsetek = new ObservableCollection<FEset>();
            FEsetek.CollectionChanged += (s, e) => {
                valtozaskor?.Invoke(this);
            };
            FEKerelemkor(kerelem);
        }

        public DateTime Azonosito { get; private set; }

        public ObservableCollection<FEset> FEsetek { get; private set; }

        // Ezt kívülről a Tortenetek_NM fogja állítgatni.
        // Csak az a célja, hogy a TortenetValto_N legyen képes eltérően
        // megjeleníteni az aktív történetet.
        private bool aktivVagyok;
        public bool AktivVagyok
        {
            get => aktivVagyok;
            set => ErtekadasErtesites(ref aktivVagyok, value);
        }


        public void FEKerelemkor(FEKerelem kerelem)
        {
            try
            {
                RegiszterBejegyzes regiszter = fesetIdFelismeres(kerelem.Id);
                if (regiszter == null)
                    throw new ArgumentException($"A {kerelem.Id} felhasználói esetre nincsenek regisztrált osztályok!");
                FEset eset = new FEset();
                // Példányosítjuk a NézetModellt
                object ismeretlenNM = ninjectKernel.GetService(Type.GetType(regiszter.NezetModellOsztaly, true));
                if (!(ismeretlenNM is ICsatolhatoNezetModell))
                    throw new ArgumentException($"A {ismeretlenNM.GetType().AssemblyQualifiedName} ICsatolhatoNezetModell kell legyen!");
                eset.NezetModell = ismeretlenNM as ICsatolhatoNezetModell;
                // Adok a nézetmodellnek egy kérelemindítót, hogy kérhesse felhasználói esetek indítását tőlem
                eset.NezetModell.FEIndito = new FEIndito(this.FEKerelemkor);
                // Lecserélem a kérelemben az eredményfeldolgozót a sajátomra,
                // amiben azért meghívom az eredetit is, de közben el tudom intézni
                // a saját dolgaimat:
                Action<FEEredmenyek> eredmenyfeldolgozo = kerelem.Eredmeny;
                kerelem.Eredmeny = (eredmenyek) =>
                {
                    // Tehát meghívom az eredeti eseménykezelőt
                    eredmenyfeldolgozo?.Invoke(eredmenyek);
                    // Majd felszámolok minden hivatkozást a befejezett FEsetre, jöhet a GC 
                    eset.NezetModell.FEIndito.Dispose();
                    FEsetek.Remove(FEsetek.Last());
                    // Ha még maradt korábbi eset, az lesz az aktív:
                    if (FEsetek.Count > 0) FEsetek.Last().Nezet.IsEnabled = true;
                };
                eset.NezetModell.FEKerelem = kerelem;
                // Példányosítjuk a Nézetet
                eset.Nezet = new FEset_N();
                object ismeretlenN = Activator.CreateInstance(Type.GetType(regiszter.NezetOsztaly, true));
                if (!(ismeretlenN is UserControl))
                    throw new ArgumentException($"A {ismeretlenN.GetType().AssemblyQualifiedName} UserControl kell legyen!");
                UserControl nezetBelso = ismeretlenN as UserControl;
                nezetBelso.DataContext = eset.NezetModell;
                eset.Nezet.NezetHelye.Child = nezetBelso;
                // Betesszük a lista végére
                if (FEsetek.Count > 0) FEsetek.Last().Nezet.IsEnabled = false;
                FEsetek.Add(eset);
            }
            catch (Exception e)
            {
                FEset eset = new FEset();
                eset.Nezet = new FEset_N();
                KivetelesHelyzet kivetel = new KivetelesHelyzet();
                kivetel.Uzenet = e.Message;
                kivetel.Vissza += (s, n) =>
                {
                    FEsetek.Remove(FEsetek.Last());
                };
                eset.Nezet.NezetHelye.Child = kivetel;
                FEsetek.Add(eset);
            }
        }

    }
}
