using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Models
{
    public class MenuRecipe
    {
        [Key, Column(Order = 0)]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
