using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class Cikk : Ellenorizheto
    {
        private int id;
        [Key]
        public int Id
        {
            get => id;
            set => ErtekadasErtesites(ref id, value);
        }

        [Timestamp]
        public byte[] RV { get; set; }

        private string cikkszam;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(50, ErrorMessage = "hossz>50")]
        public string Cikkszam
        {
            get => cikkszam;
            set => ErtekadasErtesitesEllenorzes(ref cikkszam, value);
        }

        private string nev;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(50, ErrorMessage = "hossz>50")]
        public string Nev
        {
            get => nev;
            set => ErtekadasErtesitesEllenorzes(ref nev, value);
        }

        private string mEgys;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(10, ErrorMessage = "hossz>10")]
        public string MEgys
        {
            get => mEgys;
            set => ErtekadasErtesitesEllenorzes(ref mEgys, value);
        }

        private string gyartoiCikkszam;
        [MaxLength(50, ErrorMessage = "hossz>50")]
        public string GyartoiCikkszam
        {
            get => gyartoiCikkszam;
            set => ErtekadasErtesitesEllenorzes(ref gyartoiCikkszam, value);
        }

        private string angolNev;
        [MaxLength(50, ErrorMessage = "hossz>50")]
        public string AngolNev
        {
            get => angolNev;
            set => ErtekadasErtesitesEllenorzes(ref angolNev, value);
        }

        private AlCsoport alCsoport;
        public AlCsoport AlCsoport
        {
            get => alCsoport;
            set => ErtekadasErtesitesEllenorzes(ref alCsoport, value);
        }


    }
}
