using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public class MozgasnemAllandok
    {
        public string Felirat { get; set; }

        public int Irany { get; set; }

        public bool Partnerfuggo { get; set; }

        public bool Koltseghelyfuggo { get; set; }

    }

    public static class Mozgasnemek
    {
        public static Dictionary<string, MozgasnemAllandok> Allandok = new Dictionary<string, MozgasnemAllandok>() {
            {"BE"      , new MozgasnemAllandok { Felirat = "BEVÉTELEZÉS" , Irany =  1, Partnerfuggo =  true, Koltseghelyfuggo = false } },
            {"KI"      , new MozgasnemAllandok { Felirat = "ELADÁS"      , Irany = -1, Partnerfuggo =  true, Koltseghelyfuggo = false } },
            {"ATH"     , new MozgasnemAllandok { Felirat = "ÁTHELYEZÉS"  , Irany =  1, Partnerfuggo = false, Koltseghelyfuggo = false } },
            {"HNY"     , new MozgasnemAllandok { Felirat = "HIÁNY"       , Irany = -1, Partnerfuggo = false, Koltseghelyfuggo =  true } },
            {"TBL"     , new MozgasnemAllandok { Felirat = "TÖBBLET"     , Irany =  1, Partnerfuggo = false, Koltseghelyfuggo =  true } },
            {"SELEJT"  , new MozgasnemAllandok { Felirat = "SELEJT"      , Irany = -1, Partnerfuggo = false, Koltseghelyfuggo =  true } },
            {"FLH"     , new MozgasnemAllandok { Felirat = "FELHASZNÁLÁS", Irany = -1, Partnerfuggo = false, Koltseghelyfuggo =  true } }
        };
    }


}
