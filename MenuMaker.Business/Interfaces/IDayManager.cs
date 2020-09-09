using MenuMaker.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Interfaces
{
    public interface IDayManager
    {
        DayModel FindById(int id);
        IEnumerable<DayModel> GetAll();
    }
}
