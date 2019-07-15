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
        TEntitas KiterjesztettEgyetlen(Expression<Func<TEntitas, bool>> idfeltetel, params Expression<Func<TEntitas, object>>[] kiterjesztesek);
        IEnumerable<TEntitas> Mind();
        IEnumerable<TEntitas> MindAhol(Expression<Func<TEntitas, bool>> feltetel);
        IEnumerable<TEntitas> KiterjesztettMindAhol(Expression<Func<TEntitas, bool>> feltetel, params Expression<Func<TEntitas, object>>[] kiterjesztesek);


        void EgyetBetesz(TEntitas entitas);
        void SokatBetesz(IEnumerable<TEntitas> entitasok);

        void EgyetTorol(TEntitas entitas);
        void SokatTorol(IEnumerable<TEntitas> entitasok);

        void Frissit(TEntitas entitas);
    }
}
