using System.ComponentModel.DataAnnotations;

namespace AC_BM.Models.Domain
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public string TransactionName { get; set; }
        public double Pay { get; set; }

        public double Tax { get; set; }
        public double Net_pay { get; set; }

        public double Governmentfee { get; set; }

        public double facilityfee { get; set; }

        public double Amount { get; set; }


        public DateTime Date { get; set; } = DateTime.Now;






    }
}
