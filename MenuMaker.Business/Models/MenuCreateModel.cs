using MenuMaker.Data;

namespace MenuMaker.Business.Models
{
    public class MenuCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonsCount { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int[] RecipeId { get; set; }
        public int[] DayId { get; set; }
    }
}
