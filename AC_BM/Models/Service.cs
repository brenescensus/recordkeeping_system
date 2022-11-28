using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public string Ser_Name  { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
