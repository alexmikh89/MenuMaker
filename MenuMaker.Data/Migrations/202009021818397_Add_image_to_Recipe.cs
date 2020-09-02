namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_image_to_Recipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Image");
        }
    }
}
