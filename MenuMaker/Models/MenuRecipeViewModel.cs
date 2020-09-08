using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Models
{
    public class MenuRecipeViewModel
    {
        [Key]
        public int Id { get; set; }
        public int MenuId { get; set; }
        public MenuViewModel Menu { get; set; }

        public int RecipeId { get; set; }
        public RecipeViewModel Recipe { get; set; }

        public int DayId { get; set; }
        public DayViewModel Day { get; set; }
    }
}