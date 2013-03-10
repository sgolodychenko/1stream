namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfoCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserInfo", new[] { "UserId" });
            DropForeignKey("dbo.UserInfo", "UserId", "dbo.UserProfile");
            DropTable("dbo.UserInfo");
        }
    }
}
