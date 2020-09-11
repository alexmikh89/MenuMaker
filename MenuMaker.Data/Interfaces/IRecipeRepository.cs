using MenuMaker.Data.Models;
using System.Collections.Generic;

namespace MenuMaker.Data.Interfaces
{
    public interface IRecipeRepository
    {
        int Create(Recipe recipe);
        Recipe FindById(int id);
        IEnumerable<Recipe> GetAll();
        void Remove(int id);
        void Update(Recipe recipe);
    }
}
