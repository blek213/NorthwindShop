using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthwindShop.Models.TemporaryModels
{
    public class Register
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Name must be between 50 and 3 symbols")]

        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Not correct email ")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MaxLength(50, ErrorMessage = "Max value is 50")]
        [MinLength(4, ErrorMessage = "Min value is 4")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MaxLength(50, ErrorMessage = "Max value is 50")]
        [MinLength(4, ErrorMessage = "Min value is 4")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]

        public string RepeatPassword { get; set; }

        public DateTime DatimeRegister { get; set; }
    }
}