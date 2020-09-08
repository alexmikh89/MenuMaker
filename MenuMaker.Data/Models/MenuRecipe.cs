using MenuMaker.Data.Interfaces;

namespace MenuMaker.Data.Models
{
    public class MenuRecipe : INextEntity<int>
    {
        public int Id { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int DayId { get; set; }
        public Day Day { get; set; }
    }
}
