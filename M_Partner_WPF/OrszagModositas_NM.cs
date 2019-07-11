using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class OrszagModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public OrszagModositas_NM(IOrszagValtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        #region ICsatolhatoNezetModell
        private FEKerelem kapottFEKerelem;
        public FEKerelem KapottFEKerelem
        {
            get { return kapottFEKerelem; }
            set
            {
                kapottFEKerelem = value;
                int id = value.Parameterek.As<int>("id");
                if (id == 0)
                {
                    Orszag = new Orszag();
                    valtozas.Orszagok.EgyetBetesz(Orszag);
                }
                else Orszag = valtozas.Orszagok.Egyetlen(id);
            }
        }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        private IOrszagValtozas valtozas;

        private Orszag orszag;
        public Orszag Orszag
        {
            get => orszag;
            set => ErtekadasErtesites(ref orszag, value);
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
                KapottFEKerelem.Eredmeny?.Invoke(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", true)
                        .Eredmeny("orszag", Orszag)
                );
            }
        }

        public void Elveteskor()
        {
            KapottFEKerelem.Eredmeny?.Invoke(
                new FEEredmenyek()
                    .Eredmeny("rogzites", false)
                    .Eredmeny("orszag", Orszag)
            );
        }

    }
}
