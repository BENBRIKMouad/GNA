namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_client1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Password");
        }
    }
}
