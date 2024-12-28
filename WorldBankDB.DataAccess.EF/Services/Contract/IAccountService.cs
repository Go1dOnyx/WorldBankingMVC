using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Services.Contract
{
    public interface IAccountService
    {
        Task<List<Accounts>> GetAllAsync();
        Task<Accounts> GetByIdAsync(Guid acctID);
        Task<Accounts> GetByNumAsync(int acctNum);
        Task<List<Accounts>> GetListByUserIdAsync(Guid userID);
        Task<Accounts> RegisterAsync(Accounts acct);
        Task<Accounts> EditAsync(Accounts acct);
        Task<bool> DeleteAsync(Accounts acct);
    }
}
