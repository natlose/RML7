using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFrame.API;
using WPFNotification;

namespace Partner
{
    public class SzemelyValasztasNM : MegfigyelhetokOse, IDinamikusanCsatolhatoNezetModell 
    {
        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        public FEKerelem KapottFEKerelem { get; set; }

        private string nev;

        public string Nev
        {
            get { return nev; }
            set
            {
                nev = value;
                MegfigyelokErtesitese();
            }
        }


        public void Megsem()
        {
            KapottFEKerelem.Eredmeny?.Invoke(null);
        }

        public void Uj()
        {
            FEKerelem kerelem = new FEKerelem("Partner", "Partner.SzemelyValasztasFE", eredmenyek => {
                if (eredmenyek != null) Nev = (string) eredmenyek["partner"];
            });
            SajatFEKerelem?.Invoke(kerelem);
        }

        public void Kivalaszt()
        {
            FEEredmenyek eredmenyek = new FEEredmenyek();
            eredmenyek.Add("partner", Nev);
            KapottFEKerelem.Eredmeny?.Invoke(eredmenyek);
        }
    }
}
