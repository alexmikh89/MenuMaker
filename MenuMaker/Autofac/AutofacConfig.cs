using Autofac;
using Autofac.Integration.Mvc;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Managers;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using MenuMaker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            builder.RegisterType<EntityManager<Ingredient, IngredientModel>>().As<IEntityManager<Ingredient, IngredientModel>>();
            //builder.RegisterType<AnimalManager>().As<IAnimalManager>();
            //builder.RegisterType<HouseManager>().As<IHouseManager>();
            //builder.RegisterType<CustomJsonConverter>().As<IJsonConverter>();

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