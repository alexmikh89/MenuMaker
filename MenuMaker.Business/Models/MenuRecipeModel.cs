namespace MenuMaker.Business.Models
{
    public class MenuRecipeModel
    {
        public int MenuId { get; set; }
        public MenuModel Menu { get; set; }

        public int RecipeId { get; set; }
        public RecipeModel Recipe { get; set; }


    }
}