using MenuMaker.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuMaker.Models
{
    public class RecipeIngredientsViewModel
    {
        public string RecipeName { get; set; }

        [Key, Column(Order = 0)]
        public int RecipeId { get; set; }
        [Key, Column(Order = 1)]
        public int IngredientId { get; set; }
        public RecipeViewModel Recipe { get; set; }
        public IngredientViewModel Ingredient { get; set; }

        public double Amount { get; set; }
        public IEnumerable<IngredientViewModel> IngredientsDropDownList { get; set; }        
    }
}