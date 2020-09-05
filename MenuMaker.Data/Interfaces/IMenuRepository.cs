using MenuMaker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Data.Interfaces
{
    interface IMenuRepository
    {
        int Create(Menu  menu);
        Menu FindById(int? id);
        IEnumerable<Menu> GetAll();
        IEnumerable<Menu> GetAll(Func<Menu, bool> func);
        void Remove(int? id);
        void Update(Menu entity);
    }
}
