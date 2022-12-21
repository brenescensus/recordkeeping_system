using AC_BM.Models.Domain;
using AC_BM.Repositories.Abstract;
namespace AC_BM.Repositories.Implementation
{
    public class CompanyImplementation : ICompanyAbstract
    {
        private readonly ApplicationDBContext _dbContext;
        public CompanyImplementation(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool Add(Company model)
        {
            try
            {
                
                _dbContext.Companys.Add(model);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(Company model)
        {
            try
            {
                _dbContext.Companys.Update(model);
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
                _dbContext.Companys.Remove(data);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Company GetById(int id)
        {
            return  _dbContext.Companys.Find(id);
        }

        public IQueryable<Company> List()
        {
            var data = _dbContext.Companys.AsQueryable();
            return data;
                }
            

       
    }

    
   
    
}
