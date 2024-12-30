using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Services.Contract;

namespace WorldBankDB.DataAccess.EF.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }
        public async Task<List<Accounts>> GetAllAsync() => await _accountRepository.GetAllAccountsAsync();
        public async Task<Accounts> GetByIdAsync(Guid acctID)
        {
            var result = await _accountRepository.GetAcctByIdAsync(acctID);

            if (result != null)
                return result;

            throw new InvalidOperationException($"Account was not found");
        }
        public async Task<Accounts> GetByNumAsync(int acctNum) 
        {
            var result = await _accountRepository.GetAcctByNumAsync(acctNum);

            if (result != null)
                return result;

            throw new InvalidOperationException("Could not find any accounts based on number.");
        }
        public async Task<List<Accounts>> GetListByUserIdAsync(Guid userID) 
        {
            var result = await _accountRepository.GetListByUserIdAsync(userID);

            if (result != null) 
                return result;

            throw new InvalidOperationException("Could not get list of accounts based on user ID.");
        }
        public async Task<Accounts> RegisterAsync(Accounts acct) 
        {
            var doesExist = await _accountRepository.GetAcctByIdAsync(acct.AccountId);

            if(acct != null && doesExist == null) 
            {
                var result = await _accountRepository.CreateAccountAsync(acct);

                if(result != null) 
                    return result;
            }

            throw new InvalidCastException("Could not create account or it exist.");
        }
        public async Task<Accounts> EditAsync(Accounts acct) 
        {
            //may implement try catch here instead of Repository
            if (acct != null)
                return await _accountRepository.UpdateAccountAsync(acct);

            throw new InvalidOperationException("Could not find account.");
        }
        public async Task<bool> DeleteAsync(Accounts acct) 
        {
            if(acct != null)
                return await _accountRepository.DeleteAccountAsync(acct);

            throw new InvalidOperationException("Could not find account.");
        }
    }
}
