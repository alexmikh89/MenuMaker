using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuMaker.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public int DayId { get; set; }

        public ICollection<MenuRecipeViewModel> MenuRecipeViewModels { get; set; }

        public List<RecipeViewModel> RecipeViewModelsDropdownList { get; set; }
    }
}