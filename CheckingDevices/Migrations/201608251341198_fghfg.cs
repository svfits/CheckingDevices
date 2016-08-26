namespace CheckingDevices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fghfg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ip = c.String(),
                        type_device = c.String(),
                        description = c.String(),
                        status = c.String(),
                        uptime = c.DateTime(nullable: false),
                        down_device = c.DateTime(nullable: false),
                        up_device = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        ip = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
            DropTable("dbo.Devices");
        }
    }
}
