using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data;
using MenuMaker.Data.Models;
using MenuMaker.Models;

namespace MenuMaker.Controllers
{
    public class RecipeViewModelsController : Controller
    {
        private readonly IEntityManager<Recipe, RecipeModel> _recipeManager;
        private readonly IMapper _mapper;

        public RecipeViewModelsController(IMapper mapper, IEntityManager<Recipe, RecipeModel> entityManager)
        {
            _recipeManager = entityManager;
            _mapper = mapper;
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
            return View();
        }

        // POST: RecipeViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                var recipeModel = _mapper.Map<RecipeModel>(recipeViewModel);
                _recipeManager.Create(recipeModel);

                return RedirectToAction("Index");
            }

            return View(recipeViewModel);
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
