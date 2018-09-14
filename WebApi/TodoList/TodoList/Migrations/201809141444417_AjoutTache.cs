namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutTache : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 250),
                        DateFin = c.DateTime(),
                        Statut = c.Boolean(nullable: false),
                        Priorite = c.Int(),
                        CategorieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategorieID, cascadeDelete: false)
                .Index(t => t.CategorieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taches", "CategorieID", "dbo.Categories");
            DropIndex("dbo.Taches", new[] { "CategorieID" });
            DropTable("dbo.Taches");
        }
    }
}
