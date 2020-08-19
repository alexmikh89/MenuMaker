using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Models
{
    public class RecipeToIngridient
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public Ingridient Ingridient { get; set; }
        public double Amount { get; set; }
    }
}
