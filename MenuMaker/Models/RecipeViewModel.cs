using MenuMaker.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MenuMaker.Models
{
    public class RecipeViewModel : IEntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RecipeIngredientsViewModel> RecipeIngredients { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public RecipeViewModel()
        {
            RecipeIngredients = new List<RecipeIngredientsViewModel>();
        }
    }
}