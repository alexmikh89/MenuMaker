using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System.Collections.Generic;

namespace MenuMaker.Business.Managers
{
    public class IngredientManager : IIngredientManager
    {
        protected readonly IMapper _mapper;
        protected readonly INextRepository<Ingredient, int> _ingredientRepository;
        public IngredientManager(IMapper mapper, INextRepository<Ingredient, int> ingredientRepository)
        {
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
        }

        public int Create(IngredientModel ingredientModel)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientModel);
            var addedId = _ingredientRepository.Create(ingredient);
            return addedId;
        }

        public IngredientModel FindById(int id)
        {
            var ingredient = _ingredientRepository.FindById(id);
            var result = _mapper.Map<IngredientModel>(ingredient);
            return result;
        }

        public IEnumerable<IngredientModel> GetAll()
        {
            var ingredientList = _ingredientRepository.GetAll();
            var ingredientModelsList = _mapper.Map<IEnumerable<IngredientModel>>(ingredientList);
            return ingredientModelsList;
        }

        public void Remove(int id)
        {
            _ingredientRepository.Remove(id);
        }

        public void Update(IngredientModel ingredientModel)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientModel);
            _ingredientRepository.Update(ingredient);
        }
    }
}
