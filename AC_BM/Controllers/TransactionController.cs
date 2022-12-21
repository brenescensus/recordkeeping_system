 using AC_BM.Models.Domain;
using AC_BM.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AC_BM.Controllers
{
    //[Authorize(Roles = "admin")]

    public class TransactionController : Controller

    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ITransactionAbstract  _transactionAbstract;
        public TransactionController(ITransactionAbstract transactionAbstract, ApplicationDBContext dbContext)
        {
            _transactionAbstract=transactionAbstract;  
            _dbContext=dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Transaction());

        }

        [HttpPost]
        public IActionResult Add(Transaction model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                model.Tax = ((double)(model.Pay * 16 / 100));
                model.Net_pay = ((double)(model.Tax + model.Pay));
                model.Amount = ((double)(model.Net_pay + model.facilityfee + model.Governmentfee));
                var result = _transactionAbstract.Add(model);
                if (result)
                {
                    TempData["msg"] = "The transaction has been recorded successfully";
                    RedirectToAction(nameof(Add));
                }
                else
                {
                    TempData["msg"] = "Error while recording the transaction";

                    RedirectToAction(nameof(TransactionList));

                }
                return View();
            }
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _transactionAbstract.GetById(id);
            return View(data);

        }

        [HttpPost]
        public IActionResult Update(Transaction model)
        {
            if (!ModelState.IsValid)
                return View();

            model.Tax = model.Pay * 0.16;
            model.Net_pay = model.Tax + model.Pay;
            model.Amount = model.Net_pay + model.facilityfee + model.Governmentfee;

            var result = _transactionAbstract.Update(model);
            if (result)
            {
                TempData["msg"] = "The transaction has been updated successfully";
                return RedirectToAction(nameof(TransactionList));
            }
            else
            {
                TempData["msg"] = "Error while updating the record";

                return View();

            }
        }


        public IActionResult TransactionList(Transaction model)
        {

            var data =this._transactionAbstract.List().ToList();
            return View(data);

        }
        public IActionResult Delete(int id)
        {
            var result = _transactionAbstract.Delete(id);
      
          return  RedirectToAction(nameof(TransactionList));
           
           
        }







    }
}
