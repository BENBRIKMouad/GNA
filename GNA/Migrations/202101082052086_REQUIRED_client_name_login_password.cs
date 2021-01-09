namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REQUIRED_client_name_login_password : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Password", c => c.String());
            AlterColumn("dbo.Clients", "Login", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
    }
}
