namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_DayId_as_Key : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MenuRecipes");
            AddPrimaryKey("dbo.MenuRecipes", new[] { "MenuId", "RecipeId", "DayId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MenuRecipes");
            AddPrimaryKey("dbo.MenuRecipes", new[] { "MenuId", "RecipeId" });
        }
    }
}
