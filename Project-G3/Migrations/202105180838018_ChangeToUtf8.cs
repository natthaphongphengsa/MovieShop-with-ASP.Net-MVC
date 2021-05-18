namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToUtf8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Directors", "DirectorName", c => c.String(unicode: false));
            AlterColumn("dbo.Genres", "GenreName", c => c.String(unicode: false));
            AlterColumn("dbo.Stars", "StarName", c => c.String(unicode: false));
            AlterColumn("dbo.FlashSales", "FlashSaleDiscount", c => c.String(unicode: false));
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            AlterColumn("dbo.FlashSales", "FlashSaleDiscount", c => c.String());
            AlterColumn("dbo.Stars", "StarName", c => c.String());
            AlterColumn("dbo.Genres", "GenreName", c => c.String());
            AlterColumn("dbo.Directors", "DirectorName", c => c.String());
        }
    }
}
