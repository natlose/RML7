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
    public class PolcModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public PolcModositas_NM(IValtozas valtozas)
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
                    Polc = new Polc();
                    valtozas.Tarolok.Polcok.EgyetBetesz(Polc);
                    int raktarid = value.Parameterek.As<int>("raktarid");
                    if (raktarid != 0) Polc.Raktar = valtozas.Tarolok.Raktarak.Egyetlen(raktarid);
                }
                else Polc = valtozas.Tarolok.Polcok.KiterjesztettEgyetlen(e => e.Id == id, e => e.Raktar);
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        private Polc polc;
        public Polc Polc
        {
            get => polc;
            set => ErtekadasErtesites(ref polc, value);
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

        internal void RaktarKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Keszlet-RaktarValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            Raktar valasztott = valtozas.Tarolok.Raktarak.Egyetlen(eredmenyek.As<int>("id"));
                            Polc.Raktar = valasztott;
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
                        .Eredmeny("id", Polc.Id)
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
