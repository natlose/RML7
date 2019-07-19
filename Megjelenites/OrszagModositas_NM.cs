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
    public class OrszagModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private Valtozas valtozas;
        public OrszagModositas_NM(Valtozas valtozas)
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
                    Orszag = new Orszag();
                    valtozas.Context.Orszagok.Add(Orszag);
                }
                else Orszag = valtozas.Context.Orszagok.Single(o => o.Id == id);
            }
        }

        public FEIndito FEIndito { get; set; }

        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion


        private Orszag orszag;
        public Orszag Orszag
        {
            get => orszag;
            set => ErtekadasErtesites(ref orszag, value);
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
                        .Eredmeny("orszag", Orszag)
                );
            }
        }

        public void Elveteskor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("rogzites", false)
            );
        }

    }
}
