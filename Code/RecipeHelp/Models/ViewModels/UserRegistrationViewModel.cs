using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeHelp.Models.ViewModels
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "A username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A password is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "These passwords don't match")]
        [Required(ErrorMessage = "The verification password is required")]
        public string VerificationPassword { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        public String Name { get; set; }

        [Required(ErrorMessage = "An email is required.")]
        public String Email { get; set; }
    }
}
