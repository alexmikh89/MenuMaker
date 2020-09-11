using MenuMaker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MenuMaker.Models
{
    public class MenuCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input a name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Value must be at least 1")]
        public int PersonsCount { get; set; }
        public int RecipeId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<RecipeViewModel> RecipeViewModelsDropdownList { get; set; }
        public List<DayViewModel> Days { get; set; }
    }
}