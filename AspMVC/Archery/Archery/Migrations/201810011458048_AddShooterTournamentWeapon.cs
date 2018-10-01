namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShooterTournamentWeapon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shooters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TournamentID = c.Int(nullable: false),
                        WeaponID = c.Int(nullable: false),
                        ArcherID = c.Int(nullable: false),
                        Departure = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Archers", t => t.ArcherID, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.TournamentID, cascadeDelete: true)
                .ForeignKey("dbo.Weapons", t => t.WeaponID, cascadeDelete: true)
                .Index(t => t.TournamentID)
                .Index(t => t.WeaponID)
                .Index(t => t.ArcherID);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ArcherCount = c.Int(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WeaponTournaments",
                c => new
                    {
                        Weapon_ID = c.Int(nullable: false),
                        Tournament_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Weapon_ID, t.Tournament_ID })
                .ForeignKey("dbo.Weapons", t => t.Weapon_ID, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_ID, cascadeDelete: true)
                .Index(t => t.Weapon_ID)
                .Index(t => t.Tournament_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shooters", "WeaponID", "dbo.Weapons");
            DropForeignKey("dbo.WeaponTournaments", "Tournament_ID", "dbo.Tournaments");
            DropForeignKey("dbo.WeaponTournaments", "Weapon_ID", "dbo.Weapons");
            DropForeignKey("dbo.Shooters", "TournamentID", "dbo.Tournaments");
            DropForeignKey("dbo.Shooters", "ArcherID", "dbo.Archers");
            DropIndex("dbo.WeaponTournaments", new[] { "Tournament_ID" });
            DropIndex("dbo.WeaponTournaments", new[] { "Weapon_ID" });
            DropIndex("dbo.Shooters", new[] { "ArcherID" });
            DropIndex("dbo.Shooters", new[] { "WeaponID" });
            DropIndex("dbo.Shooters", new[] { "TournamentID" });
            DropTable("dbo.WeaponTournaments");
            DropTable("dbo.Weapons");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Shooters");
        }
    }
}
