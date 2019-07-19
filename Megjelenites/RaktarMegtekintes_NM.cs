using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Sajat.Tarolas;

namespace Sajat.Megjelenites
{
    public class RaktarMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private SajatContext context;

        public RaktarMegtekintes_NM(SajatContext context)
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
                Raktar = context.Raktarak.Include(r => r.Polcok).Single(e => e.Id == id);
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => true; }
        #endregion

        private Raktar raktar;
        public Raktar Raktar
        {
            get => raktar;
            set => ErtekadasErtesites(ref raktar, value);
        }

        internal void PolcModositaskor(Polc polc)
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

        internal void PolcMegnyitaskor(Polc polc)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PolcMegtekintes",
                    new FEParameterek().Parameter("id", polc.Id),
                    null
                )
            );
        }

        internal void PolcFelveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PolcModositas",
                    new FEParameterek()
                        .Parameter("id", 0)
                        .Parameter("raktarid", Raktar.Id),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("rogzites"))
                        {
                            int id = eredmenyek.As<int>("id");
                            context.Polcok.Single(p => p.Id == id);
                        }
                    }
                )
            );
        }

        public void Bezaraskor()
        {
            FEKerelem.Befejezes(null);
        }
    }
}
