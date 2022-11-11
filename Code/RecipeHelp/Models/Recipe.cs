using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeHelp.Models
{
    [Table("Recipes")]
    public class Recipe //POCO
    {
        //FIELDS AND PROPERTIES
        
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required.")]
        public String Name { get; set; }

        [Required(ErrorMessage = "The Cooktime is Required.")]
        public int Cooktime { get; set; }

        [Required(ErrorMessage = "The Difficulty is Required.")]
        public String Difficulty { get; set; }

        [Required(ErrorMessage = "The Budget is Required.")]
        public String Budget { get; set; }

        [Required(ErrorMessage = "The Cuisine is Required.")]
        public String Cuisine { get; set; }

        [Required(ErrorMessage = "The Diet is Required.")]
        public String Diet { get; set; }

        [Required(ErrorMessage = "Ingredients are needed to make a recipe...")]
        public String Ingredients { get; set; }

        [Required(ErrorMessage ="The Course is Required.")]
        public String Course { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        //CONSTRUCTORS
        
        //METHODS
    }
}
