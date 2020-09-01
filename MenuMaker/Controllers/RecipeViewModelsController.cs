using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using MenuMaker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class RecipeViewModelsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEntityManager<Recipe, RecipeModel> _recipeManager;
        private readonly IEntityManager<Ingredient, IngredientModel> _ingredientManager;
        private readonly IEntityManager<RecipeIngredients, RecipeIngredientsModel> _recipeIngredientManager;


        public RecipeViewModelsController(IMapper mapper,
            IEntityManager<Recipe, RecipeModel> recipeManager,
            IEntityManager<Ingredient, IngredientModel> ingredientManager,
            IEntityManager<RecipeIngredients, RecipeIngredientsModel> recipeIngredientManager)
        {
            _mapper = mapper;
            _recipeManager = recipeManager;
            _ingredientManager = ingredientManager;
            _recipeIngredientManager = recipeIngredientManager;
        }

        // GET: RecipeViewModels
        public ActionResult Index()
        {
            var recipeList = _recipeManager.GetAll();
            var listOfIngredientsViewModels = _mapper.Map<IList<RecipeViewModel>>(recipeList);

            return View(listOfIngredientsViewModels);
        }

        // GET: RecipeViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipeModel = _recipeManager.FindById(id);

            if (recipeModel == null)
            {
                return HttpNotFound();
            }

            var recipeViewModel = _mapper.Map<RecipeViewModel>(recipeModel);
            return View(recipeViewModel);
        }

        // GET: RecipeViewModels/Create
        public ActionResult Create()
        {
            var newRecipe = new RecipeIngredientsViewModel();
            var dropDownListOfIngredientModels = _ingredientManager.GetAll();
            var dropDownListOfIngrediens = _mapper.Map<List<IngredientViewModel>>(dropDownListOfIngredientModels);
            newRecipe.IngredientsDropDownList = dropDownListOfIngrediens;
            return View(newRecipe);
        }

        // POST: RecipeViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeIngredientPostVM recipeIngredientPostVM)
        {
            if (ModelState.IsValid)
            {
                //add new recipe with manager which will return ID for new recipe
                var newRecipePLModel = new RecipeViewModel() { Name = recipeIngredientPostVM.RecipeName };
                var newRecipeBLModel = _mapper.Map<RecipeModel>(newRecipePLModel);
                var recipeId = _recipeManager.Create(newRecipeBLModel);




                // in loop add new rcioeIngredient entities in DB for each new ingredient:
                //creating with recipe id + ingredient id
                _recipeIngredientManager.Create(new RecipeIngredientsModel());


                //var newRecipeViewModel = new RecipeViewModel();
                //
                // Invoke a recipe manager and pass a mappped map<recipe>(recipeingredientVM)
                return RedirectToAction("Index");
            }

            return View(/*recipeViewModel*/);
        }

        // GET: RecipeViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var recipeModel = _recipeManager.FindById(id);
            var recipeViewModel = _mapper.Map<RecipeViewModel>(recipeModel);

            if (recipeViewModel == null)
            {
                return HttpNotFound();
            }

            return View(recipeViewModel);
        }

        // POST: RecipeViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipeModel = _mapper.Map<RecipeModel>(recipeViewModel);
                _recipeManager.Update(recipeModel);

                return RedirectToAction("Index");
            }
            return View(recipeViewModel);
        }

        // GET: RecipeViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var recipeModel = _recipeManager.FindById(id);

            var recipeViewModel = _mapper.Map<IngredientViewModel>(recipeModel);
            if (recipeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(recipeViewModel);
        }

        // POST: RecipeViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _recipeManager.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
