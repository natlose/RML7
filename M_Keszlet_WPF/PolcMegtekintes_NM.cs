﻿using Sajat.Alkalmazas.API;
using Sajat.Modul;
using Sajat.ObjektumModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public class PolcMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public struct KeszletListaSor
        {
            public int Id { get; set; }
            public string Cikkszam { get; set; }
            public string Nev { get; set; }
            public string MEgys { get; set; }
            public decimal Keszlet { get; set; }
        }

        public PolcMegtekintes_NM(ITarolo tarolo, ICikkReszletezo cikkReszletezo)
        {
            this.tarolo = tarolo;
            this.cikkReszletezo = cikkReszletezo;
        }

        private readonly ITarolo tarolo;
        private readonly ICikkReszletezo cikkReszletezo;


        #region ICsatolhatoNezetModell
        private FEKerelem feKerelem;
        public FEKerelem FEKerelem
        {
            get { return feKerelem; }
            set
            {
                feKerelem = value;
                int id = value.Parameterek.As<int>("id");
                Polc = tarolo.Polcok.KiterjesztettEgyetlen(
                    e => e.Id == id,
                    e => e.Keszletek,
                    e => e.Raktar
                );
                CikkReszletek[] reszletek = cikkReszletezo.Reszletezes(Polc.Keszletek.Select(k => k.CikkID).ToArray());
                keszletlista = Polc.Keszletek.Zip(reszletek, (k, r) => new KeszletListaSor()
                {
                    Id = r.Id,
                    Cikkszam = r.Cikkszam,
                    Nev = r.Nev,
                    MEgys = r.MEgys,
                    Keszlet = k.Meny
                });
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => true; }
        #endregion

        private Polc polc;
        public Polc Polc
        {
            get => polc;
            set => ErtekadasErtesites(ref polc, value);
        }

        private IEnumerable keszletlista;
        public IEnumerable KeszletLista
        {
            get => keszletlista;
            private set => ErtekadasErtesites(ref keszletlista, value);
        }

        internal void KeszletMegnyitaskor(object e)
        {
            FEIndito.Inditas(new FEKerelem(
                "Cikk-CikkMegtekintes",
                new FEParameterek().Parameter("id", ((KeszletListaSor)e).Id ),
                null)
            );
        }

        public void Bezaraskor()
        {
            FEKerelem.Befejezes(null);
        }
    }
}
