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
        public string? FullName { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        
        [Required]
        public string? Contact { get; set; }
        [Required]
        public string? Id_Passport { get; set; }

        public string? Nationality { get; set; }

        public string? Service { get; set; }

        public string? Documentss { get; set; }

        [NotMapped]
        [Required]
        // public IFormFile? DocFile { get; set; }
        public List<IFormFile> DocFiles { get; set; } 






    }
}
