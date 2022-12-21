using AC_BM.Models.Domain;
using AC_BM.Models.DTO;

namespace AC_BM.Repositories.Abstract
{
    public interface IServiceAbstract
    {
        bool Add(Service model);
        bool Update(Service model);

        Service GetById(int id);
        bool Delete(int id);
        ServiceListVM List();

        List<int> GetCompanyByServiceId(int serviceID);
    }
}
