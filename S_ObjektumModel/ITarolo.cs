using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.ObjektumModel
{
    public interface ITarolo<TEntitas> where TEntitas : class
    {
        TEntitas Egyetlen(int id);
        IEnumerable<TEntitas> Mind();
        IEnumerable<TEntitas> MindAhol(Expression<Func<TEntitas, bool>> feltetel);

        void EgyetBetesz(TEntitas entitas);
        void SokatBetesz(IEnumerable<TEntitas> entitasok);

        void EgyetTorol(TEntitas entitas);
        void SokatTorol(IEnumerable<TEntitas> entitasok);

        void Frissit(TEntitas entitas);
    }
}
