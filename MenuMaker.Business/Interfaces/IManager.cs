using System;
using System.Collections.Generic;

namespace MenuMaker.Business.Interfaces
{
    public interface IManager<DbEntity, EntityModel> 
        where EntityModel : class
        where DbEntity :class
    {
        void Create(EntityModel  entityModel);
        EntityModel FindById(int id);
        IEnumerable<EntityModel> GetAll();
        IEnumerable<EntityModel> GetAll(Func<EntityModel, bool> func);
        void Remove(int id);
        void Update(EntityModel  entityModel);
    }
}
