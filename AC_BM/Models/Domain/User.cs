using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AC_BM.Models.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        public string? Profile { get; set; }
        
        [Required]
        public int? Contact { get; set; }
        [Required]
        public int? Id_Passport { get; set; }

        public string? Address { get; set; }

        public string? Nationality { get; set; }

        public string? Dependence { get; set; }

        public string? Documentss { get; set; }

        [NotMapped]
        [Required]
        public IFormFile? DocFile { get; set; }


    }
}
