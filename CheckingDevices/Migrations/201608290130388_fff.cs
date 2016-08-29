namespace CheckingDevices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BandsIps",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        band = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BandsIps");
        }
    }
}
