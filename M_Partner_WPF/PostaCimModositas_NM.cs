using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PostaCimModositas_NM : Megfigyelheto, ICsatolhatoNezetModell
    {
        #region ICsatolhatoNezetModell
        private FEKerelem kapottFEKerelem;
        public FEKerelem FEKerelem
        {
            get { return kapottFEKerelem; }
            set
            {
                kapottFEKerelem = value;
                PostaCim = FEKerelem.Parameterek.As<PostaCim>("postacim");
            }
        }

        public FEIndito FEIndito { get; set; }

        public bool Megszakithato { get => true; }
        #endregion

        private PostaCim postacim;
        public PostaCim PostaCim
        {
            get => postacim;
            set => ErtekadasErtesites(ref postacim, value);
        }

        public void OrszagKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Partner-OrszagValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            Orszag valasztott = eredmenyek.As<Orszag>("orszag");
                            PostaCim.Orszag = valasztott.Iso;
                        }
                    }
                )
            );
        }

        internal void IrszamKereseskor()
        {
            FEIndito.Inditas(
                new FEKerelem(
                    "Partner-IrszamValasztas",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas"))
                        {
                            Irszam valasztott = eredmenyek.As<Irszam>("irszam");
                            PostaCim.Orszag = valasztott.Orszagkod;
                            PostaCim.Iranyitoszam = valasztott.Iranyitoszam;
                            PostaCim.Helyseg = valasztott.Helyseg;
                        }
                    }
                )
            );
        }

        public void Bezaraskor()
        {
            //Akkor is meg kell hívni az eredményfeldolgozót, ha nincs mit visszaadnunk.
            //A Sajat.Alkalmazas.WPF.Tortenet ebből érzi, hogy a felhasználói esetnek vége. 
            FEKerelem.Befejezes(null); 
        }

    }
}
