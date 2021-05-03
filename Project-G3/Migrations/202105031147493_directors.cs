namespace Project_G3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class directors : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovieGenres", newName: "GenreMovies");
            DropPrimaryKey("dbo.GenreMovies");
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            AddColumn("dbo.Movies", "Director_DirectorId", c => c.Int());
            AddPrimaryKey("dbo.GenreMovies", new[] { "Genre_GenreId", "Movie_MovieId" });
            CreateIndex("dbo.Movies", "Director_DirectorId");
            AddForeignKey("dbo.Movies", "Director_DirectorId", "dbo.Directors", "DirectorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Director_DirectorId", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "Director_DirectorId" });
            DropPrimaryKey("dbo.GenreMovies");
            DropColumn("dbo.Movies", "Director_DirectorId");
            DropTable("dbo.Directors");
            AddPrimaryKey("dbo.GenreMovies", new[] { "Movie_MovieId", "Genre_GenreId" });
            RenameTable(name: "dbo.GenreMovies", newName: "MovieGenres");
        }
    }
}
