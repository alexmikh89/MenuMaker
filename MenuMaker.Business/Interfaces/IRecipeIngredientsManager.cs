using MenuMaker.Business.Models;

namespace MenuMaker.Business.Interfaces
{
    public interface IRecipeIngredientsManager
    {
        int Create(CreatedRecipeModel createdRecipeModel);
    }
}
