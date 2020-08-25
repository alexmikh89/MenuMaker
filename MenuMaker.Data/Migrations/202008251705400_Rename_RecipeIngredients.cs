namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_RecipeIngredients : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RecipeIngridients", newName: "RecipeIngredients");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RecipeIngredients", newName: "RecipeIngridients");
        }
    }
}
