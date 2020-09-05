using MenuMaker.Data.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Data.Models
{
    public class Recipe : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<RecipeIngredients> RecipeIngredients { get; set; }
        public ICollection<MenuRecipe>  MenuRecipes { get; set; }

        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }
    }
}
