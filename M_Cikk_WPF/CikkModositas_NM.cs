using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Megjelenites
{
    public class CikkModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public CikkModositas_NM(IValtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        private IValtozas valtozas;

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
                    valtozas.Tarolok.Cikkek.EgyetBetesz(Cikk);
                }
                else Cikk = valtozas.Tarolok.Cikkek.KiterjesztettEgyetlen(e => e.Id == id, e => e.AlCsoport);
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        private Cikk cikk;
        public Cikk Cikk
        {
            get => cikk;
            set => ErtekadasErtesites(ref cikk, value);
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

        internal void AlCsoportKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Cikk-AlCsoportValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            AlCsoport valasztott = valtozas.Tarolok.AlCsoportok.Egyetlen(eredmenyek.As<int>("id"));
                            Cikk.AlCsoport = valasztott;
                        }
                    }
                )
            );
        }

        public void Rogziteskor()
        {
            RogzitesEredmeny = valtozas.ValtozasRogzitese();
            if (RogzitesEredmeny == RogzitesEredmeny.Siker)
            {
                FEKerelem.Befejezes(
                    new FEEredmenyek()
                        .Eredmeny("rogzites", true)
                        .Eredmeny("id", Cikk.Id)
                );
            }
        }

        public void Elveteskor()
        {
            FEKerelem.Befejezes(
                new FEEredmenyek().Eredmeny("rogzites", false)
            );
        }
    }
}
