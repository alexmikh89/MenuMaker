namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Many_to_many_relationShip_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipesToIngridients", "Ingridient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.RecipesToIngridients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipesToIngridients", new[] { "Ingridient_Id" });
            DropIndex("dbo.RecipesToIngridients", new[] { "Recipe_Id" });
            RenameColumn(table: "dbo.RecipesToIngridients", name: "Ingridient_Id", newName: "IngredientId");
            RenameColumn(table: "dbo.RecipesToIngridients", name: "Recipe_Id", newName: "RecipeId");
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Ingredient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Ingredient_Id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Ingredient_Id);
            
            AlterColumn("dbo.RecipesToIngridients", "IngredientId", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipesToIngridients", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipesToIngridients", "RecipeId");
            CreateIndex("dbo.RecipesToIngridients", "IngredientId");
            AddForeignKey("dbo.RecipesToIngridients", "IngredientId", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipesToIngridients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            DropColumn("dbo.Recipes", "Ingredients");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Ingredients", c => c.String());
            DropForeignKey("dbo.RecipesToIngridients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipesToIngridients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_Id" });
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipesToIngridients", new[] { "IngredientId" });
            DropIndex("dbo.RecipesToIngridients", new[] { "RecipeId" });
            AlterColumn("dbo.RecipesToIngridients", "RecipeId", c => c.Int());
            AlterColumn("dbo.RecipesToIngridients", "IngredientId", c => c.Int());
            DropTable("dbo.RecipeIngredients");
            RenameColumn(table: "dbo.RecipesToIngridients", name: "RecipeId", newName: "Recipe_Id");
            RenameColumn(table: "dbo.RecipesToIngridients", name: "IngredientId", newName: "Ingridient_Id");
            CreateIndex("dbo.RecipesToIngridients", "Recipe_Id");
            CreateIndex("dbo.RecipesToIngridients", "Ingridient_Id");
            AddForeignKey("dbo.RecipesToIngridients", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.RecipesToIngridients", "Ingridient_Id", "dbo.Ingredients", "Id");
        }
    }
}
