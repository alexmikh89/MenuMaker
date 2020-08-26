using MenuMaker.Data.Models;
using System.Collections.Generic;

namespace MenuMaker.Data.Interfaces
{
    public interface IEntity
    {
        ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
