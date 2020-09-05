using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Models
{
    public class MenuCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonsCount { get; set; }
        public ICollection<MenuRecipeCreateModel>  MenuRecipeCreateModels { get; set; }
    }
}
