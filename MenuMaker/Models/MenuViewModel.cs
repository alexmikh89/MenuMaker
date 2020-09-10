using System.Collections.Generic;

namespace MenuMaker.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonsCount { get; set; }
        public List<DayViewModel> Days { get; set; }
        public ICollection<MenuRecipeViewModel> MenuRecipes { get; set; }

        public List<RecipeViewModel> RecipeViewModelsDropdownList { get; set; }
    }
}