using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Sajat.Alkalmazas.API;

namespace Sajat.Alkalmazas.WPF
{
    public class Tortenet
    {
        public DateTime Azonosito { get; private set; }

        public ObservableCollection<FEset_N> Nezetek { get; private set; }

        public Tortenet(FEKerelem kerelem, Action<Tortenet> valtozaskor)
        {
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
                FEset_N nezet = new FEset_N();
                Type type = Type.GetType(kerelem.OsztalyNeve + ", " + kerelem.SzerelvenyNeve, true);
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
            catch (Exception)
            {
                throw; //todo: valami hibakezelés kéne ide
            }
        }

    }
}
