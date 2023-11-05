using System.ComponentModel;

namespace BankTransactionAPI_.Models
{
    public class BankTransactionsViewModel
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
