using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Alkalmazas.API
{
    /// <summary>
    /// Felhasználói eset indítására irányuló kérelem 
    /// </summary>
    public class FEKerelem : EventArgs
    {
        /// <summary>
        /// Felhasználói eset indítása FEParameterek megadásával
        /// </summary>
        /// <param name="id">A felhasználói eset azonosítója</param>
        /// <param name="parameterek">A felhasználói esetnek átadandó paraméterek</param>
        /// <param name="eredmeny">Az eredményt feldolgozó rutin</param>
        public FEKerelem(string id, FEParameterek parameterek, Action<FEEredmenyek> eredmeny)
        {
            Id = id;
            if (parameterek != null) Parameterek = parameterek;
            Eredmeny = eredmeny;
        }

        /// <summary>
        /// Felhasználói eset indítása parameterek megadása nélkül
        /// </summary>
        /// <param name="id">A felhasználói eset azonosítója</param>
        /// <param name="eredmeny">Az eredményt feldolgozó rutin</param>
        public FEKerelem(string id, Action<FEEredmenyek> eredmeny) : this(id, null, eredmeny) { }

        /// <summary>
        /// Felhasználói eset indítása parameterek és feldolgozó megadása nélkül
        /// </summary>
        /// <param name="id">A felhasználói eset azonosítója</param>
        public FEKerelem(string id) : this(id, null, null) { }

        /// <summary>
        /// A felhasználói esetet azonosítója
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// A felhasználói esetnek átadandó paraméterek
        /// </summary>
        public FEParameterek Parameterek { get; private set; } = new FEParameterek();

        /// <summary>
        /// A kért felhasználói eset itt fogja (köteles) visszaadni az eredményét.
        /// </summary>
        public Action<FEEredmenyek> Eredmeny { get; set; }

        public void Befejezes(FEEredmenyek eredmenyek)
        {
            Eredmeny?.Invoke(eredmenyek);
        }
    }

    public delegate void FEKerelemEsemenyKezelo(FEKerelem kerelem);

}
