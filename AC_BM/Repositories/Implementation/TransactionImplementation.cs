using AC_BM.Models.Domain;
using AC_BM.Repositories.Abstract;

namespace AC_BM.Repositories.Implementation
{
    public class TransactionImplementation : ITransactionAbstract
    {
        private readonly ApplicationDBContext _dbContext;
        public TransactionImplementation(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool Add(Transaction model)
        {
            try
            {
                _dbContext.Transactions.Add(model);
                _dbContext.SaveChanges();
                
                    var trans = new Transaction
                    {
                    Tax = ((double)(model.Pay * 16 / 100)),
                    Net_pay = ((double)(model.Tax + model.Pay)),
                    Amount = ((double)(model.Net_pay + model.facilityfee + model.Governmentfee))
                    //ServiceId = model.ServiceId,
                    //    CompanyId = companyId

                    };
                
                _dbContext.Transactions.Add(trans);
                    
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(Transaction model)
        {
            try
            {
                _dbContext.Transactions.Update(model);
                _dbContext.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                _dbContext.Transactions.Remove(data);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Transaction GetById(int id)
        {
            return  _dbContext.Transactions.Find(id);
        }

        public IQueryable<Transaction> List()
        {
            var data = _dbContext.Transactions.AsQueryable();
            return data;
                }

       

       

        //    public bool Update(int id)
        //    {
        //        try
        //        {
        //            var data = this.GetById(id);
        //            if (data == null)
        //                return false;
        //            _dbContext.Companys.Update(data);
        //            _dbContext.SaveChanges();
        //            return true;

        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }


    }

    
   
    
}
