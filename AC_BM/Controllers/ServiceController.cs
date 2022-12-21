using AC_BM.Models.Domain;
using AC_BM.Models.DTO;
using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AC_BM.Controllers
{
   // [Authorize(Roles = "admin")]

    public class ServiceController : Controller
    {
        private readonly IServiceAbstract _iserviceabstract;
        private readonly IFileService _fileService;
        private readonly ICompanyAbstract _companyAbstract;
        public ServiceController(IServiceAbstract iserviceabstract, IFileService fileService, ICompanyAbstract companyAbstract)
        {
            _iserviceabstract = iserviceabstract;
            _fileService = fileService;
            _companyAbstract = companyAbstract;
        }

        [HttpGet]
        public IActionResult Add()

        {
            var model = new Service();
            model.CompanyList = _companyAbstract.List().Select(a => new SelectListItem { Text = a.CompanyName, Value = a.CompanyId.ToString()});
            return View(model);

        }

        [HttpPost]
        public IActionResult Add(Service model)
        {
            model.CompanyList = _companyAbstract.List().Select(a => new SelectListItem { Text = a.CompanyName, Value = a.CompanyId.ToString()});
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileresult = _fileService.SaveImage(model.ImageFile);
                if (fileresult.Item1 == 0)
                {
                    TempData["msg"] = "Error while saving the file";

                }
                var ImageName = fileresult.Item2;
                model.ServiceImage = ImageName;
            }
            else
            {
                var result = _iserviceabstract.Add(model);
                if (result)
                {
                    TempData["msg"] = "The Service has been added successfully";
                    return RedirectToAction(nameof(Add));
                }
                else
                {
                    TempData["msg"] = "Error while adding the Service";

                    return RedirectToAction(nameof(Add));

                }
            }
                return View();
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _iserviceabstract.GetById(id);
            var selectedCompanys = _iserviceabstract.GetCompanyByServiceId(model.ServiceId);
            MultiSelectList multiCompanyList = new MultiSelectList(_companyAbstract.List(), "CompanyId", "CompanyName", selectedCompanys);
            //model.CompanyList = _companyAbstract.List().Select(a => new SelectListItem { Text = a.CompanyName, Value = a.CompanyId.ToString() });
            model.MultiCompanyList = multiCompanyList;
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(Service model)
        {
            var selectedCompanys = _iserviceabstract.GetCompanyByServiceId(model.ServiceId);
            MultiSelectList multiCompanyList = new MultiSelectList(_companyAbstract.List(), "CompanyId", "CompanyName", selectedCompanys);
            model.MultiCompanyList = multiCompanyList;


            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                if (model.ImageFile != null)
                {
                    var fileresult = _fileService.SaveImage(model.ImageFile);
                    if (fileresult.Item1 == 0)
                    {
                        TempData["msg"] = "Error while saving the file";
                        return View(model);

                    }
                    var ImageName = fileresult.Item2;
                    model.ServiceImage = ImageName;
                }
                else
                {
                    var result = _iserviceabstract.Update(model);
                    if (result)
                    {
                        TempData["msg"] = "The Service has been updated successfully";
                        return RedirectToAction(nameof(ServiceListVM));
                    }
                    else
                    {
                        TempData["msg"] = "Error while adding the Service";

                        return RedirectToAction(nameof(Add));

                    }

                }
                return View();
            
            }
    
        }

        public IActionResult Delete(int id)
        {
            var result = _iserviceabstract.Delete(id);

            return RedirectToAction(nameof(ServiceList));


        }
        public IActionResult ServiceList(Service model)
        {

            var data = this._iserviceabstract.List();
            return View(data);

        }
         



    }
}
