﻿using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuMaker.Business.Managers
{
    public class EntityManager<Entity, EntityModel> : IEntityManager<Entity, EntityModel>
        where Entity : class, IEntity
        where EntityModel : class
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public EntityManager(IMapper mapper, IRepository<Entity> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(EntityModel entityModel)
        {
            var dbEntity = _mapper.Map<Entity>(entityModel);
            _repository.Create(dbEntity);
        }

        public EntityModel FindById(int? id)
        {
            var dbEntity = _repository.FindById(id);
            return _mapper.Map<EntityModel>(dbEntity);
        }

        public IEnumerable<EntityModel> GetAll()
        {
            var listOfDbEntities = _repository.GetAll();
            var listOfEntityModels = _mapper.Map<IEnumerable<EntityModel>>(listOfDbEntities);
            return listOfEntityModels;
        }

        public IEnumerable<EntityModel> GetAll(Func<EntityModel, bool> blFunc)
        {
            var dbFunc = _mapper.Map<Func<Entity, bool>>(blFunc);
            var listOfDbEntities = _repository.GetAll(dbFunc);
            var listOfEntityModels = _mapper.Map<IEnumerable<EntityModel>>(listOfDbEntities);
            return listOfEntityModels;
        }

        public void Remove(int? id)
        {
            _repository.Remove(id);
        }

        public void Update(EntityModel entityModel)
        {
            var dbEntityToUpdate = _mapper.Map<Entity>(entityModel);
            _repository.Update(dbEntityToUpdate);
        }
    }
}
