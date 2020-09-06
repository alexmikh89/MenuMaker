using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using MenuMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMenuManager _menuManager;
        private readonly IEntityManager<Recipe, RecipeModel> _recipeManager;

        public MenuController(IMapper mapper, IMenuManager menuManager, IEntityManager<Recipe, RecipeModel> recipeManager)
        {
            _mapper = mapper;
            _menuManager = menuManager;
            _recipeManager = recipeManager;
        }

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            var newMenu = new MenuCreateViewModel();
            var RecipeModelsDropdownList = _recipeManager.GetAll();
            var RecipeViewModelsDropdownList = _mapper.Map<List<RecipeViewModel>>(RecipeModelsDropdownList);
            newMenu.RecipeViewModelsDropdownList = RecipeViewModelsDropdownList;

            return View(newMenu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuPostViewModel menuPostViewModel, MenuRecipePostViewModel menuRecipeViewModel)
        {
            if (ModelState.IsValid)
            {



                return RedirectToAction("Index");
            }

            return View(menuPostViewModel);
        }
    }
}