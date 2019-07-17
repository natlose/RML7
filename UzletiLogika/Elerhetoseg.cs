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
    public class Elerhetoseg : Ellenorizheto
    {
        private string telefon;
        [MaxLength(20, ErrorMessage = "hossz>20")]
        [Phone( ErrorMessage = "helytelen")]
        public string Telefon
        {
            get => telefon;
            set => ErtekadasErtesitesEllenorzes(ref telefon, value);
        }

        private string mobil;
        [MaxLength(20, ErrorMessage = "hossz>20")]
        [Phone(ErrorMessage = "helytelen")]
        public string Mobil
        {
            get => mobil;
            set => ErtekadasErtesitesEllenorzes(ref mobil, value);
        }

        private string email;
        [MaxLength(50, ErrorMessage = "hossz>50")]
        [EmailAddress(ErrorMessage = "helytelen")]
        public string Email
        {
            get => email;
            set => ErtekadasErtesitesEllenorzes(ref email, value);
        }

    }
}
