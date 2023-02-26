using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models.ViewModels
{
    public class EmailConfirm
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
