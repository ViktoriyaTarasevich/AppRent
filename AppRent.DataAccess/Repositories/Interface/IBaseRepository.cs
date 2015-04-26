using System.Collections.Generic;


namespace AppRent.DataAccess.Repositories.Interface
{
    public interface IBaseRepository<TEntity, in TKey> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        TEntity Insert(TEntity entity);
        void Update(int oldEntityId, TEntity entity);
        void Delete(TEntity entity);
    }
}
