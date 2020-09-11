namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdFor_Menu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Menus", "UserId");
            AddForeignKey("dbo.Menus", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Menus", new[] { "UserId" });
            DropColumn("dbo.Menus", "UserId");
        }
    }
}
