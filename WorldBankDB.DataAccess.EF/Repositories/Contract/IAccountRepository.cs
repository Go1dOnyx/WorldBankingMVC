using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    public interface IAccountRepository
    {
        Task<Accounts> CreateAccountAsync(Accounts acct);
        Task<Accounts> UpdateAccountAsync(Accounts acct);
        Task<Accounts> GetAcctByIdAsync(Guid acctID);
        Task<List<Accounts>> GetAllAccountAsync();
        Task<bool> DeleteAccountAsync(Accounts acct);
    }
}
