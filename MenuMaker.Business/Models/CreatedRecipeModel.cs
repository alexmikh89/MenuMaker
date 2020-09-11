using MenuMaker.Data;

namespace MenuMaker.Business.Models
{
    public class CreatedRecipeModel
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int[] IngredientId { get; set; }
        public double[] Amount { get; set; }
        public string ImagePath { get; set; }
    }
}
