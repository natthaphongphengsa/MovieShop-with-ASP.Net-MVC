namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieUtf8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieTitle", c => c.String(unicode: false));
            AlterColumn("dbo.Movies", "MovieReleaseYear", c => c.String(unicode: false));
            AlterColumn("dbo.Movies", "MovieDuration", c => c.String(unicode: false));
            AlterColumn("dbo.Movies", "MoviePosters", c => c.String(unicode: false));
            AlterColumn("dbo.Movies", "MovieDescription", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieDescription", c => c.String());
            AlterColumn("dbo.Movies", "MoviePosters", c => c.String());
            AlterColumn("dbo.Movies", "MovieDuration", c => c.String());
            AlterColumn("dbo.Movies", "MovieReleaseYear", c => c.String());
            AlterColumn("dbo.Movies", "MovieTitle", c => c.String());
        }
    }
}
