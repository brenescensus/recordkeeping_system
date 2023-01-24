using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace AC_BM.Models.DTO
{
    public class RegistrationModel
    {
        [Required]
        public String Name { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]

        public String Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$",ErrorMessage ="Minimum length is 6 and should contain 1 uppercase,1 lowercase,1special cahracter and 1 digit")]
        public String Password { get; set; }

        [Required]
        [Compare("Password")]
        public String PasswordConfirm { get; set; }


        public String ? Role { get; set; }

    }
}
