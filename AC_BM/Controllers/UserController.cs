
using AC_BM.Models.Domain;
using AC_BM.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AC_BM.Controllers
{
    public class UserController : Controller
    {

        //private readonly IHttpContextAccessor _contextAccessor;
        //private readonly ApplicationDBContext _db;

        //public UserController(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor)
        //{
        //    _contextAccessor = httpContextAccessor;
        //    _db = db;
        //}
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        ////public IActionResult Index()
        ////{
        ////    return View();
        ////}
        //[HttpGet]
        //public IActionResult SignUp()
        //{
        //    //var result = _db.Users.Where(email == email).FirstOrDefault();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult SignUp(User user)
        //{
        //    {
        //        var userModel = new User();
        //        var model = new UserVM();
        //        var us = _db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
        //        if (us == null)
        //        {
        //            //register user
        //            userModel.Email = user.Email;
        //            userModel.Password = user.Password;
        //            userModel.Usertype = "Client";
        //            _db.Users.Add(userModel);
        //            _db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            //user already exists
        //            model.ErroMessage = $"User " + user.Email + "already Exists";
        //            return View(model);

        //        }
        //    }
        //}
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        ////[HttpPost]
        ////public IActionResult Login()
        ////{
        ////    return View();
        ////}






    } }