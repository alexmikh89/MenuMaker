namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_description_for_recipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Description");
        }
    }
}
