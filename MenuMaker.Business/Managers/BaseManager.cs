using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace MenuMaker.Business.Managers
{
    public abstract class BaseManager<Entity, EntityModel> : IEntityManager<Entity, EntityModel>
        where Entity : class
        where EntityModel : class
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public BaseManager(IMapper mapper, IRepository<Entity> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual void Create(EntityModel entityModel)
        {
            var dbEntity = _mapper.Map<Entity>(entityModel);
            _repository.Create(dbEntity);
        }

        public virtual EntityModel FindById(int? id)
        {
            var dbEntity = _repository.FindById(id);
            return _mapper.Map<EntityModel>(dbEntity);
        }

        public virtual IEnumerable<EntityModel> GetAll()
        {
            var listOfDbEntities = _repository.GetAll();
            var listOfEntityModels = _mapper.Map<IEnumerable<EntityModel>>(listOfDbEntities);
            return listOfEntityModels;
        }

        public virtual IEnumerable<EntityModel> GetAll(Func<EntityModel, bool> blFunc)
        {
            var dbFunc = _mapper.Map<Func<Entity, bool>>(blFunc);
            var listOfDbEntities = _repository.GetAll(dbFunc);
            var listOfEntityModels = _mapper.Map<IEnumerable<EntityModel>>(listOfDbEntities);
            return listOfEntityModels;
        }

        public virtual void Remove(int? id)
        {
            _repository.Remove(id);
        }

        public virtual void Update(EntityModel entityModel)
        {
            var dbEntityToUpdate = _mapper.Map<Entity>(entityModel);
            _repository.Update(dbEntityToUpdate);
        }
    }
}
