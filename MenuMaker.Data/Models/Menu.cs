using MenuMaker.Data.Interfaces;
using System.Collections.Generic;

namespace MenuMaker.Data.Models
{
    public class Menu : INextEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonsCount { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<MenuRecipe> MenuRecipes { get; set; }
        public Menu()
        {
            MenuRecipes = new List<MenuRecipe>();
        }
    }
}
