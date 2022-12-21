using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models.Domain
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

       

    }
}
