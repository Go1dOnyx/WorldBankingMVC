using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Services.Contract
{
    public interface IBankAccountService
    {
        //CRUD Operations
        Task<List<BankAccounts>> GetAllAsync();
        Task<BankAccounts?> GetByIdAsync(Guid acctID);
        Task<BankAccounts> RegisterAsync(BankAccounts acct);
        Task<BankAccounts?> UpdateAsync(BankAccounts acct);
        Task<bool> DeleteAsync(BankAccounts acct);



        //Business Logic
        Task DepositAsync(Guid accountId, decimal amount);
        Task WithdrawalAsync(Guid accountId, decimal amount);
        Task TransferAsync(Guid fromAccountId, Guid toAccountId, decimal amount);
    }
}
