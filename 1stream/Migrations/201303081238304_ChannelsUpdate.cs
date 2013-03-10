namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChannelsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Channels", "CostOfLive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Channels", "CostOfStorage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Channels", "CostOfStorage");
            DropColumn("dbo.Channels", "CostOfLive");
        }
    }
}
