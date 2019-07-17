using Sajat.ObjektumModel;
using Sajat.Uzlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Uzlet
{
    public interface ITarolok : IDisposable
    {
        ITarolo<Orszag> Orszagok { get; }

        ITarolo<Irszam> Irszamok { get; }

        ILapozhatoTarolo<Partner> Partnerek { get; }

        ITarolo<Raktar> Raktarak { get; }

        ITarolo<Polc> Polcok { get; }

        ITarolo<Keszlet> Keszletek { get; }

        ITarolo<FoCsoport> FoCsoportok { get; }

        ITarolo<AlCsoport> AlCsoportok { get; }

        ITarolo<Cikk> Cikkek { get; }

    }
}
