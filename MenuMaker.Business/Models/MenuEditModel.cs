using MenuMaker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Models
{
    public class MenuEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonsCount { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int[] RecipeId { get; set; }
        public int[] DayId { get; set; }
    }
}
