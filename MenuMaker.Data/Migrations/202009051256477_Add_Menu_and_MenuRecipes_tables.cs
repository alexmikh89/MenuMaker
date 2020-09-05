namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Menu_and_MenuRecipes_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuRecipes",
                c => new
                    {
                        MenuId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuId, t.RecipeId })
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        PersonsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuRecipes", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.MenuRecipes", "MenuId", "dbo.Menus");
            DropIndex("dbo.MenuRecipes", new[] { "RecipeId" });
            DropIndex("dbo.MenuRecipes", new[] { "MenuId" });
            DropTable("dbo.Menus");
            DropTable("dbo.MenuRecipes");
        }
    }
}
