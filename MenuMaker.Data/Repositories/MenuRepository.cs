using MenuMaker.Data.Models;
using System.Linq;

namespace MenuMaker.Data.Repositories
{
    public class MenuRepository : BaseRepository<Menu, int>
    {
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
