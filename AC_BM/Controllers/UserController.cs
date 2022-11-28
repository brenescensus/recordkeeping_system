using AC_BM.Data;
using AC_BM.Models;
using Microsoft.AspNetCore.Mvc;

namespace AC_BM.Controllers
{
    public class UserController : Controller
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDBContext _db;

        public UserController(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            //var result = _db.Users.Where(email == email).SingleorDefault();
            return View();
        }

        //[HttpPost]
        //public IActionResult SignUp(User user)
        //{
        //    {
        //        if (user.Name == null && user.Password == null)
        //        {
        //            ModelState.AddModelError("name", "Name and password field cannot be null");
        //        }
        //        var us = _db.Users.Where(u => u.Email == user.Email).SingleOrDefault();
        //        if (!us.Equals(user))
        //        {
        //            ViewBag.error("the user already exists");
        //        }
        //        else
        //        {
        //            User usr = new User();
        //            usr.Name = user.Name;
        //            usr.Email = user.Email;
        //            usr.Contact = user.Contact;
        //            usr.Usertype = "admin";
        //            usr.Password = (user.Password);
        //            _db.Users.Add(usr);
        //            _db.SaveChanges();
        //            return RedirectToAction("Index");

        //        }
        //    }

        //    return View();
        //}


        //var result = _db.Users.Where(email == email).SingleorDefault();

    

    }
}
