using AC_BM.Models.Domain;

namespace AC_BM.Repositories.Abstract
{
    public interface ICompanyAbstract
    {

        bool Add(Company model);
        bool Update(Company model);

        Company GetById(int id);
        bool Delete(int id);
        IQueryable<Company> List();

    }
}
