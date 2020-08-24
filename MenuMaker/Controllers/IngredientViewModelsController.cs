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
using MenuMaker.Business.Managers;
using MenuMaker.Business.Models;
using MenuMaker.Data;
using MenuMaker.Data.Models;
using MenuMaker.Models;

namespace MenuMaker.Controllers
{
    public class IngredientViewModelsController : Controller
    {
        private readonly IEntityManager<Ingredient, IngredientModel> _ingridientManager;
        private readonly Mapper _mapper;

        public IngredientViewModelsController()
        {
            _ingridientManager = new EntityManager<Ingredient, IngredientModel>();
            var mapConfig = new MapperConfiguration(c => c.CreateMap<IngredientModel, IngredientViewModel>());
            _mapper = new Mapper(mapConfig);
        }

        // GET: IngredientViewModels
        public ActionResult Index()
        {
            var ingredientsList = _ingridientManager.GetAll();
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
            var ingredientToView = _ingridientManager.FindById(id);

            if (ingredientToView == null)
            {
                return HttpNotFound();
            }
            return View(ingredientToView);
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
                _ingridientManager.Create(ingredientModel);

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

            IngredientModel ingredientModel = _ingridientManager.FindById(id);
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
                _ingridientManager.Update(ingredientModel);

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

            var ingredientModel = _ingridientManager.FindById(id);

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
            _ingridientManager.Remove(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
