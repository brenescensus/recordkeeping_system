//using AC_BM.Areas.Identity.Pages.Account;
using AC_BM.Models.DTO;
using LoginModel = AC_BM.Models.DTO.LoginModel;

namespace AC_BM.Repositories.Abstract
{
    public interface IUserAunthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegisterAsync(RegistrationModel model);

        Task LogoutAsync();

    }
}
