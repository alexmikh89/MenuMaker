using System.Collections.Generic;

namespace MenuMaker.Business.Interfaces
{
    public interface IManager<TEntityModel> where TEntityModel : class
    {
        void Create(TEntityModel entity);
        TEntityModel Read(int? id);
        void Update(TEntityModel entity);
        void Delete();
        IEnumerable<TEntityModel> GetAll();
    }
}
