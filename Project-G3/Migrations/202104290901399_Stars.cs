namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        StarId = c.Int(nullable: false, identity: true),
                        StarName = c.String(),
                    })
                .PrimaryKey(t => t.StarId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stars");
        }
    }
}
