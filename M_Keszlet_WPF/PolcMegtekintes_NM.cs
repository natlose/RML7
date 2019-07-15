using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public class PolcMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public PolcMegtekintes_NM(ITarolo tarolo)
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
                Polc = tarolo.Polcok.KiterjesztettEgyetlen(
                    e => e.Id == id,
                    e => e.Keszletek
                );
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => true; }
        #endregion

        private Polc polc;
        public Polc Polc
        {
            get => polc;
            set => ErtekadasErtesites(ref polc, value);
        }

        public void Bezaraskor()
        {
            FEKerelem.Befejezes(null);
        }
    }
}
