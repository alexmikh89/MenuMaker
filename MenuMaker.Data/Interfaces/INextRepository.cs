using System;
using System.Collections.Generic;

namespace MenuMaker.Data.Interfaces
{
    public interface INextRepository<TEntity, TKey> where TEntity : class
    {
        TKey Create(TEntity entity);
        TEntity FindById(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> func);
        void Remove(TKey id);
        void Update(TEntity entity);
    }
}
