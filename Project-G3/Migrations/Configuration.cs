namespace Project_G3.Migrations
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Project_G3.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            decimal[] priceList = { 25M, 50M, 99.9M, 150M, 200M };
            Random r = new Random(1);
            string jsonString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "..\\SeedData100.min.json"));
            List<SeedModel> movieList = JsonConvert.DeserializeObject<List<SeedModel>>(jsonString);
            List<Star> starList = context.Stars.ToList();
            List<Genre> genreList = context.Genres.ToList();
            List<Director> directorList = context.Directors.ToList();
            foreach (SeedModel mo in movieList)
            {
                Movie movieObj = new Movie
                {
                    MovieTitle = mo.tittle,
                    MovieDuration = mo.duration,
                    MovieDescription = mo.text,
                    MoviePosters = mo.cover,
                    MovieReleaseYear = mo.releasYear,
                    MoviePrice = priceList[r.Next(0, 5)],
                    Stars = new List<Star>(),
                    Genres = new List<Genre>()
                };
                foreach (string star in mo.stars)
                {
                    Star starSelected = starList.Find(s => s.StarName.Equals(star));
                    if (starSelected == null) starList.Add(starSelected = new Star { StarName = star });
                    movieObj.Stars.Add(starSelected);
                }
                foreach (string genre in mo.genres)
                {
                    Genre genreSelected = genreList.Find(g => g.GenreName.Equals(genre));
                    if (genreSelected == null) genreList.Add(genreSelected = new Genre { GenreName = genre });
                    movieObj.Genres.Add(genreSelected);
                }
                Director directorSelected = directorList.Find(d => d.DirectorName.Equals(mo.director));
                if (directorSelected == null) directorList.Add(directorSelected = new Director { DirectorName = mo.director });
                movieObj.Director=directorSelected;
                context.Movies.AddOrUpdate(m => m.MovieTitle, movieObj);
            }
            context.SaveChanges();
        }
    }
}
