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
    public class Polc : Ellenorizheto
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

        private string kod;
        [Required(ErrorMessage = "kötelező")]
        [MaxLength(15, ErrorMessage = "hossz>15")]
        public string Kod
        {
            get => kod;
            set => ErtekadasErtesitesEllenorzes(ref kod, value);
        }

        private string megjegyzes;
        [MaxLength(50, ErrorMessage = "hossz>50")]
        public string Megjegyzes
        {
            get => megjegyzes;
            set => ErtekadasErtesitesEllenorzes(ref megjegyzes, value);
        }

        private Raktar raktar;
        public Raktar Raktar
        {
            get => raktar;
            set => ErtekadasErtesitesEllenorzes(ref raktar, value);
        }

        private ObservableCollection<Keszlet> keszletek;
        public ObservableCollection<Keszlet> Keszletek
        {
            get => keszletek;
            set => ErtekadasErtesitesEllenorzes(ref keszletek, value);
        }

    }
}
