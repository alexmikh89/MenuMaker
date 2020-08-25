namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Many_to_many_realationship_updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.RecipesToIngridients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.RecipesToIngridients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.RecipesToIngridients", new[] { "RecipeId" });
            DropIndex("dbo.RecipesToIngridients", new[] { "IngredientId" });
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_Id" });
            CreateTable(
                "dbo.RecipeIngridients",
                c => new
                    {
                        RecipeId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeId, t.IngredientId })
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.IngredientId);
            
            DropTable("dbo.RecipesToIngridients");
            DropTable("dbo.RecipeIngredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Ingredient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Ingredient_Id });
            
            CreateTable(
                "dbo.RecipesToIngridients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.RecipeIngridients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngridients", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.RecipeIngridients", new[] { "IngredientId" });
            DropIndex("dbo.RecipeIngridients", new[] { "RecipeId" });
            DropTable("dbo.RecipeIngridients");
            CreateIndex("dbo.RecipeIngredients", "Ingredient_Id");
            CreateIndex("dbo.RecipeIngredients", "Recipe_Id");
            CreateIndex("dbo.RecipesToIngridients", "IngredientId");
            CreateIndex("dbo.RecipesToIngridients", "RecipeId");
            AddForeignKey("dbo.RecipesToIngridients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipesToIngridients", "IngredientId", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredients", "Ingredient_Id", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
