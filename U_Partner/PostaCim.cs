using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class PostaCim : Ellenorizheto
    {
        private int id;
        [Key]
        public int Id
        {
            get => id;
            set => ErtekadasErtesites(ref id, value);
        }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        private string tipus;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(1, ErrorMessage = "hossz>1")]
        public string Tipus // számlázási, levelezési, szállítási
        {
            get => tipus;
            set => ErtekadasErtesitesEllenorzes(ref tipus, value);
        }

        private string orszag;
        [MaxLength(2, ErrorMessage = "hossz>2")]
        [MinLength(2, ErrorMessage = "hossz<2")]
        public string Orszag
        {
            get => orszag;
            set => ErtekadasErtesitesEllenorzes(ref orszag, value);
        }

        private string iranyitoszam;
        [MaxLength(15, ErrorMessage = "hossz>15")]
        public string Iranyitoszam
        {
            get => iranyitoszam;
            set => ErtekadasErtesitesEllenorzes(ref iranyitoszam, value);
        }

        private string helyseg;
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Helyseg
        {
            get => helyseg;
            set => ErtekadasErtesitesEllenorzes(ref helyseg, value);
        }

        private string sor1;
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Sor1
        {
            get => sor1;
            set => ErtekadasErtesitesEllenorzes(ref sor1, value);
        }

        private string sor2;
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Sor2
        {
            get => sor2;
            set => ErtekadasErtesitesEllenorzes(ref sor2, value);
        }

        private Partner partner;
        public Partner Partner
        {
            get => partner;
            set => ErtekadasErtesites(ref partner, value);
        }

    }
}
