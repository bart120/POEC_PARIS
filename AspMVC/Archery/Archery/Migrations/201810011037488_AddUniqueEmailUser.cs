namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueEmailUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Administrators", "Mail", unique: true);
            CreateIndex("dbo.Archers", "Mail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Archers", new[] { "Mail" });
            DropIndex("dbo.Administrators", new[] { "Mail" });
        }
    }
}
