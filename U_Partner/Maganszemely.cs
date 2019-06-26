using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(30, ErrorMessage = "hossz>30")]
        [TiltottKarakterek("/.,!@#$%", ErrorMessage = "tiltott jel")]
        public string Vezeteknev
        {
            get => vezeteknev; 
            set => ErtekadasErtesitesEllenorzes(ref vezeteknev, value);            
        }

        private string keresztnev;
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Keresztnev
        {
            get => keresztnev;
            set => ErtekadasErtesitesEllenorzes(ref keresztnev, value);
        }
    }
}
