using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class Director
    {
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}