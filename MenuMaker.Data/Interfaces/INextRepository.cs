using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Interfaces
{
    public interface INextRepository<TEntity, TKey> where TEntity : class
    {
        int Create(TEntity entity);
        TEntity FindById(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> func);
        void Remove(TKey id);
        void Update(TEntity entity);
    }
}
