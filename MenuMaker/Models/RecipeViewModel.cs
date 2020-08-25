using System.Collections.Generic;

namespace MenuMaker.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeIngredientsViewModel> RecipeIngredientsModels { get; set; }

        public RecipeViewModel()
        {
            RecipeIngredientsModels = new List<RecipeIngredientsViewModel>();
        }
    }
}