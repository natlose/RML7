using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public class RaktarValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public RaktarValasztas_NM(ITarolo tarolo)
        {
            this.tarolo = tarolo;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1 });
            Lekerdezeskor();
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }

        public bool Megszakithato => true;
        #endregion

        private ITarolo tarolo;

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        private ObservableCollection<Raktar> lista;
        public ObservableCollection<Raktar> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public void Lekerdezeskor()
        {
            string nev = StringMuveletek.NullHaUres(Szuromezok["nev"].Ertek);
            lista = new ObservableCollection<Raktar>(tarolo.Raktarak.MindAhol(
                raktar =>
                (nev == null || raktar.Nev.Contains(nev))
            ));
            Ertesites(nameof(Lista));
        }

        public void Visszakor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek().Eredmeny("valasztas", false)
            );
        }

        internal void Megnyitaskor(Raktar raktar)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Keszlet-RaktarMegtekintes",
                    new FEParameterek().Parameter("id", raktar.Id),
                    null
                )
            );
        }

        public void Felveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Keszlet-RaktarModositas",
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

        public void Kivalasztaskor(Raktar raktar)
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", raktar.Id)
            );
        }

        public void Modositaskor(Raktar raktar)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Keszlet-RaktarModositas",
                    new FEParameterek().Parameter("id", raktar.Id),
                    (eredmenyek) => {
                        tarolo.Raktarak.Frissit(raktar);
                    }
                )
            );
        }
    }
}
