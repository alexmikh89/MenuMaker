using MenuMaker.Data.Models;
using System.Collections.Generic;

namespace MenuMaker.Data.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
