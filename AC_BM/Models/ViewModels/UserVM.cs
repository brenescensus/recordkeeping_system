using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models.ViewModels
{
    public class UserVM
    {

        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Usertype { get; set; }

        public string Profile { get; set; }

        [Phone]
        public int Contact { get; set; }
        public int Id_Passport { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public string Dependence { get; set; }

        public string Documentss { get; set; }
        public string ErroMessage { get; set; }
    }
}
