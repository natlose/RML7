﻿using Sajat.ObjektumModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sajat.Tarolas
{
    public class Tarolo_EF<TEntitas> : ITarolo<TEntitas>, ILapozhatoTarolo<TEntitas> where TEntitas : class
    {
        protected readonly DbContext context; 

        public Tarolo_EF(DbContext context)
        {
            this.context = context;
        }

        #region ITarolo<>
        public TEntitas Egyetlen(int id)
        {
            return context.Set<TEntitas>().Find(id);
        }

        public TEntitas KiterjesztettEgyetlen(Expression<Func<TEntitas, bool>> idfeltetel, params Expression<Func<TEntitas, object>>[] kiterjesztesek)
        {
            var lekerdezes = context.Set<TEntitas>().Where(idfeltetel);
            return kiterjesztesek.Aggregate(lekerdezes, (iteracio, kiterjesztes) => iteracio.Include(kiterjesztes)).SingleOrDefault();
        }

        public IEnumerable<TEntitas> Mind()
        {
            return context.Set<TEntitas>().ToList();
        }

        public IEnumerable<TEntitas> MindAhol(Expression<Func<TEntitas, bool>> feltetel)
        {
            return context.Set<TEntitas>().Where(feltetel).ToList();
        }

        public IEnumerable<TEntitas> KiterjesztettMindAhol(
            Expression<Func<TEntitas, bool>> feltetel, 
            params Expression<Func<TEntitas, object>>[] kiterjesztesek
        )
        {
            var lekerdezes = context.Set<TEntitas>().Where(feltetel);
            return kiterjesztesek.Aggregate(lekerdezes, (iteracio, kiterjesztes) => iteracio.Include(kiterjesztes)).ToList();
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
        #endregion

        #region ILapozhatoTarolo<>
        public IEnumerable<TEntitas> EgyLapnyiMind<TKey>(Expression<Func<TEntitas, TKey>> rendezesElve, int oldalmeret = 0, int oldal = 0)
        {
            return context.Set<TEntitas>()
                .OrderBy(rendezesElve)
                .Skip((oldal - 1) * oldalmeret)
                .Take(oldalmeret)
                .ToList();
        }

        public IEnumerable<TEntitas> EgyLapnyiMindAhol<TKey>(Expression<Func<TEntitas, TKey>> rendezesElve, Expression<Func<TEntitas, bool>> feltetel, int oldalmeret = 0, int oldal = 0)
        {
            return context.Set<TEntitas>()
                .Where(feltetel)
                .OrderBy(rendezesElve)
                .Skip((oldal - 1) * oldalmeret)
                .Take(oldalmeret)
                .ToList();
        }

        public IEnumerable<TEntitas> EgyLapnyiKiterjesztettMindAhol<TKey>(Expression<Func<TEntitas, TKey>> rendezesElve, Expression<Func<TEntitas, bool>> feltetel, int oldalmeret = 0, int oldal = 0, params Expression<Func<TEntitas, object>>[] kiterjesztesek)
        {
            var lekerdezes = context.Set<TEntitas>().Where(feltetel);
            lekerdezes = kiterjesztesek.Aggregate(lekerdezes, (iteracio, kiterjesztes) => iteracio.Include(kiterjesztes));
            lekerdezes = lekerdezes
                .OrderBy(rendezesElve)
                .Skip((oldal - 1) * oldalmeret)
                .Take(oldalmeret);
            return lekerdezes.ToList();
        }
        #endregion


    }
}