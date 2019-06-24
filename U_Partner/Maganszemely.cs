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
    public class Maganszemely : Ellenorizheto
    {
        private string vezeteknev;
        public string Vezeteknev
        {
            get { return vezeteknev; }
            set
            {
                vezeteknev = value;
                TulajdonsagEllenorzesKezdete();
                if (vezeteknev.Length < 2) TulajdonsagHibauzenet("rövidebb mint 2");
                TulajdonsagEllenorzesVege();
                MegfigyelokErtesitese();
            }
        }

        private string keresztnev;
        public string Keresztnev
        {
            get { return keresztnev; }
            set
            {
                keresztnev = value;
                MegfigyelokErtesitese();
            }
        }
    }
}
