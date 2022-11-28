using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC_BM.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Title { get; set; }

        [Column(TypeName =("nvarchar(max)"))]
        public string Image { get; set; }

        public int Status { get; set; }

        public  int UserId { get; set; }
        public User User { get; set; }




    }
}
