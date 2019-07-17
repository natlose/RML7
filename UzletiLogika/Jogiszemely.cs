using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    [ComplexType]
    public class Jogiszemely : Ellenorizheto
    {
        private string rovidnev;

        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Rovidnev
        {
                get => rovidnev;
                set => ErtekadasErtesitesEllenorzes(ref rovidnev, value);
        }

        private string cegjegyzekszam;
        [MaxLength(30, ErrorMessage = "hossz>30")]
        [MinLength(5, ErrorMessage = "hossz<5")]
        public string Cegjegyzekszam
        {
            get => cegjegyzekszam;
            set => ErtekadasErtesitesEllenorzes(ref cegjegyzekszam, value);
        }

        private string adoszam;
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Adoszam
        {
            get => adoszam;
            set => ErtekadasErtesitesEllenorzes(ref adoszam, value);
        }

        private string orszag;
        [MaxLength(2, ErrorMessage = "hossz>2")]
        [MinLength(2, ErrorMessage = "hossz<2")]
        public string Orszag
        {
            get => orszag;
            set => ErtekadasErtesitesEllenorzes(ref orszag, value);
        }

    }
}
