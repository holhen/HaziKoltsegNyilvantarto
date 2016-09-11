namespace HáziKöltségNyilvántartó.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "csvId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "csvId", c => c.Int(nullable: false));
        }
    }
}
