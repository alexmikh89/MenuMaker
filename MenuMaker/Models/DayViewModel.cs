using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuMaker.Models
{
    public class DayViewModel : IComparable<DayViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(DayViewModel compareDay)
        {
            if (compareDay == null)
                return 1;

            else
                return Id.CompareTo(compareDay.Id);
        }
    }
}