using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Cikk
{
    public class AlCsoportTarolo_EF : SQLTarolas.Tarolo_EF<AlCsoport>, IAlCsoportTarolo
    {
        public AlCsoportTarolo_EF(CikkContext context) : base(context)
        {
        }
    }
}
