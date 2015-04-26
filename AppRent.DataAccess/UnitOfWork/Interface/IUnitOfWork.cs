using System;

using AppRent.DataAccess.Contexts;
using AppRent.DataAccess.Repositories.Interface;


namespace AppRent.DataAccess.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ApartmentContext Context { get; }
        IBaseRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class;
        void Save();
    }
}
