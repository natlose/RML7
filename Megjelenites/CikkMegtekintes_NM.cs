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
    public class CikkMegtekintes_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        public CikkMegtekintes_NM(ITarolok tarolok)
        {
            this.tarolok = tarolok;
        }

        private readonly ITarolok tarolok;

        #region ICsatolhatoNezetModell
        private FEKerelem feKerelem;
        public FEKerelem FEKerelem
        {
            get { return feKerelem; }
            set
            {
                feKerelem = value;
                int id = value.Parameterek.As<int>("id");
                Cikk = tarolok.Cikkek.KiterjesztettEgyetlen(
                    e => e.Id == id, 
                    e => e.AlCsoport,
                    e => e.Keszletek
                );
            }
        }

        public FEIndito FEIndito { get; set; }
        public bool Megszakithato { get => true; }
        #endregion

        private Cikk cikk;
        public Cikk Cikk
        {
            get => cikk;
            set => ErtekadasErtesites(ref cikk, value);
        }

        private IEnumerable<Keszlet> keszletlista;
        public IEnumerable<Keszlet> KeszletLista
        {
            get => keszletlista;
            set => ErtekadasErtesites(ref keszletlista, value);
        }


        public void Bezaraskor()
        {
            FEKerelem.Befejezes(null);
        }

    }
}
