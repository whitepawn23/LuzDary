using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoLuz.DataAccess.Core
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void AddOrUpdate(T entity);

        void AddRange(IEnumerable<T> entities);

        long Count();

        long Count(Expression<Func<T, bool>> where);

        void Detach(T entity);

        void DetachAll();
        IQueryable<T> Entity();

        T Find<K>(K id);

        T Find(Expression<Func<T, bool>> where);

        T Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> Get();

        IEnumerable<T> Get(Expression<Func<T, bool>> where);

        IEnumerable<T> Get(params Expression<Func<T, object>>[] includes);

        IEnumerable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        void Remove(T entity);

        void Remove(Expression<Func<T, bool>> where);

        void SaveChanges();

        IQueryable<T> Set();

        void Update(T entity);

        void Update(IEnumerable<T> entities);
    }
}
