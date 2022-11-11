using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeHelp.Models
{
    [Table("Users")]
    public class User
    {
        //FIELDS AND PROPERTIES

        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public String Password { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public String Email { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
