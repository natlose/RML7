using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Tarolas;
using Sajat.Uzlet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Sajat.Megjelenites
{
    public class PolcMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {

        private readonly SajatContext context;

        public PolcMegtekintes_NM(SajatContext context)
        {
            this.context = context;
        }

        #region ICsatolhatoNezetModell
        private FEKerelem feKerelem;
        public FEKerelem FEKerelem
        {
            get { return feKerelem; }
            set
            {
                feKerelem = value;
                int id = value.Parameterek.As<int>("id");
                Polc = context.Polcok
                    .Include(p => p.Keszletek.Select(k => k.Cikk))
                    .Include(p => p.Raktar)
                    .Single(p => p.Id == id);
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

        internal void KeszletMegnyitaskor(object e)
        {
            FEIndito.Inditas(new FEKerelem(
                "CikkMegtekintes",
                new FEParameterek().Parameter("id", ((Keszlet)e).Cikk.Id ),
                null)
            );
        }

        public void Bezaraskor()
        {
            FEKerelem.Befejezes(null);
        }
    }
}
