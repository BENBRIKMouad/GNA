namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_LastSubscription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "LastSubscription", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "LastSubscription", c => c.DateTime(nullable: false));
        }
    }
}
