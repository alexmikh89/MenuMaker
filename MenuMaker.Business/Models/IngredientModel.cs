using System.Collections.Generic;

namespace MenuMaker.Business.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeIngredientsModel> RecipeIngredientsModels { get; set; }
        public IngredientModel()
        {
            RecipeIngredientsModels = new List<RecipeIngredientsModel>();
        }
    }
}
