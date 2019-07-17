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
    public class FoCsoport : Ellenorizheto
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

        private ObservableCollection<AlCsoport> alcsoportok;
        public ObservableCollection<AlCsoport> AlCsoportok
        {
            get => alcsoportok;
            set => ErtekadasErtesitesEllenorzes(ref alcsoportok, value);
        }

    }
}
