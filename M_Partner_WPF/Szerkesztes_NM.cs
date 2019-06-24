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
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        IValtozas valtozas = new Valtozas_EF(new EFContext());

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

    }
}
