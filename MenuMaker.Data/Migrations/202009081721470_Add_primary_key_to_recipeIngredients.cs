namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_primary_key_to_recipeIngredients : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RecipeIngredients");
            AddColumn("dbo.RecipeIngredients", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RecipeIngredients", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RecipeIngredients");
            DropColumn("dbo.RecipeIngredients", "Id");
            AddPrimaryKey("dbo.RecipeIngredients", new[] { "RecipeId", "IngredientId" });
        }
    }
}
