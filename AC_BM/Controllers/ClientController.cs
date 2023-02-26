using AC_BM.Helper;
using AC_BM.Models.Domain;
using AC_BM.Models.ViewModels;
using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AC_BM.Controllers
{
    //[Authorize(Roles = "user")]

    public class ClientController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IClientServices _clientservices;
        private readonly IDocumentService _documentService;
        public ClientController(ApplicationDBContext dbContext,IClientServices clientServices, IDocumentService documentService)
        {
            _dbContext = dbContext;
            _clientservices = clientServices;
            _documentService = documentService;
        }

        [HttpGet]
        public IActionResult Add()
        {
          var countrydata = Countries.GetAll();
          var servicedata=Services.GetAll();
          var model = new ClientVM();
          model.CountriesSelectList = new List<SelectListItem>();
            model.ServiceSelectList=new List<SelectListItem>();
          foreach(var country in countrydata) { 
             model.CountriesSelectList.Add(new SelectListItem { Text=country.Name,Value=country.Name});
            }
          foreach(var service in servicedata)
            {
                model.ServiceSelectList.Add(new SelectListItem { Text = service.Name, Value = service.Name });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ClientVM model)
        {
            //but I can not select more than one document
            //if (!ModelState.IsValid)
            //    return View(model);
            //long size = model.DocFiles.Sum(f => f.Length);
            if (model.DocFiles != null)
            {
                var fileresult = _documentService.SaveDocument(model.DocFiles);
                if (!fileresult)
                   {
                    TempData["msg"] = "Error while saving the document";
                   }
                   else
                  {
                    var DocumentName = model.Documentss;
                    // model.Documentss = DocumentName;
                    // return Ok(new {count = model.DocFiles.Count});
                    var result = _clientservices.Add(model);
                    if (result)
                    {
                        TempData["msg"] = "details saved successfully";
                        return RedirectToAction(nameof(Add));
                    }
                    else
                    {
                        TempData["msg"] = "Error while saving your details";

                        return RedirectToAction(nameof(Add));

                    }

                }
                
              

            }
            return View(model); 
             


        
    }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _clientservices.GetById(id);
            return View(data);

        }

        [HttpPost]
        public IActionResult Update(ClientVM model)
        {
            //if (!ModelState.IsValid)
            //    return View();
            var result = _clientservices.Update(model);
            if (result)
            {
                TempData["msg"] = "The dtails has been edited successfully";
                return RedirectToAction(nameof(ClientList));
            }
            else
            {
                TempData["msg"] = "Error while editing the Client details";

                return View();

            }
        }



        public IActionResult ClientList()
        {

            var data = this._clientservices.List().ToList();
            return View(data);
               

        }
        public IActionResult Delete(int id)
        {
            var result = _clientservices.Delete(id);

            return RedirectToAction(nameof(ClientList));


        }

 
















    }
}
