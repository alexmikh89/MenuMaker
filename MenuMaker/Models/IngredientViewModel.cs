using System.Collections.Generic;

namespace MenuMaker.Models
{
    public class IngredientViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public  ICollection<RecipeIngredientsViewModel> RecipeIngredients { get; set; }
        
        public IngredientViewModel()
        {
            RecipeIngredients = new List<RecipeIngredientsViewModel>();
        }
    }
}