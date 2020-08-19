namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RecipesToIngridients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipesToIngridients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Ingridient_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingridients", t => t.Ingridient_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Ingridient_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipesToIngridients", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipesToIngridients", "Ingridient_Id", "dbo.Ingridients");
            DropIndex("dbo.RecipesToIngridients", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipesToIngridients", new[] { "Ingridient_Id" });
            DropTable("dbo.RecipesToIngridients");
        }
    }
}
