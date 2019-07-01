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
        public FEKerelem KapottFEKerelem { get; set; }

        public event FEKerelemEsemenyKezelo SajatFEKerelem;
        #endregion

        public void BetoltesBefejezesekor()
        {
            PostaCim = KapottFEKerelem.Parameterek.As<PostaCim>("postacim");
        }

        private PostaCim postacim;
        public PostaCim PostaCim
        {
            get => postacim;
            set => ErtekadasErtesites(ref postacim, value);
        }

        public void OrszagKereseskor()
        {
            SajatFEKerelem?.Invoke(
                new FEKerelem(
                    "M_Partner_WPF", "Sajat.Partner.OrszagValasztas_N",
                    null,
                    (eredmenyek) => {
                        if (eredmenyek.As<bool>("valasztas", null))
                        {
                            Orszag valasztott = eredmenyek.As<Orszag>("orszag");
                            PostaCim.Orszag = valasztott.Iso;
                        }
                    }
                )
            );
        }

        public void Bezaraskor()
        {
            //Akkor is meg kell hívni az eredményfeldolgozót, ha nincs mit visszaadnunk.
            //A Sajat.Alkalmazas.WPF.Tortenet ebből érzi, hogy a felhasználói esetnek vége. 
            KapottFEKerelem.Eredmeny?.Invoke(null); 
        }

    }
}
