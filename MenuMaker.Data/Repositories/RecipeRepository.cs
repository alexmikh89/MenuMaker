using MenuMaker.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MenuMaker.Data.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe, int>
    {
        public override int Create(Recipe recipe)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbRecipeSet = ctx.Set<Recipe>();
                var dbRecipeIngredientSet = ctx.Set<RecipeIngredients>();

                dbRecipeSet.Add(recipe);
                ctx.SaveChanges();
                var addedRecipeId = recipe.Id;
                return addedRecipeId;
            }
        }

        public override Recipe FindById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbSet = ctx.Set<Recipe>();
                var result = dbSet.Find(id);

                ctx.Entry(result).Collection(i => i.RecipeIngredients).Load();
                ctx.Entry(result).Collection(i => i.MenuRecipes).Load();

                foreach (var recipeIngredient in result.RecipeIngredients)
                {
                    ctx.Entry(recipeIngredient).Reference(i => i.Ingredient).Load();
                }

                return result;
            }
        }

        public override void Remove(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbRecipeSet = ctx.Set<Recipe>();
                var recipeToRemove = dbRecipeSet.Find(id);
                dbRecipeSet.Remove(recipeToRemove);

                var dbRecipeIngredientSet = ctx.Set<RecipeIngredients>();
                var recipeToIngredientsToRemove = dbRecipeIngredientSet.Where(i => i.RecipeId == id).ToList();
                dbRecipeIngredientSet.RemoveRange(recipeToIngredientsToRemove);

                var dbMenuRecipeSet = ctx.Set<RecipeIngredients>();
                var menuRecipesToRemove = dbMenuRecipeSet.Where(i => i.RecipeId == id).ToList();
                dbMenuRecipeSet.RemoveRange(recipeToIngredientsToRemove);

                ctx.SaveChanges();
            }
        }

        public override void Update(Recipe newRecipe)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dbRecipeSet = ctx.Set<Recipe>();
                var dbRecipeIngredientSet = ctx.Set<RecipeIngredients>();


                var existingRecipe = dbRecipeSet.Find(newRecipe.Id);
                ctx.Entry(existingRecipe).Collection(i => i.RecipeIngredients).Load();

                var deletedIngredients =
                    existingRecipe.RecipeIngredients.Select(i => new { i.IngredientId, i.Amount })
                    .Except(newRecipe.RecipeIngredients.Select(i => new { i.IngredientId, i.Amount }))
                    .ToList();

                foreach (var deletedIngredient in deletedIngredients)
                {
                    dbRecipeIngredientSet.Remove(
                        existingRecipe.RecipeIngredients
                        .Where(i => i.IngredientId == deletedIngredient.IngredientId)
                        .FirstOrDefault());
                }

                var addedIngredients = newRecipe.RecipeIngredients.Select(i => new { i.IngredientId, i.Amount })
                    .Except(existingRecipe.RecipeIngredients.Select(i => new { i.IngredientId, i.Amount }))
                    .ToList();

                foreach (var addedIngredient in addedIngredients)
                {
                    dbRecipeIngredientSet.Add(
                        new RecipeIngredients()
                        {
                            RecipeId = newRecipe.Id,
                            IngredientId = addedIngredient.IngredientId,
                            Amount = addedIngredient.Amount
                        });
                }

                dbRecipeSet.AddOrUpdate(newRecipe);
                ctx.SaveChanges();
            }
        }
    }
}
