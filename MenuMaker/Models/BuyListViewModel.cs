using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Models
{
    public class BuyListViewModel
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Amount { get; set; }
    }
}