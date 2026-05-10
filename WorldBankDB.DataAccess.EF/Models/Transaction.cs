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
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionDescription { get; set; }

        //Foreign Key
        public Guid BankAccountId { get; set; }

        //Navigational Propety
        public BankAccounts? BankAccount { get; set; }
    }
}
