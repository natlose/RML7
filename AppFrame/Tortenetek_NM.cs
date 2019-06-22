using AppFrame.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNotification;

namespace AppFrame
{
    public class Tortenetek_NM : MegfigyelhetokOse
    {
        private Dictionary<DateTime, Tortenet> tortenetek = new Dictionary<DateTime, Tortenet>();

        private DateTime aktivTortenetKulcsa;
        public DateTime AktivTortenetKulcsa
        {
            get => aktivTortenetKulcsa;
            set
            {
                aktivTortenetKulcsa = value;
                MegfigyelokErtesitese(nameof(AktivTortenet));
            }
        }

        public Tortenet AktivTortenet
        {
            get
            {
                if (tortenetek.ContainsKey(AktivTortenetKulcsa)) return tortenetek[aktivTortenetKulcsa];
                else return null;
            }
        }

        public void UjTortenetKerelemkor(object sender, FEKerelem kerelem)
        {
            Tortenet tortenet = new Tortenet(kerelem);
            DateTime kulcs = DateTime.Now;
            tortenetek.Add(kulcs, tortenet);
            AktivTortenetKulcsa = kulcs;
        }
    }
}
