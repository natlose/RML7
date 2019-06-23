using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkalmazasKeret.API
{
    /// <summary>
    /// Felhasználói eset indítására irányuló kérelem 
    /// </summary>
    public class FEKerelem : EventArgs
    {
        /// <summary>
        /// Felhasználói eset indítása FEParameterek megadásával
        /// </summary>
        /// <param name="szerelvenyNeve">A felhasználói esetet tartalmazó szerelvény neve (.dll nélkül)</param>
        /// <param name="osztalyNeve">A felhasználói esetet megvalósító osztály neve (névtérrel együtt)</param>
        /// <param name="parameterek">A felhasználói esetnek átadandó paraméterek</param>
        /// <param name="eredmeny">Az eredményt feldolgozó rutin</param>
        public FEKerelem(string szerelvenyNeve, string osztalyNeve, FEParameterek parameterek, Action<FEEredmenyek> eredmeny)
        {
            SzerelvenyNeve = szerelvenyNeve;
            OsztalyNeve = osztalyNeve;
            if (parameterek != null) Parameterek = parameterek;
            Eredmeny = eredmeny;
        }

        /// <summary>
        /// Felhasználói eset indítása parameterek megadása nélkül
        /// </summary>
        /// <param name="szerelvenyNeve">A felhasználói esetet tartalmazó szerelvény neve (.dll nélkül)</param>
        /// <param name="osztalyNeve">A felhasználói esetet megvalósító osztály neve (névtérrel együtt)</param>
        /// <param name="eredmeny">Az eredményt feldolgozó rutin</param>
        public FEKerelem(string szerelvenyNeve, string osztalyNeve, Action<FEEredmenyek> eredmeny) : this(szerelvenyNeve, osztalyNeve, null, eredmeny) { }

        /// <summary>
        /// Felhasználói eset indítása parameterek és feldolgozó megadása nélkül
        /// </summary>
        /// <param name="szerelvenyNeve">A felhasználói esetet tartalmazó szerelvény neve (.dll nélkül)</param>
        /// <param name="osztalyNeve">A felhasználói esetet megvalósító osztály neve (névtérrel együtt)</param>
        public FEKerelem(string szerelvenyNeve, string osztalyNeve) : this(szerelvenyNeve, osztalyNeve, null, null) { }

        /// <summary>
        /// A felhasználói esetet tartalmazó szerelvény neve
        /// </summary>
        public string SzerelvenyNeve { get; private set; }

        /// <summary>
        /// A felhasználói esetet megvalósító osztály neve (névtérrel együtt)
        /// </summary>
        public string OsztalyNeve { get; private set; }

        /// <summary>
        /// A felhasználói esetnek átadandó paraméterek
        /// </summary>
        public FEParameterek Parameterek { get; private set; } = new FEParameterek();

        /// <summary>
        /// A kért felhasználói eset itt fogja (köteles) visszaadni az eredményét.
        /// </summary>
        public Action<FEEredmenyek> Eredmeny { get; set; }
    }

    public delegate void FEKerelemEsemenyKezelo(FEKerelem kerelem);

}
