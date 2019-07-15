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
    public class AlCsoportValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public AlCsoportValasztas_NM(ITarolo tarolo)
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

        private ObservableCollection<AlCsoport> lista;
        public ObservableCollection<AlCsoport> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public void Lekerdezeskor()
        {
            string nev = StringMuveletek.NullHaUres(Szuromezok["nev"].Ertek);
            lista = new ObservableCollection<AlCsoport>(tarolo.AlCsoportok.MindAhol(
                AlCsoport =>
                (nev == null || AlCsoport.Nev.Contains(nev))
            ));
            Ertesites(nameof(Lista));
        }

        public void Visszakor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", false)
            );
        }

        public void Felveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Cikk-AlCsoportModositas",
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

        public void Kivalasztaskor(AlCsoport AlCsoport)
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", AlCsoport.Id)
            );
        }

        public void Modositaskor(AlCsoport alcsoport)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Cikk-AlCsoportModositas",
                    new FEParameterek().Parameter("id", alcsoport.Id),
                    (eredmenyek) => {
                        tarolo.AlCsoportok.Frissit(alcsoport);
                    }
                )
            );
        }
    }
}
