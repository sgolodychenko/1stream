namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tariffs", "WatchersCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tariffs", "WatchersCount");
        }
    }
}
