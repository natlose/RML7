using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public interface ILapozhatoTarolo<TEntitas> : ITarolo<TEntitas> where TEntitas : class
    {
        IEnumerable<TEntitas> MindbolEgyLapnyi<TKey>(Expression<Func<TEntitas, TKey>> rendezesElve, int oldalmeret = 0, int oldal = 0);
        IEnumerable<TEntitas> MindAholbolEgyLapnyi<TKey>(Expression<Func<TEntitas, TKey>> rendezesElve, Expression<Func<TEntitas, bool>> feltetel, int oldalmeret = 0, int oldal = 0);
    }
}
