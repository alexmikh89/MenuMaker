using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuMaker.Models
{
    public class MenuPostViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] RecipeId { get; set; }
        public int[] DayId { get; set; }
    }
}