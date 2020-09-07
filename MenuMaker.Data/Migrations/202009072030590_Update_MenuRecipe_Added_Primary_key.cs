namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_MenuRecipe_Added_Primary_key : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MenuRecipes");
            AddColumn("dbo.MenuRecipes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MenuRecipes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MenuRecipes");
            DropColumn("dbo.MenuRecipes", "Id");
            AddPrimaryKey("dbo.MenuRecipes", new[] { "MenuId", "RecipeId", "DayId" });
        }
    }
}
