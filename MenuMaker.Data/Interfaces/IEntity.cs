using MenuMaker.Data.Models;
using System.Collections.Generic;

namespace MenuMaker.Data.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
