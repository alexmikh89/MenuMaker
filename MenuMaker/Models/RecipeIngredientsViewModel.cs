using MenuMaker.Interfaces;

namespace MenuMaker.Models
{
    public class RecipeIngredientsViewModel
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public  RecipeViewModel Recipe { get; set; }
        public  IngredientViewModel Ingredient { get; set; }

        public double Amount { get; set; }
    }
}