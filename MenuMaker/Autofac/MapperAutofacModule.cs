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

                cfg.CreateMap<CreatedRecipePostVM, CreatedRecipeModel>().ReverseMap();
                cfg.CreateMap<CreatedRecipe, CreatedRecipeModel>().ReverseMap();
                cfg.CreateMap<CreatedRecipePostVM, RecipeModel>().ReverseMap();
                cfg.CreateMap<CreatedRecipeModel, RecipeModel>()
                .ForMember(i => i.Name, j => j.MapFrom(src => src.RecipeName)).ReverseMap();

                cfg.CreateMap<Ingredient, IngredientModel>().ReverseMap();
                cfg.CreateMap<Func<Ingredient, bool>, Func<IngredientModel, bool>>().ReverseMap();
                cfg.CreateMap<IngredientModel, IngredientViewModel>().ReverseMap();
                cfg.CreateMap<Func<IngredientModel, bool>, Func<IngredientViewModel, bool>>().ReverseMap();

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
                cfg.CreateMap<MenuRecipeCreateModel, MenuRecipe>().ReverseMap();
                cfg.CreateMap<Func<MenuRecipeCreateModel, bool>, Func<MenuRecipe, bool>>().ReverseMap();
                cfg.CreateMap<MenuRecipeCreateModel, MenuRecipe>().ReverseMap();
                cfg.CreateMap<MenuRecipeViewModel, MenuRecipeModel>().ReverseMap();
                cfg.CreateMap<MenuRecipeModel, MenuRecipe>().ReverseMap();
                cfg.CreateMap<MenuEditVM, MenuModel>().ReverseMap();

                //Day mapping configs.
                cfg.CreateMap<Day, DayModel>().ReverseMap();
                cfg.CreateMap<DayModel, DayViewModel>().ReverseMap();

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