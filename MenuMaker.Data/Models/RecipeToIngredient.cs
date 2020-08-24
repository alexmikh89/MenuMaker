using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Models
{
    public class RecipesToIngridients
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingridient { get; set; }
        public double Amount { get; set; }
    }
}
