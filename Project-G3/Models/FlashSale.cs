using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_G3.Models
{
    public class FlashSale
    {
        [Key]

        public int FlashSaleID { get; set; }

        public string FlashSaleDiscount { get; set; }


    }
}