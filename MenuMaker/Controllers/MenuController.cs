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

        public ActionResult Create()
        {
            var newMenu = new MenuViewModel();


            var RecipeModelsDropdownList = _recipeManager.GetAll();
            var RecipeViewModelsDropdownList = _mapper.Map<List<RecipeViewModel>>(RecipeModelsDropdownList);
            newMenu.RecipeViewModelsDropdownList = RecipeViewModelsDropdownList;

            return View(newMenu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(MenuPostViewModel menuPostViewModel)
        {
            if (ModelState.IsValid)
            {

                //string fileName = Path.GetFileNameWithoutExtension(createdRecipePostVM.ImageFile.FileName);
                //string extension = Path.GetExtension(createdRecipePostVM.ImageFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //createdRecipePostVM.ImagePath = "~/Images/" + fileName;

                //fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                //createdRecipePostVM.ImageFile.SaveAs(fileName);

                //var createdRecipeModel = _mapper.Map<CreatedRecipeModel>(createdRecipePostVM);
                //_recipeIngredientManager.Create(createdRecipeModel);

                return RedirectToAction("Index");
            }

            return View(menuPostViewModel);
        }
    }
}