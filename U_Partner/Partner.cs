using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Partner : Ellenorizheto
    {

        // Sajnos, beszűrődik egy tárolási rétegre tartozó megvalósítási részlet ide.
        // Nem kéne az üzleti rétegnek egy private alapkonstruktor, de sajnos az EF igényli.
        // Megdöbbentő módon tudja is használni. Reflection alapon példányosít...
        private Partner(){}

        public Partner(int id) { }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        private int id;
        [Key]
        public int Id
        {
            get => id;
            set => ErtekadasErtesites(ref id, value);
        }

        private string mj;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(1, ErrorMessage = "hossz>1")]
        public string MJ // M-magánszemély, J-jogi személy
        {
            get => mj;
            set => ErtekadasErtesitesEllenorzes(ref mj, value);
        }

        private Maganszemely maganszemely;
        /// <summary>
        /// Ha az MJ értéke M, akkor ez az identitása
        /// </summary>
        public Maganszemely Maganszemely
        {
            get => maganszemely;
            set => ErtekadasErtesites(ref maganszemely, value);
        }

        private Jogiszemely jogiszemely;
        /// <summary>
        /// Ha az MJ értéke J, akkor ez az identitása
        /// </summary>
        public Jogiszemely Jogiszemely
        {
            get => jogiszemely;
            set => ErtekadasErtesites(ref jogiszemely, value);
        }

        private Elerhetoseg elerhetoseg;
        public Elerhetoseg Elerhetoseg
        {
            get => elerhetoseg;
            set => ErtekadasErtesites(ref elerhetoseg, value);
        }

        private ICollection<PostaCim> postaCimek;
        public ICollection<PostaCim> PostaCimek
        {
            get => postaCimek;
            set => ErtekadasErtesites(ref postaCimek, value);
        }

    }
}
