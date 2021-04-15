using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{    
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}