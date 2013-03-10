namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBroadcast : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Broadcasts", "OffsetStart", c => c.Time());
            AlterColumn("dbo.Broadcasts", "OffsetEnd", c => c.Time());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Broadcasts", "OffsetEnd", c => c.Time(nullable: false));
            AlterColumn("dbo.Broadcasts", "OffsetStart", c => c.Time(nullable: false));
        }
    }
}
