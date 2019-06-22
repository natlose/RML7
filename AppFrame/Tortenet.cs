﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AppFrame.API;

namespace AppFrame
{
    public class Tortenet
    {
        public ObservableCollection<FEset_N> Nezetek { get; private set; }

        public Tortenet(FEKerelem kerelem)
        {
            Nezetek = new ObservableCollection<FEset_N>();
            FEKerelemkor(kerelem);
        }

        public void FEKerelemkor(FEKerelem kerelem)
        {
            try
            {
                FEset_N nezet = new FEset_N();
                Type type = Type.GetType(kerelem.OsztalyNeve + ", " + kerelem.SzerelvenyNeve, true);
                object ismeretlenObjektum = Activator.CreateInstance(type);
                if (ismeretlenObjektum is UserControl)
                {
                    UserControl dinamikusTartalom = ismeretlenObjektum as UserControl;
                    nezet.NezetHelye.Child = dinamikusTartalom;
                    if (dinamikusTartalom is INezetModelltAtad)
                    {
                        object ismeretlenNM = (dinamikusTartalom as INezetModelltAtad).NezetModell;
                        if (ismeretlenNM is IDinamikusanCsatolhatoNezetModell)
                        {
                            IDinamikusanCsatolhatoNezetModell dinamikusNM = ismeretlenNM as IDinamikusanCsatolhatoNezetModell;
                            dinamikusNM.SajatFEKerelem += this.FEKerelemkor;
                            // Lecserélem a kérelemben az eredményfeldolgozót a sajátomra,
                            // amiben azért meghívom az eredetit is, de közben el tudom intézni
                            // a saját dolgaimat:
                            Action<FEEredmenyek> eredmenyfeldolgozo = kerelem.Eredmeny;
                            kerelem.Eredmeny = (eredmenyek) =>
                            {
                                eredmenyfeldolgozo?.Invoke(eredmenyek);
                                // Majd a GC szépen mindent felszabadít, ha sehogy nem hivatkozom tovább semmire:
                                dinamikusNM.SajatFEKerelem -= this.FEKerelemkor;
                                Nezetek.Remove(Nezetek.Last());
                                if (Nezetek.Count > 0) Nezetek.Last().IsEnabled = true;
                            };
                            dinamikusNM.KapottFEKerelem = kerelem;
                            if (Nezetek.Count > 0) Nezetek.Last().IsEnabled = false;
                            Nezetek.Add(nezet);
                        }
                        else throw new ArgumentException($"A {ismeretlenNM.GetType().AssemblyQualifiedName} nem IDinamikusanCsatolhatoNezetModell.");
                    }
                    else throw new ArgumentException($"A {kerelem.OsztalyNeve}, {kerelem.SzerelvenyNeve} nem INezetModelltAtad.");
                }
                else throw new ArgumentException($"A {kerelem.OsztalyNeve}, {kerelem.SzerelvenyNeve} nem UserControl.");
            }
            catch (Exception)
            {
                throw; //todo: valami hibakezelés kéne ide
            }
        }

    }
}
