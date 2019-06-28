using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Valasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        #region ICsatolhatoNezetModell
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;
        #endregion

        private IPartnerTarolo tarolo = new PartnerTarolo_EF(new PartnerContext());

        private ObservableCollection<Partner> lista;
        public ObservableCollection<Partner> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public void Lekerdezeskor()
        {
            lista = new ObservableCollection<Partner>(tarolo.Mind());
            Ertesites(nameof(Lista));
        }

        private const string ValasztasEredmeny = "valasztas";

        public void Visszakor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny(ValasztasEredmeny, false)
            );
        }

        public void Kivalasztaskor(Partner partner)
        {

        }

        public void Modositaskor(Partner partner)
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "M_Partner_WPF", "Sajat.Partner.Szerkesztes_N", 
                    new FEParameterek().Parameter("id", partner.Id),
                    (eredmenyek) => {
                        Partner modositott = eredmenyek["partner"] as Partner;
                        tarolo.Frissit(partner);
                    }
                )
            ); 
        }
    }
}
