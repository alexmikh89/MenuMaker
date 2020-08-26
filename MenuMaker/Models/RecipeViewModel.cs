using MenuMaker.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Models
{
    public class RecipeViewModel : IEntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  ICollection<RecipeIngredientsViewModel> RecipeIngredients { get; set; }

        public RecipeViewModel()
        {
            RecipeIngredients = new List<RecipeIngredientsViewModel>();
        }
    }
}