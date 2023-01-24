using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models.ViewModels
{
    public class AdminVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? Usertype { get; set; }

    }
}
