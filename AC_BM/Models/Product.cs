using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC_BM.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public  string Pro_Name { get; set; }

        [Column(TypeName = ("nvarchar(max)"))]
        public string Image { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
