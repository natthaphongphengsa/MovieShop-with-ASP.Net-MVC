using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_G3.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Display(Name = "Movie Title")]
        [Column(TypeName = "varchar(MAX)")]
        public string MovieTitle { get; set; }

        [Display(Name = "Movie Release Year")]
        [Column(TypeName = "varchar(MAX)")]
        public string MovieReleaseYear { get; set; }

        [Display( Name = "Movie Duration")]
        [Column(TypeName = "varchar(MAX)")]
        public string MovieDuration { get; set; }

        [Display(Name = "Movie Poster")]
        [Column(TypeName = "varchar(MAX)")]
        public string MoviePosters { get; set; }

        [Display(Name = "MovieDescription")]
        [Column(TypeName = "varchar(MAX)")]
        public string MovieDescription { get; set; }

        [Display(Name = "Movie Price")]
        public decimal MoviePrice { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<FlashSale> FlashSales { get; set; }

        public Director Director { get; set; }
    }
}