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
    public class Elerhetoseg : Megfigyelheto
    {
        private string telefon;

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                MegfigyelokErtesitese();
            }
        }

        private string mobil;

        public string Mobil
        {
            get { return mobil; }
            set
            {
                mobil = value;
                MegfigyelokErtesitese();
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                MegfigyelokErtesitese();
            }
        }

    }
}
