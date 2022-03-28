namespace School_Maintenance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Aulas", "AsignacionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aulas", "AsignacionID", c => c.Int(nullable: false));
        }
    }
}
