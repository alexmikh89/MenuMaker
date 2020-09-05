namespace MenuMaker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Days_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Days");
        }
    }
}
