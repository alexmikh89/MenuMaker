using MenuMaker.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuMaker.Data.Models
{
    public class RecipeIngredients
    {
        [Key]
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public  Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public  Ingredient Ingredient { get; set; }

        public double Amount { get; set; }
    }
}
