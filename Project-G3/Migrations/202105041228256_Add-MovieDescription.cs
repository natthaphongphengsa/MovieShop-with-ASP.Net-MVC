namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieDescription");
        }
    }
}
