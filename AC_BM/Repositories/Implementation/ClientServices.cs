using AC_BM.Models.Domain;
using AC_BM.Models.ViewModels;
using AC_BM.Repositories.Abstract;

namespace AC_BM.Repositories.Implementation
{
    public class ClientServices : IClientServices
    {
        private readonly  ApplicationDBContext _dbContext;
        public ClientServices(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(ClientVM model)
        {
            try
            {
                var usr = new User
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Nationality = model.Nationality,
                    Contact = model.Contact,
                    Id_Passport = model.Id_Passport,
                    Service=model.Service,
                    DocFiles = model.DocFiles,

                };

                
                _dbContext.Client.Add(usr);
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
                var data = this.GetById(id);
                if (data == null)
                    return false;
                _dbContext.Client.Remove(data);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception )
            {
                return false;
            }
        }

        public User GetById(int id)
        {
            return _dbContext.Client.Find(id);
        }

        public IQueryable<User> List()
        {

            var data = _dbContext.Client.AsQueryable();
            return data;
        }

        public bool Update(User model)
        {
            try
            {
                _dbContext.Client.Update(model);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(ClientVM model)
        {
            try
            {
                var usr = new User
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Nationality = model.Nationality,
                    Contact = model.Contact,
                    Id_Passport = model.Id_Passport,
                    Service = model.Service,
                    DocFiles = model.DocFiles,

                };


               
                _dbContext.Client.Update(usr);
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
