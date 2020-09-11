using MenuMaker.Data.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MenuMaker.Data.Repositories
{
    public class MenuRepository : BaseRepository<Menu, int>
    {
        public override int Create(Menu newMenu)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbMenuSet = ctx.Set<Menu>();
                var dbMenuRecipeSet = ctx.Set<MenuRecipe>();

                dbMenuSet.Add(newMenu);
                ctx.SaveChanges();
                var addedMenuId = newMenu.Id;

                var addedRecipes = newMenu.MenuRecipes.ToList();

                foreach (var addedRecipe in addedRecipes)
                {
                    dbMenuRecipeSet.Add(
                        new MenuRecipe()
                        {
                            MenuId = addedMenuId,
                            RecipeId = addedRecipe.RecipeId,
                            DayId = addedRecipe.DayId
                        });
                }
                ctx.SaveChanges();


                return addedMenuId;
            }
        }
        public override Menu FindById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<Menu>();
                var result = dbSet.Find(id);

                if (result.MenuRecipes != null)
                {
                    ctx.Entry(result).Collection(i => i.MenuRecipes).Load();
                }

                foreach (var menuRecipe in result.MenuRecipes)
                {
                    ctx.Entry(menuRecipe).Reference(i => i.Recipe).Load();
                    ctx.Entry(menuRecipe).Reference(i => i.Day).Load();
                    ctx.Entry(menuRecipe.Recipe).Collection(i => i.RecipeIngredients).Load();

                    foreach (var recipeIngredients in menuRecipe.Recipe.RecipeIngredients)
                    {
                        ctx.Entry(recipeIngredients).Reference(i=>i.Ingredient).Load();

                    }
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

        public override void Update(Menu newMenu)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbMenuSet = ctx.Set<Menu>();
                var dbMenuRecipeSet = ctx.Set<MenuRecipe>();

                var existingMenu = dbMenuSet.Find(newMenu.Id);
                ctx.Entry(existingMenu).Collection(i => i.MenuRecipes).Load();

                var deletedRecipes =
                    existingMenu.MenuRecipes.Select(i => new { i.DayId, i.RecipeId })
                    .Except(newMenu.MenuRecipes.Select(i => new { i.DayId, i.RecipeId }))
                    .ToList();

                foreach (var deletedRecipe in deletedRecipes)
                {
                    dbMenuRecipeSet.Remove(
                        existingMenu.MenuRecipes
                        .Where(i => i.DayId == deletedRecipe.DayId)
                        .Where(i => i.RecipeId == deletedRecipe.RecipeId)
                        .FirstOrDefault());
                }

                var addedRecipes = newMenu.MenuRecipes.Select(i => new { i.DayId, i.RecipeId })
                    .Except(existingMenu.MenuRecipes.Select(i => new { i.DayId, i.RecipeId }))
                    .ToList();

                foreach (var addedRecipe in addedRecipes)
                {
                    dbMenuRecipeSet.Add(
                        new MenuRecipe()
                        {
                            MenuId = existingMenu.Id,
                            RecipeId = addedRecipe.RecipeId,
                            DayId = addedRecipe.DayId
                        });
                }

                dbMenuSet.AddOrUpdate(newMenu);
                ctx.SaveChanges();
            }
        }
    }
}
