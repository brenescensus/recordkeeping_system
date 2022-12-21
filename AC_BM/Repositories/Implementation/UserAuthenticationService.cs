using System.Security.Claims;
using AC_BM.Models;
using AC_BM.Models.Domain;
using AC_BM.Models.DTO;
using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace AC_BM.Repositories.Implementation
{
    public class UserAuthenticationService : IUserAunthenticationService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
    
        public async Task<Status> LoginAsync(LoginModel model)
        {
            var Status = new Status();
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                Status.StatusCode = 0;
                Status.Message = "Invalid Username";
                return Status;
            }
            if(!await userManager.CheckPasswordAsync(user, model.Password))
            {
                Status.StatusCode = 0;
                Status.Message = "Invalid Password";
                return Status;
            }
             var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                foreach( var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                Status.StatusCode = 1;
                Status.Message = "logged in successfully";
                return Status;
            }
            else if (signInResult.IsLockedOut)
            {
                Status.StatusCode = 0;
                Status.Message = "User locked out";
                return Status;
            }
            else
            {
                Status.StatusCode = 0;
                Status.Message = "Error on logginng in";
                return Status;
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> RegisterAsync(RegistrationModel model)
        {
            var Status = new Status();
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                Status.StatusCode = 0;
                Status.Message = "User already exists";
                return Status;
            }
            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
            Email = model.Email,
            UserName = model.Username,
            EmailConfirmed = true,
        };
            var result=await userManager.CreateAsync(user ,model.Password);
            if (!result.Succeeded)
            {
                Status.StatusCode = 0;
                Status.Message = "User Registration failed";
                return Status;


            }
            //ROLE MANAGEMENT
            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));

            if (await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }
            Status.StatusCode = 1;
            Status.Message = "User has been registered successfully";
            return Status;
        }
    }
}
