using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_G3.Models
{
    public class FlashSale
    {
        [Key]
        public int FlashSaleID { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string FlashSaleDiscount { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}