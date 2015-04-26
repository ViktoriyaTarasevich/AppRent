using System;
using System.Collections.Generic;
using System.Linq;

using AppRent.DataAccess.Contexts;
using AppRent.DataAccess.Repositories.Concrete;
using AppRent.DataAccess.Repositories.Interface;
using AppRent.DataAccess.UnitOfWork.Interface;


namespace AppRent.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApartmentContext _context;
        private bool _disposed;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork()
        {
            _context = new ApartmentContext();
            _repositories = new Dictionary<Type, object>();
        }

        public ApartmentContext Context
        {
            get { return _context; }
        }

        public IBaseRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IBaseRepository<TEntity, TKey>;
            }
            var repository = new BaseRepository<TEntity, TKey>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                        _context.Dispose();
                    _context = null;
                    _repositories = null;
                }

                _disposed = true;
            }
        }
    }
}
