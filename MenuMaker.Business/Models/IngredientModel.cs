using MenuMaker.Business.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Business.Models
{
    public class IngredientModel : IEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeIngredientsModel> RecipeIngredients { get; set; }

        public IngredientModel()
        {
            RecipeIngredients = new List<RecipeIngredientsModel>();
        }
    }
}
