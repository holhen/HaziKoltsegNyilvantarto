namespace HáziKöltségNyilvántartó.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "ItemId", "dbo.Items");
            DropIndex("dbo.Transactions", new[] { "ItemId" });
            AlterColumn("dbo.Transactions", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "ItemId");
            AddForeignKey("dbo.Transactions", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ItemId", "dbo.Items");
            DropIndex("dbo.Transactions", new[] { "ItemId" });
            AlterColumn("dbo.Transactions", "ItemId", c => c.Int());
            CreateIndex("dbo.Transactions", "ItemId");
            AddForeignKey("dbo.Transactions", "ItemId", "dbo.Items", "Id");
        }
    }
}
