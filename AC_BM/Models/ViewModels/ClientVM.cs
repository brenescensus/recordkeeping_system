using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AC_BM.Models.ViewModels
{
    public class ClientVM

    {
        //this is the view model for the client
        //public string ?selectedCountry { get; set; }
        public List<SelectListItem> ServiceSelectList { get; set; } 
        public List<SelectListItem> CountriesSelectList { get; set; }
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
