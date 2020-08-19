using System;
using System.Collections.Generic;

namespace MenuMaker.Business.Interfaces
{
    public interface IManager<TEntityModel> where TEntityModel : class
    {
        void Create(TEntityModel entity);
        TEntityModel FindById(int id);
        IEnumerable<TEntityModel> GetAll();
        IEnumerable<TEntityModel> GetAll(Func<TEntityModel, bool> func);
        void Remove();
        void Update(TEntityModel entity);
    }
}
