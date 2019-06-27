using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sajat.Alkalmazas.API;
using Sajat.ObjektumModel;

namespace Sajat.Alkalmazas.WPF
{
    public class Tortenetek_NM : Megfigyelheto
    {
        public ObservableCollection<Tortenet> Tortenetek { get; set; } = new ObservableCollection<Tortenet>();

        private DateTime aktiv;
        public DateTime Aktiv
        {
            get => aktiv;
            set
            {
                ErtekadasErtesites(ref aktiv, value);
                Ertesites(nameof(AktivTortenet));
            }
        }

        public Tortenet AktivTortenet
        {
            get => Tortenetek.SingleOrDefault(t => t.Azonosito == aktiv);
        }

        public void UjTortenetKerelemkor(object sender, FEKerelem kerelem)
        {
            Tortenet tortenet = new Tortenet(kerelem, (t) => {
                TortenetValtozott?.Invoke(t, null);
                // Ha kiürült a történet, akkor kidobom a listából is:
                if (t.Nezetek.Count == 0)
                {
                    Aktiv = DateTime.MinValue;
                    Tortenetek.Remove(t);
                }
            });
            Tortenetek.Add(tortenet);
            Aktiv = tortenet.Azonosito;
        }

        public event EventHandler TortenetValtozott;
    }
}
