using BankTransactionAPI_.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace BankTransactionAPI_.DataAcess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        //Dataset
        public DbSet<RawBankTransaction> RawBankTransactions { get; set; }  //called whenever curd operation is called 
        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}
