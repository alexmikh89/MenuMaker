using MenuMaker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : INextRepository<TEntity, TKey> where TEntity : class, TEntity<TKey>
    {
        public int Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(TKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Remove(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
