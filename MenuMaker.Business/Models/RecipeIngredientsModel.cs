using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Models
{
    public class RecipeIngredientsModel
    {
        public int RecipeId { get; set; }
        public virtual RecipeModel RecipeModel { get; set; }

        public int IngredientId { get; set; }
        public virtual IngredientModel IngredientModel { get; set; }

        public double Amount { get; set; }
    }
}
