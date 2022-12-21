using AC_BM.Models.Domain;
using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AC_BM.Controllers
{
   // [Authorize(Roles = "admin")]

    public class CompanyController : Controller

    {
        private readonly ICompanyAbstract _icompanyabstract;
        public CompanyController(ICompanyAbstract companyAbstract)
        {
            _icompanyabstract = companyAbstract;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Add(Company model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result=_icompanyabstract.Add(model);
            if (result) {
                TempData["msg"] = "The Company has been added successfully";
                RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error while adding the Company";

                RedirectToAction(nameof(Add));

            }
            return View();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data=_icompanyabstract.GetById(id);
            return View(data);

        }

        [HttpPost]
        public IActionResult Update(Company model)
        {
            if (!ModelState.IsValid)
                return View();
            var result = _icompanyabstract.Update(model);
            if (result)
            {
                TempData["msg"] = "The Company has been added successfully";
              return   RedirectToAction(nameof(CompanyList));
            }
            else
            {
                TempData["msg"] = "Error while adding the Company";

                return View();

            }
        }


        public IActionResult CompanyList(Company model)
        {

            var data =this._icompanyabstract.List().ToList();
            return View(data);

        }
        public IActionResult Delete(int id)
        {
            var result = _icompanyabstract.Delete(id);
      
          return  RedirectToAction(nameof(CompanyList));
           
           
        }







    }
}
