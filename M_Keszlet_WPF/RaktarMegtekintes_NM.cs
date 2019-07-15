﻿using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public class RaktarMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public RaktarMegtekintes_NM(ITarolo tarolo)
        {
            this.tarolo = tarolo;
        }

        private ITarolo tarolo;

        #region ICsatolhatoNezetModell
        private FEKerelem feKerelem;
        public FEKerelem FEKerelem
        {
            get { return feKerelem; }
            set
            {
                feKerelem = value;
                int id = value.Parameterek.As<int>("id");
                Raktar = tarolo.Raktarak.KiterjesztettEgyetlen(
                    e => e.Id == id, 
                    e => e.Polcok
                );
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
                    "Keszlet-PolcModositas",
                    new FEParameterek().Parameter("id", polc.Id),
                    (eredmenyek) => {
                        tarolo.Polcok.Frissit(polc);
                    }
                )
            );
        }

        internal void PolcMegnyitaskor(Polc polc)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Keszlet-PolcMegtekintes",
                    new FEParameterek().Parameter("id", polc.Id),
                    null
                )
            );
        }

        internal void PolcFelveszkor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Keszlet-PolcModositas",
                    new FEParameterek()
                        .Parameter("id", 0)
                        .Parameter("raktarid", Raktar.Id),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("rogzites"))
                        {
                            Raktar = tarolo.Raktarak.KiterjesztettEgyetlen(
                                e => e.Id == Raktar.Id,
                                e => e.Polcok
                            );
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