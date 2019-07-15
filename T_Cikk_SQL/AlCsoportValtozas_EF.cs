using Sajat.SQLTarolas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class AlCsoportValtozas_EF : Valtozas_EF<CikkContext>, IAlCsoportValtozas
    {
        public AlCsoportValtozas_EF(CikkContext context)
        {
            this.context = context;
            AlCsoportok = new AlCsoportTarolo_EF(context);
        }
        public IAlCsoportTarolo AlCsoportok { get; set; }

    }
}
