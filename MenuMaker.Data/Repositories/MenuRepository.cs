using MenuMaker.Data.Models;
using System.Data.Entity;
using System.Linq;

namespace MenuMaker.Data.Repositories
{
    public class MenuRepository : BaseRepository<Menu, int>
    {
        public override Menu FindById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<Menu>();
                var result = dbSet.Find(id);

                ctx.Entry(result).Collection(i => i.MenuRecipes).Load();
                //dbSet.Include(i => i.MenuRecipes).ToList();
                foreach (var menuRecipe in result.MenuRecipes)
                {
                    ctx.Entry(menuRecipe).Reference(i => i.Recipe).Load();
                    ctx.Entry(menuRecipe).Reference(i => i.Day).Load();
                }

                return result;
            }
        }
        public override void Remove(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbMenuSet = ctx.Set<Menu>();
                var menuToRemove = dbMenuSet.Find(id);
                dbMenuSet.Remove(menuToRemove);

                var dbMenuRecipeSet = ctx.Set<MenuRecipe>();
                var menuRecipesToRemove = dbMenuRecipeSet.Where(i => i.MenuId == id).ToList();
                dbMenuRecipeSet.RemoveRange(menuRecipesToRemove);

                ctx.SaveChanges();
            }
        }
    }
}
