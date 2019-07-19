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
using Sajat.Tarolas;

namespace Sajat.Megjelenites
{
    public class IrszamValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private readonly SajatContext context;

        public IrszamValasztas_NM(SajatContext context)
        {
            this.context = context;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("orszag", new Szuromezo("Ország") { Elore = 1, Ertek = "HU"})
                .Mezo("helyseg", new Szuromezo("Helység") { Elore = 2 });
            Lekerdezeskor();
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => true; }
        #endregion

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        private ObservableCollection<Irszam> lista;
        public ObservableCollection<Irszam> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        internal void Lekerdezeskor()
        {
            string orszag = StringMuveletek.NullHaUres(Szuromezok["orszag"].Ertek);
            string helyseg = StringMuveletek.NullHaUres(Szuromezok["helyseg"].Ertek);
            Lista = new ObservableCollection<Irszam>(context.Irszamok.Where(
                irsz =>
                (orszag == null || irsz.Orszagkod == orszag)
                && (helyseg == null || irsz.Helyseg.Contains(helyseg))
            ));
        }

        internal void Modositaskor(Irszam irszam)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "IrszamModositas",
                    new FEParameterek().Parameter("id", irszam.Id),
                    (eredmenyek) => {
                        context.Entry(irszam).Reload();
                    }
                )
            );
        }
        public void Felveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "IrszamModositas",
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

        internal void Visszakor()
        {
            FEKerelem.Befejezes(
                 new FEEredmenyek()
                     .Eredmeny("valasztas", false)
             );
        }

        internal void Kivalasztaskor(Irszam irszam)
        {
            FEKerelem.Befejezes(
                 new FEEredmenyek()
                     .Eredmeny("valasztas", true)
                     .Eredmeny("irszam", irszam)
             );
        }
    }
}
