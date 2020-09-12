using DemoLuz.Core;
using DemoLuz.DataAccess.Core.EF.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace DemoLuz.DataAccess.Core.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> _entitySet;

        private readonly BaseContext _context;

        public Repository(BaseContext context)
        {
            _context = context;
            _entitySet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void AddOrUpdate(T entity)
        {
            _entitySet.AddOrUpdate(new T[] { entity });
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public long Count()
        {
            long num = _entitySet.AsNoTracking().Count();
            return num;
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            long num = _entitySet.AsNoTracking().Where(where).Count();
            return num;
        }

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public void DetachAll()
        {
            _context.ChangeTracker.Entries<T>().ForEach((DbEntityEntry<T> e) => e.State = EntityState.Detached);
        }

        public IQueryable<T> Entity()
        {
            return _entitySet.AsNoTracking().AsQueryable();
        }

        public T Find<K>(K id)
        {
            return _entitySet.Find(new object[] { id });
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _entitySet.Find(new object[] { where });
        }

        public T Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> ts = _entitySet.AsNoTracking().Where(where);
            T t = ((IEnumerable<Expression<Func<T, object>>>)includes).Aggregate(ts, (IQueryable<T> current, Expression<Func<T, object>> includeProperty) => current.Include(includeProperty)).FirstOrDefault();
            return t;
        }

        public IEnumerable<T> Get()
        {
            return _entitySet.AsNoTracking();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> ts = _entitySet.Where(where).AsNoTracking();
            return ts;
        }

        public IEnumerable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> ts = _entitySet.AsNoTracking();
            IEnumerable<T> ts1 = ((IEnumerable<Expression<Func<T, object>>>)includes).Aggregate(ts, (IQueryable<T> current, Expression<Func<T, object>> includeProperty) => current.Include(includeProperty));
            return ts1;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> ts = _entitySet.Where(where).AsNoTracking();
            IEnumerable<T> ts1 = ((IEnumerable<Expression<Func<T, object>>>)includes).Aggregate(ts, (IQueryable<T> current, Expression<Func<T, object>> includeProperty) => current.Include(includeProperty));
            return ts1;
        }

        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Remove(Expression<Func<T, bool>> where)
        {
            foreach (T t in _entitySet.Where(where).AsEnumerable())
            {
                _entitySet.Remove(t);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> Set()
        {
            return _entitySet.AsNoTracking().AsQueryable();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<T> entities)
        {
            Repository<T> repository = this;
            //foreach (var e in entities)
            //{
            //    repository.Add(e);
            //}
            entities.ForEach(new Action<T>(repository.Add));
        }
    }
}
