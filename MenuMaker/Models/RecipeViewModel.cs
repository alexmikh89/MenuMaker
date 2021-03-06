﻿using MenuMaker.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MenuMaker.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<RecipeIngredientsViewModel> RecipeIngredients { get; set; }
        public IEnumerable<IngredientViewModel> IngredientsDropDownList { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public RecipeViewModel()
        {
            RecipeIngredients = new List<RecipeIngredientsViewModel>();
        }
    }
}