using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

using AppRent.DataAccess.Contexts;
using AppRent.DataAccess.Repositories.Interface;


namespace AppRent.DataAccess.Repositories.Concrete
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class 
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        public BaseRepository(ApartmentContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity GetById(TKey id)
        {
            if (id != null)
            {
                return _dbSet.Find(id);
            }
            throw new NoNullAllowedException("entity");
        }

        public TEntity Insert(TEntity entity)
        {
            if (entity != null)
            {
                return _dbSet.Add(entity);
            }
            throw new NoNullAllowedException("entity");
        }

        public void Update(int oldEntityId, TEntity entity)
        {
            if (entity != null)
            {
                var original = _dbSet.Find(oldEntityId);
                if (original != null)
                {
                    _context.Entry(original).CurrentValues.SetValues(entity);
                }
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }
    }
}
