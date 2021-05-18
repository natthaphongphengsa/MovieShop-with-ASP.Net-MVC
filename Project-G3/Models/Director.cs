using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string DirectorName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}