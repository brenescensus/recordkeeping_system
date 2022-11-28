using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int? Pay { get; set; }

        public int ?Tax { get; set; }
        public int? Net_pay { get; set; }

        public int ?Governmentfee{ get; set; }

        public int ?facilityfee { get; set; }

        public  int Amount  { get; set; }
        public int ProductId { get; set; }=0;
        public Product Product { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;






    }
}
