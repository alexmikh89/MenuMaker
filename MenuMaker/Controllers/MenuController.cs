using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Models;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MenuMaker.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMenuManager _menuManager;
        private readonly IDayManager _dayManager;

        private readonly IRecipeManager _recipeManager;

        public MenuController(IMapper mapper, IMenuManager menuManager,
            IRecipeManager recipeManager, IDayManager dayManager)
        {
            _mapper = mapper;
            _menuManager = menuManager;
            _recipeManager = recipeManager;
            _dayManager = dayManager;
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

            newMenu.Days = _mapper.Map<List<DayViewModel>>(_dayManager.GetAll());

            return View(newMenu);
        }

        [HttpPost]
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

                return RedirectToAction("Details/" + menuId);
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

            menuViewModel.Days = _mapper.Map<List<DayViewModel>>(_dayManager.GetAll());

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
            return View(menuEditVM);
        }

        [HttpPost]
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
