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
    public class PolcValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private SajatContext context;

        public PolcValasztas_NM(SajatContext context)
        {
            this.context = context;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("raktar", new Szuromezo(
                    "Raktár",
                    szm =>
                    {
                        FEIndito.Inditas(
                            new FEKerelem(
                                "RaktarValasztas",
                                null,
                                (eredmenyek) => {
                                    if (eredmenyek.As<bool>("valasztas"))
                                    {
                                        int id = eredmenyek.As<int>("id");
                                        szm.Ertek = context.Raktarak.Single(r => r.Id == id).Nev;
                                    }
                                }
                            )
                        );
                    })
                    { Elore = 1 }
                )
                .Mezo("kod", new Szuromezo("Kód"))
                .Mezo("megj", new Szuromezo("Megjegyzés"));
            Lekerdezeskor();
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }
        public bool Megszakithato => true;
        #endregion

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        private ObservableCollection<Polc> lista;
        public ObservableCollection<Polc> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public void Lekerdezeskor()
        {
            string kod = StringMuveletek.NullHaUres(Szuromezok["kod"].Ertek);
            string raktar = StringMuveletek.NullHaUres(Szuromezok["raktar"].Ertek);
            string megj = StringMuveletek.NullHaUres(Szuromezok["megj"].Ertek);
            Lista = new ObservableCollection<Polc>(context.Polcok.Include(p => p.Raktar).Where(
                Polc =>
                    (kod == null || Polc.Kod.Contains(kod))
                    && (raktar == null || Polc.Raktar.Nev.Contains(raktar))
                    && (megj == null || Polc.Megjegyzes.Contains(megj))
            ));
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
                    "PolcModositas",
                    new FEParameterek().Parameter("id", 0),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("rogzites")) Lekerdezeskor();
                    }
                )
            );
        }

        public void Kivalasztaskor(Polc Polc)
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("id", Polc.Id)
            );
        }

        public void Modositaskor(Polc polc)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PolcModositas",
                    new FEParameterek().Parameter("id", polc.Id),
                    (eredmenyek) => {
                        context.Entry(polc).Reload();
                    }
                )
            );
        }

        public void Megnyitaskor(Polc polc)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PolcMegtekintes",
                    new FEParameterek().Parameter("id", polc.Id),
                    null
                )
            );
        }
    }
}
