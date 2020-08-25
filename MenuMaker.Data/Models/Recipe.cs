using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeIngridients> RecipeIngridients { get; set; }

        public Recipe()
        {
            RecipeIngridients = new List<RecipeIngridients>();
        }
    }
}
