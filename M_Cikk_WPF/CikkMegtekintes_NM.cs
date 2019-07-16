using Sajat.Alkalmazas.API;
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
        public CikkMegtekintes_NM(ITarolo tarolo)
        {
            this.tarolo = tarolo;
        }

        private ITarolo tarolo;

        #region ICsatolhatoNezetModell
        private FEKerelem feKerelem;
        public FEKerelem FEKerelem
        {
            get { return feKerelem; }
            set
            {
                feKerelem = value;
                int id = value.Parameterek.As<int>("id");
                if (id == 0)
                {
                    Cikk = new Cikk();
                    tarolo.Cikkek.EgyetBetesz(Cikk);
                }
                else Cikk = tarolo.Cikkek.KiterjesztettEgyetlen(e => e.Id == id, e => e.AlCsoport);
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

        public void Bezaraskor()
        {
            FEKerelem.Befejezes(null);
        }

    }
}
