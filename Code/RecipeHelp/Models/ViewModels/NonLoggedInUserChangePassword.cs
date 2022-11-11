using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeHelp.Models.ViewModels
{
    public class NonLoggedInUserChangePassword
    {
        [Required(ErrorMessage = "Your email is required")]
        public String Email { get; set; }
    }
}
