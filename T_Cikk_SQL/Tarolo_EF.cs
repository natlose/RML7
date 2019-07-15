using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sajat.ObjektumModel;

namespace Sajat.Cikk
{
    public class Tarolo_EF : ITarolo
    {
        public Tarolo_EF(CikkContext context)
        {
            focsoportok = new SQLTarolas.Tarolo_EF<FoCsoport>(context);
            alcsoportok = new SQLTarolas.Tarolo_EF<AlCsoport>(context);
            cikkek = new SQLTarolas.Tarolo_EF<Cikk>(context);
        }

        private ITarolo<FoCsoport> focsoportok;
        public ITarolo<FoCsoport> FoCsoportok => focsoportok;

        private ITarolo<AlCsoport> alcsoportok;
        public ITarolo<AlCsoport> AlCsoportok => alcsoportok;

        private ITarolo<Cikk> cikkek;
        public ITarolo<Cikk> Cikkek => cikkek;

    }
}
