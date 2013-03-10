namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChannelsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        ChannelId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TariffId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        WatchersCount = c.Int(nullable: false),
                        ChatEnable = c.Boolean(nullable: false),
                        FeedbackBroadcaster = c.Boolean(nullable: false),
                        FeedbackSms = c.Boolean(nullable: false),
                        FeedbackMail = c.Boolean(nullable: false),
                        FeedbackCabinet = c.Boolean(nullable: false),
                        CustomLogo = c.Boolean(nullable: false),
                        FreeStreming = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ChannelId)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Tariffs", t => t.TariffId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TariffId);
            
            DropColumn("dbo.Tariffs", "WatchersCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tariffs", "WatchersCount", c => c.Int(nullable: false));
            DropIndex("dbo.Channels", new[] { "TariffId" });
            DropIndex("dbo.Channels", new[] { "UserId" });
            DropForeignKey("dbo.Channels", "TariffId", "dbo.Tariffs");
            DropForeignKey("dbo.Channels", "UserId", "dbo.UserProfile");
            DropTable("dbo.Channels");
        }
    }
}
