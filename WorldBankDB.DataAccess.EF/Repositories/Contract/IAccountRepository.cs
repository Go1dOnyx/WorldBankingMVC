using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IAccountRepository
    {
        Task<List<Accounts>> GetAllAccountsAsync();
        Task<Accounts?> GetAcctByIdAsync(Guid acctID);
        Task<Accounts?> GetAcctByNumAsync(int acctNum);
        Task<Accounts> CreateAccountAsync(Accounts acct);
        Task<Accounts> UpdateAccountAsync(Accounts acct);
        Task<List<Accounts>> GetListByUserIdAsync(Guid userID);
        Task<bool> DeleteAccountAsync(Accounts acct);
    }
}
