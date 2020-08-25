using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngridients{ get; set; }

        public Ingredient()
        {
            RecipeIngridients = new List<RecipeIngredients>();
        }
    }
}
