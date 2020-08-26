using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using MenuMaker.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class IngredientViewModelsController : Controller
    {
        private readonly IEntityManager<Ingredient, IngredientModel> _ingredientManager;
        private readonly IMapper _mapper;

        public IngredientViewModelsController(IMapper mapper,  IEntityManager<Ingredient, IngredientModel> entityManager)
        {
            _ingredientManager = entityManager;
            _mapper = mapper;
        }

        // GET: IngredientViewModels
        public ActionResult Index()
        {
            var ingredientsList = _ingredientManager.GetAll();
            var listOfIngredientsViewModels = _mapper.Map<IList<IngredientViewModel>>(ingredientsList);

            return View(listOfIngredientsViewModels);
        }

        // GET: IngredientViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Id,Name")]*/ IngredientViewModel ingredientViewModel)
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IngredientModel ingredientModel = _ingredientManager.FindById(id);
            IngredientViewModel ingredientViewModel = _mapper.Map<IngredientViewModel>(ingredientModel);

            if (ingredientViewModel == null)
            {
                return HttpNotFound();
            }

            return View(ingredientViewModel);
        }

        // POST: IngredientViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,Name")]*/ IngredientViewModel ingredientViewModel)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ingredientModel = _ingredientManager.FindById(id);

            IngredientViewModel ingredientViewModel = _mapper.Map<IngredientViewModel>(ingredientModel);
            if (ingredientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ingredientViewModel);
        }

        // POST: IngredientViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ingredientManager.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
