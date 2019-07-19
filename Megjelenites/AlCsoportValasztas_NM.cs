using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Tarolas;
using Sajat.Uzlet;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Megjelenites
{
    public class AlCsoportValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private readonly SajatContext context;

        public AlCsoportValasztas_NM(SajatContext context)
        {
            this.context = context;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1 })
                .Mezo("focsoport", new Szuromezo(
                    "Főcsoport", 
                    szm => 
                    {
                        FEIndito.Inditas(
                            new FEKerelem(
                                "FoCsoportValasztas",
                                null,
                                (eredmenyek) => {
                                    if (eredmenyek.As<bool>("valasztas"))
                                    {
                                        int id = eredmenyek.As<int>("id");
                                        szm.Ertek = context.FoCsoportok.Single(f => f.Id == id).Nev;
                                    }
                                }
                            )
                        );
                    }))
                ;
            Lekerdezeskor();
        }

        #region ICsatolhatoNezetModell
        public FEKerelem FEKerelem { get; set; }
        public FEIndito FEIndito { get; set; }

        public bool Megszakithato => true;
        #endregion

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
            string focsoport = StringMuveletek.NullHaUres(Szuromezok["focsoport"].Ertek);
            Lista = new ObservableCollection<AlCsoport>(
                context.AlCsoportok
                .Include(a => a.FoCsoport)
                .Where(AlCsoport =>
                    (nev == null || AlCsoport.Nev.Contains(nev))
                    && (focsoport == null || AlCsoport.FoCsoport.Nev.Contains(focsoport))
                )
                .ToList());
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
                    "AlCsoportModositas",
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
                    "AlCsoportModositas",
                    new FEParameterek().Parameter("id", alcsoport.Id),
                    (eredmenyek) => {
                        context.Entry(alcsoport).Reload();
                    }
                )
            );
        }
    }
}
