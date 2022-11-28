using AC_BM.Data;
using AC_BM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security;

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
            
            var us = _db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (us != null)
            {
                if ((us.Email !=null) && (user.Email !=null))
                {
                    if (us.Email.ToLower() == user.Email.ToLower())
                    {
                        ViewBag.error("the user already exists");
                    }
                    else
                    {
                        User usr = new User();
                        usr.Name = user.Name;
                        usr.Email = user.Email;
                        usr.Contact = user.Contact;
                        usr.Usertype = "admin";
                        usr.Password = (user.Password);
                        _db.Users.Add(usr);
                        _db.SaveChanges();
                        return RedirectToAction("Index");


                    }
                }
            }
            return View();
        }















    }
}
