using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.SQLTarolas
{
    public class Tarolo_EF<TEntitas> : ITarolo<TEntitas> where TEntitas : class
    {
        protected readonly DbContext context; 

        public Tarolo_EF(DbContext context)
        {
            this.context = context;
        }

        public TEntitas Egyetlen(int id)
        {
            return context.Set<TEntitas>().Find(id);
        }

        public IEnumerable<TEntitas> Mind()
        {
            return context.Set<TEntitas>().ToList();
        }

        public IEnumerable<TEntitas> MindAhol(Expression<Func<TEntitas, bool>> feltetel)
        {
            return context.Set<TEntitas>().Where(feltetel);
        }

        public void EgyetBetesz(TEntitas entitas)
        {
            context.Set<TEntitas>().Add(entitas);
        }

        public void SokatBetesz(IEnumerable<TEntitas> entitasok)
        {
            context.Set<TEntitas>().AddRange(entitasok);
        }

        public void EgyetTorol(TEntitas entitas)
        {
            context.Set<TEntitas>().Remove(entitas);
        }

        public void SokatTorol(IEnumerable<TEntitas> entitasok)
        {
            context.Set<TEntitas>().RemoveRange(entitasok);
        }

        public void Frissit(TEntitas entitas)
        {
            context.Entry(entitas).Reload();
        }
    }
}
