namespace Project_G3.Migrations
{
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
            string text = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "..\\..\\Project-G3\\seedData100.txt"));
            string[] movieList = text.Split(new string[] { ":::" }, StringSplitOptions.None);
            #region List declerations
            List<Genre> genresList = new List<Genre>();
            List<Star> starsList = new List<Star>();
            List<Director> directorsList = new List<Director>();
            #endregion
            foreach (string movieString in movieList)
            {
                string[] movieData = movieString.Split(new string[] { "::" }, StringSplitOptions.None);
                Movie movieObj = new Movie()
                {
                    MovieTitle = movieData[0],
                    MoviePosters = movieData[1],
                    MovieReleaseYear = movieData[2],
                    MovieDuration = movieData[3],
                    MovieDescription = movieData[5],
                    Stars = new List<Star>(),
                    Genres = new List<Genre>()
                };
                #region Add stars to movie
                foreach (string star in movieData[7].Split(new string[] { ", " }, StringSplitOptions.None))
                {
                    Star starSelected = starsList.Find(s => s.StarName.Equals(star));
                    if (starSelected == null)
                    {
                        starSelected = new Star { StarName = star };
                        starsList.Add(starSelected);
                    }
                    movieObj.Stars.Add(starSelected);
                }
                #endregion
                #region Add director to movie
                Director directorSelected = directorsList.Find(d => d.DirectorName.Equals(movieData[6])); 
                if(directorSelected == null)
                {
                    directorSelected = new Director { DirectorName = movieData[6] };
                    directorsList.Add(directorSelected);
                }
                movieObj.Director = directorSelected;
                #endregion
                #region Add genres to movie
                foreach (string genre in movieData[4].Split(new string[] { ", " }, StringSplitOptions.None))
                {
                    Genre genreSelected = genresList.Find(g => g.GenreName.Equals(genre));
                    if (genreSelected == null)
                    {
                        genreSelected = new Genre { GenreName = genre };
                        genresList.Add(genreSelected);
                    }
                    movieObj.Genres.Add(genreSelected);
                }
                #endregion

                context.Movies.AddOrUpdate(m => m.MovieTitle, movieObj);
            }
        }
    }
}
