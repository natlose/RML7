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
    public class AlCsoportModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public AlCsoportModositas_NM(IValtozas valtozas)
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
                    AlCsoport = new AlCsoport();
                    valtozas.Tarolok.AlCsoportok.EgyetBetesz(AlCsoport);
                }
                else AlCsoport = valtozas.Tarolok.AlCsoportok.KiterjesztettEgyetlen(e => e.Id == id, e => e.FoCsoport);
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

        internal void FoCsoportKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Cikk-FoCsoportValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            FoCsoport valasztott = valtozas.Tarolok.FoCsoportok.Egyetlen(eredmenyek.As<int>("id"));
                            AlCsoport.FoCsoport = valasztott;
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
                        .Eredmeny("id", AlCsoport.Id)
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
