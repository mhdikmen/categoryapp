namespace CategoryApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.Id)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        PasswordSalt = c.Binary(),
                        PasswordHash = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Id" });
            DropIndex("dbo.Categories", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
