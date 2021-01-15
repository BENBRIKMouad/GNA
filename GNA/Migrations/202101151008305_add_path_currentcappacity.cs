namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_path_currentcappacity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paths", "CurrentCapacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paths", "CurrentCapacity");
        }
    }
}
