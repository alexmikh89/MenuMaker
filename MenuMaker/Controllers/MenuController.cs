using AutoMapper;
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
        //private readonly IMenuRecipeManager _menuRecipeManager;
        private readonly IDayManager _dayManager;

        private readonly IEntityManager<Recipe, RecipeModel> _recipeManager;

        public MenuController(IMapper mapper, IMenuManager menuManager,
            IEntityManager<Recipe, RecipeModel> recipeManager,
            IDayManager dayManager/*, IMenuRecipeManager menuRecipeManager*/)
        {
            _mapper = mapper;
            _menuManager = menuManager;
            _recipeManager = recipeManager;
            _dayManager = dayManager;
            //_menuRecipeManager = menuRecipeManager;
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
        public ActionResult Create(MenuPostViewModel menuPostViewModel)
        {
            if (ModelState.IsValid)
            {
                var menuCreateModel = _mapper.Map<MenuCreateModel>(menuPostViewModel);
                var menuId = _menuManager.Create(menuCreateModel);

                if (menuPostViewModel.DayId.Length != menuPostViewModel.RecipeId.Length)
                {
                    return new HttpStatusCodeResult(400);
                }


                //for (int i = 0; i < menuRecipePostViewModel.RecipeId.Length; i++)
                //{
                //    var menuRecipeCreateModel = new MenuRecipePostModel()
                //    {
                //        MenuId = menuId,
                //        DayId = menuRecipePostViewModel.DayId[i],
                //        RecipeId = menuRecipePostViewModel.RecipeId[i]
                //    };
                //    _menuRecipeManager.Create(menuRecipeCreateModel);
                //};
                return RedirectToAction("Details/" + menuId);
                //return RedirectToAction("Index");

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

            menuEditVM.Days = _mapper.Map<List<DayViewModel>>(_dayManager.GetAll());
            //var dayViewModels = _mapper.Map<List<DayViewModel>>(_dayManager.GetAll());
            //dayViewModels.Sort();

            //ViewData["WeekDays"] = dayViewModels;

            return View(menuEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuEditPM menuEditPM)
        {

            if (ModelState.IsValid)
            {
                var menuEditModel = _mapper.Map<MenuEditModel>(menuEditPM);
                _menuManager.Update(menuEditModel);

                return RedirectToAction("Details/" + menuEditPM.Id);
            }

            var menuModel = _menuManager.FindById(menuEditPM.Id);
            var menuEditVM = _mapper.Map<MenuEditVM>(menuModel);

            return View(menuEditVM);
        }
    }
}
