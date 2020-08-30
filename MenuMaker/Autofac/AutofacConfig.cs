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

            //
            // Uncomment in case of IAPIController using.
            //builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<BaseRepository<Ingredient>>().As<IRepository<Ingredient>>();
            builder.RegisterType<BaseRepository<Recipe>>().As<IRepository<Recipe>>();
            builder.RegisterType<RecipeIngredientRepository<RecipeIngredients>>().As<IRepository<RecipeIngredients>>();

            builder.RegisterType<EntityManager<Ingredient, IngredientModel>>()
                .As<IEntityManager<Ingredient, IngredientModel>>();
            builder.RegisterType<EntityManager<Recipe, RecipeModel>>()
                .As<IEntityManager<Recipe, RecipeModel>>();
            builder.RegisterType<EntityManager<RecipeIngredients, RecipeIngredientsModel>>()
                .As<IEntityManager<RecipeIngredients, RecipeIngredientsModel>>();

            builder.RegisterModule<MapperAutofacModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //
            // Uncomment in case of IAPIController using.
            //var config = GlobalConfiguration.Configuration;
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}