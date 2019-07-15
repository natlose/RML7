using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sajat.ObjektumModel;

namespace Sajat.Keszlet
{
    public class Tarolo_EF : ITarolo
    {
        public Tarolo_EF(KeszletContext context)
        {
            raktarak = new SQLTarolas.Tarolo_EF<Raktar>(context);
            polcok = new SQLTarolas.Tarolo_EF<Polc>(context);
            keszletek = new SQLTarolas.Tarolo_EF<Keszlet>(context);
        }

        private ITarolo<Raktar> raktarak;
        public ITarolo<Raktar> Raktarak => raktarak;

        private ITarolo<Polc> polcok;
        public ITarolo<Polc> Polcok => polcok;

        private ITarolo<Keszlet> keszletek;
        public ITarolo<Keszlet> Keszletek => keszletek;
    }
}
