using MenuMaker.Data.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Data.Models
{
    public class Ingredient : INextEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  ICollection<RecipeIngredients> RecipeIngredients { get; set; }

        public Ingredient()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }
    }
}
