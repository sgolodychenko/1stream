namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChannelUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Channels", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Channels", "Name", c => c.String());
        }
    }
}
