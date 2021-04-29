using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class Star
    {
        [Key]
        public int StarId { get; set; }
        public string StarName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }    
}