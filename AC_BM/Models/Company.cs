using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models
{
    public class Company
    {
        [Key]
        public int CompanyId{ get; set; }

        public string Co_Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
