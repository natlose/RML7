using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PostaCim : Megfigyelheto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                MegfigyelokErtesitese();
            }
        }

        private string tipus;

        public string Tipus // számlázási, levelezési, szállítási
        {
            get { return tipus; }
            set
            {
                tipus = value;
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

        private string iranyitoszam;

        public string Iranyitoszam
        {
            get { return iranyitoszam; }
            set
            {
                iranyitoszam = value;
                MegfigyelokErtesitese();
            }
        }

        private string helyseg;

        public string Helyseg
        {
            get { return helyseg; }
            set
            {
                helyseg = value;
                MegfigyelokErtesitese();
            }
        }

        private string sor1;

        public string Sor1
        {
            get { return sor1; }
            set
            {
                sor1 = value;
                MegfigyelokErtesitese();
            }
        }

        private string sor2;

        public string Sor2
        {
            get { return sor2; }
            set
            {
                sor2 = value;
                MegfigyelokErtesitese();
            }
        }

        private Partner partner;

        public Partner Partner
        {
            get { return partner; }
            set
            {
                partner = value;
                MegfigyelokErtesitese();
            }
        }

    }
}
