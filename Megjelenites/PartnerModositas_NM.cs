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
    public class PartnerModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private Valtozas valtozas;

        public PartnerModositas_NM(Valtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        #region ICsatolhatoNezetModell
        private FEKerelem kapottFEKerelem;
        public FEKerelem FEKerelem
        {
            get => kapottFEKerelem;
            set
            {
                kapottFEKerelem = value;
                int id = value.Parameterek.As<int>("id");
                if (id == 0)
                {
                    Partner = new Partner();
                    valtozas.Context.Partnerek.Add(Partner);
                }
                else Partner = valtozas.Context.Partnerek.Include(p => p.PostaCimek).Single(e => e.Id == id);
            }
        }

        public FEIndito FEIndito { get; set; }

        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        private Partner partner;
        public Partner Partner
        {
            get => partner; 
            set => ErtekadasErtesites(ref partner, value);
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
                            Partner.Jogiszemely.Orszag = valasztott.Iso;
                        }
                    }
                )
            );
        }

        public void Rogziteskor()
        {
            RogzitesEredmeny = valtozas.ValtozasRogzitese();
            if (RogzitesEredmeny == RogzitesEredmeny.Siker)
            {
                FEKerelem.Befejezes(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", 1)
                        .Eredmeny("partner", Partner)
                );
            }
        }

        public void Elveteskor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("rogzites", 0)
            );
        }

        internal void Torleskor()
        {
            valtozas.Context.Partnerek.Remove(Partner);
            RogzitesEredmeny = valtozas.ValtozasRogzitese();
            if (RogzitesEredmeny == RogzitesEredmeny.Siker)
            {
                FEKerelem.Befejezes(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", -1)
                );
            }
        }

        public void PostaCimFelveszkor()
        {
            PostaCim postacim = new PostaCim();
            Partner.PostaCimek.Add(postacim);
            FEIndito.Inditas(
                new FEKerelem(
                    "PostaCimModositas",
                    new FEParameterek().Parameter("postacim", postacim),
                    //Szabad elhagyni az eredményfeldolgozót ha nincs mit csinálni benne.
                    //A Sajat.Alkalmazas.WPF.Tortenet elég okos, hogy ne hívja, ha nincs.
                    null
                )
            );
        }

        internal void PostaCimMegnyitaskor(PostaCim postaCim)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PostaCimModositas",
                    new FEParameterek().Parameter("postacim", postaCim),
                    null
                )
            );
        }

    }
}
