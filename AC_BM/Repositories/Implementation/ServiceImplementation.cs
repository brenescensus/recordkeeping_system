using AC_BM.Models.Domain;
using AC_BM.Models.DTO;
using AC_BM.Repositories.Abstract;




namespace AC_BM.Repositories.Implementation
{
    public class ServiceImplementation : IServiceAbstract 
    { 

        private readonly ApplicationDBContext _dbContext;
    public ServiceImplementation(ApplicationDBContext dbContext)
    {
        this._dbContext = dbContext;
    }
    
        public bool Add(Service model)
        {
            try
            {
                _dbContext.Services.Add(model);
                _dbContext.SaveChanges();
                foreach (var companyId in model.Companys)
                {
                    var ServiceCompany = new CompanyService
                    {

                        ServiceId = model.ServiceId,
                        CompanyId = companyId

                    };
                       _dbContext.CompanyService.Add(ServiceCompany);
                 }
                   _dbContext.SaveChanges();
                     return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var result= this.GetById(id);
                if (result == null)
                    return false;
                var CompServices = _dbContext.CompanyService.Where(a => a.ServiceId == result.ServiceId);
                foreach (var CompService in CompServices)
                {
                    _dbContext.CompanyService.Remove(CompService);
                }
                _dbContext.Services.Remove(result);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Service GetById(int id)
        {
            return _dbContext.Services.Find(id);
        }


        public ServiceListVM List()
        {
            var list = _dbContext.Services.ToList();
            foreach(var service in list)
            { 
                var companies =(from Company in _dbContext.Companys join servecom in _dbContext.CompanyService on 
                              Company.CompanyId equals servecom.CompanyId where servecom.ServiceId == service.ServiceId
                              select Company.CompanyName ).ToList();
                var CompanyNames = string.Join(',',companies );
                service.CompanyNames = CompanyNames;
            }

            var data = new ServiceListVM
            {
                ServiceList = list.AsQueryable()
                
                 
            };

            return data;
        }

        public bool Update(Service model)
        {
            try
            {
                //the company ids are not selected  and still present in companyservice table 
            var ComppanyTodeleted = _dbContext.CompanyService
           .Where(a => a.ServiceId == model.ServiceId && !model.Companys.Contains(a.CompanyId)).ToList();
                foreach(var compservice in ComppanyTodeleted)
                {
                    _dbContext.CompanyService.Remove(compservice);
                }
                foreach (int comId in model.Companys)
                {
                    var Servicecompany = _dbContext.CompanyService.FirstOrDefault(a => a.ServiceId == model.ServiceId && a.CompanyId == comId);
                    if (Servicecompany == null)
                    {
                        Servicecompany = new CompanyService { CompanyId = comId, ServiceId = model.ServiceId };
                        _dbContext.CompanyService.Add(Servicecompany);
                    }
                }
                _dbContext.Services.Update(model);
               
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                
            }
        }

       public List<int>GetCompanyByServiceId(int serviceID)
        {
            var companyids = _dbContext.CompanyService.Where(a => a.ServiceId == serviceID).Select(a => a.CompanyId).ToList();
            return companyids;
        }
    }
}
