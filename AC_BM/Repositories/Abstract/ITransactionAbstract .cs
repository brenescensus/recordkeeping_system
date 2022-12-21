using AC_BM.Models.Domain;

namespace AC_BM.Repositories.Abstract
{
    public interface ITransactionAbstract
    {

        bool Add(Transaction model);
        bool Update(Transaction model);

        Transaction GetById(int id);
        bool Delete(int id);
        IQueryable<Transaction> List();

    }
}
