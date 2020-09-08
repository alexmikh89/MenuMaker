using MenuMaker.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuMaker.Models
{
    public class RecipeIngredientsViewModel
    {
        [Key]
        public int Id { get; set; }

        public string RecipeName { get; set; }

        public int RecipeId { get; set; }
        public RecipeViewModel Recipe { get; set; }

        public int IngredientId { get; set; }
        public IngredientViewModel Ingredient { get; set; }

        public double Amount { get; set; }

        public IEnumerable<IngredientViewModel> IngredientsDropDownList { get; set; }        
    }
}