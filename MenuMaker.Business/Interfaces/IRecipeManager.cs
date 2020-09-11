using MenuMaker.Business.Models;
using System.Collections.Generic;

namespace MenuMaker.Business.Interfaces
{
    public interface IRecipeManager
    {
        int Create(CreatedRecipeModel menuCreateModel);
        RecipeModel FindById(int id);
        IEnumerable<RecipeModel> GetAll();
        void Remove(int id);
        void Update(CreatedRecipeModel menuEditModel);
    }
}
