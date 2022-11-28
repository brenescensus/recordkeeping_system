using AC_BM.Data;
using AC_BM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security;
using AC_BM.ViewModels;

namespace AC_BM.Controllers
{
    public class AdminController : Controller

    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDBContext _db;

        public AdminController(ApplicationDBContext db,IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()

        {

            //_contextAccessor.HttpContext.Session.SetString("Usertype", "Admin");

            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            User usr = _db.Users.Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password) && u.Usertype.Equals("admin")).SingleOrDefault();
            if (usr != null) { 
                _contextAccessor.HttpContext.Session.SetString("Name", "Name");
            return RedirectToAction("Home");
        }
            else
            {
                ViewBag.error = ("Invalid Username and Password");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddAdmin()

        {

         //_contextAccessor.HttpContext.Session.SetString("Usertype", "Admin");
            
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(User user)
        {
            var userModel = new User();
            var model = new UserVM();
            var us = _db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (us == null)
            {
                //register user
                userModel.Email = user.Email;
                userModel.Password = user.Password;
                userModel.Usertype = "admin";

                _db.Users.Add(userModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                //user already exists
                model.ErroMessage = $"User " + user.Email +"already Exists";
                return View(model);
            }
        }















    }
}
