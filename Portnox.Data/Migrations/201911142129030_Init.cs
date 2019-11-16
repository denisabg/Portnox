namespace Portnox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.NetworkEvents",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Event_Id = c.Int(nullable: false),
                        Switch_Ip = c.String(maxLength: 20),
                        Port_Id = c.Int(nullable: false),
                        Device_Mac = c.String(maxLength: 20),
                        Remarks = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);

            this.SqlResource("Portnox.Data.Migrations.Scripts.ViewsScript.sql");
        }

        public override void Down()
        {
        }
    }
}