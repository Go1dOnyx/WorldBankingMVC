using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IBankAccountRepository
    {
        Task<List<BankAccounts>> GetAllAccountsAsync();
        Task<BankAccounts?> GetAcctByIdAsync(Guid id);
        Task<BankAccounts?> CreateAccountAsync(BankAccounts acct);
        Task<BankAccounts?> UpdateAccountAsync(BankAccounts acct);
        Task<bool> DeleteAccountAsync(BankAccounts acct);
        Task TransferAsync(Guid fromAccountId, Guid toAccountId, decimal amount);

        //find of confused what it returns...
        //Task<BankAccounts?> GetTransactionsByIdAsync(Guid id);
    }
}
