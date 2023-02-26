using AC_BM.Models.Domain;
using AC_BM.Models.ViewModels;

namespace AC_BM.Repositories.Abstract
{
    public interface IClientServices
    {
        bool Add( ClientVM model);
        bool Update(ClientVM model);

        User GetById(int id);
        bool Delete(int id);
        IQueryable<User> List();
    }
}
