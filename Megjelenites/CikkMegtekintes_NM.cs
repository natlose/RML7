using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Tarolas;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Megjelenites
{
    public class CikkMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private readonly SajatContext context;

        public CikkMegtekintes_NM(SajatContext context)
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
                Cikk = context.Cikkek
                    .Include(c => c.AlCsoport)
                    .Include(c => c.Keszletek.Select(k => k.Polc).Select(p => p.Raktar))
                    .Single(c => c.Id == id);
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
