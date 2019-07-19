using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public class MozgasTetel : Ellenorizheto
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

        private MozgasFej mozgasFej;
        [Required(ErrorMessage = "kötelező")]
        public MozgasFej MozgasFej
        {
            get => mozgasFej;
            set => ErtekadasErtesites(ref mozgasFej, value);
        }

        private int bsrsz;
        [Required(ErrorMessage = "kötelező")]
        public int Bsrsz
        {
            get => bsrsz;
            set => ErtekadasErtesites(ref bsrsz, value);
        }

        private Cikk cikk;
        [Required(ErrorMessage = "kötelező")]
        public Cikk Cikk
        {
            get => cikk;
            set => ErtekadasErtesites(ref cikk, value);
        }

        private decimal meny;
        [Required(ErrorMessage = "kötelező")]
        public decimal Meny
        {
            get => meny;
            set => ErtekadasErtesitesEllenorzes(ref meny, value);
        }

        private decimal egysar;
        public decimal EgysAr
        {
            get => egysar;
            set => ErtekadasErtesitesEllenorzes(ref egysar, value);
        }


    }
}
