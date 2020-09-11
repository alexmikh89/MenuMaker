using MenuMaker.Business.Interfaces;
using MenuMaker.Data;
using System.Collections.Generic;

namespace MenuMaker.Business.Models
{
    public class RecipeModel : IEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<RecipeIngredientsModel> RecipeIngredients { get; set; }
        public string ImagePath { get; set; }

        public RecipeModel()
        {
            RecipeIngredients = new List<RecipeIngredientsModel>();
        }
    }
}
