using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Managers;
using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using MenuMaker.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntityManager<Ingredient, IngredientModel> _ingridientManager;
        private readonly Mapper _mapper;
        public HomeController()
        {
            _ingridientManager = new EntityManager<Ingredient, IngredientModel>();
            var mapConfig = new MapperConfiguration(c => c.CreateMap<IngredientModel, IngredientViewModel>());
            _mapper = new Mapper(mapConfig);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
        public ActionResult GetIngredients()
        {
            var listOfIngredientsModels = _ingridientManager.GetAll();
            var listOfIngredientsViewModels = _mapper.Map<IList<IngredientViewModel>>(listOfIngredientsModels);

            return View(listOfIngredientsViewModels);
        }
    }
}