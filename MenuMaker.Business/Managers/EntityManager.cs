using AutoMapper;
using MenuMaker.Data.Interfaces;

namespace MenuMaker.Business.Managers
{
    public class EntityManager<Entity, EntityModel> : BaseManager<Entity, EntityModel>
    where Entity : class
    where EntityModel : class
    {
        public EntityManager(IMapper mapper, IRepository<Entity> repository) : base(mapper, repository)
        {
        }
    }
}
