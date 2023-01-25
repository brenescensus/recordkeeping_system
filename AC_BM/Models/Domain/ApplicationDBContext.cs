using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AC_BM.Models.Domain
{
    public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }


        public DbSet<User> Client { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<CompanyService> CompanyService { get; set; }
        public DbSet<Service> Services { get; set; }


}
    }
