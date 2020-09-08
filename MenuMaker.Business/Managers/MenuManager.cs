using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;

namespace MenuMaker.Business.Managers
{
    public class MenuManager : IMenuManager
    {
        protected readonly IMapper _mapper;
        protected readonly INextRepository<Menu, int> _menuRepository;

        public MenuManager(IMapper mapper, INextRepository<Menu, int> menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }
                
        public int Create(MenuCreateModel menuCreateModel)
        {
            var menu = _mapper.Map<Menu>(menuCreateModel);
            var result = _menuRepository.Create(menu);

            return result;
        }

        public IEnumerable<MenuModel> GetAll()
        {
            var menuList = _menuRepository.GetAll();
            var menuModelsList = _mapper.Map<IEnumerable<MenuModel>>(menuList);
            return menuModelsList;
        }

        public MenuModel FindById(int id)
        {
            var menu = _menuRepository.FindById(id);
            var result = _mapper.Map<MenuModel>(menu);
            return result;
        }


        public IEnumerable<MenuModel> GetAll(Func<MenuModel, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _menuRepository.Remove(id);
        }

        public void Update(MenuModel menuModel)
        {
            throw new NotImplementedException();
        }
    }
}
