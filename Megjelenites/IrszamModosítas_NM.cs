using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Sajat.Tarolas;

namespace Sajat.Megjelenites
{
    public class IrszamModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private Valtozas valtozas;

        public IrszamModositas_NM(Valtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        #region ICsatolhatoNezetModell
        private FEKerelem kapottFEKerelem;
        public FEKerelem FEKerelem
        {
            get { return kapottFEKerelem; }
            set
            {
                kapottFEKerelem = value;
                int id = value.Parameterek.As<int>("id");
                if (id == 0)
                {
                    Irszam = new Irszam();
                    valtozas.Context.Irszamok.Add(Irszam);
                }
                else Irszam = valtozas.Context.Irszamok.Single(i => i.Id == id);
            }
        }

        public FEIndito FEIndito { get; set; }

        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion


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
                FEKerelem.Befejezes(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", true)
                        .Eredmeny("irszam", Irszam)
                );
            }
        }

        public void Elveteskor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("rogzites", false)
                    .Eredmeny("irszam", Irszam)
            );
        }

        public void OrszagKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "OrszagValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
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
