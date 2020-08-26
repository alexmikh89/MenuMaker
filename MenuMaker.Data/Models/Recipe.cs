using MenuMaker.Data.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Data.Models
{
    public class Recipe : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngridients { get; set; }

        public Recipe()
        {
            RecipeIngridients = new List<RecipeIngredients>();
        }
    }
}
