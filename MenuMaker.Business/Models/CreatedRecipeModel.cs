namespace MenuMaker.Business.Models
{
    public class CreatedRecipeModel
    {
        public string RecipeName { get; set; }
        public int[] IngredientId { get; set; }
        public double[] Amount { get; set; }
        public string ImagePath { get; set; }
    }
}
