namespace CheckingDevices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghfgff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "uptime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "uptime", c => c.String());
        }
    }
}
