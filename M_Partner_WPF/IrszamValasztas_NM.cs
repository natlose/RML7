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
        public IrszamValasztas_NM()
        {
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("irsz", new Szuromezo("Irányítószám"));

            Lekerdezeskor();
        }
        public FEKerelem KapottFEKerelem { get; set; }

        public bool Megszakithato { get => true; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        private IIrszamTarolo tarolo = new IrszamTarolo_EF(new PartnerContext());

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

        internal void Visszakor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                 new FEEredmenyek()
                     .Eredmeny("valasztas", false)
             );
        }

        public SzuromezoGyujtemeny Szuromezok { get; set; }
    }
}
