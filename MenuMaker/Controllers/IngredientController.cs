using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientManager _ingredientManager;
        private readonly IMapper _mapper;

        public IngredientController(IMapper mapper, IIngredientManager ingredientManager)
        {
            _mapper = mapper;
            _ingredientManager = ingredientManager;
        }

        // GET: IngredientViewModels
        public ActionResult Index()
        {
            var ingredientsList = _ingredientManager.GetAll();
            var listOfIngredientsViewModels = _mapper.Map<IList<IngredientViewModel>>(ingredientsList);

            return View(listOfIngredientsViewModels);
        }

        // GET: IngredientViewModels/Details/5
        public ActionResult Details(int id)
        {
            var ingredientModel = _ingredientManager.FindById(id);

            if (ingredientModel == null)
            {
                return HttpNotFound();
            }

            var ingredientViewModel = _mapper.Map<IngredientViewModel>(ingredientModel);
            return View(ingredientViewModel);
        }

        // GET: IngredientViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientViewModels/Create
        [HttpPost]
        public ActionResult Create(IngredientViewModel ingredientViewModel)
        {
            if (ModelState.IsValid)
            {
                var ingredientModel = _mapper.Map<IngredientModel>(ingredientViewModel);
                _ingredientManager.Create(ingredientModel);

                return RedirectToAction("Index");
            }

            return View(ingredientViewModel);
        }

        // GET: IngredientViewModels/Edit/5
        public ActionResult Edit(int id)
        {

            IngredientModel ingredientModel = _ingredientManager.FindById(id);
            IngredientViewModel ingredientViewModel = _mapper.Map<IngredientViewModel>(ingredientModel);

            if (ingredientViewModel == null)
            {
                return HttpNotFound();
            }

            return View(ingredientViewModel);
        }

        // POST: IngredientViewModels/Edit/5
        [HttpPost]
        public ActionResult Edit(IngredientViewModel ingredientViewModel)
        {
            if (ModelState.IsValid)
            {
                var ingredientModel = _mapper.Map<IngredientModel>(ingredientViewModel);
                _ingredientManager.Update(ingredientModel);

                return RedirectToAction("Index");
            }
            return View(ingredientViewModel);
        }

        // GET: IngredientViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            var ingredientModel = _ingredientManager.FindById(id);
            if (ingredientModel == null)
            {
                return HttpNotFound();
            }
            _ingredientManager.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
