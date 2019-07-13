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
using System.Windows;

namespace Sajat.Partner
{
    public class PartnerValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public PartnerValasztas_NM(IPartnerTarolo tarolo)
        {
            this.tarolo = tarolo;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1})
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
                                "Partner-OrszagValasztas",
                                null,
                                (eredmenyek) => {
                                    if (eredmenyek.As<bool>("valasztas"))
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

        public bool Megszakithato { get => true; }
        #endregion

        private IPartnerTarolo tarolo;

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
            Lapozaskor();
        }

        public void Felveszkor()
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-PartnerModositas",
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
            KapottFEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", false)
            );
        }

        public void Kivalasztaskor(Partner partner)
        {
            KapottFEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", partner.Id)
            );
        }

        public void Modositaskor(Partner partner)
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-PartnerModositas", 
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
