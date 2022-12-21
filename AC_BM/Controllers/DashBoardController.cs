using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AC_BM.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IServiceAbstract _serviceAbstract;
        public DashBoardController(IServiceAbstract serviceAbstract)
        {
            _serviceAbstract = serviceAbstract;
        }

        //[Authorize/*]*/
        public IActionResult Display()
        {
            var servicess = _serviceAbstract.List();
            return View(servicess);
        }
    }
}
