using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankTransactionAPI_.Models.DBEntities
{
    public class RawBankTransaction //to communicate with database 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string Narration { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
    public class BankTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string Narration { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }

}


