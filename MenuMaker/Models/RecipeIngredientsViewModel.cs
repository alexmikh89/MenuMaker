﻿namespace MenuMaker.Models
{
    public class RecipeIngredientsViewModel
    {
        public int RecipeId { get; set; }
        public virtual RecipeViewModel RecipeViewModel { get; set; }

        public int IngredientId { get; set; }
        public virtual IngredientViewModel IngredientViewModel { get; set; }

        public double Amount { get; set; }
    }
}