namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_client : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        IsSubscribed = c.Boolean(nullable: false),
                        LastSubscription = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
