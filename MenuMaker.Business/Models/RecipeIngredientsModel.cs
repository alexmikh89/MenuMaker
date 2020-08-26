using MenuMaker.Business.Interfaces;

namespace MenuMaker.Business.Models
{
    public class RecipeIngredientsModel
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public RecipeModel Recipe { get; set; }
        public IngredientModel Ingredient { get; set; }

        public double Amount { get; set; }
    }
}
