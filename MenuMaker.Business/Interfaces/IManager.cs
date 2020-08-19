using System;
using System.Collections.Generic;

namespace MenuMaker.Business.Interfaces
{
    public interface IManager<DbEntity, EntityModel> 
        where EntityModel : class
        where DbEntity :class
    {
        void Create(EntityModel entity);
        EntityModel FindById(int id);
        IEnumerable<EntityModel> GetAll();
        IEnumerable<EntityModel> GetAll(Func<EntityModel, bool> func);
        void Remove();
        void Update(EntityModel entity);
    }
}
