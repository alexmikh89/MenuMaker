using MenuMaker.Data;
using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Models
{
    public class MenuPostViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Value must be at least 1")]
        public int PersonsCount { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int[] RecipeId { get; set; }
        public int[] DayId { get; set; }
    }
}