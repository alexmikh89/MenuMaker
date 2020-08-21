namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamed_Ingredients : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ingridients", newName: "Ingredients");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Ingredients", newName: "Ingridients");
        }
    }
}
