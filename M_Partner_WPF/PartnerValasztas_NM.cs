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
        public PartnerValasztas_NM()
        {
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név"))
                .Mezo("mobil", new Szuromezo("Mobil"))
                .Mezo("telefon", new Szuromezo("Telefon"))
                .Mezo("email", new Szuromezo("Email"))
                .Mezo("cegjegyzekszam", new Szuromezo("Cégjegyzékszám"))
                .Mezo("adoszam", new Szuromezo("Adószám"))
                .Mezo("orszag", new Szuromezo(
                    "Bejegyzés országa",
                    (szm) =>
                    {
                        SajatFEKerelem?.Invoke(
                            new FEKerelem(
                                "M_Partner_WPF", "Sajat.Partner.OrszagValasztas_N",
                                null,
                                (eredmenyek) => {
                                    if (eredmenyek.As<bool>("valasztas", null))
                                    {
                                        Orszag valasztott = eredmenyek.As<Orszag>("orszag");
                                        szm.Ertek = valasztott.Iso;
                                    }
                                }
                            )
                        );

                    })
                );
        }

        #region ICsatolhatoNezetModell
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;
        #endregion

        private IPartnerTarolo tarolo = new PartnerTarolo_EF(new PartnerContext());

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        private Lapozo lapozo = new Lapozo();
        public Lapozo Lapozo
        {
            get => lapozo;
            set => ErtekadasErtesites(ref lapozo, value);
        }

        private ObservableCollection<Partner> lista;
        public ObservableCollection<Partner> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        internal void Lapozaskor()
        {
            Lista = new ObservableCollection<Partner>(
                tarolo.MindAholReszletek(
                    Szuromezok["nev"].Ertek,
                    Szuromezok["mobil"].Ertek,
                    Szuromezok["telefon"].Ertek,
                    Szuromezok["email"].Ertek,
                    Szuromezok["cegjegyzekszam"].Ertek,
                    Szuromezok["adoszam"].Ertek,
                    Szuromezok["orszag"].Ertek,
                    Lapozo.Oldalmeret,
                    Lapozo.Oldal
                )
            );
        }

        public void Lekerdezeskor()
        {
            Lapozo.Ujraindit();
            Lapozo.Oldalmeret = 10;
            Lapozaskor();
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
