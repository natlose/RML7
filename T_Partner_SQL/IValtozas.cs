using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Partner
{
    public interface IValtozas : SQLTarolas.IValtozas
    {
        ITarolo Partnerek { get; set; }
    }
}
