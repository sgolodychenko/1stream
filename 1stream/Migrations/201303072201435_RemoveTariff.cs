namespace OneStream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTariff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Channels", "TariffId", "dbo.Tariffs");
            DropIndex("dbo.Channels", new[] { "TariffId" });
            DropColumn("dbo.Channels", "TariffId");
            DropTable("dbo.Tariffs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tariffs",
                c => new
                    {
                        TariffId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.TariffId);
            
            AddColumn("dbo.Channels", "TariffId", c => c.Int(nullable: false));
            CreateIndex("dbo.Channels", "TariffId");
            AddForeignKey("dbo.Channels", "TariffId", "dbo.Tariffs", "TariffId", cascadeDelete: true);
        }
    }
}
