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
    public class Raktar : Ellenorizheto
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
        [MaxLength(30, ErrorMessage = "hossz>30")]
        public string Nev
        {
            get => nev;
            set => ErtekadasErtesitesEllenorzes(ref nev, value);
        }

        private ObservableCollection<Polc> polcok;
        public ObservableCollection<Polc> Polcok
        {
            get => polcok;
            set => ErtekadasErtesitesEllenorzes(ref polcok, value);
        }

    }
}
