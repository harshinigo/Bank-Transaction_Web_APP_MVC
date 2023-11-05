using BankTransactionAPI_.DataAcess;
using BankTransactionAPI_.Models.DBEntities;
using BankTransactionAPI_.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankTransactionAPI_.Controllers
{
    public class RawBankTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RawBankTransactionsController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var RawBankTransactions = _context.RawBankTransactions.ToList();

            List<RawBankTransactionsViewModel> RawBankTransactionList = new List<RawBankTransactionsViewModel>();

            if (RawBankTransactions != null)
            {

                foreach (var RawBankTransaction in RawBankTransactions)
                {
                    var RawBankTransactionsViewModel = new RawBankTransactionsViewModel()

                    {
                        ID = RawBankTransaction.ID,
                        AccountNumber = RawBankTransaction.AccountNumber,
                        Date = RawBankTransaction.Date,
                        Narration = RawBankTransaction.Narration,
                        Amount = RawBankTransaction.Amount,
                        Balance = RawBankTransaction.Balance,
                    };
                    RawBankTransactionList.Add(RawBankTransactionsViewModel);
                }
                return View(RawBankTransactionList);
            }
            //else
            //{
            //    foreach (var RawBankTransaction in RawBankTransactions)
            //    {
            //        var RawBankTransactionsViewModel = new RawBankTransactionsViewModel()

            //        {
            //            ID = RawBankTransaction.ID,
            //            AccountNumber = RawBankTransaction.AccountNumber,
            //            Date = RawBankTransaction.Date,
            //            Narration = RawBankTransaction.Narration,
            //            Amount = RawBankTransaction.Amount,
            //            Balance = RawBankTransaction.Balance,
            //        };
            //        RawBankTransactionList.Add(RawBankTransactionsViewModel);
            //    }
            //    return View(RawBankTransactionList);
            //}

            return View(RawBankTransactionList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RawBankTransactionsViewModel RawBankTransactions)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var rawBankTransaction = new RawBankTransaction()
                    {
                        AccountNumber = RawBankTransactions.AccountNumber,
                        Date = RawBankTransactions.Date,
                        Amount = RawBankTransactions.Amount,
                        Narration = RawBankTransactions.Narration,
                        Balance = RawBankTransactions.Balance,
                    };
                    _context.RawBankTransactions.Add(rawBankTransaction);
                    _context.SaveChanges();
                    TempData["successMessage"] = "New transaction is added successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Data is not valid.";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var rawBankTransactions = _context.RawBankTransactions.SingleOrDefault(x => x.ID == Id);

                if (rawBankTransactions != null)
                {
                    var rawBankTransactionsView = new RawBankTransactionsViewModel()
                    {
                        ID = rawBankTransactions.ID,
                        AccountNumber = rawBankTransactions.AccountNumber,
                        Date = rawBankTransactions.Date,
                        Narration = rawBankTransactions.Narration,
                        Balance = rawBankTransactions.Balance
                    };
                    return View(rawBankTransactionsView);
                }
                else
                {
                    TempData["errorMessage"] = $"There is not account with that ID:{Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(RawBankTransactionsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var rawBankTransactions = new RawBankTransaction()
                    {
                        ID = model.ID,
                        AccountNumber = model.AccountNumber,
                        Date = model.Date,
                        Narration = model.Narration,
                        Amount = model.Amount,
                        Balance = model.Balance,
                    };
                    _context.RawBankTransactions.Update(rawBankTransactions);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Raw transaction is updated!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Data is invaild";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            try
            {
                var rawBankTransactions = _context.RawBankTransactions.SingleOrDefault(x => x.ID == ID);

                if (rawBankTransactions != null)
                {
                    var rawBankTransactionsView = new RawBankTransactionsViewModel()
                    {
                        ID = rawBankTransactions.ID,
                        AccountNumber = rawBankTransactions.AccountNumber,
                        Date = rawBankTransactions.Date,
                        Narration = rawBankTransactions.Narration,
                        Balance = rawBankTransactions.Balance
                    };
                    return View(rawBankTransactionsView);
                }
                else
                {
                    TempData["errorMessage"] = $"There is not account with that ID:{ID}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(RawBankTransactionsViewModel model)
        {
            try
            {
                var rawBankTransactions = _context.RawBankTransactions.SingleOrDefault(x => x.ID == model.ID);

                if (rawBankTransactions != null)
                {
                    _context.RawBankTransactions.Remove(rawBankTransactions);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Transaction deleted successfully!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"There is not account with that ID:{@model.ID}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
         
    }

}












































//using BankTransactionAPI_.DataAcess;
//using BankTransactionAPI_.Models.DBEntities;
//using BankTransactionAPI_.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace BankTransactionAPI_.Controllers
//{
//    public class RawBankTransactionsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public RawBankTransactionsController(ApplicationDbContext context)
//        {
//            this._context = context;
//        }
//        [HttpGet]
//        public IActionResult Index()
//        {
//            var RawBankTransactions = _context.RawBankTransactions.ToList();

//            List<RawBankTransactionsViewModel> RawBankTransactionList = new List<RawBankTransactionsViewModel>();

//            if (RawBankTransactions != null)
//            {

//                foreach (var RawBankTransaction in RawBankTransactions)
//                {
//                    var RawBankTransactionsViewModel = new RawBankTransactionsViewModel();

//                    RawBankTransactionsViewModel.ID = RawBankTransaction.ID;

//                    if (RawBankTransaction.AccountNumber != null)
//                    {
//                        RawBankTransactionsViewModel.AccountNumber = (int)RawBankTransaction.AccountNumber;
//                    }
//                    else
//                    {
//                        RawBankTransactionsViewModel.AccountNumber = NULL;
//                    }

//                    if (RawBankTransaction.Date != null)
//                    {
//                        RawBankTransactionsViewModel.Date = RawBankTransaction.Date;
//                    }
//                    else
//                    {
//                        RawBankTransactionsViewModel.Date = DateTime.MinValue;
//                    }
//                    if (RawBankTransaction.Narration != null)
//                    {
//                        RawBankTransactionsViewModel.Narration = RawBankTransaction.Narration;
//                    }
//                    else
//                    {
//                        RawBankTransactionsViewModel.Narration = "No data";
//                    }

//                    if (RawBankTransaction.Amount != null)
//                    {
//                        RawBankTransactionsViewModel.Amount = (decimal)RawBankTransaction.Amount;
//                    }
//                    else
//                    {
//                        RawBankTransactionsViewModel.Amount = NULL;
//                    }

//                    if (RawBankTransaction.Balance != null)
//                    {
//                        RawBankTransactionsViewModel.Balance = (decimal)RawBankTransaction.Balance;
//                    }
//                    else
//                    {
//                        RawBankTransactionsViewModel.Balance = NULL;
//                    }

//                    RawBankTransactionList.Add(RawBankTransactionsViewModel);
//                }

//                return View(RawBankTransactionList);
//            }

//            return View(RawBankTransactionList);
//        }
//    }
//}