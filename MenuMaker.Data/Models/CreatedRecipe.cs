using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Models
{
    public class CreatedRecipe
    {
        public string RecipeName { get; set; }
        public int[] IngredientId { get; set; }
        public double[] Amount { get; set; }
    }
}
