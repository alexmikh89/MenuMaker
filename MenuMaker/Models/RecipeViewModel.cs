using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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