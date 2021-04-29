namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlashSaleEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlashSales",
                c => new
                    {
                        FlashSaleID = c.Int(nullable: false, identity: true),
                        FlashSaleDiscount = c.String(),
                    })
                .PrimaryKey(t => t.FlashSaleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlashSales");
        }
    }
}
