using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


namespace MenuMaker.Models
{
    public class CreatedRecipePostModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] IngredientId { get; set; }
        public double[] Amount { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}