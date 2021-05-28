using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_G3.Models
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class AddMovieModels
    {
        [Required]
        [Display(Name = "Titel")]
        public string MovieTitel { get; set; }

        [Required]
        [Display(Name = "Release year")]
        public string MovieReleaseYear { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public string MovieDuration { get; set; }

        [Required]
        [Display(Name = "Poster/URL")]
        public string MoviePosters { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string MovieDescription { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal MoviePrice { get; set; }


    }


}