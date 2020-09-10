using DemoLuz.DataAccess.Core.EF.Base;
using System;
using System.Collections.Generic;

namespace DemoLuz.DataAccess.Core.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories;

        private readonly BaseContext _context;

        private bool _disposed;
        public UnitOfWork(BaseContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
        public void ExecuteSqlCommand(string command)
        {
            _context.Database.ExecuteSqlCommand(command, new object[0]);
        }

        public IRepository<T> Repository<T>() where T : class
        {
            string name = typeof(T).Name;
            if (!_repositories.ContainsKey(name))
            {
                Type type = typeof(Repository<>);
                object obj = Activator.CreateInstance(type.MakeGenericType(new Type[] { typeof(T) }), new object[] { _context });
                _repositories.Add(name, obj);
                return (Repository<T>)_repositories[name];
            }
            return (Repository<T>)_repositories[name];
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SetAutoDetectChanges(bool enabled)
        {
            _context.Configuration.AutoDetectChangesEnabled = enabled;
        }
    }
}
