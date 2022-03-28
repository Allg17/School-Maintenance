namespace School_Maintenance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionDeAulas",
                c => new
                    {
                        AsignacionID = c.Int(nullable: false, identity: true),
                        IDAula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsignacionID)
                .ForeignKey("dbo.Aulas", t => t.IDAula, cascadeDelete: true)
                .Index(t => t.IDAula);
            
            CreateTable(
                "dbo.Aulas",
                c => new
                    {
                        IDAula = c.Int(nullable: false, identity: true),
                        Curso = c.String(nullable: false),
                        Capacidad = c.Int(nullable: false),
                        AsignacionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDAula);
            
            CreateTable(
                "dbo.AsignacionAulaDetalle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AsignacionID = c.Int(nullable: false),
                        IDAsignatura = c.Int(nullable: false),
                        IDEstudiante = c.Int(nullable: false),
                        IDProfesor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AsignacionDeAulas", t => t.AsignacionID, cascadeDelete: true)
                .Index(t => t.AsignacionID);
            
            CreateTable(
                "dbo.Asignatura",
                c => new
                    {
                        IDAsignatura = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Horario = c.String(),
                    })
                .PrimaryKey(t => t.IDAsignatura);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        IDEstudiante = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Sexo = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDEstudiante);
            
            CreateTable(
                "dbo.Profesores",
                c => new
                    {
                        IDProfesor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Sexo = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDProfesor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionAulaDetalle", "AsignacionID", "dbo.AsignacionDeAulas");
            DropForeignKey("dbo.AsignacionDeAulas", "IDAula", "dbo.Aulas");
            DropIndex("dbo.AsignacionAulaDetalle", new[] { "AsignacionID" });
            DropIndex("dbo.AsignacionDeAulas", new[] { "IDAula" });
            DropTable("dbo.Profesores");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Asignatura");
            DropTable("dbo.AsignacionAulaDetalle");
            DropTable("dbo.Aulas");
            DropTable("dbo.AsignacionDeAulas");
        }
    }
}
