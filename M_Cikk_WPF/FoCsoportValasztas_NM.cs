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
    public class FoCsoportValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public FoCsoportValasztas_NM(ITarolok tarolok)
        {
            this.tarolok = tarolok;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1 });
            Lekerdezeskor();
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }

        public bool Megszakithato => true;
        #endregion

        private ITarolok tarolok;

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        private ObservableCollection<FoCsoport> lista;
        public ObservableCollection<FoCsoport> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public void Lekerdezeskor()
        {
            string nev = StringMuveletek.NullHaUres(Szuromezok["nev"].Ertek);
            lista = new ObservableCollection<FoCsoport>(tarolok.FoCsoportok.MindAhol(
                focsoport =>
                (nev == null || focsoport.Nev.Contains(nev))
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
                    "Cikk-FoCsoportModositas",
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

        public void Kivalasztaskor(FoCsoport focsoport)
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", focsoport.Id)
            );
        }

        public void Modositaskor(FoCsoport focsoport)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Cikk-FoCsoportModositas",
                    new FEParameterek().Parameter("id", focsoport.Id),
                    (eredmenyek) => {
                        tarolok.FoCsoportok.Frissit(focsoport);
                    }
                )
            );
        }
    }
}
