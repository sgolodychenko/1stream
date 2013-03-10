namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBroadcast1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Broadcasts", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Broadcasts", "Name", c => c.String());
        }
    }
}
