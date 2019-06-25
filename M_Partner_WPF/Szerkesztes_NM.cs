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
    public class Szerkesztes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        #region ICsatolhatoNezetModell
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;
        #endregion

        IEgysegnyiValtozas valtozas = new Valtozas_EF(new EFContext());

        public void BetoltesBefejezesekor()
        {
            //object id = KapottFEKerelem.Parameterek["id"];
            //if (id is int)
            Partner = valtozas.Partnerek.Egyetlen(1);
        }

        private Partner partner;
        public Partner Partner
        {
            get { return partner; }
            set
            {
                partner = value;
                MegfigyelokErtesitese();
            }
        }

        public bool VanValtozas
        {
            get
            {
                return valtozas.VanValtozas();
            }
        }

        private const string IdEredmeny = "id";
        private const string RogzitesEredmeny = "rogzites";

        public void Rogziteskor(Action kivetel)
        {
            valtozas.ValtozasRogzitese(
                () =>
                {
                    KapottFEKerelem.Eredmeny?.Invoke(
                     new FEEredmenyek()
                         .Eredmeny(RogzitesEredmeny, true)
                         .Eredmeny(IdEredmeny, Partner.Id)
                    );
                },
                () =>
                {
                    kivetel?.Invoke();
                }
            );
        }

        public void Elveteskor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny(RogzitesEredmeny, false)
            );
        }

    }
}
