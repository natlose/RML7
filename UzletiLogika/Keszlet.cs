using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public class Keszlet : Ellenorizheto
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

        private Polc polc;
        [Required(ErrorMessage = "kötelező")]
        public Polc Polc
        {
            get => polc;
            set => ErtekadasErtesitesEllenorzes(ref polc, value);
        }

        private Cikk cikk;
        [Required(ErrorMessage = "kötelező")]
        public Cikk Cikk
        {
            get => cikk;
            set => ErtekadasErtesitesEllenorzes(ref cikk, value);
        }

        private decimal meny;
        [Required(ErrorMessage = "kötelező")]
        public decimal Meny
        {
            get => meny;
            set => ErtekadasErtesitesEllenorzes(ref meny, value);
        }


    }
}
