namespace GNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_path_currentcappacity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Paths", "CurrentCapacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paths", "CurrentCapacity", c => c.Int(nullable: false));
        }
    }
}
