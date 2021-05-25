using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class PaymentOptionViewModels
    {        
        public int PaymentId { get; set; }        
        public string PaymentName { get; set; }
        public string PaymentIcon { get; set; }
    }
}