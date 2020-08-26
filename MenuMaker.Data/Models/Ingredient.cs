using MenuMaker.Data.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Data.Models
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngridients { get; set; }

        public Ingredient()
        {
            RecipeIngridients = new List<RecipeIngredients>();
        }
    }
}
