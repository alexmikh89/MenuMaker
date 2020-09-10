using MenuMaker.Business.Models;
using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Interfaces
{
    public interface IIngredientManager
    {
        int Create(IngredientModel ingredient);
        IngredientModel FindById(int id);
        IEnumerable<IngredientModel> GetAll();
        void Remove(int id);
        void Update(IngredientModel ingredient);
    }
}
