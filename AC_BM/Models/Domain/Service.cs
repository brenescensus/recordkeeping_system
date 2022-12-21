using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AC_BM.Models.Domain
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set;}
        [Required]

        public string ServiceName { get; set;}
        //[Required]

        public string? ServiceImage { get; set;}
        [NotMapped]
        [Required]

        public IFormFile ? ImageFile { get; set;}
        [NotMapped]
        [Required]
        public List <int> ? Companys { get; set; }

        [NotMapped]
        public IEnumerable <SelectListItem>  ?  CompanyList{ get; set; }
        [NotMapped]
        public string ? CompanyNames { get; set; }
        [NotMapped]
        public MultiSelectList ? MultiCompanyList { get; set; }
    }
}
