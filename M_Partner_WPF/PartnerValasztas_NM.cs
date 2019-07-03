using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PartnerValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        #region ICsatolhatoNezetModell
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;
        #endregion

        private IPartnerTarolo tarolo = new PartnerTarolo_EF(new PartnerContext());

        public SzuromezoGyujtemeny Szuromezok { get; set; } =
            new SzuromezoGyujtemeny()
                    .Mezo("nev", new Szuromezo("Név"))
                    .Mezo("mobil", new Szuromezo("Mobil"))
                    .Mezo("telefon", new Szuromezo("Telefon"))
                    .Mezo("email", new Szuromezo("Email"))
                    .Mezo("cegjegyzekszam", new Szuromezo("Cégjegyzékszám"))
                    .Mezo("adoszam", new Szuromezo("Adószám"))
                    .Mezo("orszag", new Szuromezo("Bejegyzés országa"));

        private ObservableCollection<Partner> lista;
        public ObservableCollection<Partner> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public void Lekerdezeskor()
        {
            Lista = new ObservableCollection<Partner>(
                tarolo.MindAholReszletek(
                    Szuromezok["nev"].Ertek,
                    Szuromezok["mobil"].Ertek,
                    Szuromezok["telefon"].Ertek,
                    Szuromezok["email"].Ertek,
                    Szuromezok["cegjegyzekszam"].Ertek,
                    Szuromezok["adoszam"].Ertek,
                    Szuromezok["orszag"].Ertek
                )
            );
        }

        public void Felveszkor()
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "M_Partner_WPF", "Sajat.Partner.PartnerModositas_N",
                    new FEParameterek().Parameter("id", 0),
                    (eredmenyek) => {
                        if (eredmenyek.As<int>("rogzites") == 1)
                        {
                            Partner felvett = eredmenyek.As<Partner>("partner");
                            Lekerdezeskor();
                        }
                    }
                )
            );
        }

        public void Visszakor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny("valasztas", false)
            );
        }

        public void Kivalasztaskor(Partner partner)
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", partner.Id)
            );
        }

        public void Modositaskor(Partner partner)
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "M_Partner_WPF", "Sajat.Partner.PartnerModositas_N", 
                    new FEParameterek().Parameter("id", partner.Id),
                    (eredmenyek) => {
                        Partner modositott = eredmenyek.As<Partner>("partner");
                        if (eredmenyek.As<int>("rogzites") == 1) tarolo.Frissit(partner);
                        else if (eredmenyek.As<int>("rogzites") == -1) Lekerdezeskor();
                    }
                )
            ); 
        }
    }
}
