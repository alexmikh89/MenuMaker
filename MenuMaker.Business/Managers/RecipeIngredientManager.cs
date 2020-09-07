using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Managers
{
    public class RecipeIngredientManager : IRecipeIngredientsManager
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<RecipeIngredients> _repository;
        private readonly IEntityManager<Recipe, RecipeModel> _recipeManager;
        private readonly IEntityManager<Ingredient, IngredientModel> _ingredientManager;

        public RecipeIngredientManager(IMapper mapper,
            IRepository<RecipeIngredients> repository,
            IEntityManager<Recipe, RecipeModel> recipeManager,
            IEntityManager<Ingredient, IngredientModel> ingredientManager
            )
        {
            _mapper = mapper;
            _repository = repository;
            _recipeManager = recipeManager;
            _ingredientManager = ingredientManager;
        }

        public int Create(CreatedRecipeModel createdRecipeModel)
        {
            var ingredientIdCollection = createdRecipeModel.IngredientId/*.ToArray()*/;
            var ingredientAmountCollection = createdRecipeModel.Amount/*.ToArray()*/;

            var recipeModel = CreateNewRecipe(createdRecipeModel);

            var ingredientModelList = GetIngredient(ingredientIdCollection);

            for (int i = 0; i < ingredientModelList.Count; i++)
            {
                var recipeIngredientsModel = new RecipeIngredientsModel()
                {
                    RecipeId = recipeModel.Id,
                    IngredientId = ingredientModelList[i].Id,
                    Amount = ingredientAmountCollection[i]
                };

                var recipeIngredients = _mapper.Map<RecipeIngredients>(recipeIngredientsModel);

                var res = _repository.Create(recipeIngredients);

                if (res == 0)
                {
                    throw new Exception();
                }
            }

            return 1;
        }

        //should return recipe
        protected RecipeModel CreateNewRecipe(CreatedRecipeModel createdRecipe)
        {
            var newRecipeModel = _mapper.Map<RecipeModel>(createdRecipe);
            var newRecipeId = _recipeManager.Create(newRecipeModel);
            var result = _recipeManager.FindById(newRecipeId);
            return result;
        }

        //should return ingredients in list
        protected List<IngredientModel> GetIngredient(int[] ingredientIdCollection)
        {
            List<IngredientModel> result = _ingredientManager.GetAll()
                .Where(ingr => ingredientIdCollection.Contains(ingr.Id)).ToList();
            return result;
        }
    }
}
