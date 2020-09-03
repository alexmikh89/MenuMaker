namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_imagePath_to_Recipe_remove_ImageByteArray : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ImagePath", c => c.String());
            DropColumn("dbo.Recipes", "RecipeImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "RecipeImage", c => c.Binary());
            DropColumn("dbo.Recipes", "ImagePath");
        }
    }
}
