using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using MenuMaker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    [Authorize(Roles="superUser")]
    public class RecipeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRecipeManager _recipeManager;
        private readonly IIngredientManager _ingredientManager;


        public RecipeController(IMapper mapper, IRecipeManager recipeManager, IIngredientManager ingredientManager)
        {
            _mapper = mapper;
            _ingredientManager = ingredientManager;
            _recipeManager = recipeManager;
        }

        // GET: Recipe
        public ActionResult Index()
        {
            var recipeList = _recipeManager.GetAll();
            var listOfIngredientsViewModels = _mapper.Map<IList<RecipeViewModel>>(recipeList);

            return View(listOfIngredientsViewModels);
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            var recipeModel = _recipeManager.FindById(id);

            if (recipeModel == null)
            {
                return HttpNotFound();
            }

            var recipeViewModel = _mapper.Map<RecipeViewModel>(recipeModel);
            return View(recipeViewModel);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            var newRecipe = new RecipeIngredientsViewModel();

            var dropDownListOfIngredientModels = _ingredientManager.GetAll();
            var dropDownListOfIngrediens = _mapper.Map<List<IngredientViewModel>>(dropDownListOfIngredientModels);
            newRecipe.IngredientsDropDownList = dropDownListOfIngrediens;

            return View(newRecipe);
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(CreatedRecipePostModel createdRecipePostVM)
        {
            if (ModelState.IsValid)
            {
                if (createdRecipePostVM.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(createdRecipePostVM.ImageFile.FileName);
                    string extension = Path.GetExtension(createdRecipePostVM.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    createdRecipePostVM.ImageFile.SaveAs(path);
                    createdRecipePostVM.ImagePath = "~/Images/" + fileName;
                }

                var createdRecipeModel = _mapper.Map<CreatedRecipeModel>(createdRecipePostVM);
                _recipeManager.Create(createdRecipeModel);

                return RedirectToAction("Index");
            }

            return View(createdRecipePostVM);
        }

        // GET: RecipeViewModels/Edit/5
        public ActionResult Edit(int id)
        {
            var recipeModel = _recipeManager.FindById(id);
            var recipeViewModel = _mapper.Map<RecipeViewModel>(recipeModel);

            if (recipeViewModel == null)
            {
                return HttpNotFound();
            }

            recipeViewModel.IngredientsDropDownList = _mapper.Map<List<IngredientViewModel>>( _ingredientManager.GetAll());

            return View(recipeViewModel);
        }

        // POST: RecipeViewModels/Edit/5
        [HttpPost]
        public ActionResult Edit(CreatedRecipePostModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                if (recipeViewModel.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(recipeViewModel.ImageFile.FileName);
                    string extension = Path.GetExtension(recipeViewModel.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    recipeViewModel.ImageFile.SaveAs(path);
                    recipeViewModel.ImagePath = "~/Images/" + fileName;
                }
                var recipeModel = _mapper.Map<CreatedRecipeModel>(recipeViewModel);

                _recipeManager.Update(recipeModel);

                return RedirectToAction("Index");
            }
            return View(recipeViewModel);
        }

        // GET: RecipeViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            _recipeManager.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
