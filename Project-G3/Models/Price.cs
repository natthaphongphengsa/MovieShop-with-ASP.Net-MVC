using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }
        public int PriceValue { get; set; }
    }
}