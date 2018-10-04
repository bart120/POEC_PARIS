namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTournamentPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TournamentPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        TournamentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tournaments", t => t.TournamentID, cascadeDelete: true)
                .Index(t => t.TournamentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentPictures", "TournamentID", "dbo.Tournaments");
            DropIndex("dbo.TournamentPictures", new[] { "TournamentID" });
            DropTable("dbo.TournamentPictures");
        }
    }
}
