using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactionAPI_.Models
{
    public class RawBankTransactionsViewModel  //Communicates with controller to view and view to controller
    {
        public int ID { get; set; }

        [DisplayName("Account Number")]
        public int AccountNumber { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Narration")]
        public string? Narration { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Balance")]
        public decimal Balance { get; set; }
    }
}
