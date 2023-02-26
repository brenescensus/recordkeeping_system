using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AC_BM.Controllers
{
    public class DashBoardController : Controller
    {
        public DashBoardController()
        {
        }
        //[Authorize(Roles = "admin")]

        //[Authorize/*]*/
        public IActionResult Display()
        {
            return  View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
