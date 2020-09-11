using MenuMaker.Business.Models;
using System;
using System.Collections.Generic;

namespace MenuMaker.Business.Interfaces
{
    public interface IMenuManager
    {
        int Create(MenuCreateModel menuCreateModel);
        MenuModel FindById(int id);
        IEnumerable<MenuModel> GetAll();
        IEnumerable<MenuModel> GetAll(Func<MenuModel, bool> func);
        void Remove(int id);
        void Update(MenuEditModel  menuEditModel);
        IEnumerable<BuyListModel> GetBuyList(int id);

    }
}
