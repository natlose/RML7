using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    [ComplexType]
    public class Jogiszemely : Megfigyelheto
    {
        private string rovidnev;

        public string Rovidnev
        {
            get { return rovidnev; }
            set
            {
                rovidnev = value;
                MegfigyelokErtesitese();
            }
        }

        private string cegjegyzekszam;

        public string Cegjegyzekszam
        {
            get { return cegjegyzekszam; }
            set
            {
                cegjegyzekszam = value;
                MegfigyelokErtesitese();
            }
        }

        private string adoszam;

        public string Adoszam
        {
            get { return adoszam; }
            set
            {
                adoszam = value;
                MegfigyelokErtesitese();
            }
        }

        private string orszag;

        public string Orszag
        {
            get { return orszag; }
            set
            {
                orszag = value;
                MegfigyelokErtesitese();
            }
        }

    }
}
