namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class path_modCleint_modSubs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subscriptions", "CompanyId", "dbo.TransportCompanies");
            DropIndex("dbo.Subscriptions", new[] { "CompanyId" });
            AddColumn("dbo.Subscriptions", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Subscriptions", "ClientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Subscriptions", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "ClientId");
            AddForeignKey("dbo.Subscriptions", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            DropColumn("dbo.Clients", "LastSubscription");
            DropColumn("dbo.Subscriptions", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subscriptions", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "LastSubscription", c => c.DateTime());
            DropForeignKey("dbo.Subscriptions", "ClientId", "dbo.Clients");
            DropIndex("dbo.Subscriptions", new[] { "ClientId" });
            AlterColumn("dbo.Subscriptions", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Subscriptions", "ClientId");
            DropColumn("dbo.Subscriptions", "EndTime");
            CreateIndex("dbo.Subscriptions", "CompanyId");
            AddForeignKey("dbo.Subscriptions", "CompanyId", "dbo.TransportCompanies", "Id", cascadeDelete: true);
        }
    }
}
