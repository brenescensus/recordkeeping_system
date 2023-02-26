using AC_BM.Models.Domain;
using AC_BM.Models.DTO;
using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
 

namespace AC_BM.Controllers
{
    public class UserAunthenticationController : Controller
    {
        IUserAunthenticationService _service;
            private readonly UserManager<ApplicationUser> _userManager;
        public UserAunthenticationController(IUserAunthenticationService service, UserManager<ApplicationUser> userManager)
        {
           this._service=service;
            _userManager = userManager;

        }



        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            model.Role = "User";

            if (!ModelState.IsValid)
                return View(model);
            var result = await _service.RegisterAsync(model);
            if (result.StatusCode == 1)
            {
                TempData["msg"] = "registration successful";
                return RedirectToAction(nameof(Login));
            }
            else
            {
                TempData["msg"] = "registration failed";
                return RedirectToAction(nameof(Registration));
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
        if (!ModelState.IsValid) 
         return View(model);
        var result = await _service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                var roles = await _userManager.GetRolesAsync(user);
                string rolename = roles[0];
                if (rolename == "Admin")
                {

                   // TempData["msg"] = "Logged in successfully";
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                   // TempData["msg"] = "Logged in successfully";

                    return RedirectToAction("Add", "Client");
                }

            }
            else
            {
                TempData["msg"] = "Could not log in";
                return RedirectToAction(nameof(Login));
            }
           
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));

        }

        public async Task<IActionResult> Reg()
        {
            var model = new RegistrationModel
            {
                Username = "Collins",
                Email = "agweyucollins@gmail.com",
                Name = "Agweyu Collins",
                Password = "Admin@123"
            };
            model.Role = "Admin";
            var result = await _service.RegisterAsync(model);
            return Ok(result);
        }


       

    



    }
}

