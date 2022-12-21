
using AC_BM.Models.Domain;

namespace AC_BM.Models.DTO
{
    public class ServiceListVM
    {
        public IQueryable<Service> ServiceList { get; set; }
      

    }
}
