using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class CikkValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public CikkValasztas_NM(ITarolo tarolo)
        {
            this.tarolo = tarolo;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1 })
                .Mezo("cikkszam", new Szuromezo("Cikkszám") { Elore = 2 })
                .Mezo("gyartoi", new Szuromezo("Gyártói"))
                .Mezo("angolnev", new Szuromezo("Angol név"));
            Lekerdezeskor();
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }

        public bool Megszakithato => true;
        #endregion

        private ITarolo tarolo;

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        private ObservableCollection<Cikk> lista;
        public ObservableCollection<Cikk> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public void Lekerdezeskor()
        {
            string nev = StringMuveletek.NullHaUres(Szuromezok["nev"].Ertek);
            string cikkszam = StringMuveletek.NullHaUres(Szuromezok["cikkszam"].Ertek);
            string gyartoi = StringMuveletek.NullHaUres(Szuromezok["gyartoi"].Ertek);
            string angolnev = StringMuveletek.NullHaUres(Szuromezok["angolnev"].Ertek);
            lista = new ObservableCollection<Cikk>(tarolo.Cikkek.MindAhol(
                cikk =>
                (nev == null || cikk.Nev.Contains(nev))
                && (cikkszam == null || cikk.Cikkszam.Contains(cikkszam))
                && (gyartoi == null || cikk.GyartoiCikkszam.Contains(gyartoi))
                && (angolnev == null || cikk.AngolNev.Contains(angolnev))
            ));
            Ertesites(nameof(Lista));
        }

        public void Visszakor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek().Eredmeny("valasztas", false)
            );
        }

        public void Felveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Cikk-CikkModositas",
                    new FEParameterek().Parameter("id", 0),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("rogzites"))
                        {
                            Lekerdezeskor();
                        }
                    }
                )
            );
        }

        public void Kivalasztaskor(Cikk cikk)
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", cikk.Id)
            );
        }

        public void Modositaskor(Cikk cikk)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Cikk-CikkModositas",
                    new FEParameterek().Parameter("id", cikk.Id),
                    (eredmenyek) => {
                        tarolo.Cikkek.Frissit(cikk);
                    }
                )
            );
        }
    }
}
