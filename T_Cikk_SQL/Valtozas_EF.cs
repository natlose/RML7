using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class Valtozas_EF : SQLTarolas.Valtozas_EF<CikkContext>, IValtozas
    {
        public Valtozas_EF(CikkContext context)
        {
            this.context = context;
            tarolo = new Tarolo_EF(context);
        }
        private ITarolo tarolo;
        public ITarolo Tarolo => tarolo;
    }
}
