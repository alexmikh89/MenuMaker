using MenuMaker.Business.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Business.Models
{
    public class RecipeIngredientsModel
    {
        [Key]
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public RecipeModel Recipe { get; set; }

        public int IngredientId { get; set; }
        public IngredientModel Ingredient { get; set; }

        public double Amount { get; set; }
    }
}
