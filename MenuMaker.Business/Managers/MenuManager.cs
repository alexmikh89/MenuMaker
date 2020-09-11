using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuMaker.Business.Managers
{
    public class MenuManager : IMenuManager
    {
        protected readonly IMapper _mapper;
        protected readonly INextRepository<Menu, int> _menuRepository;

        public MenuManager(IMapper mapper, INextRepository<Menu, int> menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public int Create(MenuCreateModel menuCreateModel)
        {
            var newMenu = _mapper.Map<Menu>(menuCreateModel);

            for (int i = 0; i < menuCreateModel.RecipeId.Length; i++)
            {
                if (menuCreateModel.RecipeId[i] != 0)
                {
                    newMenu.MenuRecipes.Add(new MenuRecipe()
                    {
                        RecipeId = menuCreateModel.RecipeId[i],
                        DayId = menuCreateModel.DayId[i]
                    });
                }
            }
            var result = _menuRepository.Create(newMenu);

            return result;
        }

        public IEnumerable<MenuModel> GetAll()
        {
            var menuList = _menuRepository.GetAll();
            var menuModelsList = _mapper.Map<IEnumerable<MenuModel>>(menuList);
            return menuModelsList;
        }

        public MenuModel FindById(int id)
        {
            var menu = _menuRepository.FindById(id);
            var result = _mapper.Map<MenuModel>(menu);
            return result;
        }


        public IEnumerable<MenuModel> GetAll(Func<MenuModel, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _menuRepository.Remove(id);
        }

        public void Update(MenuEditModel menuEditModel)
        {
            var editedMenu = _mapper.Map<Menu>(menuEditModel);

            for (int i = 0; i < menuEditModel.RecipeId.Length; i++)
            {
                if (menuEditModel.RecipeId[i] != 0)
                {
                    editedMenu.MenuRecipes.Add(new MenuRecipe()
                    {
                        MenuId = menuEditModel.Id,
                        RecipeId = menuEditModel.RecipeId[i],
                        DayId = menuEditModel.DayId[i]
                    });
                }
            }
            _menuRepository.Update(editedMenu);
        }

        public IEnumerable<BuyListModel> GetBuyList(int id)
        {
            var menu = FindById(id);
            var personsCount = menu.PersonsCount;

            var menuRecipeModels = menu.MenuRecipes.ToList();

            var ingredients = new List<RecipeIngredientsModel>();

            foreach (var menuRecipeModel in menuRecipeModels)
            {
                foreach (var recipeIngredient in menuRecipeModel.Recipe.RecipeIngredients.ToList())
                {
                    ingredients.Add(recipeIngredient);
                }
            }

            List<BuyListModel> result = ingredients
                .GroupBy(i => i.IngredientId).Select(c => new BuyListModel
                {  Id = c.First().IngredientId,
                    ProductName = c.First().Ingredient.Name,
                 Amount = c.Sum(j=>j.Amount)
                }).ToList();

            result.ForEach(i => i.MenuId = id);

            return result;
        }
    }
}
