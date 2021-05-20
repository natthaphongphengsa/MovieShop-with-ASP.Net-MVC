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
        [Column(TypeName = "varchar(MAX)")]
        public string MovieTitle { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string MovieReleaseYear { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string MovieDuration { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string MoviePosters { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string MovieDescription { get; set; }
       
        public decimal MoviePrice { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<FlashSale> FlashSales { get; set; }
        public Director Director { get; set; }

    }
}