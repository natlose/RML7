using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Orszag : Ellenorizheto
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }

        private int id;
        [Key]
        public int Id
        {
            get => id;
            set => ErtekadasErtesites(ref id, value);
        }

        private string iso;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(2, ErrorMessage = "hossz>2")]
        [MinLength(2, ErrorMessage = "hossz<2")]
        public string Iso
        {
            get => iso;
            set => ErtekadasErtesitesEllenorzes(ref iso, value);
        }

        private string nev;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Nev
        {
            get => nev;
            set => ErtekadasErtesitesEllenorzes(ref nev, value);
        }

    }
}
