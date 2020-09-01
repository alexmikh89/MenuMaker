using System.Collections.Generic;

namespace MenuMaker.Models
{
    public class CreatedRecipePostVM
    {
        public string RecipeName { get; set; }
        public int[] IngredientId { get; set; }
        public double[] Amount { get; set; }
    }
}