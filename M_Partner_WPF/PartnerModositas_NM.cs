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
    // Hívása:
    //    int id - módosítandó partner azonosítója, 0: új partner
    // Eredmények:
    //    bool rogzites - false: rögzítés elvetve, true: rögzítve
    //    Partner partner - a partner (módosítva vagy sem)
    public class PartnerModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        #region ICsatolhatoNezetModell
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem; 
        #endregion

        IPartnerValtozas valtozas = new PartnerValtozas_EF(new PartnerContext()); //todo: IOC kell ide!Az M_Partner_WPF nem függhet a T_Partner_SQL-től!

        public void BetoltesBefejezesekor()
        {
            int id = KapottFEKerelem.Parameterek.As<int>("id");
            if (id == 0)
            {
                Partner = new Partner();
                valtozas.Partnerek.EgyetBetesz(Partner);
            }
            else Partner = valtozas.Partnerek.PartnerCimekkel(id);
        }

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
                    "M_Partner_WPF", "Sajat.Partner.OrszagValasztas_N",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas", null))
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
                KapottFEKerelem.Eredmeny?.Invoke(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", true)
                        .Eredmeny("partner", Partner)
                );
            }
        }

        public void Elveteskor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny("rogzites", false)
                    .Eredmeny("partner", Partner)
            );
        }

        public void PostaCimFelveszkor()
        {
            
        }

        internal void PostaCimModositaskor(PostaCim postaCim)
        {
            
        }

    }
}
