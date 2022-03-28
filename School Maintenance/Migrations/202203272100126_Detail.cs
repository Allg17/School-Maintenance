namespace School_Maintenance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Detail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstudiantesAgregados",
                c => new
                    {
                        IDEstudianteAgr = c.Int(nullable: false, identity: true),
                        AsignacionID = c.Int(nullable: false),
                        IDEstudiante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDEstudianteAgr)
                .ForeignKey("dbo.AsignacionDeAulas", t => t.AsignacionID, cascadeDelete: true)
                .Index(t => t.AsignacionID);
            
            DropColumn("dbo.AsignacionAulaDetalle", "IDEstudiante");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AsignacionAulaDetalle", "IDEstudiante", c => c.Int(nullable: false));
            DropForeignKey("dbo.EstudiantesAgregados", "AsignacionID", "dbo.AsignacionDeAulas");
            DropIndex("dbo.EstudiantesAgregados", new[] { "AsignacionID" });
            DropTable("dbo.EstudiantesAgregados");
        }
    }
}
