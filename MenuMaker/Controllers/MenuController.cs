﻿using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using MenuMaker.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMenuManager _menuManager;
        private readonly IMenuRecipeManager _menuRecipeManager;

        private readonly IEntityManager<Recipe, RecipeModel> _recipeManager;

        public MenuController(IMapper mapper, IMenuManager menuManager,
            IEntityManager<Recipe, RecipeModel> recipeManager,
            IMenuRecipeManager menuRecipeManager)
        {
            _mapper = mapper;
            _menuManager = menuManager;
            _recipeManager = recipeManager;
            _menuRecipeManager = menuRecipeManager;
        }

        // GET: Menu
        public ActionResult Index()
        {
            var menuModelsList = _menuManager.GetAll();
            var menuViewModelsList = _mapper.Map<IEnumerable<MenuIndexViewModel>>(menuModelsList);
            return View(menuViewModelsList);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            var newMenu = new MenuCreateViewModel();
            var recipeModelsDropdownList = _recipeManager.GetAll();
            var recipeViewModelsDropdownList = _mapper.Map<List<RecipeViewModel>>(recipeModelsDropdownList);
            newMenu.RecipeViewModelsDropdownList = recipeViewModelsDropdownList;

            return View(newMenu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuPostViewModel menuPostViewModel, MenuRecipePostViewModel menuRecipePostViewModel)
        {
            if (ModelState.IsValid)
            {
                var menuCreateModel = _mapper.Map<MenuCreateModel>(menuPostViewModel);
                var menuId = _menuManager.Create(menuCreateModel);

                if (menuRecipePostViewModel.DayId.Length != menuRecipePostViewModel.RecipeId.Length)
                {
                    return new HttpStatusCodeResult(400);
                }

                for (int i = 0; i < menuRecipePostViewModel.RecipeId.Length; i++)
                {
                    var menuRecipeCreateModel = new MenuRecipeCreateModel()
                    {
                        MenuId = menuId,
                        DayId = menuRecipePostViewModel.DayId[i],
                        RecipeId = menuRecipePostViewModel.RecipeId[i]
                    };
                    _menuRecipeManager.Create(menuRecipeCreateModel);
                };
                return RedirectToAction("Index");
            }
            return View(menuPostViewModel);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            _menuManager.Remove(id);
            return RedirectToAction("Index");
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            MenuModel menuModel = _menuManager.FindById(id);

            if (menuModel == null)
            {
                return HttpNotFound();
            }

            var menuViewModel = _mapper.Map<MenuViewModel>(menuModel);

            return View(menuViewModel);
        }

        public ActionResult Edit(int id)
        {
            var menuModel = _menuManager.FindById(id);
            if (menuModel == null)
            {
                return HttpNotFound();
            }

            var menuEditVM = _mapper.Map<MenuEditVM>(menuModel);

            var recipeModelsDropdownList = _recipeManager.GetAll();
            var recipeViewModelsDropdownList = _mapper.Map<List<RecipeViewModel>>(recipeModelsDropdownList);
            menuEditVM.RecipeViewModelsDropdownList = recipeViewModelsDropdownList;

            return View(menuEditVM);

            //IngredientModel ingredientModel = _ingredientManager.FindById(id);
            //IngredientViewModel ingredientViewModel = _mapper.Map<IngredientViewModel>(ingredientModel);

            //if (ingredientViewModel == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(ingredientViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuEditPM menuEditPM)
        {

            if (ModelState.IsValid)
            {
                //    var ingredientModel = _mapper.Map<IngredientModel>(ingredientViewModel);
                //    _ingredientManager.Update(ingredientModel);

                //    return RedirectToAction("Index");
            }

            return RedirectToAction("Details/" + menuEditPM.Id);

            return View(/*ingredientViewModel*/);
        }

    }
}
