using MenuMaker.Business.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Business.Models
{
    public class RecipeModel : IEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredientsModel> RecipeIngredientsModels { get; set; }

        public RecipeModel()
        {
            RecipeIngredientsModels = new List<RecipeIngredientsModel>();
        }
    }
}
