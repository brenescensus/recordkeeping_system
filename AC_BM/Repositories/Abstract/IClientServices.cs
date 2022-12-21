using AC_BM.Models.Domain;

namespace AC_BM.Repositories.Abstract
{
    public interface IClientServices
    {
        bool Add(User model);
        bool Update(User model);

        User GetById(int id);
        bool Delete(int id);
        IQueryable<User> List();
    }
}
