namespace School_Maintenance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AsignacionDeAulas", "IDAula");
            AddForeignKey("dbo.AsignacionDeAulas", "IDAula", "dbo.Aulas", "IDAula", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDeAulas", "IDAula", "dbo.Aulas");
            DropIndex("dbo.AsignacionDeAulas", new[] { "IDAula" });
        }
    }
}
