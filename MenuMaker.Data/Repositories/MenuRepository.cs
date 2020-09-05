using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;

namespace MenuMaker.Data.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        public int Create(Menu menu)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbMenuSet = ctx.Set<Menu>();
                var dbMenuRecipeSet = ctx.Set<MenuRecipe>();
                dbMenuSet.Add(menu);

                foreach (var menuRecipe in menu.MenuRecipes)
                {
                    dbMenuRecipeSet.Add(menuRecipe);
                }

                var result = ctx.SaveChanges();
                return result;
            }
        }

        public Menu FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> GetAll(Func<Menu, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu entity)
        {
            throw new NotImplementedException();
        }
    }
}
