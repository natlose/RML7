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
using System.Collections.ObjectModel;

namespace Sajat.Megjelenites
{
    public class MozgasModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        private readonly Valtozas valtozas;

        public MozgasModositas_NM(Valtozas valtozas)
        {
            this.valtozas = valtozas;
        }

        #region ICsatolhatoNezetModell
        private FEKerelem feKerelem;
        public FEKerelem FEKerelem {
            get => feKerelem;
            set
            {
                feKerelem = value;
                int id = value.Parameterek.As<int>("id");
                if (id == 0)
                {
                    string mozgasnem = value.Parameterek.As<string>("mozgasnem");
                    MozgasFej = new MozgasFej() {
                        Piszkozat = "I",
                        Mozgasnem = mozgasnem,
                        Irany = Mozgasnemek.Allandok[mozgasnem].Irany,
                        Kelt = DateTime.Now,
                        Tetelek = new ObservableCollection<MozgasTetel>()
                    };
                    valtozas.Context.MozgasFejek.Add(MozgasFej);
                }
                else MozgasFej = valtozas.Context.MozgasFejek
                        .Include(f => f.Tetelek.Select(t => t.Cikk))
                        .Include(f => f.Partner)
                        .Include(f => f.Koltseghely)
                        .Single(e => e.Id == id);
                LegyenUresUtolsoSor();
                MozgasnemAllandok = Mozgasnemek.Allandok[MozgasFej.Mozgasnem];
            }
        }


        public FEIndito FEIndito { get; set; }
        public bool Megszakithato => valtozas.VanValtozas;
        #endregion

        private MozgasnemAllandok mozgasnemAllandok;
        public MozgasnemAllandok MozgasnemAllandok
        {
            get => mozgasnemAllandok;
            set => ErtekadasErtesites(ref mozgasnemAllandok, value);
        }

        private void LegyenUresUtolsoSor()
        {
            if (MozgasFej.Tetelek.Count == 0 || MozgasFej.Tetelek.Last().Cikk.Id != 0 )
                MozgasFej.Tetelek.Add(new MozgasTetel() { Bsrsz = MozgasFej.Tetelek.Count + 1, Cikk = new Cikk() });
        }


        private MozgasFej mozgasfej;
        public MozgasFej MozgasFej
        {
            get => mozgasfej;
            set => ErtekadasErtesites(ref mozgasfej, value);
        }

        private MozgasTetel kijeloltTetel;
        public MozgasTetel KijeloltTetel
        {
            get => kijeloltTetel;
            set => ErtekadasErtesites(ref kijeloltTetel, value);
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

        internal void PartnerKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "PartnerValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            int id = eredmenyek.As<int>("id");
                            Partner valasztott = valtozas.Context.Partnerek.Single(p => p.Id == id);
                            MozgasFej.Partner = valasztott;
                        }
                    }
                )
            );
        }

        internal void KoltseghelyKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "KoltseghelyValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            int id = eredmenyek.As<int>("id");
                            Koltseghely valasztott = valtozas.Context.Koltseghelyek.Single(p => p.Id == id);
                            MozgasFej.Koltseghely = valasztott;
                        }
                    }
                )
            );
        }

        internal void CikkszamKereseskor(MozgasTetel tetel)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "CikkValasztas",
                    new FEParameterek()
                        .Parameter("cikkszam", tetel.Cikk.Cikkszam),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            int id = eredmenyek.As<int>("id");
                            Cikk valasztott = valtozas.Context.Cikkek.Single(p => p.Id == id);
                            tetel.Cikk = valasztott;
                            LegyenUresUtolsoSor();
                        }
                    }
                )
            );
        }

        internal void CikkszamUtan(MozgasTetel tetel)
        {
        }

        internal void NevKereseskor(MozgasTetel tetel)
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "CikkValasztas",
                    new FEParameterek()
                        .Parameter("nev", tetel.Cikk.Nev),
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            int id = eredmenyek.As<int>("id");
                            Cikk valasztott = valtozas.Context.Cikkek.Single(p => p.Id == id);
                            tetel.Cikk = valasztott;
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
                        .Eredmeny("id", MozgasFej.Id)
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
