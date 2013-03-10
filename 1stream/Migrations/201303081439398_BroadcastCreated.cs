namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BroadcastCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Broadcasts",
                c => new
                    {
                        BroadcastId = c.Int(nullable: false, identity: true),
                        ChannelId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        WatchersCount = c.Int(nullable: false),
                        ChatEnable = c.Boolean(nullable: false),
                        FeedbackBroadcaster = c.Boolean(nullable: false),
                        FeedbackSms = c.Boolean(nullable: false),
                        FeedbackMail = c.Boolean(nullable: false),
                        FeedbackCabinet = c.Boolean(nullable: false),
                        CustomLogo = c.Boolean(nullable: false),
                        FreeStreming = c.Boolean(nullable: false),
                        AccessTime = c.Int(nullable: false),
                        AnnounceInChannel = c.Boolean(nullable: false),
                        StorageTime = c.Int(nullable: false),
                        CostOfLive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostOfStorage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostOfLiveSpecial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostOfStorageSpecial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OffsetStart = c.Time(nullable: false),
                        OffsetEnd = c.Time(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.BroadcastId)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Broadcasts", new[] { "ChannelId" });
            DropForeignKey("dbo.Broadcasts", "ChannelId", "dbo.Channels");
            DropTable("dbo.Broadcasts");
        }
    }
}
