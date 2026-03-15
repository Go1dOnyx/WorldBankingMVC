using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldBankDB.DataAccess.EF.Models
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }
        //Might need to add a description public string? Description

        //Foreign
        public Guid BankAccountId { get; set; }
        public BankAccounts? BankAccount { get; set; }
    }
}
