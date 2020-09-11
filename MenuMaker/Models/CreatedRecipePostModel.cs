using MenuMaker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


namespace MenuMaker.Models
{
    public class CreatedRecipePostModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Input a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] IngredientId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Value must be at least 1")]
        public double[] Amount { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}