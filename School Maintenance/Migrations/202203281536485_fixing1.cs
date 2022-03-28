namespace School_Maintenance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AsignacionDeAulas", "IDAula", "dbo.Aulas");
            DropIndex("dbo.AsignacionDeAulas", new[] { "IDAula" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AsignacionDeAulas", "IDAula");
            AddForeignKey("dbo.AsignacionDeAulas", "IDAula", "dbo.Aulas", "IDAula", cascadeDelete: true);
        }
    }
}
