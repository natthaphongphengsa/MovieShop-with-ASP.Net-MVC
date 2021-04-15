namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        PriceValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prices");
        }
    }
}
