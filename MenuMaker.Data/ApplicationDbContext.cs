using MenuMaker.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MenuMaker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingridients { get; set; }
        public DbSet<RecipeIngredients> RecipeIngridients { get; set; }
        public DbSet<MenuRecipe> MenuRecipes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Day> Days { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
