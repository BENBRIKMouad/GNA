namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sub_add_FK_to_transportCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "CompanyId");
            AddForeignKey("dbo.Subscriptions", "CompanyId", "dbo.TransportCompanies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "CompanyId", "dbo.TransportCompanies");
            DropIndex("dbo.Subscriptions", new[] { "CompanyId" });
            DropColumn("dbo.Subscriptions", "CompanyId");
        }
    }
}
