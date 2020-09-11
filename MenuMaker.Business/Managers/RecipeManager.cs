using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System.Collections.Generic;

namespace MenuMaker.Business.Managers
{
    public class RecipeManager : IRecipeManager
    {
        protected readonly IMapper _mapper;
        protected readonly INextRepository<Recipe, int> _recipeRepository;


        public RecipeManager(IMapper mapper, INextRepository<Recipe, int> recipeRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }

        public int Create(CreatedRecipeModel createdRecipeModel)
        {
            var newRecipe = _mapper.Map<Recipe>(createdRecipeModel);

            for (int i = 0; i < createdRecipeModel.IngredientId.Length; i++)
            {
                if (createdRecipeModel.IngredientId[i] != 0)
                {
                    newRecipe.RecipeIngredients.Add(new RecipeIngredients()
                    {
                        IngredientId = createdRecipeModel.IngredientId[i],
                        Amount = createdRecipeModel.Amount[i]
                    });
                }
            }
            var result = _recipeRepository.Create(newRecipe);

            return result;
        }
        public IEnumerable<RecipeModel> GetAll()
        {
            var recipeList = _recipeRepository.GetAll();
            var recipeModelsList = _mapper.Map<IEnumerable<RecipeModel>>(recipeList);
            return recipeModelsList;
        }

        public RecipeModel FindById(int id)
        {
            var recipe = _recipeRepository.FindById(id);
            var result = _mapper.Map<RecipeModel>(recipe);
            return result;
        }

        public void Remove(int id)
        {
            _recipeRepository.Remove(id);
        }

        public void Update(CreatedRecipeModel createdRecipeModel)
        {
            var editedRecipe = _mapper.Map<Recipe>(createdRecipeModel);

            for (int i = 0; i < createdRecipeModel.IngredientId.Length; i++)
            {
                if (createdRecipeModel.IngredientId[i] != 0)
                {
                    editedRecipe.RecipeIngredients.Add(new RecipeIngredients()
                    {
                        RecipeId = createdRecipeModel.Id,
                        IngredientId = createdRecipeModel.IngredientId[i],
                        Amount = createdRecipeModel.Amount[i]
                    });
                }
            }
            _recipeRepository.Update(editedRecipe);
        }
    }
}
