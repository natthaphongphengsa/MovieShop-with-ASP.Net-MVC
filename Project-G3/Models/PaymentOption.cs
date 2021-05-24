using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class PaymentOption
    {
        [Key]
        public int PaymentId { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string PaymentName { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string PaymentIcon { get; set; }
    }
}