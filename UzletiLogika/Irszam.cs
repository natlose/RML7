using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public class Irszam:Ellenorizheto
    {

        private int id;
        [Key]
        public int Id
        {
            get => id;
            set => ErtekadasErtesitesEllenorzes(ref id, value);
        }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        private string orszagkod;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(2, ErrorMessage = "hossz>2")]
        public string Orszagkod
        {
            get => orszagkod;
            set => ErtekadasErtesitesEllenorzes(ref orszagkod, value);
        }

        private string iranyitoszam;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(10, ErrorMessage = "hossz>10")]
        public string Iranyitoszam     
        {
            get => iranyitoszam;
            set => ErtekadasErtesitesEllenorzes(ref iranyitoszam, value);
        }

        private string helyseg;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Helyseg
        {
            get => helyseg;
            set => ErtekadasErtesitesEllenorzes(ref helyseg, value);
        }

    }
}
