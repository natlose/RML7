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
    public class FEKerelem 
    {
        /// <summary>
        /// Felhasználói eset indítása FEParameterek megadásával
        /// </summary>
        /// <param name="id">A felhasználói eset azonosítója</param>
        /// <param name="parameterek">A felhasználói esetnek átadandó paraméterek</param>
        /// <param name="eredmenykor">Az eredményt feldolgozó rutin</param>
        public FEKerelem(string id, FEParameterek parameterek, Action<FEEredmenyek> eredmenykor)
        {
            Id = id;
            if (parameterek != null) Parameterek = parameterek;
            Eredmenykor = eredmenykor;
        }

        /// <summary>
        /// Felhasználói eset indítása parameterek megadása nélkül
        /// </summary>
        /// <param name="id">A felhasználói eset azonosítója</param>
        /// <param name="eredmenykor">Az eredményt feldolgozó rutin</param>
        public FEKerelem(string id, Action<FEEredmenyek> eredmenykor) : this(id, null, eredmenykor) { }

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
        public Action<FEEredmenyek> Eredmenykor { get; set; }

        public void Befejezes(FEEredmenyek eredmenyek)
        {
            Eredmenykor?.Invoke(eredmenyek);
        }
    }
}
