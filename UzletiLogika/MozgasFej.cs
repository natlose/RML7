using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public class MozgasFej : Ellenorizheto
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

        private string piszkozat;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(1, ErrorMessage = "hossz>1")]
        public string Piszkozat 
        {
            get => piszkozat;
            set => ErtekadasErtesitesEllenorzes(ref piszkozat, value);
        }

        private string mozgasnem;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(10, ErrorMessage = "hossz>10")]
        public string Mozgasnem
        {
            get => mozgasnem;
            set => ErtekadasErtesitesEllenorzes(ref mozgasnem, value);
        }

        private int irany;
        [Required(ErrorMessage = "kötelező")]
        //ide kéne egy Validator -1, 1 értékekre
        public int Irany
        {
            get => irany;
            set => ErtekadasErtesitesEllenorzes(ref irany, value);
        }

        private DateTime kelt;
        // nem kötelező amíg piszkozat
        public DateTime Kelt
        {
            get => kelt;
            set => ErtekadasErtesitesEllenorzes(ref kelt, value);
        }

        private string sorszam;
        // nem kötelező amíg piszkozat
        [MaxLength(15, ErrorMessage = "hossz>15")]
        public string Sorszam
        {
            get => sorszam;
            set => ErtekadasErtesitesEllenorzes(ref sorszam, value);
        }

        private Partner partner;
        public Partner Partner
        {
            get => partner;
            set => ErtekadasErtesitesEllenorzes(ref partner, value);
        }

        private Koltseghely koltseghely;
        public Koltseghely Koltseghely
        {
            get => koltseghely;
            set => ErtekadasErtesitesEllenorzes(ref koltseghely, value);
        }


        private ObservableCollection<MozgasTetel> tetelek;
        public ObservableCollection<MozgasTetel> Tetelek
        {
            get => tetelek;
            set => ErtekadasErtesites(ref tetelek, value);
        }

    }
}
