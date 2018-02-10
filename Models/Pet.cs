using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace mvcdemo.Models{
    public class Pet{
        public int Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage="{0} must be greater or equal to {1} characters in length.")]
        [Remote(action: "VerifyName", controller: "Pet")]
        public string Name { get; set; }    

        [Required]
        [Range(0,5,ErrorMessage="{0} must be between {1} and {2} years")]
        public int Age { get; set; }

        [Required]
        public string Color { get; set; }
    }
}