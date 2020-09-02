namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_column_in_recipeTable_renamed_to_RecipeImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "RecipeImage", c => c.Binary());
            DropColumn("dbo.Recipes", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Image", c => c.Binary());
            DropColumn("dbo.Recipes", "RecipeImage");
        }
    }
}
