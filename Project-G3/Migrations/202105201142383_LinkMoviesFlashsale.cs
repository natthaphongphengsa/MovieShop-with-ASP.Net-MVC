namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkMoviesFlashsale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlashSaleMovies",
                c => new
                    {
                        FlashSale_FlashSaleID = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FlashSale_FlashSaleID, t.Movie_MovieId })
                .ForeignKey("dbo.FlashSales", t => t.FlashSale_FlashSaleID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.FlashSale_FlashSaleID)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FlashSaleMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.FlashSaleMovies", "FlashSale_FlashSaleID", "dbo.FlashSales");
            DropIndex("dbo.FlashSaleMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.FlashSaleMovies", new[] { "FlashSale_FlashSaleID" });
            DropTable("dbo.FlashSaleMovies");
        }
    }
}
