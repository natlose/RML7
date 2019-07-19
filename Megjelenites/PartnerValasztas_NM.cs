using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Uzlet;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Sajat.Tarolas;

namespace Sajat.Megjelenites
{
    public class PartnerValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private SajatContext context;

        public PartnerValasztas_NM(SajatContext context)
        {
            this.context = context;
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
                        FEIndito.Inditas(
                            new FEKerelem(
                                "OrszagValasztas",
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
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => true; }
        #endregion

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
            string nev = StringMuveletek.NullHaUres(Szuromezok["nev"].Ertek);
            string mobil = StringMuveletek.NullHaUres(Szuromezok["mobil"].Ertek);
            string telefon = StringMuveletek.NullHaUres(Szuromezok["telefon"].Ertek);
            string email = StringMuveletek.NullHaUres(Szuromezok["email"].Ertek);
            string cegjegyzekszam = StringMuveletek.NullHaUres(Szuromezok["cegjegyzekszam"].Ertek);
            string adoszam = StringMuveletek.NullHaUres(Szuromezok["adoszam"].Ertek);
            string orszag = StringMuveletek.NullHaUres(Szuromezok["orszag"].Ertek);
            Lista = new ObservableCollection<Partner>(
                context.Partnerek
                    .Include(p => p.PostaCimek)
                    .Where(
                        p =>
                        (nev == null || p.Nev.Contains(nev))
                        && (mobil == null || p.Elerhetoseg.Mobil.Contains(mobil))
                        && (telefon == null || p.Elerhetoseg.Telefon.Contains(telefon))
                        && (email == null || p.Elerhetoseg.Email.Contains(email))
                        && (cegjegyzekszam == null || p.MJ == "J" && p.Jogiszemely.Cegjegyzekszam.Contains(cegjegyzekszam))
                        && (adoszam == null || p.MJ == "J" && p.Jogiszemely.Adoszam.Contains(adoszam))
                        && (orszag == null || p.MJ == "J" && p.Jogiszemely.Orszag == orszag))
                    .OrderBy(p => p.Nev)
                .Skip((Lapozo.Oldal - 1) * Lapozo.Oldalmeret)
                .Take(Lapozo.Oldalmeret)                
            );
        }

        public void Lekerdezeskor()
        {
            Lapozo.Ujraindit();
            Lapozaskor();
        }

        public void Felveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PartnerModositas",
                    new FEParameterek().Parameter("id", 0),
                    (eredmenyek) => {
                        if (eredmenyek.As<int>("rogzites") == 1)
                        {
                            Lekerdezeskor();
                        }
                    }
                )
            );
        }

        public void Visszakor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", false)
            );
        }

        public void Kivalasztaskor(Partner partner)
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", partner.Id)
            );
        }

        public void Modositaskor(Partner partner)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PartnerModositas", 
                    new FEParameterek().Parameter("id", partner.Id),
                    (eredmenyek) => {
                        Partner modositott = eredmenyek.As<Partner>("partner");
                        if (eredmenyek.As<int>("rogzites") == 1) context.Entry(partner).Reload();
                        else if (eredmenyek.As<int>("rogzites") == -1) Lekerdezeskor();
                    }
                )
            ); 
        }
    }
}
