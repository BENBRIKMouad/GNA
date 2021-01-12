namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscription : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransportCompanies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "CompanyId", "dbo.TransportCompanies");
            DropIndex("dbo.Subscriptions", new[] { "CompanyId" });
            DropTable("dbo.Subscriptions");
        }
    }
}
