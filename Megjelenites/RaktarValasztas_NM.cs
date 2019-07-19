using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Uzlet;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Sajat.Tarolas;

namespace Sajat.Megjelenites
{
    public class RaktarValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private SajatContext context;

        public RaktarValasztas_NM(SajatContext context)
        {
            this.context = context;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1 });
            Lekerdezeskor();
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }
        public bool Megszakithato => true;
        #endregion

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
            Lista = new ObservableCollection<Raktar>(context.Raktarak.Where(
                raktar =>
                (nev == null || raktar.Nev.Contains(nev))
            ));
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
                    "RaktarMegtekintes",
                    new FEParameterek().Parameter("id", raktar.Id),
                    null
                )
            );
        }

        public void Felveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "RaktarModositas",
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
                    "RaktarModositas",
                    new FEParameterek().Parameter("id", raktar.Id),
                    (eredmenyek) => {
                        context.Entry(raktar).Reload();
                    }
                )
            );
        }
    }
}
