using Autofac;
using Autofac.Integration.Mvc;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Managers;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using MenuMaker.Data.Repositories;
using System.Web.Mvc;

namespace MenuMaker.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<DayRepository>().As<INextRepository<Day, int>>();
            builder.RegisterType<DayManager>().As<IDayManager>();

            builder.RegisterType<MenuRepository>().As<INextRepository<Menu, int>>();
            builder.RegisterType<MenuManager>().As<IMenuManager>();

            builder.RegisterType<IngredientRepository>().As<INextRepository<Ingredient, int>>();
            builder.RegisterType<IngredientManager>().As<IIngredientManager>();

            builder.RegisterType<RecipeRepository>().As<INextRepository<Recipe, int>>();
            builder.RegisterType<RecipeManager>().As<IRecipeManager>();

            builder.RegisterType<EntityManager<Ingredient, IngredientModel>>()
                .As<IEntityManager<Ingredient, IngredientModel>>();
            builder.RegisterType<EntityManager<Recipe, RecipeModel>>()
                .As<IEntityManager<Recipe, RecipeModel>>();
            builder.RegisterType<EntityManager<RecipeIngredients, RecipeIngredientsModel>>()
                .As<IEntityManager<RecipeIngredients, RecipeIngredientsModel>>();
            builder.RegisterType<RecipeManager>().As<IRecipeManager>();
            builder.RegisterModule<MapperAutofacModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}