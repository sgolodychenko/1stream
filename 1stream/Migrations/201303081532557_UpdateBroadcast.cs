namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBroadcast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Broadcasts", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Broadcasts", "StartDate");
        }
    }
}
