using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Business.Models
{
    public class BuyListModel
    {
        [Key]
        public int Id { get; set; }
        public int MenuId { get; set; }

        public string ProductName { get; set; }
        public double Amount { get; set; }
    }
}
