namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Day_FK_to_MenuRecipes_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuRecipes", "DayId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuRecipes", "DayId");
            AddForeignKey("dbo.MenuRecipes", "DayId", "dbo.Days", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuRecipes", "DayId", "dbo.Days");
            DropIndex("dbo.MenuRecipes", new[] { "DayId" });
            DropColumn("dbo.MenuRecipes", "DayId");
        }
    }
}
