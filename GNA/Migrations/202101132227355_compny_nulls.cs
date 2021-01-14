namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compny_nulls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromCity = c.String(nullable: false),
                        ToCity = c.String(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        ArivalTime = c.DateTime(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransportCompanies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            AddColumn("dbo.Subscriptions", "Path_Id", c => c.Int());
            AlterColumn("dbo.TransportCompanies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TransportCompanies", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.TransportCompanies", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Subscriptions", "Path_Id");
            AddForeignKey("dbo.Subscriptions", "Path_Id", "dbo.Paths", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "Path_Id", "dbo.Paths");
            DropForeignKey("dbo.Paths", "CompanyId", "dbo.TransportCompanies");
            DropIndex("dbo.Paths", new[] { "CompanyId" });
            DropIndex("dbo.Subscriptions", new[] { "Path_Id" });
            AlterColumn("dbo.TransportCompanies", "Password", c => c.String());
            AlterColumn("dbo.TransportCompanies", "Email", c => c.String());
            AlterColumn("dbo.TransportCompanies", "Name", c => c.String());
            DropColumn("dbo.Subscriptions", "Path_Id");
            DropTable("dbo.Paths");
        }
    }
}
