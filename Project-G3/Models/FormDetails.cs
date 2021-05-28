using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class FormDetails
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetAdress { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Contry { get; set; }
        [Required]
        public string PaymentName { get; set; }
        public int UserType { get; set; }
    }
    public class Contries
    {
        public string Name { get; set; }
        public string Capital { get; set; }
    }
}