using Autofac;
using AutoMapper;
using MenuMaker.Business.Models;
using MenuMaker.Models;

namespace MenuMaker.Autofac
{
    public class MapperAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IngredientViewModel, IngredientModel>().ReverseMap();
            })).AsSelf().SingleInstance();

            builder.Register(i =>
            {
                var context = i.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}