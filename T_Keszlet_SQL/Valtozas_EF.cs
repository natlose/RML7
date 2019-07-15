using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Keszlet
{
    public class Valtozas_EF : SQLTarolas.Valtozas_EF<KeszletContext>, IValtozas
    {
        public Valtozas_EF(KeszletContext context)
        {
            this.context = context;
            tarolo = new Tarolo_EF(context);
        }
        private ITarolo tarolo;
        public ITarolo Tarolo => tarolo;
    }
}
