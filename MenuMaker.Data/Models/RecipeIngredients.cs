using MenuMaker.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuMaker.Data.Models
{
    public class RecipeIngredients
    {
        [Key, Column(Order = 0)]
        public int RecipeId { get; set; }

        [Key, Column(Order = 1)]
        public int IngredientId { get; set; }

        public  Recipe Recipe { get; set; }
        public  Ingredient Ingredient { get; set; }

        public double Amount { get; set; }
    }
}
