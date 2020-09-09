using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;

namespace MenuMaker.Business.Managers
{
    public class MenuRecipeManager : IMenuRecipeManager
    {
        protected readonly IMapper _mapper;
        protected readonly INextRepository<MenuRecipe, int> _menuRecipeRepository;

        public MenuRecipeManager(IMapper mapper, INextRepository<MenuRecipe, int> menuRecipeRepository)
        {
            _mapper = mapper;
            _menuRecipeRepository = menuRecipeRepository;
        }

        public int Create(MenuRecipePostModel menuRecipeCreateModel)
        {
            var menuRecipe = _mapper.Map<MenuRecipe>(menuRecipeCreateModel);

            var menuRecipeId = _menuRecipeRepository.Create(menuRecipe);

            return menuRecipeId;
        }


        public MenuRecipeModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuRecipeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuRecipeModel> GetAll(Func<MenuRecipeModel, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MenuRecipeModel menuRecipeModel)
        {
            throw new NotImplementedException();
        }
    }
}
