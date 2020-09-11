﻿using MenuMaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuMaker.Models
{
    public class MenuCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonsCount { get; set; }
        public int RecipeId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<RecipeViewModel> RecipeViewModelsDropdownList { get; set; }
        public List<DayViewModel> Days { get; set; }
    }
}