using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Uzlet;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Megjelenites
{
    public class OrszagValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public OrszagValasztas_NM(ITarolok tarolok)
        {
            this.tarolok = tarolok;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1 });
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }

        public FEIndito FEIndito { get; set; }

        public bool Megszakithato { get => true; }
        #endregion

        private ITarolok tarolok;

        private ObservableCollection<Orszag> lista;
        public ObservableCollection<Orszag> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        public void Lekerdezeskor()
        {
            string nev = StringMuveletek.NullHaUres(Szuromezok["nev"].Ertek);
            lista = new ObservableCollection<Orszag>(tarolok.Orszagok.MindAhol(
                orszag =>
                (nev == null || orszag.Nev.Contains(nev))
            ));
            Ertesites(nameof(Lista));
        }

        public void Felveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Partner-OrszagModositas",
                    new FEParameterek().Parameter("id", 0),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("rogzites"))
                        {
                            Orszag felvett = eredmenyek.As<Orszag>("orszag");
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

        public void Kivalasztaskor(Orszag orszag)
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("orszag", orszag)
            );
        }

        public void Modositaskor(Orszag orszag)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Partner-OrszagModositas",
                    new FEParameterek().Parameter("id", orszag.Id),
                    (eredmenyek) => {
                        Orszag modositott = eredmenyek.As<Orszag>("orszag");
                        tarolok.Orszagok.Frissit(orszag);
                    }
                )
            );
        }
    }
}
