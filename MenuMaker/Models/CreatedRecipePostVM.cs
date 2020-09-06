using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


namespace MenuMaker.Models
{
    public class CreatedRecipePostVM
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public int[] IngredientId { get; set; }
        public double[] Amount { get; set; }
        //public int[] DayOfWeekId { get; set; }

        //public IEnumerable<IngredientViewModel> IngredientsDropDownList { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}