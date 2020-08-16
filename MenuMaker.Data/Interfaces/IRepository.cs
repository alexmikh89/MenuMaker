using System;
using System.Collections.Generic;

namespace MenuMaker.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetEntities();
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> func);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
