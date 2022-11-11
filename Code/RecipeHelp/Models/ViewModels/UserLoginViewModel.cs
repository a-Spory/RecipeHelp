using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeHelp.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "User or password is not recognized")]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
