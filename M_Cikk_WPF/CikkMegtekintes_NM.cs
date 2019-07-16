using Sajat.Alkalmazas.API;
using Sajat.Modul;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class CikkMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public CikkMegtekintes_NM(ITarolo tarolo, IKeszletReszletezo keszletReszletezo)
        {
            this.tarolo = tarolo;
            this.keszletReszletezo = keszletReszletezo;
        }

        private readonly ITarolo tarolo;
        private readonly IKeszletReszletezo keszletReszletezo;

        #region ICsatolhatoNezetModell
        private FEKerelem feKerelem;
        public FEKerelem FEKerelem
        {
            get { return feKerelem; }
            set
            {
                feKerelem = value;
                int id = value.Parameterek.As<int>("id");
                Cikk = tarolo.Cikkek.KiterjesztettEgyetlen(e => e.Id == id, e => e.AlCsoport);
                KeszletLista = keszletReszletezo.Reszletezes(new[] { Cikk.Id });                
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => true; }
        #endregion

        private Cikk cikk;
        public Cikk Cikk
        {
            get => cikk;
            set => ErtekadasErtesites(ref cikk, value);
        }

        private IEnumerable<KeszletReszletek> keszletlista;
        public IEnumerable<KeszletReszletek> KeszletLista
        {
            get => keszletlista;
            set => ErtekadasErtesites(ref keszletlista, value);
        }


        public void Bezaraskor()
        {
            FEKerelem.Befejezes(null);
        }

    }
}
