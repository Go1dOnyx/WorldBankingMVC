using WorldBankDB.DataAccess.EF.Models;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Services.Contract;

namespace WorldBankDB.DataAccess.EF.Services
{
    public class BankAccountService: IBankAccountService
    {
        private readonly IBankAccountRepository _accountRepository;
        public BankAccountService(IBankAccountRepository accountRepository) 
        {
            _accountRepository = accountRepository;
        }
        public async Task<List<BankAccounts>> GetAllAsync() => await _accountRepository.GetAllAccountsAsync();
        public async Task<BankAccounts?> GetByIdAsync(Guid acctID) => await _accountRepository.GetAcctByIdAsync(acctID);
        public async Task<BankAccounts> RegisterAsync(BankAccounts acct)
        {
            var doesExist = await _accountRepository.GetAcctByIdAsync(acct.BankAccountId);

            if(doesExist is null) 
            {
                var result = await _accountRepository.CreateAccountAsync(acct);

                if(result is not null) 
                    return result;
            }

            throw new InvalidCastException("Could not create account or it exist.");
        }
        public async Task<BankAccounts?> UpdateAsync(BankAccounts acct) 
        {
            if (acct is not null)
                return await _accountRepository.UpdateAccountAsync(acct);

            throw new InvalidOperationException("Could not find account.");
        }
        public async Task<bool> DeleteAsync(BankAccounts acct) 
        {
            if(acct is null)
                return false;

            try { return await _accountRepository.DeleteAccountAsync(acct); }
            catch { throw new InvalidOperationException("Account could not be deleted."); }
        }
        public async Task TransferAsync(Guid fromAccountId, Guid toAccountId, decimal amount) 
        {
            if(amount <= 0)
                throw new InvalidOperationException("Insufficient funds.");

            await _accountRepository.TransferAsync(fromAccountId, toAccountId, amount);
        }


        //Might need to add separate parameters to verify the deposit
        public async Task DepositAsync(Guid accountId, decimal amount)
        {
            var account = await _accountRepository.GetAcctByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found!");

            account.AccountBalance += amount;

            account.Transactions?.Add(new Transaction 
            { 
                Amount = amount,
                Type = TransactionType.Deposit
            });

            await _accountRepository.UpdateAccountAsync(account); //Might need to wrap this inside try-catch
        }
        public async Task WithdrawalAsync(Guid accountId, decimal amount)
        {
            var account = await _accountRepository.GetAcctByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found!");

            if (account.AccountBalance < amount)
                throw new Exception("Insufficient funds!");

            account.AccountBalance -= amount;

            account.Transactions?.Add(new Transaction
            {
                Amount = amount,
                Type = TransactionType.Withdrawal
            });

            //Might need to change this
            await _accountRepository.UpdateAccountAsync(account);
        }
 
    }
}
