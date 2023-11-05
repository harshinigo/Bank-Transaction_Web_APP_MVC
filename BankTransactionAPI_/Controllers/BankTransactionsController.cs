using BankTransactionAPI_.DataAcess;
using BankTransactionAPI_.Models;
using BankTransactionAPI_.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace BankTransactionAPI_.Controllers
{
    public class BankTransactionsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public BankTransactionsController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var bankTransactions = _context.BankTransactions.ToList();

            List<BankTransactionsViewModel> BankTransactionList = new List<BankTransactionsViewModel>();

            if (bankTransactions != null)
            {

                foreach (var bankTransaction in bankTransactions)
                {
                    var BankTransactionsViewModel = new BankTransactionsViewModel()

                    {
                        //ID = bankTransactions.ID,
                        //AccountNumber = bankTransactions.AccountNumber,
                        //Date = bankTransactions.Date,
                        //Narration = bankTransactions.Narration,
                        //Amount = bankTransactions.Amount,
                        //Balance = bankTransactions.Balance,
                    };
                    BankTransactionList.Add(BankTransactionsViewModel);
                }
                return View(BankTransactionList);
            }
            return View(BankTransactionList);
        }
    }
}
