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
    public class PolcValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public PolcValasztas_NM(ITarolo tarolo)
        {
            this.tarolo = tarolo;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("raktar", new Szuromezo(
                    "Raktár",
                    szm =>
                    {
                        FEIndito.Inditas(
                            new FEKerelem(
                                "Keszlet-RaktarValasztas",
                                null,
                                (eredmenyek) => {
                                    if (eredmenyek.As<bool>("valasztas"))
                                    {
                                        int id = eredmenyek.As<int>("id");
                                        szm.Ertek = tarolo.Raktarak.Egyetlen(id).Nev;
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

        private ITarolo tarolo;

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
            lista = new ObservableCollection<Polc>(tarolo.Polcok.KiterjesztettMindAhol(
                Polc =>
                    (kod == null || Polc.Kod.Contains(kod))
                    && (raktar == null || Polc.Raktar.Nev.Contains(raktar))
                    && (megj == null || Polc.Megjegyzes.Contains(megj)),
                e => e.Raktar
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
                    "Keszlet-PolcModositas",
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
                    "Keszlet-PolcModositas",
                    new FEParameterek().Parameter("id", polc.Id),
                    (eredmenyek) => {
                        tarolo.Polcok.Frissit(polc);
                    }
                )
            );
        }
    }
}
