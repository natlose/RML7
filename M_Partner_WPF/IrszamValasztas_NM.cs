using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class IrszamValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public IrszamValasztas_NM(IIrszamTarolo tarolo)
        {
            this.tarolo = tarolo;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("irsz", new Szuromezo("Irányítószám"));

            Lekerdezeskor();
        }

        public FEKerelem KapottFEKerelem { get; set; }

        public bool Megszakithato { get => true; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        private IIrszamTarolo tarolo;

        private ObservableCollection<Irszam> lista;
        public ObservableCollection<Irszam> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        internal void Lekerdezeskor()
        {
            string irsz = Szuromezok["irsz"].Ertek==null ? "" : Szuromezok["irsz"].Ertek;
            
            Lista = new ObservableCollection<Irszam>(tarolo.MindAhol(i => i.Iranyitoszam.Contains(irsz)));
            
        }

        internal void Modositaskor(Irszam irszam)
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-IrszamModositas",
                    new FEParameterek().Parameter("id", irszam.Id),
                    (eredmenyek) => {
                        Irszam modositott = eredmenyek.As<Irszam>("irszam");
                        tarolo.Frissit(irszam);
                    }
                )
            );
        }
        public void Felveszkor()
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-IrszamModositas",
                    new FEParameterek().Parameter("id", 0),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("rogzites"))
                        {
                            Irszam felvett = eredmenyek.As<Irszam>("irszam");
                            Lekerdezeskor();
                        }
                    }
                )
            );
        }

        internal void Visszakor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                 new FEEredmenyek()
                     .Eredmeny("valasztas", false)
             );
        }

        internal void Kivalasztaskor(Irszam irszam)
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                 new FEEredmenyek()
                     .Eredmeny("valasztas", true)
                     .Eredmeny("irszam", irszam)
             );
        }

        public SzuromezoGyujtemeny Szuromezok { get; set; }

    }
}
