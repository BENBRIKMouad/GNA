namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sub_add_FK_to_path : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subscriptions", "CompanyId", "dbo.TransportCompanies");
            DropForeignKey("dbo.Subscriptions", "Path_Id", "dbo.Paths");
            DropIndex("dbo.Subscriptions", new[] { "CompanyId" });
            DropIndex("dbo.Subscriptions", new[] { "Path_Id" });
            RenameColumn(table: "dbo.Subscriptions", name: "Path_Id", newName: "PathId");
            AlterColumn("dbo.Subscriptions", "PathId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subscriptions", "PathId");
            AddForeignKey("dbo.Subscriptions", "PathId", "dbo.Paths", "Id", cascadeDelete: true);
            DropColumn("dbo.Subscriptions", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subscriptions", "CompanyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subscriptions", "PathId", "dbo.Paths");
            DropIndex("dbo.Subscriptions", new[] { "PathId" });
            AlterColumn("dbo.Subscriptions", "PathId", c => c.Int());
            RenameColumn(table: "dbo.Subscriptions", name: "PathId", newName: "Path_Id");
            CreateIndex("dbo.Subscriptions", "Path_Id");
            CreateIndex("dbo.Subscriptions", "CompanyId");
            AddForeignKey("dbo.Subscriptions", "Path_Id", "dbo.Paths", "Id");
            AddForeignKey("dbo.Subscriptions", "CompanyId", "dbo.TransportCompanies", "Id", cascadeDelete: true);
        }
    }
}
