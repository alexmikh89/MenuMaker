using Autofac;
using AutoMapper;
using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using MenuMaker.Models;
using System;

namespace MenuMaker.Autofac
{
    public class MapperAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeModel>()
                .ForMember(i => i.RecipeIngredients, j => j.MapFrom(src => src.RecipeIngredients)).ReverseMap();
                cfg.CreateMap<Func<Recipe, bool>, Func<RecipeModel, bool>>().ReverseMap();
                cfg.CreateMap<RecipeModel, RecipeViewModel>().ReverseMap();
                cfg.CreateMap<Func<RecipeModel, bool>, Func<RecipeViewModel, bool>>().ReverseMap();

                //cfg.CreateMap<CreatedRecipe, CreatedRecipeModel>().ReverseMap();
                cfg.CreateMap<CreatedRecipePostModel, RecipeModel>().ReverseMap();

                cfg.CreateMap<RecipeIngredients, RecipeIngredientsModel>().ReverseMap();
                cfg.CreateMap<Func<RecipeIngredients, bool>, Func<RecipeIngredientsModel, bool>>().ReverseMap();
                cfg.CreateMap<RecipeIngredientsModel, RecipeIngredientsViewModel>().ReverseMap();
                cfg.CreateMap<Func<RecipeIngredientsModel, bool>, Func<RecipeIngredientsViewModel, bool>>().ReverseMap();

                //Menu mapping configs.
                cfg.CreateMap<MenuPostViewModel, MenuCreateModel>().ReverseMap();
                cfg.CreateMap<Menu, MenuCreateModel>().ReverseMap();
                cfg.CreateMap<Func<Menu, bool>, Func<MenuCreateModel, bool>>().ReverseMap();
                cfg.CreateMap<Menu, MenuModel>().ReverseMap();
                cfg.CreateMap<Func<Menu, bool>, Func<MenuModel, bool>>().ReverseMap();
                cfg.CreateMap<MenuModel, MenuViewModel>().ReverseMap();
                cfg.CreateMap<MenuIndexViewModel, MenuModel>().ReverseMap();
                cfg.CreateMap<Func<MenuIndexViewModel, bool>, Func<MenuModel, bool>>().ReverseMap();

                //MenuRecipe mapping configs.
                cfg.CreateMap<MenuRecipePostModel, MenuRecipe>().ReverseMap();
                cfg.CreateMap<Func<MenuRecipePostModel, bool>, Func<MenuRecipe, bool>>().ReverseMap();
                cfg.CreateMap<MenuRecipePostModel, MenuRecipe>().ReverseMap();
                cfg.CreateMap<MenuRecipeViewModel, MenuRecipeModel>().ReverseMap();
                cfg.CreateMap<MenuRecipeModel, MenuRecipe>().ReverseMap();
                cfg.CreateMap<MenuEditVM, MenuModel>().ReverseMap();
                cfg.CreateMap<MenuEditPM, MenuEditModel>().ReverseMap();
                cfg.CreateMap<Menu, MenuEditModel>().ReverseMap();


                //Day mapping configs.
                cfg.CreateMap<Day, DayModel>().ReverseMap();
                cfg.CreateMap<DayModel, DayViewModel>().ReverseMap();

                //IngredientMapping
                cfg.CreateMap<IngredientModel, IngredientViewModel>().ReverseMap();
                cfg.CreateMap<Ingredient, IngredientModel>().ReverseMap();

                //recipe mappings
                cfg.CreateMap<Recipe, CreatedRecipeModel>().ForMember(i => i.RecipeName, j => j.MapFrom(src => src.Name)).ReverseMap();
                cfg.CreateMap<CreatedRecipeModel, RecipeModel>().ForMember(i => i.Name, j => j.MapFrom(src => src.RecipeName)).ReverseMap();
                cfg.CreateMap<CreatedRecipePostModel, CreatedRecipeModel>().ForMember(i=>i.RecipeName, j=>j.MapFrom(src=>src.Name)).ReverseMap();


            }))
                .AsSelf()
                .SingleInstance();

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