using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class FlashSalePriceViewModel
    {
        public Movie Movie { get; set; }
        public string NewPrice { get; set; }
        public string FlashSale { get; set; }
    }
    public class MovieDisplayViewModel
    {
        [Required]
        public Movie Movie { get; set; }
        [Required]
        public bool IsOnSale { get; set; }
        public string NewPrice { get; set; }
        public string FlashSale { get; set; }
    }
}