using MenuMaker.Data.Interfaces;

namespace MenuMaker.Data.Models
{
    public class Day : INextEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
