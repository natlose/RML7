using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;

namespace Sajat.Partner
{
    public class SzemelyValasztasNM : Megfigyelheto, ICsatolhatoNezetModell 
    {
        public event FEKerelemEsemenyKezelo SajatFEKerelem;

        public FEKerelem KapottFEKerelem { get; set; }

        private string nev;

        public string Nev
        {
            get { return nev; }
            set
            {
                ErtekadasErtesites(ref nev, value);
            }
        }


        public void Megsem()
        {
            KapottFEKerelem.Eredmeny?.Invoke(null);
        }

        public void Uj()
        {
            FEKerelem kerelem = new FEKerelem("M_Partner_WPF", "Sajat.Partner.SzemelyValasztasFE", eredmenyek => {
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
