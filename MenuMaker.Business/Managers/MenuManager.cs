using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Managers
{
    public class MenuManager : IMenuManager
    {
        protected readonly IMapper _mapper;
        protected readonly IMenuRepository _menuRepository;

        public MenuManager(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public int Create(MenuCreateModel menuCreateModel)
        {
            var menuModel = _mapper.Map<Menu>(menuCreateModel);
            var result = _menuRepository.Create(menuModel);
            return result;
        }

        public MenuModel FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuModel> GetAll(Func<MenuModel, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(MenuModel menuModel)
        {
            throw new NotImplementedException();
        }
    }
}
