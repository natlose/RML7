using Sajat.SQLTarolas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class FoCsoportValtozas_EF : Valtozas_EF<CikkContext>, IFoCsoportValtozas
    {
        public FoCsoportValtozas_EF(CikkContext context)
        {
            this.context = context;
            FoCsoportok = new FoCsoportTarolo_EF(context);
        }
        public IFoCsoportTarolo FoCsoportok { get; set; }
    }
}
