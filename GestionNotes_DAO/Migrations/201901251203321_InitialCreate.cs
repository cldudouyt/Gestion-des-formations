namespace GestionNotes_DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eleve",
                c => new
                    {
                        Identifiant = c.Long(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 20),
                        Prenom = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Identifiant);
            
            CreateTable(
                "dbo.Evaluation",
                c => new
                    {
                        Identifiant = c.Long(nullable: false, identity: true),
                        IdExamen = c.Long(nullable: false),
                        IdEleve = c.Long(nullable: false),
                        Note = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Identifiant)
                .ForeignKey("dbo.Eleve", t => t.IdEleve, cascadeDelete: true)
                .ForeignKey("dbo.Examen", t => t.IdExamen, cascadeDelete: true)
                .Index(t => t.IdExamen)
                .Index(t => t.IdEleve);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        Identifiant = c.Long(nullable: false, identity: true),
                        Libelle = c.String(nullable: false, maxLength: 20),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Identifiant);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluation", "IdExamen", "dbo.Examen");
            DropForeignKey("dbo.Evaluation", "IdEleve", "dbo.Eleve");
            DropIndex("dbo.Evaluation", new[] { "IdEleve" });
            DropIndex("dbo.Evaluation", new[] { "IdExamen" });
            DropTable("dbo.Examen");
            DropTable("dbo.Evaluation");
            DropTable("dbo.Eleve");
        }
    }
}
