using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class AlCsoport : Ellenorizheto
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

        private string nev;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(50, ErrorMessage = "hossz>50")]
        public string Nev
        {
            get => nev;
            set => ErtekadasErtesitesEllenorzes(ref nev, value);
        }

        private FoCsoport focsoport;
        public FoCsoport FoCsoport
        {
            get => focsoport;
            set => ErtekadasErtesitesEllenorzes(ref focsoport, value);
        }

    }
}
