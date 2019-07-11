﻿using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class IrszamModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        #region ICsatolhatoNezetModell
        private FEKerelem kapottFEKerelem;
        public FEKerelem KapottFEKerelem
        {
            get { return kapottFEKerelem; }
            set
            {
                kapottFEKerelem = value;
                int id = value.Parameterek.As<int>("id");
                if (id == 0)
                {
                    Irszam = new Irszam();
                    valtozas.Irszamok.EgyetBetesz(Irszam);
                }
                else Irszam = valtozas.Irszamok.Egyetlen(id);
            }
        }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        IIrszamValtozas valtozas = new IrszamValtozas_EF(new PartnerContext());

        private Irszam irszam;
        public Irszam Irszam
        {
            get => irszam;
            set => ErtekadasErtesites(ref irszam, value);
        }

        public bool VanValtozas
        {
            get => valtozas.VanValtozas;
        }

        private RogzitesEredmeny rogzitesEredmeny;
        public RogzitesEredmeny RogzitesEredmeny
        {
            get => rogzitesEredmeny;
            set => ErtekadasErtesites(ref rogzitesEredmeny, value);
        }

        public void Rogziteskor()
        {
            RogzitesEredmeny = valtozas.ValtozasRogzitese();
            if (RogzitesEredmeny == RogzitesEredmeny.Siker)
            {
                KapottFEKerelem.Eredmeny?.Invoke(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", true)
                        .Eredmeny("irszam", Irszam)
                );
            }
        }

        public void Elveteskor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny("rogzites", false)
                    .Eredmeny("irszam", Irszam)
            );
        }

        public void OrszagKereseskor()
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-OrszagValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas", null))
                        {
                            Orszag valasztott = eredmenyek.As<Orszag>("orszag");
                            Irszam.Orszagkod = valasztott.Iso;
                        }
                    }
                )
            );
        }

    }
}
