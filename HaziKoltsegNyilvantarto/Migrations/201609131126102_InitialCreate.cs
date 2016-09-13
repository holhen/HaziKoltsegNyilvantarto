namespace HáziKöltségNyilvántartó.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        csvId = c.Int(),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        LastValue = c.Int(nullable: false),
                        IsIncome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        IsIncome = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Categories", "Item_Id", "dbo.Items");
            DropIndex("dbo.Transactions", new[] { "ItemId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "Item_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
