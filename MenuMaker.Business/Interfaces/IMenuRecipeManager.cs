using MenuMaker.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Interfaces
{
    public interface IMenuRecipeManager
    {
        int Create(MenuRecipeCreateModel menuCreateModel);
        MenuRecipeModel FindById(int id);
        IEnumerable<MenuRecipeModel> GetAll();
        IEnumerable<MenuRecipeModel> GetAll(Func<MenuRecipeModel, bool> func);
        void Remove(int id);
        void Update(MenuRecipeModel menuModel);
    }
}
