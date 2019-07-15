using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class AlCsoportModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public AlCsoportModositas_NM(IAlCsoportValtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        private IAlCsoportValtozas valtozas;

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
                    AlCsoport = new AlCsoport();
                    valtozas.AlCsoportok.EgyetBetesz(AlCsoport);
                }
                else AlCsoport = valtozas.AlCsoportok.Egyetlen(id);
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        private AlCsoport alcsoport;
        public AlCsoport AlCsoport
        {
            get => alcsoport;
            set => ErtekadasErtesites(ref alcsoport, value);
        }

        public bool VanValtozas
        {
            get => valtozas.VanValtozas;
        }

        private RogzitesEredmeny rogzitesEredmeny;
        public RogzitesEredmeny RogzitesEredmeny
        {
            get => rogzitesEredmeny;
            set => ErtekadasErtesites(ref rogzitesEredmeny, value);
        }

        public void Rogziteskor()
        {
            RogzitesEredmeny = valtozas.ValtozasRogzitese();
            if (RogzitesEredmeny == RogzitesEredmeny.Siker)
            {
                FEKerelem.Befejezes(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", true)
                        .Eredmeny("alcsoport", AlCsoport)
                );
            }
        }

        public void Elveteskor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("rogzites", false)
                    .Eredmeny("alcsoport", AlCsoport)
            );
        }
    }
}
