using AC_BM.Models.Domain;
using AC_BM.Repositories.Abstract;
using AC_BM.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
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
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(User model)
        {

            if (!ModelState.IsValid)
                return View(model);
            if (model.DocFile != null)
            {
                var fileresult = _documentService.SaveDoc(model.DocFile);
                if (fileresult.Item1 == 0)
                {
                    TempData["msg"] = "Error while saving the document";

                }
                var DocumentName = fileresult.Item2;
                model.Documentss = DocumentName;
            }
            else
            {
                var result = _clientservices.Add(model);
                if (result)
                {
                    TempData["msg"] = "Your details have been saved  successfully";
                    return RedirectToAction(nameof(Add));
                }
                else
                {
                    TempData["msg"] = "Error while saving your details";

                    return RedirectToAction(nameof(Add));

                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _clientservices.GetById(id);
            return View(data);

        }

        [HttpPost]
        public IActionResult Update(User model)
        {
            if (!ModelState.IsValid)
                return View();
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



        public IActionResult ClientList(User model)
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
