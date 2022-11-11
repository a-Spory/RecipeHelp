using System.ComponentModel.DataAnnotations;

namespace RecipeHelp.Models.ViewModels
{
    public class UserChangePasswordViewModel
    {
        [Required(ErrorMessage = "Your current password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "A new password is required")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The passwords must match")]
        [Required(ErrorMessage = "A verification password is required")]
        public string VerifyNewPassword { get; set; }
    }
}
