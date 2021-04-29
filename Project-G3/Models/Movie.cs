﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Project_G3.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieReleaseYear { get; set; }
        public string MovieDuration { get; set; }
        public string MoviePosters { get; set; }
        public decimal MoviePrice { get; set; }

    }
}