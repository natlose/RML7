﻿using Sajat.Alkalmazas.API;
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
    public class RaktarModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private Valtozas valtozas;

        public RaktarModositas_NM(Valtozas valtozas)
        {
            this.valtozas = valtozas;
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
                if (id == 0)
                {
                    Raktar = new Raktar();
                    valtozas.Context.Raktarak.Add(Raktar);
                }
                else Raktar = valtozas.Context.Raktarak.Single(r => r.Id == id);
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => !valtozas.VanValtozas; }
        #endregion

        private Raktar raktar;
        public Raktar Raktar
        {
            get => raktar;
            set => ErtekadasErtesites(ref raktar, value);
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
                        .Eredmeny("id", Raktar.Id)
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
