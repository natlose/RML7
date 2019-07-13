﻿using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using Sajat.SQLTarolas;
using Sajat.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class OrszagValasztas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public OrszagValasztas_NM(IOrszagTarolo tarolo)
        {
            this.tarolo = tarolo;
            Szuromezok = new SzuromezoGyujtemeny()
                .Mezo("nev", new Szuromezo("Név") { Elore = 1 });
        }

        #region ICsatolhatoNezetModell
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        public bool Megszakithato { get => true; }
        #endregion

        private IOrszagTarolo tarolo;

        private ObservableCollection<Orszag> lista;
        public ObservableCollection<Orszag> Lista
        {
            get => lista;
            set => ErtekadasErtesites(ref lista, value);
        }

        public SzuromezoGyujtemeny Szuromezok { get; set; }

        public void Lekerdezeskor()
        {
            string nev = StringMuveletek.NullHaUres(Szuromezok["nev"].Ertek);
            lista = new ObservableCollection<Orszag>(tarolo.MindAhol(
                orszag =>
                (nev == null || orszag.Nev.Contains(nev))
            ));
            Ertesites(nameof(Lista));
        }

        public void Felveszkor()
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-OrszagModositas",
                    new FEParameterek().Parameter("id", 0),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("rogzites"))
                        {
                            Orszag felvett = eredmenyek.As<Orszag>("orszag");
                            Lekerdezeskor();
                        }
                    }
                )
            );
        }

        public void Visszakor()
        {
            KapottFEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", false)
            );
        }

        public void Kivalasztaskor(Orszag orszag)
        {
            KapottFEKerelem.Befejezes(
                new FEEredmenyek()
                    .Eredmeny("valasztas", true)
                    .Eredmeny("orszag", orszag)
            );
        }

        public void Modositaskor(Orszag orszag)
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "Partner-OrszagModositas",
                    new FEParameterek().Parameter("id", orszag.Id),
                    (eredmenyek) => {
                        Orszag modositott = eredmenyek.As<Orszag>("orszag");
                        tarolo.Frissit(orszag);
                    }
                )
            );
        }
    }
}
