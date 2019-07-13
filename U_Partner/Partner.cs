using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public class Partner : Ellenorizheto
    {

        public Partner()
        {
            MJ = "M";
            Maganszemely = new Maganszemely();
            Jogiszemely = new Jogiszemely();
            Elerhetoseg = new Elerhetoseg();
        }

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

        private string nev;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Nev
        {
            get => nev;
            private set => ErtekadasErtesites(ref nev, value);
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

        private ObservableCollection<PostaCim> postaCimek;
        public ObservableCollection<PostaCim> PostaCimek
        {
            get => postaCimek;
            set => ErtekadasErtesites(ref postaCimek, value);
        }

        [NotMapped]
        public PostaCim SzamlazasiCim
        {
            get => PostaCimek.FirstOrDefault(pc => pc.Tipus == "S");
        }


    }
}
