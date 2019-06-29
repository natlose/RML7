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
    public class Szerkesztes_NM : Megfigyelheto, ICsatolhatoNezetModell
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
            else Partner = valtozas.Partnerek.Egyetlen(id);
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

        public bool VanUtkozes
        {
            get => valtozas.VanUtkozes;
        }

        public bool VanErvenytelenAdat
        {
            get => valtozas.VanErvenytelenAdat;
        }

        public void Rogziteskor()
        {
            if (valtozas.ValtozasRogzitese())
            {
                KapottFEKerelem.Eredmeny?.Invoke(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", true)
                        .Eredmeny("partner", Partner)
                );
            }
            else Ertesites(nameof(VanUtkozes));
        }

        public void Elveteskor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny("rogzites", false)
                    .Eredmeny("partner", Partner)
            );
        }

    }
}
