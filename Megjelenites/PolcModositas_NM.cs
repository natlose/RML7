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
    public class PolcModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public PolcModositas_NM(Valtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        private Valtozas valtozas;

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
                    valtozas.Context.Polcok.Add(Polc);
                    int raktarid = value.Parameterek.As<int>("raktarid");
                    if (raktarid != 0) Polc.Raktar = valtozas.Context.Raktarak.Single(r => r.Id == raktarid);
                }
                else Polc = valtozas.Context.Polcok.Include(p => p.Raktar).Single(p => p.Id == id);
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
                    "RaktarValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            int id = eredmenyek.As<int>("id");
                            Raktar valasztott = valtozas.Context.Raktarak.Single(r => r.Id == id);
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
