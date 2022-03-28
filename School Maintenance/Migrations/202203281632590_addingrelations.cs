namespace School_Maintenance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingrelations : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AsignacionAulaDetalle", "IDAsignatura");
            CreateIndex("dbo.AsignacionAulaDetalle", "IDProfesor");
            CreateIndex("dbo.EstudiantesAgregados", "IDEstudiante");
            AddForeignKey("dbo.AsignacionAulaDetalle", "IDAsignatura", "dbo.Asignatura", "IDAsignatura", cascadeDelete: true);
            AddForeignKey("dbo.AsignacionAulaDetalle", "IDProfesor", "dbo.Profesores", "IDProfesor", cascadeDelete: true);
            AddForeignKey("dbo.EstudiantesAgregados", "IDEstudiante", "dbo.Estudiante", "IDEstudiante", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstudiantesAgregados", "IDEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.AsignacionAulaDetalle", "IDProfesor", "dbo.Profesores");
            DropForeignKey("dbo.AsignacionAulaDetalle", "IDAsignatura", "dbo.Asignatura");
            DropIndex("dbo.EstudiantesAgregados", new[] { "IDEstudiante" });
            DropIndex("dbo.AsignacionAulaDetalle", new[] { "IDProfesor" });
            DropIndex("dbo.AsignacionAulaDetalle", new[] { "IDAsignatura" });
        }
    }
}
