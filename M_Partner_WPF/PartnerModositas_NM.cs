using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Partner;
using Sajat.SQLTarolas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PartnerModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public PartnerModositas_NM(IPartnerValtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        #region ICsatolhatoNezetModell
        private FEKerelem kapottFEKerelem;
        public FEKerelem KapottFEKerelem
        {
            get => kapottFEKerelem;
            set
            {
                kapottFEKerelem = value;
                int id = value.Parameterek.As<int>("id");
                if (id == 0)
                {
                    Partner = new Partner();
                    valtozas.Partnerek.EgyetBetesz(Partner);
                }
                else Partner = valtozas.Partnerek.Egyetlen(id);
            }
        }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        IPartnerValtozas valtozas;

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
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-OrszagValasztas",
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
                KapottFEKerelem.Befejezes(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", 1)
                        .Eredmeny("partner", Partner)
                );
            }
        }

        public void Elveteskor()
        {
            KapottFEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("rogzites", 0)
                    .Eredmeny("partner", Partner)
            );
        }

        internal void Torleskor()
        {
            valtozas.Partnerek.EgyetTorol(Partner);
            RogzitesEredmeny = valtozas.ValtozasRogzitese();
            if (RogzitesEredmeny == RogzitesEredmeny.Siker)
            {
                KapottFEKerelem.Eredmeny?.Invoke(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", -1)
                        .Eredmeny("partner", Partner)
                );
            }
        }

        public void PostaCimFelveszkor()
        {
            PostaCim postacim = new PostaCim();
            Partner.PostaCimek.Add(postacim);
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-PostaCimModositas",
                    new FEParameterek().Parameter("postacim", postacim),
                    //Szabad elhagyni az eredményfeldolgozót ha nincs mit csinálni benne.
                    //A Sajat.Alkalmazas.WPF.Tortenet elég okos, hogy ne hívja, ha nincs.
                    null
                )
            );
        }

        internal void PostaCimMegnyitaskor(PostaCim postaCim)
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-PostaCimModositas",
                    new FEParameterek().Parameter("postacim", postaCim),
                    null
                )
            );
        }

    }
}
