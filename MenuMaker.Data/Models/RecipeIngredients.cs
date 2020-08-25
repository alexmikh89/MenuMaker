using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Models
{
    public class RecipeIngridients
    {
        [Key, Column(Order = 0)]
        public int RecipeId { get; set; }

        [Key, Column(Order = 1)]
        public int IngredientId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingridient { get; set; }
        public double Amount { get; set; }
    }
}
