using MenuMaker.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Models
{
    public class IngredientViewModel : IEntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<RecipeIngredientsViewModel> RecipeIngredientsViewModels { get; set; }
        
        public IngredientViewModel()
        {
            RecipeIngredientsViewModels = new List<RecipeIngredientsViewModel>();
        }
    }
}