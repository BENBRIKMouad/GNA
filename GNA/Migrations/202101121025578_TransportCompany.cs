namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransportCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransportCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransportCompanies");
        }
    }
}
